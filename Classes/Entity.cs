using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Net;
using System.Collections;

namespace InfinityScript
{
    public class Entity : Notifiable
    {

        private int _entRef;

        public static Entity Level = new Entity(2046);

        internal Entity(int entRef)
        {
            _entRef = entRef;

            OnNotify("spawned_player", thisEntity =>
            {
                if (thisEntity.SpawnedPlayer != null)
                {
                    thisEntity.SpawnedPlayer();
                }
            });
        }

        public int EntRef
        {
            get
            {
                return _entRef;
            }
        }

        #region onnotify
        public void OnNotify(string type, Action<Entity> handler)
        {
            OnNotifyInternal(type, handler);
        }

        public void OnNotify(string type, Action<Entity, Parameter> handler)
        {
            OnNotifyInternal(type, handler);
        }

        public void OnNotify(string type, Action<Entity, Parameter, Parameter> handler)
        {
            OnNotifyInternal(type, handler);
        }

        public void OnNotify(string type, Action<Entity, Parameter, Parameter, Parameter> handler)
        {
            OnNotifyInternal(type, handler);
        }

        public void OnNotify(string type, Action<Entity, Parameter, Parameter, Parameter, Parameter> handler)
        {
            OnNotifyInternal(type, handler);
        }

        public void OnNotify(string type, Action<Entity, Parameter, Parameter, Parameter, Parameter, Parameter> handler)
        {
            OnNotifyInternal(type, handler);
        }

        public void OnNotify(string type, Action<Entity, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter> handler)
        {
            OnNotifyInternal(type, handler);
        }

        public void OnNotify(string type, Action<Entity, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter> handler)
        {
            OnNotifyInternal(type, handler);
        }

        public void OnNotify(string type, Action<Entity, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter> handler)
        {
            OnNotifyInternal(type, handler);
        }

        public void OnNotify(string type, Action<Entity, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter> handler)
        {
            OnNotifyInternal(type, handler);
        }

        public void OnNotify(string type, Action<Entity, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter> handler)
        {
            OnNotifyInternal(type, handler);
        }
        public IEnumerator WaitTill(string type)
        {
            yield return ISWait.WaitTill(this, type);
        }
        public IEnumerator WaitTill_return(string type, Action<Parameter[]> returnParams = null)
        {
            yield return ISWait.WaitTill_return(this, type, returnParams);
        }
        public IEnumerator WaitTill_any(params string[] type)
        {
            yield return ISWait.WaitTill_any(this, type);
        }
        public IEnumerator WaitTill_any_return(Action<string> returnString, params string[] type)
        {
            yield return ISWait.WaitTill_any_return(this, returnString, type);
        }
        public IEnumerator WaitTill_notify_or_timeout(string type, int time, Action<string> returnString = null)
        {
            yield return ISWait.WaitTill_notify_or_timeout(this, type, time, returnString);
        }
        #endregion

        #region events
        public event Action SpawnedPlayer;
        //public event Action LastStand;
        #endregion
        
        #region calls
        /*
        public void Call(string func, params Parameter[] parameters)
        {
            Function.SetEntRef(_entRef);
            Function.Call(func, parameters);
        }

        public void Call(ScriptNames.FunctionList func, params Parameter[] parameters)
        {
            Function.SetEntRef(_entRef);
            Function.Call(func, parameters);
        }

        public TReturn Call<TReturn>(string func, params Parameter[] parameters)
        {
            Function.SetEntRef(_entRef);
            return Function.Call<TReturn>(func, parameters);
        }

        public dynamic CallRet(ScriptNames.FunctionList func, params Parameter[] parameters)
        {
            Function.SetEntRef(_entRef);
            return Function.CallReturn(func, parameters);
        }
         */
        #endregion

        #region call wrappers
        public bool IsAlive
        {
            get
            {
                Function.SetEntRef(-1);
                return GSCFunctions.IsAlive(this); 
            }
        }

        public bool IsPlayer
        {
            get
            {
                Function.SetEntRef(-1);
                return GSCFunctions.IsPlayer(this);
            }
        }

        public string CurrentWeapon
        {
            get
            {
                return this.GetCurrentWeapon();
            }
        }

        public long GUID
        {
            get
            {
                return long.Parse(this.GetGUID(), System.Globalization.NumberStyles.HexNumber);
            }
        }

        #endregion

        #region field wrappers
        public string TitleText
        {
            get { return Utilities.getPlayerTitle(_entRef); }
            set { Utilities.setPlayerTitle(_entRef, value); }
        }
        public string ClanTag
        {
            get { return Utilities.getPlayerClanTag(_entRef); }
            set { Utilities.setPlayerClanTag(_entRef, value); }
        }

        public string Code_Classname
        {
            get { Parameter ret; ret = GetField(0); if (ret != null)return (string)ret; else return ""; }
            set { SetField(0, value); }
        }

        public string Classname
        {
            get { Parameter ret; ret = GetField(1); if (ret != null)return (string)ret; else return ""; }
            set { SetField(1, value); }
        }

        public Vector3 Origin
        {
            get { Parameter ret; ret = GetField(2); if (ret != null)return ret.As<Vector3>(); else return Vector3.Zero; }
            set { SetField(2, value); }
        }

        public string Model
        {
            get { Parameter ret; ret = GetField(3); if (ret != null)return (string)ret; else return ""; }
            set { this.SetModel(value); SetField(3, value); }
        }

        public int SpawnFlags
        {
            get { Parameter ret; ret = GetField(4); if (ret != null)return (int)ret; else return 0; }
            set { SetField(4, value); }
        }

        public string Target
        {
            get { Parameter ret; ret = GetField(5); if (ret != null)return (string)ret; else return ""; }
            set { SetField(5, value); }
        }

        public string TargetName
        {
            get { Parameter ret; ret = GetField(6); if (ret != null)return (string)ret; else return ""; }
            set { SetField(6, value); }
        }

        public int Count
        {
            get { Parameter ret; ret = GetField(7); if (ret != null)return (int)ret; else return 0; }
            set { SetField(7, value); }
        }

        public int Health
        {
            get { Parameter ret; ret = GetField(8); if (ret != null)return (int)ret; else return 0; }
            set { SetField(8, value); }
        }

        public int dmg
        {
            get { Parameter ret; ret = GetField(9); if (ret != null)return (int)ret; else return 0; }
            set { SetField(9, value); }
        }

        public Vector3 Angles
        {
            get
            {
                //if (Value =< 18) return this.GetPlayerAngles();
                Parameter ret; ret = GetField(10); if (ret != null) return ret.As<Vector3>(); else return Vector3.Zero;
            }
            set
            {
                //if (Value =< 18) this.SetPlayerAngles(value);
                SetField(10, value);
            }
        }

        public int BirthTime
        {
            get { Parameter ret; ret = GetField(11); if (ret != null)return (int)ret; else return 0; }
        }

        public string Script_LinkName
        {
            get { Parameter ret; ret = GetField(12); if (ret != null)return (string)ret; else return ""; }
            set { SetField(12, value); }
        }

        public Vector3 SlideVelocity
        {
            get { Parameter ret; ret = GetField(13); if (ret != null)return ret.As<Vector3>(); else return Vector3.Zero; }
            set { SetField(13, value); }
        }

        public int EntityNumber
        {
            get { Parameter ret; ret = GetField(14); if (ret != null) return (int)ret; else return -1; }
            set { SetField(14, value); }
        }

        public string Name
        {
            get { Parameter ret; ret = GetField(24576); if (ret != null)return (string)ret; else return ""; }
            set
            {
                SetField(24576, value);
                Utilities.setPlayerName(_entRef, value);
            }
        }

        public string SessionTeam
        {
            get { Parameter ret; ret = GetField(24577); if (ret != null)return (string)ret; else return ""; }
            set { SetField(24577, value); }
        }

        public string SessionState
        {
            get { Parameter ret; ret = GetField(24578); if (ret != null)return (string)ret; else return ""; }
            set { SetField(24578, value); }
        }

        public int MaxHealth
        {
            get { Parameter ret; ret = GetField(24579); if (ret != null)return (int)ret; else return 0; }
            set { SetField(24579, value); }
        }

        public int Score
        {
            get { Parameter ret; ret = GetField(24580); if (ret != null)return (int)ret; else return 0; }
            set { SetField(24580, value); }
        }

        public int Deaths
        {
            get { Parameter ret; ret = GetField(24581); if (ret != null)return (int)ret; else return 0; }
            set { SetField(24581, value); }
        }

        public string StatusIcon
        {
            get { Parameter ret; ret = GetField(24582); if (ret != null)return (string)ret; else return ""; }
            set { SetField(24582, value); }
        }

        public string HeadIcon
        {
            get { Parameter ret; ret = GetField(24583); if (ret != null)return (string)ret; else return ""; }
            set { SetField(24583, value); }
        }

        public string HeadIconTeam
        {
            get { Parameter ret; ret = GetField(24584); if (ret != null)return (string)ret; else return ""; }
            set { SetField(24584, value); }
        }

        public int Kills
        {
            get { Parameter ret; ret = GetField(24585); if (ret != null)return (int)ret; else return 0; }
            set { SetField(24585, value); }
        }

        public int Assists
        {
            get { Parameter ret; ret = GetField(24586); if (ret != null)return (int)ret; else return 0; }
            set { SetField(24586, value); }
        }

        public bool HasRadar
        {
            get { Parameter ret; ret = GetField(24587); if (ret != null)return (int)ret != 0; else return false; }
            set { SetField(24587, value ? 1 : 0); }
        }

        public bool IsRadarBlocked
        {
            get { Parameter ret; ret = GetField(24588); if (ret != null) return (int)ret != 0; else return false; }
            set { SetField(24588, value ? 1 : 0); }
        }
        public int RadarStrength
        {
            get { Parameter ret; ret = GetField(24589); if (ret != null) return (int)ret; else return 0; }
            set { SetField(24589, value); }
        }
        public bool RadarShowEnemyDirection
        {
            get { Parameter ret; ret = GetField(24590); if (ret != null) return (int)ret != 0; else return false; }
            set { SetField(24590, value ? 1 : 0); }
        }
        public string RadarMode
        {
            get { Parameter ret; ret = GetField(24591); if (ret != null) return (string)ret; else return ""; }
            set { SetField(24591, value); }
        }

        public int ForceSpectatorClient
        {
            get { Parameter ret; ret = GetField(24592); if (ret != null) return (int)ret; else return 0; }
            set { SetField(24592, value); }
        }
        public int KillcamEntity
        {
            get { Parameter ret; ret = GetField(24593); if (ret != null) return (int)ret; else return 0; }
            set { SetField(24593, value); }
        }
        public int KillcamEntityLookAt
        {
            get { Parameter ret; ret = GetField(24594); if (ret != null) return (int)ret; else return 0; }
            set { SetField(24594, value); }
        }
        public int ArchiveTime
        {
            get { Parameter ret; ret = GetField(24595); if (ret != null) return (int)ret; else return 0; }
            set { SetField(24595, value); }
        }
        public int psOffsetTime
        {
            get { Parameter ret; ret = GetField(24596); if (ret != null) return (int)ret; else return 0; }
            set { SetField(24596, value); }
        }
        #endregion

        #region fields
        private Dictionary<string, Parameter> _privateFields = new Dictionary<string, Parameter>();

        public bool HasField(string name)
        {
            name = name.ToLowerInvariant();

            return (_privateFields.ContainsKey(name));
        }

        public void ClearField(string name)
        {
            name = name.ToLowerInvariant();
            _privateFields.Remove(name);
        }

        internal void ClearAllFields()
            => _privateFields.Clear();

        public Parameter GetField(string name)
        {
            name = name.ToLowerInvariant();

            //if (!_fieldNames.ContainsKey(name))
            //{
                return _privateFields[name];
            //}
            /*
            Parameter returnValue = null;
            int fieldID = _fieldNames[name];

            returnValue = GetField(fieldID);

            return returnValue;
            */
        }

        public Parameter GetField(int fieldID)
        {
            Parameter returnValue = null;

            GameInterface.Script_GetField(_entRef, fieldID);

            switch (GameInterface.Script_GetType(0))
            {
                case VariableType.Integer:
                    returnValue = GameInterface.Script_GetInt(0);
                    break;
                case VariableType.Float:
                    returnValue = GameInterface.Script_GetFloat(0);
                    break;
                case VariableType.String:
                case VariableType.IString:
                    returnValue = GameInterface.Script_GetString(0);
                    break;
                case VariableType.Vector:
                    Vector3 outValue;
                    GameInterface.Script_GetVector(0, out outValue);
                    returnValue = outValue;
                    break;
                case VariableType.Entity:
                    returnValue = new Entity(GameInterface.Script_GetEntRef(0));
                    break;
            }

            GameInterface.Script_CleanReturnStack();

            return returnValue;
        }

        public T GetField<T>(string name)
        {
            Parameter ret = GetField(name);
            return ret.As<T>();
        }

        public void SetField(string name, Parameter value)
        {
            name = name.ToLowerInvariant();

            //if (!_fieldNames.ContainsKey(name))
            //{
                _privateFields[name] = value;
                //return;
            //}
            /*
            int fieldID = _fieldNames[name];

            value.PushValue();
            GameInterface.Script_SetField(_entRef, fieldID);
            */
        }

        public void SetField(int fieldID, Parameter value)
        {
            /*
            name = name.ToLowerInvariant();

            if (!_fieldNames.ContainsKey(name))
            {
                _privateFields[name] = value.InternalValue;
                return;
            }

            int fieldID = _fieldNames[name];
             */

            value.PushValue();
            GameInterface.Script_SetField(_entRef, fieldID);
        }
        #endregion

        #region notify
        public void Notify(string type, params Parameter[] parameters)
        {
            // push arguments
            foreach (var parameter in parameters.Reverse())
            {
                parameter.PushValue();
            }

            // call game function
            GameInterface.Script_NotifyNum(_entRef, type, parameters.Length);
        }
        #endregion

        #region pool stuff
        private static Dictionary<int, Entity> _entities = new Dictionary<int, Entity>();

        public static Entity GetEntity(int entRef)
        {
            if (_entities.ContainsKey(entRef))
            {
                return _entities[entRef];
            }

            var entity = new Entity(entRef);
            _entities[entRef] = entity;
            if (entRef < 18)
            {
                entity.OnNotify("disconnect", ent =>
                {
                    _entities.Remove(ent.EntRef);
                });
            }

            return entity;
        }

        internal static void RunAll(Action<Entity> cb)
        {
            var entities = _entities.Values.ToArray();

            foreach (var entity in entities)
            {
                try
                {
                    cb(entity);
                }
                catch (Exception ex)
                {
                    Log.Write(LogLevel.Error, "Exception during RunAll call: {0}", ex.ToString());
                }
            }
        }
        #endregion

        #region ontimer
        /*
        public void OnInterval(int interval, Func<Entity, bool> function)
        {
            _timers.Add(new ScriptTimer()
            {
                func = function,
                triggerTime = 0,
                interval = interval
            });
        }

        public void AfterDelay(int delay, Action<Entity> function)
        {
            _timers.Add(new ScriptTimer()
            {
                func = function,
                triggerTime = (_currentTime + delay),
                interval = -1
            });
        }
        */
        #endregion

        public int UserID
        {
            get
            {
                return (int)(GUID & 0xFFFFFFFF);
            }
        }

        public int Ping
        {
            get
            {
                return GameInterface.GetPing(_entRef);
            }
        }

        public IPEndPoint IP
        {
            get
            {
                var l = GameInterface.GetClientAddress(_entRef);
                var ip = (l >> 32);
                var port = (int)(l & 0xFFFFFFFF);
                return new IPEndPoint(new IPAddress(ip), port);
            }
        }

        public string HWID
        {
            get
            {
                return GameInterface.GetEntrefHWID(EntRef);
            }
        }

        public override string ToString()
        {
            return string.Format("[Entity:{0}:{1}]", _entRef >> 16, _entRef & 0xFFFF);
        }

        public override int GetHashCode()
        {
            return _entRef;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Entity;

            return other != null && other.EntRef == EntRef;
        }
    }
}
