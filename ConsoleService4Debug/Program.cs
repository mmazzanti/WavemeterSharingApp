using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsoleService4Debug
{
    class Program
    {
        [DllImport("wlmData.dll")]
        public static extern long Instantiate(long RFC, long Mode, long P1, long P2);
        [DllImport("wlmData.dll")]
        public static extern double GetWavelength(double WL);

        static void Main(string[] args)
        {
            int PORT = 9898;
            WMChannel[] WMDATA = new WMChannel[9];
            for (int i = 0; i < 9; i++)
            {
                WMDATA[i] = new WMChannel();
            }
            UdpClient udpClient = new UdpClient();
            udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, PORT));
            Console.WriteLine(IPAddress.Any);
            var from = new IPEndPoint(0, 0);

            Task.Run(() =>
            {
                while (true)
                {
                    var recvBuffer = udpClient.Receive(ref from);
                    Console.WriteLine(Encoding.UTF8.GetString(recvBuffer));
                }
            });
            var data = Encoding.UTF8.GetBytes("ABCD");
            udpClient.Send(data, data.Length, "255.255.255.255", PORT); //IMPORTANT!! CHANGE THIS TO THE SUBNET BROADCAST ADDRESS (10.10.12.255) THE ROUTERS DON'T FORWARD 255.255.255.255

            long WMAPI = Instantiate(1, 2, 3, 4);
            Console.WriteLine(WMAPI);
            for(int i = 0; i<9; i++)
            {
                double WL = GetWavelength(i);
                WMDATA[i].Channel = i+1;
                WMDATA[i].Wavelength = WL;
                //WMDATA.SetWL(i,WL);
            }
            //WMDATA.TemperatureCelsius= 1;
            //WMDATA.Wavelengths[1] = 20;
            //Console.WriteLine(WMDATA.GetWL(1));
            Console.WriteLine(JsonSerializer.Serialize(WMDATA));
            Console.ReadLine();
            Console.ReadKey();

        }
    }
}
