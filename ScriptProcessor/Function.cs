using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace InfinityScript
{
    internal static class Function
    {

        //public static bool IsFunction(string name)
        //{
            //return (ScriptNames.FunctionList.IsDefined(typeof(ScriptNames.FunctionList), name));
        //}

        private static int _entRef;

        private static object _returnValue;

        internal static void SetEntRef(int entRef)
        {
            _entRef = entRef;
        }
        /*
        public static void Call(ScriptNames.FunctionList func, params Parameter[] parameters)
        {
            //func = func.ToLowerInvariant();

            CallRaw((uint)func, parameters);
        }
         */
        internal static void Call(ScriptNames.FunctionList func, params Parameter[] parameters)
        {
            CallRaw((uint)func, parameters);
        }

        internal static object GetReturns()
        {
            //if (!_returnValue == null)
                return _returnValue;
            //else 
        }

        //public static dynamic Call(ScriptNames.FunctionList func, params Parameter[] parameters)
        //{
            //func = func.ToLowerInvariant();
            /*
            var table = _globalFunctionMappings;

            if (_entRef != -1)
            {
                table = _functionMappings;
            }

            if (!table.ContainsKey(func))
            {
                Log.Write(LogLevel.Warning, "no such function: {0}", func);
                return default(TReturn);
            }
             */

            //return Call<TReturn>(table[func], parameters);
        //}
        /*
        public static dynamic Call(ScriptNames.FunctionList func, params Parameter[] parameters)
        {
            dynamic retval = Call(func, parameters);

            return retval;
        }

        public static dynamic CallReturn(ScriptNames.FunctionList func, params Parameter[] parameters)
        {
            CallRaw((uint)func, parameters);

            return _returnValue;
        }
         */

        private static void CallRaw(uint identifier, params Parameter[] parameters)
        {
            // push arguments
            //foreach (var parameter in parameters.Reverse())
            //{
                //parameter.PushValue();
            //}
            for (int i = parameters.Length-1; i >= 0; i--)
                parameters[i].PushValue();

            // call the function
            GameInterface.Script_Call((int)identifier, _entRef, parameters.Length);

            // reset the entref to 0
            SetEntRef(-1);

            // check for return values
            _returnValue = null;

            if (GameInterface.Notify_NumArgs() == 1)
            {
                switch (GameInterface.Script_GetType(0))
                {
                    case VariableType.Entity:
                        _returnValue = Entity.GetEntity(GameInterface.Script_GetEntRef(0));
                        break;
                    case VariableType.Integer:
                        _returnValue = GameInterface.Script_GetInt(0);
                        break;
                    case VariableType.Float:
                        _returnValue = GameInterface.Script_GetFloat(0);
                        break;
                    case VariableType.String:
                    case VariableType.IString:
                        _returnValue = GameInterface.Script_GetString(0);
                        break;
                    case VariableType.Vector:
                        Vector3 outValue;
                        GameInterface.Script_GetVector(0, out outValue);
                        _returnValue = outValue;
                        break;
                }
            }

            GameInterface.Script_CleanReturnStack();
        }
    }
}
