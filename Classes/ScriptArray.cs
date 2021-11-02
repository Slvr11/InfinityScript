using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Net;

namespace InfinityScript
{
    public class ScriptArray : Notifiable
    {
        private static Dictionary<string, Parameter> _array = new Dictionary<string, Parameter>();

        private int _entRef;

        internal ScriptArray(int entRef)
        {
            _entRef = entRef;
            setArrayValues();
        }

        private static void setArrayValues()
        {

        }

        public int ArrayRef
        {
            get
            {
                return _entRef;
            }
        }

        /// <summary>
        /// Gets all values of a ScriptArray
        /// </summary>
        /// <returns>Returns all values of this ScriptArray as a <see cref="ScriptValue[]"/></returns>
        public Parameter[] GetAllValues()
        {
            return _array.Values.ToArray();
        }
        //Alt 1337 way? - Slvr 27/9/16
        //{
        //ScriptValue[] ret = new ScriptValue[_array.Keys.Count];
        //ret = _array.Values.ToArray();
        //return ret;
        //return _array.Values.ToArray();
        //}

        /// <summary>
        /// Gets a specific value of a ScriptArray by name
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Returns the value of the given key in the ScriptArray</returns>
        public Parameter GetValue(string key)
        {
            if (!_array.ContainsKey(key))
                return null;
            return _array[key];
        }

        /// <summary>
        /// Gets a specific value of a ScriptArray by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Returns the value of the given index in the ScriptArray</returns>
        public Parameter GetValue(int index)
        {
            string[] keys = _array.Keys.ToArray();
            if (_array[keys[index]] == null)
                return null;
            return _array[keys[index]];
        }

        public int Count
        { get { return _entRef; } }

        public override string ToString()
        {
            return string.Format("[Array:{0}:{1}]", _entRef >> 16, _entRef & 0xFFFF);
        }

        //public override int GetHashCode()
        //{
            //return _entRef;
        //}

        public override bool Equals(object obj)
        {
            var other = obj as ScriptArray;

            return other != null && other.ArrayRef == ArrayRef;
        }
    }
}
