using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
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
            try
            {
                this.port = port;
                this.ipAddress = ipAddress;
                this.client = new TcpClient(ipAddress, port);
                this.stream = client.GetStream();
            }
            catch
            {
                client = null;
                stream = null;
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
                        this.client = new TcpClient(ipAddress, port);
                        this.stream = client.GetStream();
                    }
                    catch
                    {
                        client = null;
                        stream = null;
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
    }
}
