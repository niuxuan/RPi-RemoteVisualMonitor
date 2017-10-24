using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

/*
 * By NiuXuan(左牧) QQ:79069622 
 */
namespace MyCtrler.Control
{
    public class SocketClient
    {

        public UdpClient client;
        Socket sender = null;
        string ip = string.Empty;
        int port = 0;
        IPEndPoint hostPoint = null;
        public IPEndPoint remotePoint = null;

        private Thread listenThread;

        public SocketClient(string ipP, int portP)
        {
            ip = ipP;
            port = portP;
            remotePoint = new IPEndPoint(IPAddress.Any, 0);
            IPAddress ipAddress = IPAddress.Parse(ip);
            hostPoint = new IPEndPoint(ipAddress, port);
            client = new UdpClient();
        }

        public string StartListening(string key, Action<object> action)
        {
            string result = string.Empty;
            try
            {
                byte[] buffer = Encoding.Default.GetBytes("video:" + key);

                client.Send(buffer, buffer.Length, hostPoint);

                // 接受服务器的登录应答消息

                buffer = client.Receive(ref remotePoint);

                result = Encoding.Default.GetString(buffer);

                if (result.Split('|')[0] == "success")
                {
                    listenThread = new Thread(new ParameterizedThreadStart(action));

                    listenThread.Start(this);
                }
            }
            catch { }

            return result;
        }

        public string ConnectToServer(string userName, string password, int sizemode)
        {
            try
            {
                byte[] buffer = Encoding.Default.GetBytes("connect:" + sizemode);
                
                client.Send(buffer, buffer.Length, hostPoint);

                // 接受服务器的登录应答消息
                buffer = client.Receive(ref remotePoint);

                // 更新用户列表
                return Encoding.Default.GetString(buffer);
            }
            catch
            {
                return "服务端暂未开启，连接失败";
            }
        }

        public string DisposeToServer()
        {
            try
            {
                byte[] buffer = Encoding.Default.GetBytes("dispose:");

                client.Send(buffer, buffer.Length, hostPoint);

                // 接受服务器的登录应答消息

                buffer = client.Receive(ref remotePoint);

                // 更新用户列表
                return Encoding.Default.GetString(buffer);
            }
            catch
            {
                return "通信异常，释放失败，请关闭控制端重新打开";
            }
        }

        public void sendto(string msgStr)
        {
            try
            {
                try
                {
                    byte[] buffer = Encoding.Default.GetBytes(msgStr);

                    client.Send(buffer, buffer.Length, hostPoint);

                    // 接受服务器的登录应答消息

                    //buffer = client.Receive(ref remotePoint);
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        public string Send(string msgStr)
        {
            // Data buffer for incoming data.
            byte[] bytes = new byte[1024];
            string result = string.Empty;
            // Connect to a remote device.
            try
            {
                // Establish the remote endpoint for the socket.
                // This example uses port 11000 on the local computer.
                //IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());

                // Create a TCP/IP  socket.

                //IPAddress ipAddress = IPAddress.Parse(ip);
                //remoteEP = new IPEndPoint(ipAddress, port);
                //sender = new Socket(AddressFamily.InterNetwork,
                //        SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.
                try
                {

                    // Encode the data string into a byte array.
                    byte[] msg = Encoding.ASCII.GetBytes(msgStr);

                    // Send the data through the socket.
                    int bytesSent = sender.Send(msg, msg.Length, SocketFlags.None);

                    // Receive the response from the remote device.
                    int bytesRec = sender.Receive(bytes);

                    result = Encoding.ASCII.GetString(bytes, 0, bytesRec);

                    //sender.Shutdown(SocketShutdown.Both);
                    //sender.Close();
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return result;
        }

        public void dispose()
        {
            if (client != null)
            {
                // Release the socket.
                client.Close();
                client = null;

            }
        }

    }
}
