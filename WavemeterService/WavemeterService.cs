//WavemeterService A Windows service for sharing Wavelengths information in a network
//Copyright (C) 2021  Matteo Mazzanti

//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License
//along with this program.  If not, see <https://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Timers;
using System.Configuration;
using System.Collections.Specialized;

//Libraries for network communication
using System.Net;
using System.Net.Sockets;

//JSON library
using Newtonsoft.Json;


namespace WavemeterService
{
    public partial class WavemeterService : ServiceBase
    {
        //PUBLIC VARS
        public enum ServiceState
        {
            SERVICE_STOPPED = 0x00000001,
            SERVICE_START_PENDING = 0x00000002,
            SERVICE_STOP_PENDING = 0x00000003,
            SERVICE_RUNNING = 0x00000004,
            SERVICE_CONTINUE_PENDING = 0x00000005,
            SERVICE_PAUSE_PENDING = 0x00000006,
            SERVICE_PAUSED = 0x00000007,
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ServiceStatus
        {
            public int dwServiceType;
            public ServiceState dwCurrentState;
            public int dwControlsAccepted;
            public int dwWin32ExitCode;
            public int dwServiceSpecificExitCode;
            public int dwCheckPoint;
            public int dwWaitHint;
        };

        [DllImport("advapi32.dll", SetLastError = true)]

        // ----- LOAD USEFUL WAVEMETER FUNCTIONS FROM THE wlmData.dll ----- //
        private static extern bool SetServiceStatus(System.IntPtr handle, ref ServiceStatus serviceStatus);
        [DllImport("lib/wlmData.dll")]
        public static extern long Instantiate(long RFC, long Mode, long P1, long P2);
        [DllImport("lib/wlmData.dll")]
        public static extern double GetFrequencyNum(long channel, int res = 0);
        [DllImport("lib/wlmData.dll")]
        public static extern long GetAnalysisItemSize(long index);
        [DllImport("lib/wlmData.dll")]
        public static extern long GetAnalysisItemCount(long index);
        [DllImport("lib/wlmData.dll")]
        public static extern long GetPatternItemSize(long index);
        [DllImport("lib/wlmData.dll")]
        public static extern long GetPatternItemCount(long index);
        [DllImport("lib/wlmData.dll")]
        public static extern long GetPatternDataNum(long Chn, long Index, IntPtr PArray);
        [DllImport("lib/wlmData.dll")]
        public static extern long SetPattern(long Index, long iEnable);
        // ----- ENF OF LOAD USEFUL WAVEMETER FUNCTIONS FROM THE wlmData.dll ----- //

        //Array of objects of WMChannel type
        private WMChannel[] WMDATA;

        //Network handler, this will take care of sending packages on the network
        private NetworkUtils NetworkHandler;


        public WavemeterService(string[] args)
        {
            InitializeComponent();
            string eventSourceName = "WavemeterServie";
            string logName = "WavemeterServiceLog";
            if (args.Length > 0)
            {
                eventSourceName = args[0];
            }

            if (args.Length > 1)
            {
                logName = args[1];
            }
            eventLog1 = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists(eventSourceName))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    eventSourceName, logName);
            }
            eventLog1.Source = eventSourceName;
            eventLog1.Log = logName;
            
        }

        public void OnTimer(object sender, ElapsedEventArgs args)
        {
            // TODO: Insert monitoring activities here.
            //eventLog1.WriteEntry("Sending Wavemeter Data", EventLogEntryType.Information, eventId++);
            for (int i = 0; i < 9; i++)
            {
                double Freq = GetFrequencyNum(i + 1, 0);
                WMDATA[i].Frequency = Freq;
                WMDATA[i].SetPatternSize(GetPatternItemCount(Globals.cSignal1Grating), GetPatternItemSize(Globals.cSignal1Grating));
                //WMDATA.SetWL(i,WL);

                if (WMDATA[i].GetPatternSize() > 0)
                {
                    GetPatternDataNum(i + 1, Globals.cSignal1Grating, WMDATA[i].GetPatternPtr());
                    WMDATA[i].SetPatternDataFromPtr();

                    //Debugging
                    /*for (int el = 0; el < WMDATA[i].GetPatternItemCnt(); el++)
                    {
                       Console.WriteLine(Marshal.ReadIntPtr(WMDATA[i].Patternhglobal, el * (int)WMDATA[i].GetPatternItemSize()));
                    }*/
                }
            }
            byte[] data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(WMDATA));
            //eventLog1.WriteEntry("Sending following data : " + data, EventLogEntryType.Information, eventId++);
            NetworkHandler.SendPayload(data);
            //Debugging... change BroadcastAddresses to private
            //foreach (IPAddress IPaddr in NetworkHandler.BroadcastAddresses)
            //{
            //    eventLog1.WriteEntry("Sending following data to : " + IPaddr.ToString(), EventLogEntryType.Information, eventId++);
            //}
            
        }

        protected override void OnStart(string[] args)
        {
            // Update the service state to Start Pending.
            ServiceStatus serviceStatus = new ServiceStatus();
            serviceStatus.dwCurrentState = ServiceState.SERVICE_START_PENDING;
            serviceStatus.dwWaitHint = 100000;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);

            //Logging
            eventLog1.WriteEntry("Wavemeter service Started.");

            
            var from = new IPEndPoint(0, 0);

            //Initialize Wavemeter Channels objects (1 per channel)
            WMDATA = new WMChannel[9];
            for (int i = 0; i < 9; i++)
            {
                WMDATA[i] = new WMChannel();
                WMDATA[i].Channel = i + 1;
            }

            SetPattern(Globals.cSignal1Grating, Globals.cPatternEnable); //Enable the loading of the pattern array in memory
            
            //Initialize a new network handler
            NetworkHandler = new NetworkUtils(ConfigurationManager.AppSettings.Get("InterfaceName"));

            // Set up a timer that triggers every minute.
            Timer timer = new Timer();
            timer.Interval = Convert.ToDouble(ConfigurationManager.AppSettings.Get("RefreshRate")); // # of seconds to wait
            timer.Elapsed += new ElapsedEventHandler(this.OnTimer);
            timer.Start();

            // Update the service state to Running.
            serviceStatus.dwCurrentState = ServiceState.SERVICE_RUNNING;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("WavemeterService stopped.");

        }

        private void eventLog1_EntryWritten(object sender, EntryWrittenEventArgs e)
        {

        }
    }
}
