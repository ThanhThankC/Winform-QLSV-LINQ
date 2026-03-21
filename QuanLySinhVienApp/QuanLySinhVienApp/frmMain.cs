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
                    frmLogin frmLogin = new frmLogin();
                    frmLogin.Show();
                    this.Close();
                }
                else
                {
                    tabMain.SelectedIndex = 0;
                }
            }
        }
    }
}
