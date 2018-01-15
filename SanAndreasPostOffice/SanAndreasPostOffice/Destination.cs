using System;
using System.Collections.Generic;
using System.Text;

namespace SanAndreasPostOffice
{
    class Destination
    {
        public string Name;
        public string Abreviation;
        public Dictionary<string, int> Connections;

        public Destination()
        {
            Name = string.Empty;
            Connections = new Dictionary<string, int>();
        }

        public Destination(string name, string abreviation, Dictionary<string, int> connections)
        {
            Name = name;
            Abreviation = abreviation;
            Connections = connections;
        }
    }
}
