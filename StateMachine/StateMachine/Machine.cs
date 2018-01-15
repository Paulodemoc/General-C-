using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine
{
    class Machine
    {
        Dictionary<string, State> States;

        public Machine()
        {
            States = new Dictionary<string, State>();
            InitializeStates();
        }

        private void InitializeStates()
        {
            for (int i = 1; i <= 4; i++)
            {
                string name = $"S{i}";
                State state = new State(name, new Dictionary<char, string>());
                switch (i)
                {
                    case 1:
                        state.Outcomes.Add('a', "S2");
                        break;
                    case 2:
                        state.Outcomes.Add('a', "S2");
                        state.Outcomes.Add('b', "S1");
                        state.Outcomes.Add('c', "S4");
                        break;
                    case 3:
                        state.Outcomes.Add('a', "S1");
                        state.Outcomes.Add('b', "S4");
                        break;
                    case 4:
                        state.Outcomes.Add('d', "S3");
                        break;
                }
                States.Add(name, state);
            }
        }

        public string ProcessOutcome(char[] input)
        {
            State state = States["S1"];
            foreach(char action in input)
            {
                if (state.Outcomes.ContainsKey(action))
                {
                    state = States[state.Outcomes[action]];
                }
            }
            return state.Name;
        }
    }
}
