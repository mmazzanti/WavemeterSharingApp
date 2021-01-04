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
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
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
        [DllImport("lib/wlmData.dll")]
        public static extern long Instantiate(long RFC, long Mode, long P1, long P2);
        [DllImport("lib/wlmData.dll")]
        public static extern double GetFrequencyNum(long channel, int res=0);
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

        private static List<IPAddress> BroadcastAddresses = new List<IPAddress>();

        private static void GetIPBroadcast()
        {
            foreach (var netInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (netInterface.Supports(NetworkInterfaceComponent.IPv4) && netInterface.Name=="Local Area Connection" )
                {
                    foreach (var unicast in netInterface.GetIPProperties().UnicastAddresses)
                    {
                        if ((unicast.Address.AddressFamily != AddressFamily.InterNetwork) || (IPAddress.IsLoopback(unicast.Address) == true)) { continue; }
                        var address = unicast.Address;
                        var mask = unicast.IPv4Mask;
                        var addressInt = BitConverter.ToInt32(address.GetAddressBytes(), 0);
                        var maskInt = BitConverter.ToInt32(mask.GetAddressBytes(), 0);
                        var broadcastInt = addressInt | ~maskInt;
                        var broadcastAddress = new IPAddress(BitConverter.GetBytes(broadcastInt));
                        //Console.WriteLine(string.Format("{0,16} {1,16} {2,20}", address, mask, broadcastAddress));
                        BroadcastAddresses.Add(broadcastAddress);
                    }
                }
            }

        }
        static void Main(string[] args)
        {
            int PORT = 9898;

            UdpClient udpClient = new UdpClient();
            udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, PORT));
            //Console.WriteLine(IPAddress.Any); Debugging
            //var from = new IPEndPoint(0, 0);
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
            Console.WriteLine(IPAddress.Broadcast);

            SetPattern(Globals.cSignal1Grating, Globals.cPatternEnable); //Enable the loading of the pattern array in memory
            for (int looping = 0; looping < 100; looping++) {
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
                GetIPBroadcast();
                foreach (IPAddress IPaddr in BroadcastAddresses)
                {
                    udpClient.Send(data, data.Length, IPaddr.ToString(), PORT); //IMPORTANT!! CHANGE THIS TO THE SUBNET BROADCAST ADDRESS (10.10.12.255) THE ROUTERS DON'T FORWARD 255.255.255.255
                    Console.WriteLine("Packet sent to :" + IPaddr.ToString());
                    //Console.WriteLine(num);
                }
                //udpClient.Send(data, data.Length, "10.10.12.255", PORT); //IMPORTANT!! CHANGE THIS TO THE SUBNET BROADCAST ADDRESS (10.10.12.255) THE ROUTERS DON'T FORWARD 255.255.255.255
                //Console.WriteLine("Packet sent");
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
