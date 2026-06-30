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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Microsoft.VisualBasic;

namespace CuoiKiLTMServer
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
        }
        //

        Dictionary<string, List<ClientInfo>> Group = new Dictionary<string, List<ClientInfo>>();
        List<ClientInfo> groupMembers = new List<ClientInfo>();
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

                string msg = Encoding.UTF8.GetString(info.data, 0, receive);
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
                string username = part[1];
                bool exists = false;
                foreach (ClientInfo c in sck)
                {
                    if (c.Username == username)
                    {
                        exists = true;
                        break;
                    }
                }
                if (exists)
                {
                    sender.sckInfo.Send(Encoding.UTF8.GetBytes("loginfail"));
                    return;
                }
                sender.Username = part[1];
                lstUser.Invoke(new Action(() => lstUser.Items.Add(sender)));
                sender.sckInfo.Send(Encoding.UTF8.GetBytes("loginok"));
                UpdateOnlineList();
                UpdateGroupList();
            }
            else if (part[0] == "grouplist")
            {
                UpdateGroupList();
            }
            else if (part[0] == "msg" && part.Length > 2)
            {
                string receiver = part[1];
                string content = part[2];
                if (Group.ContainsKey(receiver))
                {
                    string packet = "msg|" + "[" + receiver + "] " + sender.Username + "|" + content;
                    byte[] data = Encoding.UTF8.GetBytes(packet);

                    foreach (ClientInfo member in Group[receiver])
                    {
                        try
                        {
                            if (member.Username != sender.Username && member.sckInfo != null && member.sckInfo.Connected)
                            {
                                member.sckInfo.Send(data);
                            }
                        }
                        catch { }
                    }
                    txtBox.Invoke(new Action(() => { CapNhatNoiDungChat(sender.Username + " -> Nhóm [" + receiver + "]: " + content); }));
                }
                else
                {
                    ForwardMessage(sender.Username, receiver, content);
                }

            }
            else if (part[0] == "file")
            {

                HandleFile(sender, part[1], part[2], long.Parse(part[3]), long.Parse(part[4]));
            }

        }
        void HandleFile(ClientInfo sender, string receiverName, string fileName, long fileSize, long numberFrame)
        {
            ClientInfo receiver = sck.FirstOrDefault(x => x.Username == receiverName);
            if (receiver == null)
            {
                return;
            }
            string file = "file|" + sender.Username + "|" + fileName + "|" + fileSize + "|" + numberFrame;
            receiver.sckInfo.Send(Encoding.UTF8.GetBytes(file));
            byte[] buffer = new byte[1024];

            for (int i = 0; i < numberFrame; i++)
            {
                int n = sender.sckInfo.Receive(buffer);
                receiver.sckInfo.Send(buffer, n, SocketFlags.None);
            }
        }
        void ForwardMessage(string from, string to, string content)
        {
            ClientInfo receiver = sck.FirstOrDefault(x => x.Username == to);
            if (receiver == null)
                return;
            string packet = "msg|" + from + "|" + content;
            try
            {
                receiver.sckInfo.Send(Encoding.UTF8.GetBytes(packet));
                txtBox.Invoke(new CapNhatGiaoDien(CapNhatNoiDungChat), new object[] { from + " -> " + to + " : " + content });
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
            if (string.IsNullOrEmpty(txtMessage.Text)) return;

            if (SelectedClient != null)
            {
                string groupName = lbUser.Text;
                string packet = "msg|Server (Nhóm " + groupName + ")|" + txtMessage.Text;
                byte[] data = Encoding.UTF8.GetBytes(packet);

                // Vòng lặp gửi tin nhắn cho TẤT CẢ các thành viên nằm trong nhóm này
                foreach (ClientInfo member in Group[groupName])
                {
                    try
                    {
                        if (member.sckInfo != null && member.sckInfo.Connected)
                        {
                            member.sckInfo.Send(data);
                        }
                    }
                    catch { }
                }
                CapNhatNoiDungChat("Server -> Nhóm [" + groupName + "]: " + txtMessage.Text);
            }

            // HOẶC NẾU BIẾN SELECTEDCLIENT ĐÃ ĐƯỢC GÁN TRƯỚC ĐÓ THÌ VẪN CHAT RIÊNG ĐƯỢC
            else if (SelectedClient != null)
            {
                SendToSelected(SelectedClient, txtMessage.Text);
            }
            // 3. NẾU KHÔNG CHỌN AI THÌ GỬI BROADCAST TẤT CẢ
            else
            {
                BroadcastMessage(txtMessage.Text);
            }

            txtMessage.Text = "";
        }
        void BroadcastMessage(string content)
        {
            string packet = "msg|Server|" + content;
            byte[] data = Encoding.UTF8.GetBytes(packet);

            foreach (ClientInfo client in sck)
            {
                try
                {
                    if (client.sckInfo != null && client.sckInfo.Connected)
                    {
                        client.sckInfo.Send(data);
                    }
                }
                catch
                {
                    // Bỏ qua nếu socket client đó bị lỗi ngầm
                }
            }
            CapNhatNoiDungChat("Server (Thông báo chung): " + content);
        }
        private void butBroadcastSelect_Click(object sender, EventArgs e)
        {
            SelectedClient = null;

            lbUser.Invoke(new Action(() => { lbUser.Text = "Tất cả (Broadcast)"; }));

            lstUser.Invoke(new Action(() => { lstUser.ClearSelected(); }));

            CapNhatNoiDungChat("Hệ thống: Đã chuyển về chế độ gửi Thông báo chung (Broadcast).");
        }

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
                Encoding.UTF8.GetBytes(users);

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
        void SendToSelected(ClientInfo client, string s)
        {
            string msg = "msg|" + "Server|" + s;
            client.sckInfo.Send(Encoding.UTF8.GetBytes(msg));
            CapNhatNoiDungChat("Server -> " + client.Username + ": " + s);
        }

        // 1. Hàm đồng bộ danh sách nhóm xuống tất cả Client
        void UpdateGroupList()
        {
            string groupNames = "grouplist|";
            foreach (string gName in Group.Keys)
            {
                groupNames += gName + ",";
            }

            if (groupNames.EndsWith(","))
            {
                groupNames = groupNames.TrimEnd(',');
            }

            byte[] packet = Encoding.UTF8.GetBytes(groupNames);

            foreach (ClientInfo c in groupMembers)
            {
                try
                {
                    if (c.sckInfo != null && c.sckInfo.Connected)
                    {
                        c.sckInfo.Send(packet);
                    }
                }
                catch { }
            }
        }
        private void butSend_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                butSend_Click(sender, e);
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
        private void Server_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUser.SelectedItem == null) return;

            // Trường hợp 1: Chọn một Client cá nhân để chat riêng (Giữ cũ)
            if (lstUser.SelectedItem is ClientInfo client)
            {
                SelectedClient = client;
                lbUser.Invoke(new CapNhatGiaoDien(CapNhatNguoiDung), new object[] { client.Username });
                txtBox.Clear();
            }
        }
        // TỰ ĐỘNG LÀM MỚI DANH SÁCH LSTUSER MỖI KHI BẤM CHUYỂN TAB
        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstUser.Items.Clear();
            if (tabControl.SelectedIndex == 0) // Tab Online
            {
                foreach (var client in sck) lstUser.Items.Add(client);
            }
            else // Tab Group
            {
                foreach (string gName in Group.Keys) lstUser.Items.Add(gName);

            }
        }



        private void lstGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstGroup.SelectedItem == null) return;

            SelectedClient = null;
            string groupName = lstGroup.SelectedItem.ToString();
            lbUser.Invoke(new CapNhatGiaoDien(CapNhatNguoiDung), new object[] { groupName });
            txtBox.Clear();
        }



        // 1. SỰ KIỆN KHI SERVER BẤM NÚT "CREAT GROUP"
        private void butCreatGroup_Click(object sender, EventArgs e)
        {
            string groupName = Interaction.InputBox("Nhập tên nhóm chat cần tạo:", "Tạo Nhóm", "");

            if (string.IsNullOrEmpty(groupName.Trim()))
            {
                MessageBox.Show("Tên nhóm không được để trống!");
                return;
            }

            if (Group.ContainsKey(groupName))
            {
                MessageBox.Show("Tên nhóm này đã tồn tại!");
                return;
            }


            // SỬA CHUẨN: Vì lstUser chứa trực tiếp đối tượng ClientInfo, ép kiểu thẳng để bốc đối tượng ra mà không sợ sai lệch chuỗi
            if (lstUser.SelectedItems.Count > 0)
            {
                foreach (var item in lstUser.SelectedItems)
                {
                    if (item is ClientInfo selectedClient)
                    {
                        groupMembers.Add(selectedClient);
                    }
                }
                CapNhatNoiDungChat($"Server: Đã tạo nhóm [{groupName}] với {lstUser.SelectedItems.Count} thành viên được chọn .");
            }
            else
            {
                // Nếu không bôi chọn ai, mặc định thêm TẤT CẢ các Client đang online vào nhóm
                groupMembers = new List<ClientInfo>(sck);
                CapNhatNoiDungChat($"Server: Đã tạo nhóm chung [{groupName}] cho toàn bộ thành viên.");
            }

            // Lưu nhóm vào bộ nhớ của Server và đồng bộ danh sách nhóm công khai
            Group.Add(groupName, groupMembers);
            UpdateGroupList();
            lstGroup.Invoke(new Action(() => lstGroup.Items.Add(groupName)));

            // Gửi lệnh thông báo tạo nhóm thành công xuống RIÊNG các máy thành viên trong nhóm để Client cập nhật giao diện
            string createGroupPacket = "creategroup|" + groupName;
            byte[] groupData = Encoding.UTF8.GetBytes(createGroupPacket);
            foreach (ClientInfo member in groupMembers)
            {
                try
                {
                    if (member.sckInfo != null && member.sckInfo.Connected)
                    {
                        member.sckInfo.Send(groupData);
                    }
                }
                catch { }
            }
        }


        // 2. SỰ KIỆN KHI SERVER BẤM NÚT "DELETE GROUP"
        private void butDeleteGroup_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem người dùng đã chọn nhóm nào trong ListBox chưa
            if (lstGroup.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng click chọn một nhóm trong danh sách trước khi xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // 2. Lấy thẳng tên nhóm đang được chọn
            string groupName = lstGroup.SelectedItem.ToString();
            // 3. Hiện hộp thoại xác nhận để tránh bấm nhầm
            DialogResult dialogResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhóm [{groupName}] không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                if (Group.ContainsKey(groupName))
                {
                    Group.Remove(groupName); // Xóa khỏi bộ nhớ Server
                    UpdateGroupList();       // Đồng bộ để tất cả Client biến mất nhóm này

                    lstGroup.Invoke(new Action(() =>
                    {
                        if (lstGroup.Items.Contains(groupName))
                        {
                            lstGroup.Items.Remove(groupName);
                        }
                    }));

                    CapNhatNoiDungChat($"Server: Đã xóa nhóm [{groupName}].");

                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhóm có tên này để xóa!");
                }
            }


        }
    }
}
