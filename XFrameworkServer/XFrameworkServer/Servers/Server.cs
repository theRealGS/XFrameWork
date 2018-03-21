using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace XFrameworkServer.Servers
{
    /// <summary>
    /// 服务器主类
    /// 接受通信
    /// </summary>
    class Server
    {
        private IPEndPoint m_IPEndPoint;
        private Socket m_serverSocket;

        public Server() { }


        /// <summary>
        /// 传入IP和端口号即可构造
        /// </summary>
        /// <param name="ipStr"></param>
        /// <param name="port"></param>
        public Server(string ipStr, int port)
        {
            SetIPEndPoint(ipStr, port);
        }

        public void SetIPEndPoint(string ipstr, int port)
        {
            m_IPEndPoint = new IPEndPoint(IPAddress.Parse(ipstr), port);
        }

        /// <summary>
        /// 开启TCP服务,开始监听客户端连接
        /// </summary>
        public void StartServer()
        {
            m_serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            if(m_IPEndPoint == null)
            {
                SetIPEndPoint("127.0.0.1", 8809);
            }
            m_serverSocket.Bind(m_IPEndPoint);
            m_serverSocket.Listen(0);
            m_serverSocket.BeginAccept(AcceptCallBack, null);
        }

        /// <summary>
        /// 接收客户端请求
        /// </summary>
        /// <param name="ar"></param>
        private void AcceptCallBack(IAsyncResult ar)
        {
            Socket clientSocket = m_serverSocket.EndAccept(ar);
            m_serverSocket.BeginAccept(AcceptCallBack, null);
        }
    }
}
