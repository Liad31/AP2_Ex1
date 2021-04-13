using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Net.NetworkInformation;

namespace AP2_Ex1
{
    class Client
    {
        private String ipAddress;
        private int port;
        private TcpClient client;
        private NetworkStream stream;

        public Client(String ipAddress, int port)
        {
            this.port = port;
            this.ipAddress = ipAddress;
            if (PortInUse(port))
            {
                try
                {

                    this.client = new TcpClient(ipAddress, port);
                    this.stream = client.GetStream();
                }
                catch
                {
                    client = null;
                    stream = null;
                }
            }
        }
        public void sendString(String str)
        {
            if (client == null)
            {
                Task initClient = new Task(() =>
                {
                    try
                    {
                        if (PortInUse(port))
                        {
                            this.client = new TcpClient(ipAddress, port);
                            this.stream = client.GetStream();
                        }
                    }
                    catch
                    {
                        return;
                    }
                });
                initClient.Start();
                return;
            }
            try
            {
                stream.Write(Encoding.ASCII.GetBytes(str), 0, str.Length);
                stream.Flush();
            }
            catch
            {
                client = null;
                stream = null;
            }
        }

        public void close()
        {
            if (client != null)
            {
                client.Close();
            }
        }

        /// <summary>
        /// checks if someone listens to given port
        /// </summary>
        /// <param name="port">port number we want to check</param>
        /// <returns>true is someone is listening</returns>
        public static bool PortInUse(int port)
        {
            bool inUse = false;

            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] ipEndPoints = ipProperties.GetActiveTcpListeners();


            foreach (IPEndPoint endPoint in ipEndPoints)
            {
                if (endPoint.Port == port)
                {
                    inUse = true;
                    break;
                }
            }


            return inUse;
        }
    }
}
