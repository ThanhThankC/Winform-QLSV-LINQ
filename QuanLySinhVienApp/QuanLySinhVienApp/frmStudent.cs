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
    public partial class frmStudent : Form
    {
        public frmStudent()
        {
            InitializeComponent();
            LoadStudents();
            LoadComboBox();
        }
        private void LoadStudents(string keyword = "")
        {
            using (var db = new DataClasses1DataContext())
            {
                var query = from s in db.Students
                            where keyword == "" || s.StudentID.Contains(keyword) || s.FullName.Contains(keyword) || s.ClassID.Contains(keyword)
                            select new
                            {
                                s.StudentID,
                                s.FullName,
                                s.Age,
                                s.ClassID,
                            };

                dgvStudents.DataSource = query.ToList();
            }
        }

        private void LoadComboBox()
        {
            using (var db = new DataClasses1DataContext())
            {
                cboClassID.DataSource = db.Classes.ToList();
                cboClassID.DisplayMember = "ClassID"; 
                cboClassID.ValueMember = "ClassID";  
                cboClassID.SelectedIndex = -1;   
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            LoadStudents(keyword);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var db = new DataClasses1DataContext())
            {
                var newStudent = new Student
                {
                    StudentID = txtStudentID.Text.Trim(),
                    FullName = txtFullName.Text.Trim(),
                    Age = (int)nudAge.Value,
                    ClassID = cboClassID.SelectedValue.ToString()
                };
                db.Students.InsertOnSubmit(newStudent);
                db.SubmitChanges();
            }

            MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearInputs();
            LoadStudents();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            using (var db = new DataClasses1DataContext())
            {
                var existingStudent = db.Students.FirstOrDefault(c => c.StudentID == txtStudentID.Text.Trim());
                existingStudent.FullName = txtFullName.Text.Trim();
                existingStudent.Age = (int)nudAge.Value;
                existingStudent.ClassID = cboClassID.SelectedValue.ToString();
                db.SubmitChanges();
            }

            MessageBox.Show("Sửa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearInputs();
            LoadStudents();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (var db = new DataClasses1DataContext())
            {
                var existingStudent = db.Students.FirstOrDefault(c => c.StudentID == txtStudentID.Text.Trim());

                var confirm = MessageBox.Show($"Bạn có chắc muốn xóa sinh viên {existingStudent.StudentID}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    db.Students.DeleteOnSubmit(existingStudent);
                    db.SubmitChanges();

                    MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadStudents();
                }
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            //TODO xoa toan bo trong grid.
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
            UpdateButtonVisual(false);
        }

        private void txtStudentID_TextChanged(object sender, EventArgs e)
        {
            bool isValidStudentID = !(string.IsNullOrEmpty(txtStudentID.Text.Trim()) || cboClassID.SelectedIndex == -1 || string.IsNullOrEmpty(txtFullName.Text.Trim()));

            using (var db = new DataClasses1DataContext())
            {
                var existing = db.Students.FirstOrDefault(c => c.StudentID == txtStudentID.Text.Trim());
                btnAdd.Enabled = existing == null && isValidStudentID;
                btnEdit.Enabled = existing != null && isValidStudentID;
                btnDelete.Enabled = existing != null;
            }
        }

        private void cboClassID_TextChanged(object sender, EventArgs e)
        {
            txtStudentID_TextChanged(sender, e);
        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {
            txtStudentID_TextChanged(sender, e);
        }

        private void UpdateButtonVisual(bool isValid)
        {
            btnAdd.Enabled = isValid;
            btnEdit.Enabled = isValid;
            btnDelete.Enabled = isValid;
        }

        private void ClearInputs()
        {
            txtStudentID.Text = "";
            cboClassID.SelectedIndex = -1;
            txtFullName.Text = "";
            txtSearch.Text = "";
        }

        private void dgvStudents_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtStudentID.Text = dgvStudents.Rows[e.RowIndex].Cells["StudentID"].Value.ToString();
                txtFullName.Text = dgvStudents.Rows[e.RowIndex].Cells["FullName"].Value.ToString();
                nudAge.Value = Convert.ToDecimal(dgvStudents.Rows[e.RowIndex].Cells["Age"].Value);
                cboClassID.SelectedValue = dgvStudents.Rows[e.RowIndex].Cells["ClassID"].Value.ToString();
            }
        }
    }
}
