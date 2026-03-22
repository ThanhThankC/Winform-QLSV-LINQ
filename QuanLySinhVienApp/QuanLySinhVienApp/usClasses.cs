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
        }

        private void usClasses_Load(object sender, EventArgs e)
        {
            LoadDepartments();
            LoadClasses();
            UpdateButtons();
        }

        private void LoadDepartments()
        {
            try
            {
                using (var db = new DataClasses1DataContext())
                {
                    cboDepartment.DataSource = db.Departments.ToList();
                    cboDepartment.DisplayMember = "DepartmentName";
                    cboDepartment.ValueMember = "DepartmentID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadClasses(string keyword = "")
        {
            try
            {
                using (var db = new DataClasses1DataContext())
                {
                    var query = from c in db.Classes
                                join d in db.Departments on c.DepartmentID equals d.DepartmentID
                                where c.ClassID.Contains(keyword) || c.ClassName.Contains(keyword)
                                select new
                                {
                                    c.ClassID,
                                    c.ClassName,
                                    c.DepartmentID,
                                    d.DepartmentName,
                                    CountStudents = db.Students.Count(s => s.ClassID == c.ClassID),
                                };

                    dgvClasses.DataSource = query.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadClasses(txtSearch.Text.Trim());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new DataClasses1DataContext())
                {
                    var newClass = new Class
                    {
                        ClassID = txtClassID.Text.Trim(),
                        ClassName = txtClassName.Text.Trim(),
                        DepartmentID = cboDepartment.SelectedValue.ToString()
                    };
                    db.Classes.InsertOnSubmit(newClass);
                    db.SubmitChanges();
                }
                MessageBox.Show("Thêm lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadClasses();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new DataClasses1DataContext())
                {
                    var existing = db.Classes.FirstOrDefault(c => c.ClassID == txtClassID.Text.Trim());
                    if (existing == null) return;

                    existing.ClassName = txtClassName.Text.Trim();
                    existing.DepartmentID = cboDepartment.SelectedValue.ToString();
                    db.SubmitChanges();
                }
                MessageBox.Show("Cập nhật lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadClasses();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new DataClasses1DataContext())
                {
                    bool hasStudents = db.Students.Any(s => s.ClassID == txtClassID.Text.Trim());
                    if (hasStudents)
                    {
                        MessageBox.Show("Không thể xóa! Lớp này vẫn còn sinh viên.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var existing = db.Classes.FirstOrDefault(c => c.ClassID == txtClassID.Text.Trim());
                    if (existing == null) return;

                    var result = MessageBox.Show("Bạn có chắc muốn xóa lớp này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result != DialogResult.Yes) return;

                    db.Classes.DeleteOnSubmit(existing);
                    db.SubmitChanges();
                }
                MessageBox.Show("Xóa lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadClasses();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            UpdateButtons();
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

        private void UpdateButtons()
        {
            bool isValid = !string.IsNullOrEmpty(txtClassID.Text.Trim()) && !string.IsNullOrEmpty(txtClassName.Text.Trim());

            try
            {
                using (var db = new DataClasses1DataContext())
                {
                    bool exists = db.Classes.Any(c => c.ClassID == txtClassID.Text.Trim());
                    int countStudents = db.Students.Count(s => s.ClassID == txtClassID.Text.Trim());
                    btnAdd.Enabled = isValid && !exists;
                    btnEdit.Enabled = isValid && exists;
                    btnDelete.Enabled = exists && countStudents == 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtClassID.Clear();
            txtClassName.Clear();
            if (cboDepartment.Items.Count > 0) cboDepartment.SelectedIndex = 0;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            dgvClasses.ClearSelection();
            txtClassID.Focus();
            txtSearch.Clear();
        }

        private void dgvClasses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txtClassID.Text = dgvClasses.Rows[e.RowIndex].Cells["colClassID"].Value.ToString();
            txtClassName.Text = dgvClasses.Rows[e.RowIndex].Cells["colClassName"].Value.ToString();
            cboDepartment.SelectedValue = dgvClasses.Rows[e.RowIndex].Cells["colDepartmentID"].Value.ToString();

            UpdateButtons();
        }


    }
}
