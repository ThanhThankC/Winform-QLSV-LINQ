using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVienApp
{
    public partial class frmLogin : Form
    {
        public static string LoggedInUsername = "";

        public frmLogin()
        {
            InitializeComponent();
            btnLogin.Enabled = false;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            UpdateLoginButton();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            UpdateLoginButton();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            try
            {
                using (var db = new DataClasses1DataContext())
                {
                    var user = db.Users.FirstOrDefault(u =>
                        u.Username == username && u.Password == password);

                    if (user == null)
                    {
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.Clear();
                        txtPassword.Focus();
                    }
                    else
                    {
                        LoggedInUsername = user.Username;

                        frmMain main = new frmMain();
                        main.Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateLoginButton()
        {
            btnLogin.Enabled = txtUsername.Text.Trim().Length > 0 && txtPassword.Text.Length > 0;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && btnLogin.Enabled)
                btnLogin.PerformClick();
        }
    }
}
