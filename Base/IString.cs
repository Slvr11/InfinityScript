using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfinityScript
{
    public struct IString
    {
        public string text;
        public IString(string s) : this()
        {
            text = s;
        }

        public override string ToString()
            => text;
    }
}
