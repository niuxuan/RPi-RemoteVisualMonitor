using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Drawing.Imaging;

/*
 * By NiuXuan(左牧) QQ:79069622 
 */
namespace MyCtrler.Control
{
    public class ServerListen
    {
        private static EndPoint RemotePoint;
        public static string data = null;

        public static Socket listener;

        public static Thread thread = null;
        public static void StartListening(Action action)
        {
            //启动本地IP
            string strHostName = Dns.GetHostName();  //得到本机的主机名
            IPHostEntry ipEntry = Dns.GetHostByName(strHostName); //取得本机IP
            string strAddr = ipEntry.AddressList[0].ToString();
            IPAddress ipAddress = IPAddress.Parse(strAddr);
            //IPAddress ipAddress = new IPAddress(new byte[] { 192, 168, 7, 105 });
            //IPAddress ipAddress = new IPAddress(new byte[] { 127, 0, 0, 1 });
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 12345);

            listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Dgram, ProtocolType.Udp);

            try
            {
                //绑定网络地址  
                listener.Bind(localEndPoint);
                
                //listener.ReceiveBufferSize = 80000;
                RemotePoint = (EndPoint)localEndPoint;
                thread = new Thread(new ThreadStart(action));
                thread.Start();  
            }
            catch { }
        }


        public static Image ReadImage(byte[] bytes)
        {
            Image image = null;
            using (MemoryStream DataStream = new MemoryStream(bytes))
            {
                DataStream.Write(bytes, 0, bytes.Length);
                image = new Bitmap((Image)new Bitmap(DataStream));
                return image;
            }
        }
    }
}
