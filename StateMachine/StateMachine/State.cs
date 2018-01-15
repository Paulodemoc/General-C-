using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine
{
    class State
    {
        public string Name;
        public Dictionary<char, string> Outcomes;

        public State()
        {
            Name = string.Empty;
            Outcomes = new Dictionary<char, string>();
        }

        public State(string name, Dictionary<char, string> outcomes)
        {
            Name = name;
            Outcomes = outcomes;
        }
    }
}
