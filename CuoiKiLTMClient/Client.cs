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

namespace CuoiKiLTMClient
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        Socket sckClient = null;
        byte[] data = new byte[1024];
        int n;
        private void butConnect_Click(object sender, EventArgs e)
        {
            if (sckClient != null)
            {
                sckClient.Close();
            }
            sckClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint clientEP = new IPEndPoint(IPAddress.Parse(txtServerIP.Text), (int)numPort.Value);
            sckClient.BeginConnect(clientEP, new AsyncCallback(xulyketnoi), null);
            lbStatus.Text = "Dang ket noi den Server...";
        }

        private void xulyketnoi(IAsyncResult result)
        {
            sckClient.EndConnect(result);
            lbStatus.Invoke(new CapNhatGiaoDien(CapNhatTrangThai), new object[] { "Ket noi thanh cong" });
            sckClient.BeginReceive(data, 0, data.Length, SocketFlags.None, new AsyncCallback(xulydulieu), null);
        }
        
        void xulydulieu(IAsyncResult result)
        {
            n = sckClient.EndReceive(result);
            string msg = Encoding.ASCII.GetString(data, 0, n);
            txtBox.Invoke(new CapNhatGiaoDien(CapNhatNoiDungChat), new object[] { "Server :" + msg });
            sckClient.BeginReceive(data, 0, data.Length, SocketFlags.None, new AsyncCallback(xulydulieu), null);

        }
        delegate void CapNhatGiaoDien(string s);
        void CapNhatTrangThai(string s)
        {
            lbStatus.Text = s;

        }
     
        void CapNhatNoiDungChat(string s)
        {
            txtBox.Text += s + "\r\n";
        }

        private void butSend_Click(object sender, EventArgs e)
        {
            sckClient.Send(Encoding.ASCII.GetBytes(txtMessage.Text));
            CapNhatNoiDungChat("Client: " + txtMessage.Text);
            txtMessage.Text = "";
        }
        private void txtServerIP_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void Online_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numPort_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lbStatus_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbPort_Click(object sender, EventArgs e)
        {

        }

        private void txtBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
