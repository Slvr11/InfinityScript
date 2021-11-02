using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfinityScript
{
    static class ScriptProcessor
    {
        internal static List<BaseScript> _scripts = new List<BaseScript>();

        public static void AddScript(BaseScript script)
        {
            _scripts.Add(script);
        }

        public static void RunAll(Action<BaseScript> cb)
        {
            var scripts = _scripts.ToArray();

            foreach (var script in scripts)
            {
                try
                {
                    cb(script);
                }
                catch (Exception ex)
                {
                    Utilities.PrintToConsole(string.Format("[InfinityScript] Exception during RunAll call: {0}", ex.ToString()));
                }
            }
        }
    }
}
