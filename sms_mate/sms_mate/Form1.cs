using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sms_mate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        public static string GetMyIP
        {
            get
            {
                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
                string ClientIP = string.Empty;
                for (int i = 0; i < host.AddressList.Length; i++)
                {
                    if (host.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        ClientIP = host.AddressList[i].ToString();
                    }
                }
                return ClientIP;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblMyIP.Text = GetMyIP;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            AsynchronousSocketListener.StartListening();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            AsynchronousSocketListener.Stop();
        }
    }
}
