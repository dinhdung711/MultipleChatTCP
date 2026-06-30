using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CuoiKiLTMClient
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public string Username { get; private set; }

        void butLogin_Click(object sender, EventArgs e)
        {
            Username = txtUser.Text.Trim();

            if (Username == "")
            {
                MessageBox.Show("Nhap Username");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

         void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                butLogin_Click(sender, e);
            }
        }
    }
}
