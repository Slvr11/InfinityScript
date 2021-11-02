﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfinityScript
{
    public class Parameter
    {
        private VariableType _type;
        private object _value;

        internal object InternalValue
        {
            get
            {
                return _value;
            }
        }

        public VariableType Type
        {
            get
            {
                return _type;
            }
        }

        internal Parameter(VariableType type, object value)
        {
            _type = type;
            _value = value;
        }

        public static explicit operator int(Parameter p)
        {
            return Convert.ToInt32(p._value);
        }

        public static explicit operator bool(Parameter p)
        {
            return Convert.ToInt32(p._value) != 0;
        }

        public static explicit operator float(Parameter p)
        {
            return Convert.ToSingle(p._value);
        }

        public static explicit operator string(Parameter p)
        {
            return Convert.ToString(p._value);
        }

        public static explicit operator Entity(Parameter p)
        {
            return (Entity)p._value;
        }

        public static explicit operator HudElem(Parameter p)
        {
            return (HudElem)p._value;
        }

        public T As<T>()
        {
            return (T)Convert.ChangeType(_value, typeof(T));
        }

        public Parameter(string v)
        {
            _type = VariableType.String;
            _value = v;
        }

        public static implicit operator Parameter(string v)
        {
            return new Parameter(v);
        }
        /*
        public Parameter(IString v)
        {
            _type = VariableType.IString;
            _value = v;
        }

        public static implicit operator Parameter(IString v)
        {
            return new Parameter(v);
        }
        */

        public Parameter(int v)
        {
            _type = VariableType.Integer;
            _value = v;
        }

        public static implicit operator Parameter(int v)
        {
            return new Parameter(v);
        }

        public Parameter(float v)
        {
            _type = VariableType.Float;
            _value = v;
        }

        public static implicit operator Parameter(float v)
        {
            return new Parameter(v);
        }

        public Parameter(Vector3 v)
        {
            _type = VariableType.Vector;
            _value = v;
        }

        public static implicit operator Parameter(Vector3 v)
        {
            return new Parameter(v);
        }

        public Parameter(Entity v)
        {
            _type = VariableType.Entity;
            _value = v;
        }

        public static implicit operator Parameter(Entity v)
        {
            return new Parameter(v);
        }

        public Parameter(HudElem v)
        {
            _type = VariableType.Entity;
            _value = v;
        }

        public static implicit operator Parameter(HudElem v)
        {
            return new Parameter(v);
        }

        public static implicit operator Parameter(bool v)
        {
            return new Parameter((v) ? 1 : 0);
        }

        public Parameter(object v)
        {
            _value = v;
        }

        internal void PushValue()
        {
            switch (_type)
            {
                case VariableType.Float:
                    GameInterface.Script_PushFloat(Convert.ToSingle(_value));
                    break;
                case VariableType.Integer:
                    GameInterface.Script_PushInt(Convert.ToInt32(_value));
                    break;
                case VariableType.String:
                case VariableType.IString:
                    GameInterface.Script_PushString(Convert.ToString(_value));
                    break;
                case VariableType.Entity:
                    GameInterface.Script_PushEntRef(((Entity)_value).EntRef);
                    break;
                case VariableType.Vector:
                    var v = (Vector3)_value;
                    GameInterface.Script_PushVector(v.X, v.Y, v.Z);
                    break;
            }
        }

        public bool IsNull
        {
            get
            {
                return _value == null;
            }
        }

        public override string ToString()
        {
            return _value.ToString();
        }
    }
}
