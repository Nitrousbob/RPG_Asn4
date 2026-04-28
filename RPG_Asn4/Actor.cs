using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Asn4
{
    public abstract class Actor
    {
        public string Name { get; private set; }

        protected Actor(string name)
        {
            Name = name;
        }
    }
}
