using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

//TODO: Fix notifies stacking per entity(same notify for different ents

namespace InfinityScript
{
    internal class ISWait : Notifiable
    {
        public static List<IEnumerator> routines = new List<IEnumerator>();
        private static Dictionary<string, bool> Notifies = new Dictionary<string, bool>();
        private static Dictionary<string[], bool> GroupedNotifies = new Dictionary<string[], bool>();
        //private static int notifyCount = -1;
        //public static bool notified = false;
        //private static bool entNotified = false;
        private static string lastNotify = "";

        //public ISWait()
        //{
        //}

        public static bool stepForward()
        {
            if (Running)
            {
                try
                {
                    Update();
                }
                catch { return false; }
                return true;
            }
            else return false;
        }

        private static void StopAll()
        {
            routines.Clear();
        }

        //private static int incrementList()
        //{
            //notifyCount++;
            //return notifyCount;
        //}

        private static void InternalWait(string notifyCheck, string notify, params Parameter[] par)
        {
            if (notify == notifyCheck)
            //{
                //notified = true;
                Notifies[notify] = true;
                //Notifiable._notifyHandlers.Remove(notify);
            //}
            //return null;
        }
        private static void InternalWait_return(string notifyCheck, string notify, Action<Parameter[]> returnParams, params Parameter[] par)
        {
            if (notify == notifyCheck)
            {
                Notifies[notify] = true;
                returnParams?.Invoke(par);
            }
        }

        private static void InternalWaitAll(string[] notifyCheck, string notify, params Parameter[] pars)
        {
            foreach (string not in notifyCheck)
            {
                if (notify == not)
                {
                    //notified = true;
                    lastNotify = notify;
                    GroupedNotifies[notifyCheck] = true;
                    //Notifiable._notifyHandlers.Remove(notify);
                }
            }
            //return null;
        }
        #region waitFuncs

        internal static Action<string> addHandler(string notify)
        {
            Notifies.Add(notify, false);
            Action<string> notifyWaiter = new Action<string>(m => InternalWait(notify, m));
            
            return notifyWaiter;
        }
        internal static void removeHandler(string notify)
        {
            Notifies.Remove(notify);
        }
        internal static void removeGroupHandlers(string[] notify)
        {
            //foreach (string message in notify)
            //Notifies.Remove(message);
            GroupedNotifies.Remove(notify);
        }
        internal static Action<string> addGroupHandler(string[] notify)
        {
            GroupedNotifies.Add(notify, false);
            Action<string> notifyWaiter = new Action<string>(m => InternalWaitAll(notify, m));

            return notifyWaiter;
        }

        public static bool checkStatus(string notify)
        {
            if (Notifies[notify])
            {
                Notifies.Remove(notify);
                return true;
            }
            return false;
        }
        public static bool checkGroupStatus(string[] notify)
        {
            if (GroupedNotifies[notify])
            {
                GroupedNotifies.Remove(notify);
                return true;
            }
            return false;
        }

        //public static IEnumerator WaitTill(string notify)
        //{
            //int thisNotify = incrementList();
            //notifyCollector thisNotify = new notifyCollector();
            //ent.OnNotify(notify, (e, p) => InternalWait(notify));
            
            //Entity.Level.WaitTillEvents += notifyWaiter;
            
            //Entity.Level.WaitTillEvents -= notifyWaiter;
        //}

        internal static IEnumerator WaitTill(Entity ent, string notify)
        {
            //if (Notifies.ContainsKey(notify)) yield break;
            //int thisNotify = incrementList();
            //notifyCollector thisNotify = new notifyCollector();
            //ent.OnNotify(notify, (e, p) => InternalWait(notify));
            if (!Notifies.ContainsKey(notify))
                Notifies.Add(notify, false);
            Action<int, string, Parameter[]> notifyWaiter = new Action<int, string, Parameter[]>((e, m, p) => InternalWait(notify, m, p));
            ent.Notified += notifyWaiter;
            while (!Notifies[notify])
                yield return 0;
            removeHandler(notify);
            ent.Notified -= notifyWaiter;
            yield break;
        }
        internal static IEnumerator WaitTill_return(Entity ent, string notify, Action<Parameter[]> returnParams)
        {
            //if (Notifies.ContainsKey(notify)) yield break;
            //int thisNotify = incrementList();
            //notifyCollector thisNotify = new notifyCollector();
            //ent.OnNotify(notify, (e, p) => InternalWait(notify));
            if (!Notifies.ContainsKey(notify))
                Notifies.Add(notify, false);

            Parameter[] parameters = null;

            Action<int, string, Parameter[]> notifyWaiter = new Action<int, string, Parameter[]>((e, m, p) => InternalWait_return(notify, m, new Action<Parameter[]>((param) => parameters = param), p));
            ent.Notified += notifyWaiter;
            while (!Notifies[notify])
                yield return 0;
            removeHandler(notify);
            ent.Notified -= notifyWaiter;
            if (parameters != null) returnParams?.Invoke(parameters);
            yield break;
        }

        //public IEnumerator WaitTill_any(params string[] notify)
        //{
        //    //foreach (string not in notify)
        //        //OnNotify(not, (p) => InternalWaitAll(notify));
        //    GroupedNotifies.Add(notify, false);
        //    Action<string> notifyWaiter = new Action<string>(m => InternalWaitAll(notify, m));
        //    //WaitTillEvents += notifyWaiter;
        //    while (!GroupedNotifies[notify])
        //        yield return 0;
        //    GroupedNotifies.Remove(notify);
        //    //WaitTillEvents -= notifyWaiter;
        //}

        public static IEnumerator WaitTill_any(Entity ent, params string[] notify)
        {
            if (!GroupedNotifies.ContainsKey(notify))
                GroupedNotifies.Add(notify, false);
            Action<int, string, Parameter[]> notifyWaiter = new Action<int, string, Parameter[]>((e, m, p) => InternalWaitAll(notify, m, p));
            ent.Notified += notifyWaiter;
            while (!GroupedNotifies[notify])
                yield return 0;
            removeGroupHandlers(notify);
            ent.Notified -= notifyWaiter;
            yield break;
        }

        public static IEnumerator WaitTill_any_return(Entity ent, Action<string> returnString, params string[] notify)
        {
            if (!GroupedNotifies.ContainsKey(notify))
                GroupedNotifies.Add(notify, false);
            Action<int, string, Parameter[]> notifyWaiter = new Action<int, string, Parameter[]>((e, m, p) => InternalWaitAll(notify, m, p));
            ent.Notified += notifyWaiter;
            while (!GroupedNotifies[notify])
                yield return 0;
            removeGroupHandlers(notify);
            ent.Notified -= notifyWaiter;
            returnString?.Invoke(lastNotify);
            yield break;
        }

        //public IEnumerator WaitTill_notify_or_timeout(string notify, int time)
        //{
        //    Notifies.Add(notify, false);
        //    var watch = Stopwatch.StartNew();
        //    Action<string> notifyWaiter = new Action<string>(m => InternalWait(notify, m));
        //    //WaitTillEvents += notifyWaiter;
        //    while (!Notifies[notify] || watch.Elapsed.TotalSeconds < time)
        //        yield return 0;
        //    Notifies.Remove(notify);
        //    //WaitTillEvents -= notifyWaiter;
        //}

        public static IEnumerator WaitTill_notify_or_timeout(Entity ent, string notify, int time, Action<string> returnString = null)
        {
            if (!Notifies.ContainsKey(notify))
                Notifies.Add(notify, false);
            var watch = Stopwatch.StartNew();
            Action<int, string, Parameter[]> notifyWaiter = new Action<int, string, Parameter[]>((e, m, p) => InternalWait(notify, m, p));
            ent.Notified += notifyWaiter;
            while (!Notifies[notify] && watch.Elapsed.TotalSeconds < time)
                yield return 0;
            removeHandler(notify);
            if (watch.IsRunning) watch.Stop();
            ent.Notified -= notifyWaiter;
            if (watch.Elapsed.TotalSeconds >= time)
            {
                returnString?.Invoke("timeout");
                yield break;
            }
            else
            {
                returnString?.Invoke(notify);
                yield break;
            }
        }
        #endregion

        private static void Update()
        {
            for (int i = 0; i < routines.Count; i++)
            {
                if (routines[i].Current is IEnumerator)
                    if (MoveNext((IEnumerator)routines[i].Current))
                        continue;
                if (!routines[i].MoveNext())
                    routines.RemoveAt(i--);
            }
        }

        private static bool MoveNext(IEnumerator routine)
        {
            if (routine.Current is IEnumerator)
                if (MoveNext((IEnumerator)routine.Current))
                    return true;
            return routine.MoveNext();
        }

        internal static int Count
        {
            get { return routines.Count; }
        }

        internal static bool Running
        {
            get { return routines.Count > 0; }
        }
    }
}