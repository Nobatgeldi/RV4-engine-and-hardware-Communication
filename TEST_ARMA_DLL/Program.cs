using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOTION_SERVICE;

namespace MOTION_SERVICE_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            String input = "";
            Console.WriteLine("Motion Service control system");
            StringBuilder output = new StringBuilder("");

            while (true)
            {
                input = Console.ReadLine();
                Service_control.RvExtension(output, 8, input);
          
                Console.WriteLine(output);
                output.Clear();
            }

        }
    }
}
