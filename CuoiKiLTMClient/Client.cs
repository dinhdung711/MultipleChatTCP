using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
    
        Socket sckClient = null;
        string myName = "";


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
            
            try
            {
                myName = frm.Username;
                string login = "login|" + myName; 
                info.sckInfo.Send(Encoding.UTF8.GetBytes(login));
            }
            catch (SocketException)
            {
                info.sckInfo.Close();
            }
            lbStatus.Invoke(new CapNhatGiaoDien(CapNhatTrangThai), new object[] { "Ket noi thanh cong" });
            //lbName.Invoke(new CapNhatGiaoDien(CapNhatTen), new object[] { myName });
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
                string msg = Encoding.UTF8.GetString(info.data, 0, receive);
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
            if (msg == "loginfail")
            {
                MessageBox.Show("Tên đã tồn tại, vui lòng nhập tên khác.");

                Login frm = new Login();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    myName = frm.Username;

                    string login = "login|" + myName;

                    sckClient.Send(
                        Encoding.UTF8.GetBytes(login));
                }
            }
            if (msg == "loginok")
            {
                lbName.Invoke(new CapNhatGiaoDien(CapNhatTen), new object[] { myName });
            }
            if (part[0] == "online")
            {
                updateOnline(part[1]);
            }
            else if (part[0] == "msg" && part.Length >= 3)
            {
                if (part[1] == "Server")
                {

                    string tb = part[2];
                    txtBox.Invoke(new CapNhatGiaoDien(CapNhatNoiDungChat), new object[] { part[1] + ": " + tb });
                }
                string from = part[1];
                string content = part[2];
                SaveMessage(from, from + ": " + content);
                if (SelectedUser == from)
                {
                    txtBox.Invoke(new CapNhatGiaoDien(CapNhatNoiDungChat), new object[] { from + ": " + content });
                }
            }
            else if (part[0] == "file")
            {
                string from = part[1];
                string content = part[2];
                SaveMessage(from, from + ": " + content);
                if (SelectedUser == from)
                {
                    receiveFile(part[1], part[2], long.Parse(part[3]), long.Parse(part[4]));
                }
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
            string packet = "msg|" + SelectedUser + "|" + txtMessage.Text;
            sckClient.Send(Encoding.UTF8.GetBytes(packet));
            SaveMessage(SelectedUser, "Me: " + txtMessage.Text);
            CapNhatNoiDungChat("Me: " + txtMessage.Text);
            txtMessage.Clear();
        }

        string SelectedUser = "";



        void updateOnline(string users)
        {
            lstUser.Invoke(new Action(() =>
            {
                lstUser.Items.Clear();

                string[] ds = users.Split(',');
                foreach (string user in ds)
                {
                    if (user.Trim() != "")
                    {
                        if (user != myName)
                        {
                            lstUser.Items.Add(user);
                        }
                    }
                }
            }));
        }
        private void lstUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == userOnline)
            {
                if (lstUser.SelectedItem != null)
                {
                    SelectedUser = lstUser.SelectedItem.ToString();
                    lbUser.Text = SelectedUser;
                }
                txtBox.Clear();
                if (ChatHistory.ContainsKey(SelectedUser)) 
                { 
                    foreach (string msg in ChatHistory[SelectedUser]) 
                    { 
                        txtBox.AppendText(msg + "\r\n"); 
                    }
                }

            }
        }

        private void txtMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                butSend_Click(sender, e);
            }
        }
        private void butExit_Click(object sender, EventArgs e)
        {

            this.Close();
        }
        // gui file
        private void butFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string path = dlg.FileName;
                FileInfo fi = new FileInfo(path);
                if (fi.Length > 10 * 1024)
                {
                    MessageBox.Show("Kich thuoc file qua lon");
                    return;
                }
                sendFile(path);

            }
        }
        void sendFile(string path)
        {
            FileInfo fi = new FileInfo(path);
            const int BUFFER_SIZE = 1024;
            long numberFrame = fi.Length / BUFFER_SIZE;

            if (fi.Length % BUFFER_SIZE != 0)
            {
                numberFrame++;
            }
            string file = "file|" + SelectedUser + "|" + fi.Name + "|" + fi.Length + "|" + numberFrame;
            sckClient.Send(Encoding.UTF8.GetBytes(file));
            FileStream fs = fi.OpenRead();
            byte[] buffer = new byte[BUFFER_SIZE];
            int read = 0;
            for (int i = 0; i < numberFrame; i++)
            {
                read = fs.Read(buffer, 0, BUFFER_SIZE);
                sckClient.Send(buffer, read, SocketFlags.None);
            }
            fs.Close();
            txtBox.Invoke(new CapNhatGiaoDien(CapNhatNoiDungChat), new object[] { "Me: "+fi.Name});
        }

        void receiveFile(string senderName, string fileName, long fileSize, long numberFrame)
        {
            
            this.Invoke(new Action(() =>
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.FileName = fileName;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = new FileStream(dlg.FileName, FileMode.Create);
                    byte[] buffer = new byte[1024];
                    for (int i = 0; i < numberFrame; i++)
                    {
                        int n = sckClient.Receive(buffer);
                        fs.Write(buffer, 0, n);
                    }
                    fs.Close();
                    txtBox.Invoke(new CapNhatGiaoDien(CapNhatNoiDungChat), new object[] { senderName +": "+ fileName });
                }
            }));
        }
        //gui file

        //luu lịch sử tin nhắn
        Dictionary<string, List<string>> ChatHistory = new Dictionary<string, List<string>>();

        void SaveMessage(string user, string message)
        { 
            if (!ChatHistory.ContainsKey(user)) 
            { 
                ChatHistory[user] = new List<string>(); 
            } 
            ChatHistory[user].Add(message); }

        //luu lịch sử tin nhắn



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
    }
}
