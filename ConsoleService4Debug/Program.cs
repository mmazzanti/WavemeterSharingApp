using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
//using System.Text.Json;
//using System.Text.Json.Serialization;

namespace ConsoleService4Debug
{
    class Program
    {
        [DllImport("wlmData.dll")]
        public static extern long Instantiate(long RFC, long Mode, long P1, long P2);
        [DllImport("wlmData.dll")]
        public static extern double GetFrequencyNum(long channel, int res=0);
        [DllImport("wlmData.dll")]
        public static extern long GetAnalysisItemSize(long index);
        [DllImport("wlmData.dll")]
        public static extern long GetAnalysisItemCount(long index);
        [DllImport("wlmData.dll")]
        public static extern long GetPatternItemSize(long index);
        [DllImport("wlmData.dll")]
        public static extern long GetPatternItemCount(long index);
        [DllImport("wlmData.dll")]
        public static extern long GetPatternDataNum(long Chn, long Index, IntPtr PArray);
        [DllImport("wlmData.dll")]
        public static extern long SetPattern(long Index, long iEnable);
        static void Main(string[] args)
        {
            int PORT = 9898;
            UdpClient udpClient = new UdpClient();
            udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, PORT));
            //Console.WriteLine(IPAddress.Any); Debugging
            var from = new IPEndPoint(0, 0);
            /* //Listening task, will be used if one wants to remote control the WM
            Task.Run(() =>
            {
                while (true)
                {
                    var recvBuffer = udpClient.Receive(ref from);
                    Console.WriteLine(Encoding.UTF8.GetString(recvBuffer));
                }
            });*/

            WMChannel[] WMDATA = new WMChannel[9];
            for (int i = 0; i < 9; i++)
            {
                WMDATA[i] = new WMChannel();
                WMDATA[i].Channel = i + 1;
            }

            SetPattern(Globals.cSignal1Grating, Globals.cPatternEnable); //Enable the loading of the pattern array in memory
            for (int looping = 0; looping < 100; looping++){
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

                        /*for (int el = 0; el < WMDATA[i].GetPatternItemCnt(); el++)
                        {
                           Console.WriteLine(Marshal.ReadIntPtr(WMDATA[i].Patternhglobal, el * (int)WMDATA[i].GetPatternItemSize()));
                        }*/
                    }
                }
                var data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(WMDATA));
                udpClient.Send(data, data.Length, "255.255.255.255", PORT); //IMPORTANT!! CHANGE THIS TO THE SUBNET BROADCAST ADDRESS (10.10.12.255) THE ROUTERS DON'T FORWARD 255.255.255.255
                Console.WriteLine("Packet sent");
            }



            //long WMAPI = Instantiate(1, 2, 3, 4);
            //Console.WriteLine(WMAPI);


            //Console.WriteLine(GetPatternItemSize(Globals.cSignal1Grating));
            //Console.WriteLine(GetPatternItemCount(Globals.cSignal1Grating));
            //WMDATA[1].SetPatternSize(GetPatternItemCount(Globals.cSignal1Grating), GetPatternItemSize(Globals.cSignal1Grating));
            /*
            int temp = 0;
            for (int el = 0; el < WMDATA[6].GetPatternItemCnt();)
            {

                temp = Marshal.ReadByte(WMDATA[6].GetPatternPtr(), el) | Marshal.ReadByte(WMDATA[6].GetPatternPtr(), el + 1) << 8;
                el += 2;
                Console.WriteLine(temp);
            }*/
            //WMDATA.TemperatureCelsius= 1;
            //WMDATA.Wavelengths[1] = 20;
            //Console.WriteLine(WMDATA.GetWL(1));
            //Console.WriteLine(JsonConvert.SerializeObject(WMDATA));
            
            //Console.WriteLine(JsonSerializer.Serialize(WMDATA));
            //Console.ReadLine();
            //Console.ReadKey();

        }
    }
}
