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
            Console.WriteLine("Hi Dude");
            while (true)
            {
                input = Console.ReadLine();
                Serial_Port_List.Send_Data(input);
            }
            
        }
    }
}
