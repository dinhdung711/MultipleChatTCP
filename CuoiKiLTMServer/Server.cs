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

namespace CuoiKiLTMServer
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
        }
        //
        Dictionary<string,List<ClientInfo>> Group = new Dictionary<string,List<ClientInfo>>();
        List<ClientInfo> sck = new List<ClientInfo>();
        //
        Socket sckServer = null;
        Socket sckClient = null;
        int connection = 0;
        private void butStart_Click(object sender, EventArgs e)
        {
            if (sckServer != null)
            {
                sckServer.Close();
            }
            sckServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint serverEp = new IPEndPoint(IPAddress.Any, (int)numPort.Value);
            sckServer.Bind(serverEp);
            sckServer.Listen(5);
            lbStatus.Text = "Server dang cho ket noi ...";
            sckServer.BeginAccept(new AsyncCallback(xulyketnoi), sckServer);
        }

        private void xulyketnoi(IAsyncResult result)
        {
            sckServer = (Socket)result.AsyncState;
            //
            sckClient = sckServer.EndAccept(result);
            //
            ClientInfo info = new ClientInfo();
            info.sckInfo = sckClient;
            info.data = new byte[1024];
            sck.Add(info);
            connection++;
            //
            lbStatus.Invoke(new CapNhatGiaoDien(CapNhatTrangThai), new object[] { "hien co " + connection + "Client" });
            
            info.sckInfo.BeginReceive(info.data, 0, info.data.Length, SocketFlags.None, new AsyncCallback(xulydulieu), info);
            //
            sckServer.BeginAccept(new AsyncCallback(xulyketnoi), sckServer);
        }   
     

        private void xulydulieu(IAsyncResult result)
        {
            ClientInfo info = (ClientInfo)result.AsyncState;
            try
            {
                int receive = info.sckInfo.EndReceive(result);
                if (receive == 0)
                {
                    CloseClient(info);
                    return;
                }
                
                string msg = Encoding.ASCII.GetString(info.data, 0, receive);
                xulitinnhan(info, msg);
                 
                info.sckInfo.BeginReceive(info.data, 0, info.data.Length, SocketFlags.None, new AsyncCallback(xulydulieu), info);
                
            }
            catch (SocketException)
            {
                CloseClient(info);
            }
        }
        void xulitinnhan(ClientInfo sender, string msg)
        {
            string[] part = msg.Split('|');
            if (part.Length == 0) return;
            if (part[0] == "login" && part.Length > 1)
            {
                sender.Username = part[1];
                //Online.Invoke(new Action(() => Online.Items.Add(sender)));
                lstUser.Invoke(new Action(() => lstUser.Items.Add(sender)));
                UpdateOnlineList();
            }
            else if (part[0] == "msg" && part.Length > 2)
            {
                string receiver =part[1];
                string content = part[2];
                ForwardMessage(
                    sender.Username,
                    receiver,
                    content);
            }
        }

        void ForwardMessage(string from,string to,string content)  
        {
            ClientInfo receiver =  sck.FirstOrDefault( x => x.Username == to);
            if (receiver == null)
                return;
            string packet ="msg|" + from + "|" +content;       
            try
            {
                receiver.sckInfo.Send(Encoding.ASCII.GetBytes(packet));
                txtBox.Invoke(new CapNhatGiaoDien(CapNhatNoiDungChat), new object[]{from +" -> " + to +" : " + content });          
            }
            catch
            {
            }
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

            
            if (SelectedClient != null)
            {
                SendToSelected(SelectedClient, txtMessage.Text);
            }

             //broatcast ( server không chọn người gửi thì sẽ gửi cho tất cả người dùng online 

            //

            txtMessage.Text = "";
        }
        //
        public void CloseClient(ClientInfo client)
        {
            try { client.sckInfo.Shutdown(SocketShutdown.Both); } catch { }
            try { client.sckInfo.Close(); } catch { }
            
            sck.Remove(client);
            // xoa client tren thanh online
            lstUser.Invoke(new Action(() => lstUser.Items.Remove(client)));
            //
            connection--;
            lbStatus.Invoke(new CapNhatGiaoDien(CapNhatTrangThai), new object[] { "So Client ket noi :" + connection });
            UpdateOnlineList();
        }
       
        ClientInfo SelectedClient = null;
       
        void CapNhatNguoiDung(string s)
        {
            lbUser.Text = s;
        }
        //
        void UpdateOnlineList()
        {
            string users = "online|";

            foreach (ClientInfo c in sck)
            {
                if (!string.IsNullOrEmpty(c.Username))
                {
                    users += c.Username + ",";
                }
            }

            byte[] packet =
                Encoding.ASCII.GetBytes(users);

            foreach (ClientInfo c in sck)
            {
                try
                {
                    c.sckInfo.Send(packet);
                }
                catch
                {
                }
            }
        }
        //
        void SendToSelected(ClientInfo client, string s)
        {
            //sửa 6/27/  1:35 
            string msg = "msg|" +"Server|" + s;
            client.sckInfo.Send(Encoding.ASCII.GetBytes(msg));
            CapNhatNoiDungChat("Server: " + msg);

        }
        private void butSend_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                butSend_Click(sender, e);
            }
        }

        
        // tao nhom
        void creatGroup(string groupName,List<ClientInfo> clients)
        {

        }
        private void Server_Load(object sender, EventArgs e)
        {

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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == userOnline)
            {
                if (lstUser.SelectedItem is ClientInfo client)
                {
                    MessageBox.Show(client.Username);
                    SelectedClient = client;
                    lbUser.Invoke(new CapNhatGiaoDien(CapNhatNguoiDung), new object[] { client.Username });

                    txtBox.Clear();
                }
            }
        }
    }
}
