using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace InfinityScript
{
    internal static class SHManager
    {
        public static void Initialize()
        {
            // initialize logging
            Log.Initialize(LogLevel.All);
            Log.AddListener(new FileLogListener("InfinityScript.log", false));
            Log.AddListener(new TraceLogListener());
            Log.AddListener(new GameLogListener());

            // load scripts
            try
            {
                //Entity.InitializeMappings();
                //ScriptNames.Initialize();
                ScriptLoader.Initialize();
            }
            catch (Exception ex)
            {
                Log.Write(LogLevel.Critical, ex.ToString());
                Environment.Exit(0);
            }

            //GameInterface.TempFunc();
            //Environment.Exit(0);
        }

        public static void RunFrame()
        {
            try
            {
                Entity.RunAll(entity => entity.ProcessNotifications());
                Entity.RunAll(entity => entity.ProcessTimers());
                ScriptProcessor.RunAll(script => script.RunFrame());
            }
            catch (Exception ex)
            {
                Log.Write(LogLevel.Critical, ex.ToString());
                Environment.Exit(0);
            }
            //GameInterface.Script_PushString("Hello!");
            //GameInterface.Script_PushInt(1337);
            //GameInterface.Script_Call(362, 0, 1);
        }

        public static void Shutdown()
        {
            ScriptProcessor.RunAll(script => script.OnExitLevel());
        }

        public static void LoadScript(string scriptName)
        {
            ScriptLoader.LoadAssemblies("scripts", scriptName);
        }

        public static bool HandleSay(int clientNum, string clientName, ref string message, int team)
        {
            var entity = Entity.GetEntity(clientNum);
            var eatgame = false;
            var eatscript = false;
            var messageTemp = message;
            ScriptProcessor.RunAll(script =>
            {
                
                // Run Script.OnSay3 (by reference, with team and eat)
                if (eatscript) return;

                var handled = script.OnSay3(entity, team == 0 ? BaseScript.ChatType.All : BaseScript.ChatType.Team, clientName, ref messageTemp);

                eatgame = eatgame || handled.HasFlag(BaseScript.EventEat.EatGame);
                eatscript = handled.HasFlag(BaseScript.EventEat.EatScript);

                // Run Script.OnSay2 (normal, with eat)
                if (eatscript) return;

                handled = script.OnSay2(entity, clientName, messageTemp);
                eatgame = eatgame || handled.HasFlag(BaseScript.EventEat.EatGame);
                eatscript = handled.HasFlag(BaseScript.EventEat.EatScript);
                
                // Run Script.OnSay (normal, without eat)
                if (eatscript) return;
                script.OnSay(entity, clientName, messageTemp);
            });

            message = messageTemp;

            return eatgame;
        }

        public static void HandleCall(int entityRef, CallType funcID)
        {
            //Log.Write(LogLevel.Debug, "Callback {0} called from {1}", funcID.ToString(), entityRef);
            var entity = Entity.GetEntity(entityRef);
            //if (entity == null) return;
            int numArgs = GameInterface.Notify_NumArgs();
            var paras = CollectParameters(numArgs);

            switch (funcID)
            {
                case CallType.StartGameType:
                    ScriptProcessor.RunAll(script => script.OnStartGameType());
                    break;
                case CallType.PlayerConnect:
                    ScriptProcessor.RunAll(script => script.OnPlayerConnecting(entity));
                    break;
                case CallType.PlayerDisconnect:
                    ScriptProcessor.RunAll(script => script.OnPlayerDisconnect(entity));
                    break;
                case CallType.PlayerDamage:
                    if (paras[6].IsNull)
                    {
                        paras[6] = new Vector3(0, 0, 0);
                    }

                    if (paras[7].IsNull)
                    {
                        paras[7] = new Vector3(0, 0, 0);
                    }

                    ScriptProcessor.RunAll(script => script.OnPlayerDamage(entity, paras[0].As<Entity>(), paras[1].As<Entity>(), paras[2].As<int>(), paras[3].As<int>(), paras[4].As<string>(), paras[5].As<string>(), paras[6].As<Vector3>(), paras[7].As<Vector3>(), paras[8].As<string>()));
                    break;
                case CallType.PlayerKilled:
                    if (paras[5].IsNull)
                    {
                        paras[5] = new Vector3(0, 0, 0);
                    }

                    ScriptProcessor.RunAll(script => script.OnPlayerKilled(entity, paras[0].As<Entity>(), paras[1].As<Entity>(), paras[2].As<int>(), paras[3].As<string>(), paras[4].As<string>(), paras[5].As<Vector3>(), paras[6].As<string>()));
                    break;
                case CallType.VehicleDamage:
                    ScriptProcessor.RunAll(script => script.OnVehicleDamage(entity, paras[0].As<Entity>(), paras[1].As<Entity>(), paras[2].As<int>(), paras[3].As<int>(), paras[4].As<string>(), paras[5].As<string>(), paras[6].As<Vector3>(), paras[7].As<Vector3>(), paras[8].As<string>(), paras[9].As<int>(), paras[10].As<int>(), paras[11].As<string>()));
                    break;
                case CallType.EndGame:
                    ScriptProcessor.RunAll(script => script.OnExitLevel());
                    break;
                case CallType.LastStand:
                    ScriptProcessor.RunAll(script => script.OnPlayerLastStand(entity, paras[0].As<Entity>(), paras[1].As<Entity>(), paras[2].As<int>(), paras[3].As<string>(), paras[4].As<string>(), paras[5].As<Vector3>(), paras[6].As<string>(), paras[7].As<int>(), paras[8].As<int>()));
                    break;
            }
        }

        public static void HandleNotify(int entity)
        {
            string type = GameInterface.Notify_Type();
            int numArgs = GameInterface.Notify_NumArgs();

            var paras = CollectParameters(numArgs);

            if (type != "touch")
            {
                // dispatch the thingy
                if (GameInterface.Script_GetObjectType(entity) == 21 || GameInterface.Script_GetObjectType(entity) == 20) // actual entity
                {
                    var entRef = GameInterface.Script_ToEntRef(entity);
                    var entObj = Entity.GetEntity(entRef);

                    entObj.HandleNotify(entity, type, paras);
                    ScriptProcessor.RunAll(script => script.HandleNotify(entRef, type, paras));
                }
                else if (GameInterface.Script_GetObjectType(entity) == 24) // not an actual entity
                {
                    var entRef = GameInterface.Script_GetTempEntRef();
                    var entObj = Entity.GetEntity(entRef);

                    entObj.HandleNotify(entity, type, paras);
                    ScriptProcessor.RunAll(script => script.HandleNotify(entRef, type, paras));
                }
                else if (GameInterface.Script_GetObjectType(entity) == 19) //Level
                {
                    var entRef = Entity.Level.EntRef;
                    var entObj = Entity.GetEntity(entRef);

                    entObj.HandleNotify(entity, type, paras);
                    ScriptProcessor.RunAll(script => script.HandleNotify(entRef, type, paras));
                }
                //else 
                //ScriptProcessor.RunAll(script => script.HandleNotify(entity, type, paras));

                //var ent = GameInterface.Script_ToEntRef(entity);

            }
        }

        public static bool HandleServerCommand(string commandName)
        {
            var args = new string[GameInterface.Cmd_Argc()];

            //GameInterface.Print("Server CMD: " + commandName + ", Args:" + '\n');
            for (var i = 0; i < args.Length; i++)
            {
                args[i] = GameInterface.Cmd_Argv(i);
                //GameInterface.Print("|Arg " + i + ": " + args[i] + '\n');
            }

            var eat = false;
            ScriptProcessor.RunAll(script =>
            {
                var success = script.ProcessServerCommand(commandName.ToLowerInvariant(), args);
                if (success)
                {
                    eat = true;
                }
            });
            return eat;
        }

        public static bool HandleClientCommand(string commandName, int entity)
        {
            var args = new string[GameInterface.Cmd_Argc_sv()];

            //GameInterface.Print("Client CMD: " + commandName + ", Args:" + '\n');
            for (var i = 0; i < args.Length; i++)
            {
                args[i] = GameInterface.Cmd_Argv_sv(i);
                //GameInterface.Print("|Arg " + i + ": " + args[i] + '\n');
            }

            var entObj = Entity.GetEntity(entity);
            var handled = false;

            ScriptProcessor.RunAll(script =>
            {
                var success = script.ProcessClientCommand(commandName.ToLowerInvariant(), entObj, args);
                if (success)
                {
                    handled = true;
                }
            });

            return handled;
        }

        public static bool HandleClientConnect(string connectString)
        {
            var eat = false;

            try
            {
                //Log.Write(LogLevel.Debug, "Connect func called\nInfo: {0}", connectString);
                string connectName = connectString.Split(new string[] { "name" }, StringSplitOptions.None)[1];
                string connectHWID = connectString.Split(new string[] { "HWID" }, StringSplitOptions.None)[1];
                string connectXUID = connectString.Split(new string[] { "XUID" }, StringSplitOptions.None)[1];
                string connectIP = connectString.Split(new string[] { "IP-string" }, StringSplitOptions.None)[1];
                string connectSID = connectString.Split(new string[] { "steamid" }, StringSplitOptions.None)[1];
                string connectXNA = connectString.Split(new string[] { "xnaddr" }, StringSplitOptions.None)[1];

                string playerName = connectName.Split('\\')[1];
                string playerHWID = connectHWID.Split('\\')[1];
                string playerXUID = connectXUID.Split('\\')[1];
                string playerIP = connectIP.Split('\\')[1];
                string playerSID = connectSID.Split('\\')[1];
                string playerXNA = connectXNA.Split('\\')[1];
                ScriptProcessor.RunAll(script =>
                {
                    string result = script.OnPlayerRequestConnection(playerName, playerHWID, playerXUID, playerIP, playerSID, playerXNA);
                    if (!string.IsNullOrEmpty(result))
                    {
                        eat = true;
                        GameInterface.SetConnectErrorMsg(result);
                    }
                });

                return eat;
            }
            catch (Exception e)
            {
                Utilities.PrintToConsole(string.Format("[InfinityScript] An error occurred during the handling of a client connecting!: {0}\nAdditional Info:{1}", e.Message, e.StackTrace));
                return true;
            }
        }

        private static Parameter[] CollectParameters(int numArgs)
        {
            var paras = new Parameter[numArgs];

            for (int i = 0; i < numArgs; i++)
            {
                var ptype = GameInterface.Script_GetType(i);
                object value = null;

                switch (ptype)
                {
                    case VariableType.Integer:
                        value = GameInterface.Script_GetInt(i);
                        break;
                    case VariableType.String:
                    case VariableType.IString:
                        value = GameInterface.Script_GetString(i);
                        break;
                    case VariableType.Float:
                        value = GameInterface.Script_GetFloat(i);
                        break;
                    case VariableType.Entity:
                        value = Entity.GetEntity(GameInterface.Script_GetEntRef(i));
                        break;
                    case VariableType.Vector:
                        Vector3 v;
                        GameInterface.Script_GetVector(i, out v);
                        value = v;
                        break;
                    default:
                        break;
                }

                paras[i] = new Parameter(ptype, value);
            }

            return paras;
        }
    }

    internal enum CallType
    {
        StartGameType = 0,
        PlayerConnect = 1,
        PlayerDisconnect = 2,
        PlayerDamage = 3,
        PlayerKilled = 4,
        VehicleDamage = 5,
        EndGame = 6,
        LastStand = -1,
    }
}
