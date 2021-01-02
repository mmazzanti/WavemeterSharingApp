using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Diagnostics;
using System.Threading;

namespace Wavemeter_SVC_Manager
{
    class Service
    {
        private ServiceController sc;
        public Service() //Constructor ? bit useless ?
        { 
        }

        ~Service()  // Destructor, useless?
        {
            // what to do at the cleanup ?
        }

        public ServiceControllerStatus SVCStatus() 
        {
            sc.Refresh();
            return sc.Status;
        }

        public void LoadServiceInfo()
        {
            ServiceController[] scServices;
            scServices = ServiceController.GetServices();
            int found = 0; // Bit to check that the service is actually installed
            foreach (ServiceController scTemp in scServices)
            {
                if (scTemp.ServiceName == "WavemeterService")
                {
                    // Display properties for the Simple Service sample
                    // from the ServiceBase example.
                    sc = new ServiceController("WavemeterService");
                    //Console.WriteLine("Status = " + sc.Status);
                    //Console.WriteLine("Can Pause and Continue = " + sc.CanPauseAndContinue);
                    //Console.WriteLine("Can ShutDown = " + sc.CanShutdown);
                    //Console.WriteLine("Can Stop = " + sc.CanStop);
                    found = 1;
                }
            }
            if (found == 0)
            {

                throw new ServiceNotInstalled();
                //Application.Exit();  //DEPRECATED now inside a throw catch
            }

        }
        public void SVCStop()
        {
            try { sc.Stop(); }
            catch(Exception e) {
                throw e;
            }
        }
        public void SVCRestart()
        {
            sc.Refresh();
            string svcStatus = sc.Status.ToString();
            try 
            {
                sc.Refresh();
                svcStatus = sc.Status.ToString();
                if (svcStatus != "Stopped")
                {
                    sc.Stop();
                }
                while (svcStatus != "Stopped")
                {
                    sc.Refresh();
                    svcStatus = sc.Status.ToString();
                }
                sc.Start();
                }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void SVCStart()
        {
            try { sc.Start(); }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
    [Serializable]
    class ServiceNotInstalled : Exception
    {
        public ServiceNotInstalled()
        {

        }

        public ServiceNotInstalled(string message)
            : base(message)
        {

        }

    }
}
