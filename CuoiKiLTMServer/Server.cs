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
        List<ClientInfo> sck = new List<ClientInfo>();
        //
        Socket sckServer = null;
        Socket sckClient = null;
        int connection = 0;
        byte[] data = new byte[1024];
        int n;
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
            
            info.sckInfo.BeginReceive(data, 0, data.Length, SocketFlags.None, new AsyncCallback(xulydulieu), info);
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
                
                string msg = Encoding.ASCII.GetString(data, 0, receive);
                xulitinnhan(info, msg);
                //txtBox.Invoke(new CapNhatGiaoDien(CapNhatNoiDungChat), new object[] { "Client: " + msg });
                info.sckInfo.BeginReceive(data, 0, data.Length, SocketFlags.None, new AsyncCallback(xulydulieu), info);
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
                Online.Invoke(new Action(() => Online.Items.Add(sender.Username)));
            }
            else if (part[0] == "msg" && part.Length > 1)
            {
                string send = sender.Username + ":" + part[1];
                txtBox.Invoke(new CapNhatGiaoDien(CapNhatNoiDungChat), new object[] { send });
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
            sckClient.Send(Encoding.ASCII.GetBytes(txtMessage.Text));
            CapNhatNoiDungChat("Server: " + txtMessage.Text);
            txtMessage.Text = "";
        }
        //
        public void CloseClient(ClientInfo client)
        {
            try { client.sckInfo.Shutdown(SocketShutdown.Both); } catch { }
            try { client.sckInfo.Close(); } catch { }
            sck.Remove(client);
            connection--;
            lbStatus.Invoke(new CapNhatGiaoDien(CapNhatTrangThai), new object[] { "So Client ket noi :" + connection });
        }
    }
}
