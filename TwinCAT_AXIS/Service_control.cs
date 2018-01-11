using System;
using System.Text;
using System.Runtime.InteropServices;
using RGiesecke.DllExport;
using System.ServiceProcess;

namespace MOTION_SERVICE
{
    public class Service_control
    {
        public static ServiceController sc;

        [DllExport("RVExtension", CallingConvention = CallingConvention.Winapi)]
        public static void RvExtension(StringBuilder output, int outputSize, [MarshalAs(UnmanagedType.LPStr)] string function)
        {
            outputSize--;
            string result = "Free";
            if (function == "status")
            {
                try
                {
                    //Process.Start("C:/Users/nobat/Documents/Arma Drive/Arma 3 Apex/@dll/Proccess_DLL.exe");
                    result = Status_Service("Motion_SERVICE");
                }
                catch (Exception ex)
                {
                    result = ex.ToString();
                }
            }
            else if (function == "start")
            {
                try
                {
                    //Process.Start("C:/Users/nobat/Documents/Arma Drive/Arma 3 Apex/@dll/Proccess_DLL.exe");
                    Start_Service("Motion_SERVICE");
                    result = "Started";
                }
                catch (Exception ex)
                {
                    result = ex.ToString();
                }
            }
            else if(function == "stop")
            {
                try
                {
                    //Process.Start("C:/Users/nobat/Documents/Arma Drive/Arma 3 Apex/@dll/Proccess_DLL.exe");
                    Stop_Service("Motion_SERVICE");
                    result = "Stoped";
                }
                catch (Exception ex)
                {
                    result = ex.ToString();
                }
            }
            else
                result = "false";
            output.Append(result);
        }
        public static string Status_Service(string servicename)
        {
            // Toggle the service - 
            // If it is started (running, paused, etc), stop the service.
            // If it is stopped, start the service.
            sc = new ServiceController(servicename);
            //Console.WriteLine("The {0} service status is currently set to {1}", servicename, sc.Status.ToString());
            servicename =sc.Status.ToString();
            return servicename;
        }
        public static string Start_Service(string servicename)
        {
            sc = new ServiceController(servicename);
            try
            {
                sc.Start();
                // Refresh and display the current service status.
                sc.Refresh();
                servicename = sc.Status.ToString();
            }
            catch(Exception exp)
            {
                servicename = exp.ToString();
            }
            return servicename;
        }
        public static string Stop_Service(string servicename)
        {

            sc = new ServiceController(servicename);
            try
            {
                sc.Stop();
                // Refresh and display the current service status.
                sc.Refresh();
                servicename = sc.Status.ToString();
            }
            catch (Exception exp)
            {
                servicename = exp.ToString();
            }
            return servicename;
        }
    }
}
