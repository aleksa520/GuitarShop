using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        private Socket listener;

        public bool StartServer()
        {
            try
            {
                listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                listener.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9090));
                listener.Listen(5);
                return true;

            }
            catch (SocketException)
            {
                return false;
            }
        }

        public void StartListening()
        {
            bool end = false;

            while (!end)
            {
                Socket clientSocket = listener.Accept();
                ClientHandler client = new ClientHandler(clientSocket);
                Thread clientThread = new Thread(client.RequestHandler);
                clientThread.Start();
            }
        }
    }
}
