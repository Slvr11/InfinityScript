using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.IO;

namespace InfinityScript
{

    public class ScriptLoader
    {
        private static List<string> _loadedAssemblies = new List<string>();

        public static void Initialize()
        {
            LoadScripts();
        }

        public static void LoadScripts()
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

            LoadAssembly(Assembly.GetExecutingAssembly());
            LoadAssemblies("scripts", "*.auto.dll");
        }

        public static void LoadAssemblies(string dir, string filter)
        {
            var files = Directory.GetFiles(dir, filter, SearchOption.TopDirectoryOnly);

            foreach (string file in files)
            {
                try
                {
                    using (var fs = new FileStream(file, FileMode.Open))
                    {
                        var rawAssembly = new byte[fs.Length];
                        fs.Read(rawAssembly, 0, rawAssembly.Length);
                        var assembly = Assembly.Load(rawAssembly);
                        //var assembly = Assembly.LoadFile(file);
                        LoadAssembly(assembly);
                    }
                }
                catch (Exception ex)
                {
                    Utilities.PrintToConsole(string.Format("[InfinityScript] Error while loading {0}: {1}", file, ex.ToString()));
                }
            }
        }

        private static void LoadAssembly(Assembly assembly)
        {
            try
            {
                Type[] types = assembly.GetTypes();
                var sortedTypes = from type in types orderby type.Name select type;

                foreach (Type type in sortedTypes)
                {
                    if (type.IsPublic && !type.IsAbstract)
                    {
                        try
                        {
                            if (type.IsSubclassOf(typeof(BaseScript)))
                            {
                                Utilities.PrintToConsole(string.Format("[InfinityScript] Loading script {0} v{1}", type.Name, assembly.GetName().Version));

                                BaseScript script = (BaseScript)Activator.CreateInstance(type);
                                ScriptProcessor.AddScript(script);
                            }
                        }
                        catch (Exception ex)
                        {
                            Utilities.PrintToConsole(string.Format("[InfinityScript] An error occurred during initialization of the script {0}: {1}", type.Name, ex.ToString()));
                        }
                    }
                }
            }
            catch (ReflectionTypeLoadException ex)
            {
                Utilities.PrintToConsole(string.Format("[InfinityScript] Assembly {0} could not be loaded because of a loader exception: {1}", assembly.GetName(), ex.LoaderExceptions[0].ToString()));
            }
        }

        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (args.Name.Contains("CitizenSHManager"))
            {
                return Assembly.GetExecutingAssembly();
            }

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (assembly.FullName == args.Name)
                {
                    return assembly;
                }
            }

            return null;
        }
    }
}
