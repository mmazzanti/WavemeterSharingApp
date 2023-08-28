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
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WavemeterService
{
    class NetworkUtils
    {
        private List<IPAddress> BroadcastAddresses;
        //UDP Client for sending data
        private UdpClient udpClient;
        private int PORT = 9898;
        public NetworkUtils(string interfacename)
        {
            //Initialize ports and udpclient
            udpClient = new UdpClient();
            udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, PORT));
            BroadcastAddresses = new List<IPAddress>();
            GetIPBroadcast(interfacename);
        }

        private void GetIPBroadcast(string interfacename)
        {
            foreach (var netInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (netInterface.Supports(NetworkInterfaceComponent.IPv4) && netInterface.Name == interfacename)
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

        public void SendPayload(byte[] data)
        {
            foreach (IPAddress IPaddr in BroadcastAddresses)
            {
                udpClient.Send(data, data.Length, IPaddr.ToString(), PORT); //IMPORTANT!! (DONE) CHANGE THIS TO THE SUBNET BROADCAST ADDRESS (10.10.12.255) THE ROUTERS DON'T FORWARD 255.255.255.255
                
                //Debugging
                //Console.WriteLine("Packet sent to :" + IPaddr.ToString());
                //Console.WriteLine(num);
            }
        }
    }
}
