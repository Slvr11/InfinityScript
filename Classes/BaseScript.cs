using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace InfinityScript
{
    public abstract class BaseScript : Notifiable
    {
        #region events
        protected event Action Tick;
        protected event Action<Entity> PlayerConnecting;
        protected event Action<Entity> PlayerConnected;
        protected event Action<Entity> PlayerDisconnected;
        #endregion

        #region player list
        public static List<Entity> Players { get; private set; }
        #endregion

        public BaseScript()
        {
            Players = new List<Entity>();

            OnNotify("connecting", entity =>
            {
                if (!Players.Contains(entity.As<Entity>())) Players.Add(entity.As<Entity>());

                if (PlayerConnecting != null)
                {
                    PlayerConnecting(entity.As<Entity>());
                }
            });

            OnNotify("connected", entity =>
            {
                if (PlayerConnected != null)
                {
                    PlayerConnected(entity.As<Entity>());
                }
            });
        }

        #region virtual call functions
        public virtual void OnStartGameType() { }
        //public virtual string OnPlayerAttemptConnect(Entity player) { return null; }
        public virtual string OnPlayerRequestConnection(string playerName, string playerHWID, string playerXUID, string playerIP, string playerSteamID, string playerXNAddress) { return null; }
        public virtual void OnPlayerConnecting(Entity player) { }
        public virtual void OnPlayerDisconnect(Entity player)
        {
            Players.Remove(player);

            if (PlayerDisconnected != null)
            {
                PlayerDisconnected(player);
            }
        }

        public virtual void OnPlayerDamage(Entity player, Entity inflictor, Entity attacker, int damage, int dFlags, string mod, string weapon, Vector3 point, Vector3 dir, string hitLoc) { }
        public virtual void OnPlayerKilled(Entity player, Entity inflictor, Entity attacker, int damage, string mod, string weapon, Vector3 dir, string hitLoc) { }
        public virtual void OnVehicleDamage(Entity player, Entity inflictor, Entity attacker, int damage, int dFlags, string mod, string weapon, Vector3 point, Vector3 dir, string hitLoc, int timeOffset, int modelIndex, string partName) { }
        public virtual void OnPlayerLastStand(Entity player, Entity inflictor, Entity attacker, int damage, string mod, string weapon, Vector3 dir, string hitLoc, int timeOffset, int deathAnimDuration) { }

        public virtual void OnSay(Entity player, string name, string message) { }
        public virtual EventEat OnSay2(Entity player, string name, string message) { return EventEat.EatNone; }
        public virtual EventEat OnSay3(Entity player, ChatType type, string name, ref string message) { return EventEat.EatNone; }
        public enum EventEat { EatNone = 0, EatScript = 1, EatGame = 2 };
        public enum ChatType { All = 0, Team = 1 };

        public virtual void OnExitLevel() { }
        #endregion

        #region onnotify
        public void OnNotify(string type, Action handler)
        {
            OnNotifyInternal(type, handler);
        }

        public void OnNotify(string type, Action<Parameter> handler)
        {
            OnNotifyInternal(type, handler);
        }

        public void OnNotify(string type, Action<Parameter, Parameter> handler)
        {
            OnNotifyInternal(type, handler);
        }

        public void OnNotify(string type, Action<Parameter, Parameter, Parameter> handler)
        {
            OnNotifyInternal(type, handler);
        }

        public void OnNotify(string type, Action<Parameter, Parameter, Parameter, Parameter> handler)
        {
            OnNotifyInternal(type, handler);
        }

        public void OnNotify(string type, Action<Parameter, Parameter, Parameter, Parameter, Parameter> handler)
        {
            OnNotifyInternal(type, handler);
        }

        public void OnNotify(string type, Action<Parameter, Parameter, Parameter, Parameter, Parameter, Parameter> handler)
        {
            OnNotifyInternal(type, handler);
        }

        public void OnNotify(string type, Action<Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter> handler)
        {
            OnNotifyInternal(type, handler);
        }

        public void OnNotify(string type, Action<Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter> handler)
        {
            OnNotifyInternal(type, handler);
        }

        public void OnNotify(string type, Action<Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter> handler)
        {
            OnNotifyInternal(type, handler);
        }

        public void OnNotify(string type, Action<Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter> handler)
        {
            OnNotifyInternal(type, handler);
        }

        //Waits
        public static void StartAsync(IEnumerator routine)
        {
            ISWait.routines.Add(routine);
            OnInterval(50, () => ISWait.stepForward());
        }

        public static IEnumerator Wait(float time)
        {
            var watch = Stopwatch.StartNew();
            while (watch.Elapsed.TotalSeconds < time)
                yield return 0;
        }
        public static IEnumerator WaitForFrame()
        {
            var watch = Stopwatch.StartNew();
            while (watch.Elapsed.TotalSeconds < .05f)
                yield return 0;
        }
        public IEnumerator WaitTill(string type)
        {
            Action<string> notifyWaiter = ISWait.addHandler(type);
            WaitTillEvents += notifyWaiter;
            while (!ISWait.checkStatus(type))
                yield return 0;
            ISWait.removeHandler(type);
            WaitTillEvents -= notifyWaiter;
        }
        public IEnumerator WaitTill_any(params string[] type)
        {
            Action<string> notifyWaiter = ISWait.addGroupHandler(type);
            WaitTillEvents += notifyWaiter;
            while (!ISWait.checkGroupStatus(type))
                yield return 0;
            ISWait.removeGroupHandlers(type);
            WaitTillEvents -= notifyWaiter;
        }
        public IEnumerator WaitTill_notify_or_timeout(string type, int time, Action<string> returnString = null)
        {
            Action<string> notifyWaiter = ISWait.addHandler(type);
            var watch = Stopwatch.StartNew();
            WaitTillEvents += notifyWaiter;
            while (!ISWait.checkStatus(type) && watch.Elapsed.TotalSeconds < time)
                yield return 0;
            ISWait.removeHandler(type);
            if (watch.IsRunning) watch.Stop();
            WaitTillEvents -= notifyWaiter;
            if (watch.Elapsed.TotalSeconds >= time)
            {
                returnString?.Invoke("timeout");
                yield return "timeout";
            }
            else
            {
                returnString?.Invoke(type);
                yield return type;
            }
        }
        #endregion

        #region timer adders
        public static void OnInterval(int interval, Func<bool> function)
        {
            _timers.Add(new ScriptTimer()
            {
                func = function,
                triggerTime = 0,
                interval = interval
            });
        }

        public static void AfterDelay(int delay, Action function)
        {
            _timers.Add(new ScriptTimer()
            {
                func = function,
                triggerTime = (_currentTime + delay),
                interval = -1
            });
        }
        #endregion

        #region runframe
        internal void RunFrame()
        {
            // handle tick
            if (Tick != null)
            {
                try
                {
                    Tick();
                }
                catch (Exception ex)
                {
                    Log.Write(LogLevel.Error, "Exception during Tick on script {0}: {1}", GetType().Name, ex.ToString());
                }
            }

            ProcessTimers();
            ProcessNotifications();
        }
        #endregion

        #region notify
        public static void Notify(string type, params Parameter[] parameters)
        {
            // push arguments
            //foreach (var parameter in parameters.Reverse())
            //{
            //parameter.PushValue();
            //}
            for (int i = parameters.Length - 1; i >= 0; i--)
                parameters[i].PushValue();

            // call game function
            GameInterface.Script_NotifyLevel(type, parameters.Length);
        }
        #endregion

        #region commands
        internal Dictionary<string, List<Func<string[], bool>>> _serverCommandHandlers = new Dictionary<string, List<Func<string[], bool>>>();
        internal Dictionary<string, List<Action<Entity, string[]>>> _clientCommandHandlers = new Dictionary<string, List<Action<Entity, string[]>>>();

        internal bool ProcessServerCommand(string command, string[] args)
        {
            bool eat = false;
            if (_serverCommandHandlers.ContainsKey(command))
            {
                var handles = _serverCommandHandlers[command];
                foreach (var handle in handles)
                {
                    if (handle(args))
                    {
                        eat = true;
                    }
                }
            }
            return eat;
        }
        internal bool ProcessClientCommand(string command, Entity entity, string[] args)
        {
            bool eat = false;
            if (_clientCommandHandlers.ContainsKey(command))
            {
                var handles = _clientCommandHandlers[command];
                foreach (var handle in handles)
                {
                    handle(entity, args);
                    eat = true;
                }
            }
            return eat;
        }

        public void OnServerCommand(string command, Func<string[], bool> func)
        {
            if (!_serverCommandHandlers.ContainsKey(command))
            {
                _serverCommandHandlers[command] = new List<Func<string[], bool>>();
            }
            _serverCommandHandlers[command].Add(func);
        }
        public void OnServerCommand(string command, Action<string[]> func)
        {
            OnServerCommand(command, args =>
            {
                func(args);
                return true;
            });
        }
        public void OnServerCommand(string command, Action func)
        {
            OnServerCommand(command, args =>
            {
                func();
                return true;
            });
        }

        public void OnClientCommand(string command, Action<Entity, string[]> func)
        {
            if (!_clientCommandHandlers.ContainsKey(command))
            {
                _clientCommandHandlers[command] = new List<Action<Entity, string[]>>();
            }
            _clientCommandHandlers[command].Add(func);
        }
        public void OnClientCommand(string command, Action<Entity> func)
        {
            OnClientCommand(command, (entity, args) => func(entity));
        }
        public void OnClientCommand(string command, Action func)
        {
            OnClientCommand(command, (entity, args) => func());
        }
        #endregion
    }
}
