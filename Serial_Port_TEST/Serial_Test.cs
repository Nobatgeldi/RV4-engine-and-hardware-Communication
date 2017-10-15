using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serial_Port;


namespace Serial_Port_TEST
{
    class Serial_Test
    {
        static void Main(string[] args)
        {
            String input = "";
            String get = "";
            Console.WriteLine("Welcome to simulation of simulation :D");
            StringBuilder output = new StringBuilder("");
            StringBuilder income = new StringBuilder(" ");
            while (true)
            {
                input = Console.ReadLine();
                Serial_Port_List.RvExtension(output, 8, input);
                Console.WriteLine(output);
                output.Clear();
            }
            
        }
    }
}
