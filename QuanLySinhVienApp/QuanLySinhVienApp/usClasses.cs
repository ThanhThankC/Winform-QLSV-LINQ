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
    public partial class usClasses : UserControl
    {
        public usClasses()
        {
            InitializeComponent();
            LoadClasses();
            UpdateButtonVisual(false);
        }


        private void LoadClasses(string keyword = "")
        {
            try
            {
                using (var db = new DataClasses1DataContext())
                {
                    var query = from c in db.Classes
                                where keyword == "" || c.ClassID.Contains(keyword) || c.ClassName.Contains(keyword)
                                select c;
                    dgvClasses.DataSource = query.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách lớp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            LoadClasses(keyword);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new DataClasses1DataContext())
                {
                    var newClass = new Class { ClassID = txtClassID.Text.Trim(), ClassName = txtClassName.Text.Trim() };
                    db.Classes.InsertOnSubmit(newClass);
                    db.SubmitChanges();
                }
                MessageBox.Show("Thêm lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadClasses();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm lớp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new DataClasses1DataContext())
                {
                    var existingClass = db.Classes.FirstOrDefault(c => c.ClassID == txtClassID.Text.Trim());
                    existingClass.ClassName = txtClassName.Text.Trim();
                    db.SubmitChanges();
                }
                MessageBox.Show("Sửa lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadClasses();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa lớp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new DataClasses1DataContext())
                {
                    var hasStudents = db.Students.Any(s => s.ClassID == txtClassID.Text.Trim());
                    if (hasStudents)
                    {
                        MessageBox.Show("Không thể xóa! Lớp này còn sinh viên.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var existingClass = db.Classes.FirstOrDefault(c => c.ClassID == txtClassID.Text.Trim());
                    var confirm = MessageBox.Show($"Bạn có chắc muốn xóa lớp {existingClass.ClassID}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirm == DialogResult.Yes)
                    {
                        db.Classes.DeleteOnSubmit(existingClass);
                        db.SubmitChanges();
                        MessageBox.Show("Xóa lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearInputs();
                        LoadClasses();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa lớp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
            UpdateButtonVisual(false);
        }

        private void txtClassID_TextChanged(object sender, EventArgs e)
        {
            bool isValidClassID = !(string.IsNullOrEmpty(txtClassID.Text.Trim()) || string.IsNullOrEmpty(txtClassName.Text.Trim()));

            using (var db = new DataClasses1DataContext())
            {
                var existing = db.Classes.FirstOrDefault(c => c.ClassID == txtClassID.Text.Trim());
                btnAdd.Enabled = existing == null && isValidClassID;
                btnEdit.Enabled = existing != null && isValidClassID;
                btnDelete.Enabled = existing != null;
            }
        }

        private void txtClassName_TextChanged(object sender, EventArgs e)
        {
            txtClassID_TextChanged(sender, e);
        }

        private void UpdateButtonVisual(bool isValid)
        {
            btnAdd.Enabled = isValid;
            btnEdit.Enabled = isValid;
            btnDelete.Enabled = isValid;
        }

        private void ClearInputs()
        {
            txtClassID.Text = "";
            txtClassName.Text = "";
            txtSearch.Text = "";
        }

        private void dgvClasses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtClassID.Text = dgvClasses.Rows[e.RowIndex].Cells["ClassID"].Value.ToString();
                txtClassName.Text = dgvClasses.Rows[e.RowIndex].Cells["ClassName"].Value.ToString();
            }
        }
    }
}
