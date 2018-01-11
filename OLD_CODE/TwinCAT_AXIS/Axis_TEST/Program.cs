using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinCAT_AXIS;

namespace Axis_TEST
{
    class Program
    {
        static void Main(string[] args)
        {
            String input = "";
            Console.WriteLine("Welcome to simulation of simulation :D");
            StringBuilder output = new StringBuilder("");
            StringBuilder income = new StringBuilder(" ");

            while (true)
            {
                input = Console.ReadLine();
                Axis_control.RvExtension(output, 8, input);

                Console.WriteLine(output);
                output.Clear();
            }

        }
    }
}
