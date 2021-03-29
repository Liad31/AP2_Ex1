using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
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
            this.client = new TcpClient(ipAddress, port);
            this.stream = client.GetStream();
        }

        public void sendString(String str)
        {
            stream.Write(Encoding.ASCII.GetBytes(str), 0, str.Length);
            stream.Flush();
        }

        public void close()
        {
            client.Close();
        }
    }
}
