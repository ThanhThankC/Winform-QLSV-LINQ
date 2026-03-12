using Microsoft.IdentityModel.Tokens;
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
    public partial class frmLogin : Form
    {
        private bool isEnableUsername = false;
        private bool isEnablePassword = false;

        public frmLogin()
        {
            InitializeComponent();
            btnLogin.Enabled = false;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();

            isEnableUsername = !string.IsNullOrEmpty(username);
            UpdateButtonVisual();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            string password = txtPassword.Text.Trim();

            isEnablePassword = !string.IsNullOrEmpty(password);
            UpdateButtonVisual();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            using (var db = new DataClasses1DataContext())
            {
                var user = (from u in db.Users where u.Username == username && u.Password == password select u).FirstOrDefault();

                if (user != null)
                {
                    frmMain frmMain = new frmMain();
                    frmMain.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
        }

        private void UpdateButtonVisual()
        {
            btnLogin.Enabled = isEnableUsername && isEnablePassword;
        }
    }
}
