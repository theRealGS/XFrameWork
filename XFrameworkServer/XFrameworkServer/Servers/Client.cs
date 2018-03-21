using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace XFrameworkServer.Servers
{
    /// <summary>
    /// 客户端类
    /// 用于存储连接到服务器的客户端 接收、发送消息
    /// </summary>
    class Client
    {
        private Socket m_socket;

        public Client() { }
        public Client(Socket clientSocket)
        {
            this.m_socket = clientSocket;
        }
        byte[] datas;
        /// <summary>
        /// 开始接收客户端传入的数据
        /// 1.接收消息
        /// 2.解析数据
        /// 3.处理数据
        /// 4.响应客户端
        /// </summary>
        public void Start()
        {
            if (m_socket == null || m_socket.Connected == false) return;
            m_socket.BeginReceive(datas, 0, 1024, SocketFlags.None, ReceiveCallback, null);
        }

        private void ReceiveCallback(IAsyncResult ar)
        {

        }
    }
}
