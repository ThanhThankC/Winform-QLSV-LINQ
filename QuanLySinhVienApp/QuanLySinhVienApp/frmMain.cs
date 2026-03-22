using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVienApp
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMain.SelectedTab == tabLogout)
            {
                var confirm = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    this.Close();
                    foreach (Form f in Application.OpenForms)
                    {
                        if (f is frmLogin)
                        {
                            f.Show();
                            break;
                        }
                    }
                }
                else
                {
                    tabMain.SelectedIndex = 0;
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Xin chào, " + frmLogin.LoggedInUsername + "!";
        }
    }
}
