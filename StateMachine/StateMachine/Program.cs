using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input a sequence of actions (accepted values are: a, b, c or d)");
            Console.WriteLine("e.g.: aaaaacdb");
            string value = Console.ReadLine();
            List<char> datalist = new List<char>();
            datalist.AddRange(value);
            Machine machina = new Machine();
            string result = machina.ProcessOutcome(datalist.ToArray());
            Console.WriteLine($"Output: {result}");
            Console.ReadKey(false);
        }
    }
}
