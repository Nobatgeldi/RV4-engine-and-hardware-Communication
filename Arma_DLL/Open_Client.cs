using Maca134.Arma.DllExport;
using System;
using System.Diagnostics;
using System.ServiceProcess;

namespace Arma_DLL
{
    public class Open_Client
    {
        public static ServiceController sc;

        [ArmaDllExport]
        public static string Invoke(string input, int size)
        {
            String output = "false";
            if (input== "status")
            {
                try
                {
                    //Process.Start("C:/Users/nobat/Documents/Arma Drive/Arma 3 Apex/@dll/Proccess_DLL.exe");
                    output = Status_Service("Motion_SERVICE"); ;
                }
                catch (Exception ex)
                {
                    output = ex.ToString();
                }
                return output;
            }
            else
                return output;
        }
        public static string Status_Service(string servicename)
        {
            // Toggle the service - 
            // If it is started (running, paused, etc), stop the service.
            // If it is stopped, start the service.
            sc = new ServiceController(servicename);
            //Console.WriteLine("The {0} service status is currently set to {1}", servicename, sc.Status.ToString());
            servicename= "The "+ servicename+ " service status is currently set to" + sc.Status.ToString();

            return servicename;
        }
        public static string Start_Service(string servicename)
        {
            // Toggle the service - 
            // If it is started (running, paused, etc), stop the service.
            // If it is stopped, start the service.
            sc = new ServiceController(servicename);
            if ((sc.Status.Equals(ServiceControllerStatus.Stopped)) || (sc.Status.Equals(ServiceControllerStatus.StopPending)))
            {
                // Start the service if the current status is stopped.
                Console.WriteLine("Starting the {0} service...", servicename);
                sc.Start();
            }
            else
            {
                // Stop the service if its status is not set to "Stopped".
                Console.WriteLine("Stopping the {0} service...", servicename);
                sc.Stop();
            }
        
            // Refresh and display the current service status.
            sc.Refresh();
            Console.WriteLine("The {0} service status is now set to {1}.", servicename, sc.Status.ToString());

            return servicename;
        }
        public static string Stop_Service(string servicename)
        {
            // Toggle the service - 
            // If it is started (running, paused, etc), stop the service.
            // If it is stopped, start the service.
            sc = new ServiceController(servicename);
            if ((sc.Status.Equals(ServiceControllerStatus.Stopped)) || (sc.Status.Equals(ServiceControllerStatus.StopPending)))
            {
                // Start the service if the current status is stopped.
                Console.WriteLine("Starting the {0} service...", servicename);
                sc.Start();
            }
            else
            {
                // Stop the service if its status is not set to "Stopped".
                Console.WriteLine("Stopping the {0} service...", servicename);
                sc.Stop();
            }

            // Refresh and display the current service status.
            sc.Refresh();
            Console.WriteLine("The {0} service status is now set to {1}.", servicename, sc.Status.ToString());

            return servicename;
        }
    }
}
