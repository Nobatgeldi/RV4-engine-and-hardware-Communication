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
        Serial_Port_List connect = new Serial_Port_List();
        static void Main(string[] args)
        {
            String input = "";
            String get = "";
            Console.WriteLine("Hi Dude");
            StringBuilder MyStringBuilder = new StringBuilder("");
            while (true)
            {
                input = Console.ReadLine();
                /*get=Serial_Port_List.Test_Connection(input);
                Console.WriteLine(get);*/
                Serial_Port_List.RvExtension(MyStringBuilder, 8, input);
            }
            
        }
    }
}
