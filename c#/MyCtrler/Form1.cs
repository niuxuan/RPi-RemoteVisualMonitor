using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using MyCtrler.Control;
using System.IO;
using System.Net;
using MyCtrler.model;

/*
 * By NiuXuan(左牧) QQ:79069622 
 */
namespace MyCtrler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SocketClient sc = null;

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIP.Text))
            {
                MessageBox.Show("请输入IP", "提示");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPort.Text))
            {
                MessageBox.Show("请输入端口", "提示");
                return;
            }

            string ip = txtIP.Text;
            int port = Int32.Parse(txtPort.Text);
            int sizemode = Int32.Parse("0" + ((SizeMode)cmbMode.SelectedItem).Value);

            if (sc == null)
            {
                sc = new SocketClient(ip, port);

                //连接成功
                string result = sc.ConnectToServer("windy", "123456", sizemode);

                if (result.Split('|')[0] == "success")
                {
                    SocketClient vClient = new SocketClient(ip, port);

                    result = vClient.StartListening(result.Split('|')[1], Run);
                    //启动视频画面监听
                    //ServerListen.StartListening(ReceiveHandle);

                    if (result.Split('|')[0] == "success")
                    {
                        btnConnect.Enabled = false;
                        btnDispose.Enabled = true;
                        txtIP.Enabled = false;
                        txtPort.Enabled = false;
                        cmbMode.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show(result, "提示");
                    sc.dispose();
                    sc = null;
                }
            }

            //启动视频画面监听
            //ServerListen.StartListening(ReceiveHandle);
        }

        private void Run(object vsc)
        {

            byte[] buffer;
            byte[] imgBuffer = new byte[] { };
            bool flag = false;
            int lastIndex = -1;
            while (true)
            {
                try
                {
                    buffer = ((SocketClient)vsc).client.Receive(ref ((SocketClient)vsc).remotePoint);

                    string strSumLen = Encoding.Default.GetString(buffer, 0, 5);
                    string strIndex = Encoding.Default.GetString(buffer, 5, 2);
                    int sumLen = Int32.Parse(strSumLen);
                    int index = Int32.Parse(strIndex);
                    int allIndex = sumLen % 1024 > 0 ? sumLen / 1024 + 1 : sumLen / 1024;

                    //若与上一包不连续，并且上一包未完全封装时
                    if (index != lastIndex + 1 && !flag)
                    {
                        //先打包上一包图片
                        Image img = ServerListen.ReadImage(imgBuffer);

                        this.picImage.Image = img;
                        imgBuffer = new byte[] { };

                        byte[] imgTemp = buffer.Skip(7).ToArray();

                        imgBuffer = imgTemp;

                        flag = false;
                    }
                    //else if (index > lastIndex + 1 && !flag)
                    //{
                    //    //填充丢失包
                    //    for (int i = 0; i < index - (lastIndex+1); i++)
                    //    {
                    //        byte[] imgEmpty = new byte[1024];

                    //        imgBuffer = imgBuffer.Concat(imgEmpty).ToArray();
                    //    }

                    //    byte[] imgTemp = buffer.Skip(7).ToArray();

                    //    imgBuffer = imgBuffer.Concat(imgTemp).ToArray();

                    //    if (index == allIndex)
                    //    {
                    //        Image img = ServerListen.ReadImage(imgBuffer);

                    //        this.picImage.Image = img;
                    //        imgBuffer = new byte[] { };
                    //        flag = true;
                    //    }
                    //    else
                    //    {
                    //        flag = false;
                    //    }
                    //}
                    else
                    {
                        byte[] imgTemp = buffer.Skip(7).ToArray();

                        imgBuffer = imgBuffer.Concat(imgTemp).ToArray();
                        if (index == allIndex)
                        {
                            Image img = ServerListen.ReadImage(imgBuffer);

                            this.picImage.Image = img;
                            imgBuffer = new byte[] { };
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                        }
                    }

                    lastIndex = index;
                }
                catch
                {
                    imgBuffer = new byte[] { };
                    lastIndex = -1;
                    flag = false;
                }
            }

        }

        delegate void ShowDistance(Label lbl, string dis);

        private void ShowDistanceText(Label lbl, string str)
        {
            if (lbl.InvokeRequired)
            {
                ShowDistance d = new ShowDistance(ShowDistanceText);
                lbl.Invoke(d, new object[] { lbl, str });
            }
            else
            {
                lbl.Text = str;
            }
        }

        private void btnDispose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void Dispose()
        {
            if (sc != null)
            {
                string strHostName = Dns.GetHostName();  //得到本机的主机名
                IPHostEntry ipEntry = Dns.GetHostByName(strHostName); //取得本机IP
                string strAddr = ipEntry.AddressList[0].ToString();
                //连接成功
                string result = sc.DisposeToServer();

                if (result.Split('|')[0] == "success")
                {
                    sc.dispose();
                    //ServerListen.listener.Dispose();
                    //ServerListen.thread.Abort();
                    //ServerListen.thread = null;
                    sc = null;
                    btnConnect.Enabled = true;
                    btnDispose.Enabled = false;
                    txtIP.Enabled = true;
                    txtPort.Enabled = true;
                    cmbMode.Enabled = true;
                }
                else
                {

                }
            }
        }

        private void btnAbsDispose_Click(object sender, EventArgs e)
        {
            if (sc != null)
            {
                string strHostName = Dns.GetHostName();  //得到本机的主机名
                IPHostEntry ipEntry = Dns.GetHostByName(strHostName); //取得本机IP
                string strAddr = ipEntry.AddressList[0].ToString();
                //连接成功
                string result = sc.Send("dispose:" + strAddr);

                if (result.Split('|')[0] == "success")
                {
                    sc.dispose();
                    ServerListen.listener.Dispose();
                    ServerListen.thread.Abort();
                    ServerListen.thread = null;
                    sc = null;
                    btnConnect.Enabled = true;
                    btnDispose.Enabled = false;
                    cmbMode.Enabled = true;
                }
                else
                {

                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void btnDispose_KeyUp(object sender, KeyEventArgs e)
        {
        }

        public void ControlCar(string cmd)
        {
            if (sc != null)
            {
                string strHostName = Dns.GetHostName();  //得到本机的主机名
                IPHostEntry ipEntry = Dns.GetHostByName(strHostName); //取得本机IP
                string strAddr = ipEntry.AddressList[0].ToString();
                //连接成功
                sc.sendto(cmd + ":" + strAddr);

            }
        }

        public char key = '0';

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (key != e.KeyChar)
            {
                key = e.KeyChar;
                switch (e.KeyChar.ToString().ToLower())
                {
                    case "w":

                        ControlCar("g-up");
                        break;
                    case "a":
                        ControlCar("g-left");
                        break;
                    case "s":

                        ControlCar("g-down");
                        break;
                    case "d":
                        ControlCar("g-right");
                        break;
                    case "j":
                        ControlCar("l-up");
                        break;
                    case "k":
                        ControlCar("l-left");
                        break;
                    case "l":
                        ControlCar("l-right");
                        break;
                    case ";":
                        ControlCar("l-down");
                        break;
                }

            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            key = '0';

            ControlCar("g-stop");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbMode.Items.Add(new SizeMode { Value = 0, Text = "流畅" });

            cmbMode.Items.Add(new SizeMode { Value = 1, Text = "清晰" });

            cmbMode.SelectedIndex = 0;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }

        /// <summary>
        /// 水平复位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCM_Click(object sender, EventArgs e)
        {
            ControlCar("c-m");
        }

        /// <summary>
        /// 垂直复位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDM_Click(object sender, EventArgs e)
        {
            ControlCar("d-m");
        }

        /// <summary>
        /// 云台左
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDU_MouseDown(object sender, MouseEventArgs e)
        {
            ControlCar("d-up");
        }

        /// <summary>
        /// 云台下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDD_MouseDown(object sender, MouseEventArgs e)
        {
            ControlCar("d-down");
        }

        /// <summary>
        /// 云台停
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDU_MouseUp(object sender, MouseEventArgs e)
        {
            ControlCar("d-s");
        }

        /// <summary>
        /// 云台左
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCL_MouseDown(object sender, MouseEventArgs e)
        {
            ControlCar("c-up");
        }

        /// <summary>
        /// 云台右
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCR_MouseDown(object sender, MouseEventArgs e)
        {
            ControlCar("c-down");
        }

        private void btnCL_MouseUp(object sender, MouseEventArgs e)
        {
            ControlCar("c-s");
        }

        /// <summary>
        /// 全灯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLU_Click(object sender, EventArgs e)
        {
            ControlCar("l-up");
        }

        /// <summary>
        /// 熄灯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLD_Click(object sender, EventArgs e)
        {
            ControlCar("l-down");
        }

        /// <summary>
        /// 左灯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLL_Click(object sender, EventArgs e)
        {
            ControlCar("l-left");
        }

        /// <summary>
        /// 右灯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLR_Click(object sender, EventArgs e)
        {
            ControlCar("l-right");
        }

        int mX = 0;
        int mY = 0;
        bool flag = false;

        private void picImage_MouseDown(object sender, MouseEventArgs e)
        {
            mX = e.Location.X;
            mY = e.Location.Y;
            flag = true;
        }

        private void picImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (flag)
            {
                int x = 0;
                int y = 0;

                int cx = -(e.Location.X - mX);
                int cy = -(e.Location.Y - mY);

                if (cx > 270)
                {
                    x = 150;
                }
                else if (cx < -180)
                {
                    x = 0;
                }
                else
                {
                    x = cx / 3 + 60;
                }

                if (cy > 345)
                {
                    y = 0;
                }
                else if (cy < -195)
                {
                    y = 180;
                }
                else
                {
                    y = -cy / 3 + 115;
                }

                if (x % 5 == 0)
                {
                    ControlCar("c-c:" + x);
                }

                if (y % 5 == 0)
                {
                    ControlCar("d-c:" + y);
                }
            }
        }

        private void picImage_MouseUp(object sender, MouseEventArgs e)
        {
            mX = 0;
            mY = 0;
            flag = false;
            ControlCar("d-m");
            ControlCar("c-m");
        }
    }
}
