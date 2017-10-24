using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

/*
 * By NiuXuan(左牧) QQ:79069622 
 */
namespace MyCtrler
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
