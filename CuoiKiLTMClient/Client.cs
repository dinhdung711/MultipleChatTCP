using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace CuoiKiLTMClient
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }
        List<ClientInfo> sck = new List<ClientInfo>();
        Socket sckClient = null;
         
    
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
            Login frm = new Login();
            frm.ShowDialog();
            ClientInfo info = new ClientInfo();
            info.sckInfo = sckClient;
            info.data = new byte[1024];
            string username = "";
            try
            {
                username = frm.Username;
                string login = "login|" + username;
                info.sckInfo.Send(Encoding.ASCII.GetBytes(login));
            }
            catch (SocketException)
            {
                info.sckInfo.Close();
            }
            lbStatus.Invoke(new CapNhatGiaoDien(CapNhatTrangThai), new object[] { "Ket noi thanh cong" });
            lbName.Invoke(new CapNhatGiaoDien(CapNhatTen), new object[] { username });
            sckClient.BeginReceive(info.data, 0, info.data.Length, SocketFlags.None, new AsyncCallback(xulydulieu), info);
            

        }
        
        void xulydulieu(IAsyncResult result)
        {

            //var info = result.AsyncState as ClientInfo;
            ClientInfo info = (ClientInfo)result.AsyncState;
            if (info == null) 
                return;
            try
            {
                int receive = info.sckInfo.EndReceive(result);
                if (receive == 0)
                {
                    info.sckInfo.Close();
                    return;
                }
                string msg = Encoding.ASCII.GetString(info.data, 0, receive);
                xulitinnhan(info, msg);
                 
                info.sckInfo.BeginReceive(info.data, 0, info.data.Length, SocketFlags.None, new AsyncCallback(xulydulieu), info);
                
            }
            catch (SocketException)
            {
                info.sckInfo.Close();
            }

        }
        void xulitinnhan(ClientInfo sender, string msg)
        {
            string[] part = msg.Split('|');
            if (part.Length == 0) return;
            if (part[0] == "online")
            {
                updateOnline(part[1]);
            }
            else if (part[0] == "msg"&& part.Length >= 3)
            {
                string from = part[1];
                string content = part[2];
                txtBox.Invoke(new CapNhatGiaoDien(CapNhatNoiDungChat),new object[]{from + ": " + content});                           
            }
        }

        delegate void CapNhatGiaoDien(string s);
        void CapNhatTrangThai(string s)
        {
            lbStatus.Text = s;

        }
        void CapNhatTen(string s)
        {
            lbName.Text = s;
        }
        void CapNhatNoiDungChat(string s)
        {
            txtBox.Text += s + "\r\n";
        }

        private void butSend_Click(object sender, EventArgs e)
        {
            
            if (SelectedUser == "")
            {
                MessageBox.Show(
                    "Vui lòng chọn người nhận");
                return;
            }
            string packet ="msg|" +SelectedUser + "|" +txtMessage.Text;
            sckClient.Send( Encoding.ASCII.GetBytes(packet));
            CapNhatNoiDungChat("Me: " + txtMessage.Text);
            txtMessage.Clear();    
        }
      
        string SelectedUser = "";
        private void Online_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (Online.SelectedItem != null)
            {
                SelectedUser = Online.SelectedItem.ToString();
                lbUser.Text =SelectedUser;
            }
            MessageBox.Show(SelectedUser);
            //txtBox.Clear();
        }
        
   
        void updateOnline(string users)
        {
            Online.Invoke(new Action(() =>
            {
                Online.Items.Clear();

                string[] ds = users.Split(',');
                foreach (string user in ds)
                {
                    if (user.Trim() != "")
                    {
                        Online.Items.Add(user);
                    }
                }
            }));
        }

        
        void CapNhatNguoiDung(string s)
        {
            lbUser.Text = s;
        } 
        private void txtMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                butSend_Click(sender, e);
            }
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

        private void lbUser_Click(object sender, EventArgs e)
        {

        }

        private void butFile_Click(object sender, EventArgs e)
        {

        }

        private void butExit_Click(object sender, EventArgs e)
        {
            sckClient.Close();
            this.Close();
        }
    }
}
