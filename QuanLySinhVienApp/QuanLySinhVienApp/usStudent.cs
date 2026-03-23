using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVienApp
{
    public partial class usStudents : UserControl
    {
        private int _currentPage = 1;
        private int _pageSize = 20;
        private List<dynamic> _allData = new List<dynamic>();

        public usStudents()
        {
            InitializeComponent();
        }

        private void usStudents_Load(object sender, EventArgs e)
        {
            LoadClasses();
            LoadStudents();
        }


        private void LoadClasses()
        {
            try
            {
                using (var db = new DataClasses1DataContext())
                {
                    var list = db.Classes.Select(c => new { c.ClassID, c.ClassName }).ToList();

                    cboFilterClass.DataSource = null;
                    var filterList = new List<object> { new { ClassID = "", ClassName = "-- Tất cả --" } };
                    filterList.AddRange(list.Cast<object>());
                    cboFilterClass.DataSource = filterList;
                    cboFilterClass.DisplayMember = "ClassName";
                    cboFilterClass.ValueMember = "ClassID";

                    cboClass.DataSource = list.ToList();
                    cboClass.DisplayMember = "ClassName";
                    cboClass.ValueMember = "ClassID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStudents()
        {
            try
            {
                using (var db = new DataClasses1DataContext())
                {
                    string keyword = txtSearch.Text.Trim();
                    string filterClass = cboFilterClass.SelectedValue?.ToString() ?? "";

                    var query = from s in db.Students
                                join c in db.Classes on s.ClassID equals c.ClassID
                                where (s.StudentID.Contains(keyword) || s.FullName.Contains(keyword))
                                   && (filterClass == "" || s.ClassID == filterClass)
                                select new
                                {
                                    s.StudentID,
                                    s.FullName,
                                    s.DateOfBirth,
                                    s.Gender,
                                    s.ClassID,
                                    c.ClassName
                                };

                    _allData = query.ToList().Cast<dynamic>().ToList();
                }

                _currentPage = 1;
                ShowPage();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowPage()
        {
            int totalPages = Math.Max(1, (int)Math.Ceiling((double)_allData.Count / _pageSize));
            _currentPage = Math.Max(1, Math.Min(_currentPage, totalPages));

            var pageData = _allData
                .Skip((_currentPage - 1) * _pageSize)
                .Take(_pageSize)
                .ToList();

            dgvStudents.DataSource = pageData;
            lblPage.Text = $"Trang {_currentPage} / {totalPages}";
            btnPrev.Enabled = _currentPage > 1;
            btnNext.Enabled = _currentPage < totalPages;
        }

        private void ClearForm()
        {
            txtStudentID.Clear();
            txtFullName.Clear();
            dtpDOB.Value = DateTime.Today;
            lblAge.Text = "Tuổi: ...";
            if (cboGender.Items.Count > 0) cboGender.SelectedIndex = 0;
            if (cboClass.Items.Count > 0) cboClass.SelectedIndex = 0;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            dgvStudents.ClearSelection();
            txtSearch.Clear();
        }


        private void txtFullName_TextChanged_1(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void txtStudentID_TextChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }


        private void btnPrev_Click(object sender, EventArgs e)
        {
            _currentPage--;
            ShowPage();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _currentPage++;
            ShowPage();
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txtStudentID.Text = dgvStudents.Rows[e.RowIndex].Cells["StudentID"].Value.ToString();
            txtFullName.Text = dgvStudents.Rows[e.RowIndex].Cells["FullName"].Value.ToString();
            dtpDOB.Value = Convert.ToDateTime(dgvStudents.Rows[e.RowIndex].Cells["DateOfBirth"].Value);
            cboGender.SelectedItem = dgvStudents.Rows[e.RowIndex].Cells["Gender"].Value.ToString();
            cboClass.SelectedValue = dgvStudents.Rows[e.RowIndex].Cells["ClassID"].Value.ToString();

            UpdateAge();
            UpdateButtons();
        }

        private void UpdateAge()
        {
            int age = DateTime.Now.Year - dtpDOB.Value.Year;
            if (dtpDOB.Value.Date > DateTime.Now.AddYears(-age)) age--;
            lblAge.Text = $"Tuổi: {age}";
        }

        private void UpdateButtons()
        {
            bool isValid = txtStudentID.Text.Trim().Length > 0 && txtFullName.Text.Trim().Length > 0;

            try
            {
                using (var db = new DataClasses1DataContext())
                {
                    bool exists = db.Students.Any(s => s.StudentID == txtStudentID.Text.Trim());
                    btnAdd.Enabled = isValid && !exists;
                    btnEdit.Enabled = isValid && exists;
                    btnDelete.Enabled = exists;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void cboFilterClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStudents();
        }


        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {
            UpdateAge();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new DataClasses1DataContext())
                {
                    var newStudent = new Student
                    {
                        StudentID = txtStudentID.Text.Trim(),
                        FullName = txtFullName.Text.Trim(),
                        DateOfBirth = dtpDOB.Value.Date,
                        Gender = cboGender.SelectedItem.ToString(),
                        ClassID = cboClass.SelectedValue.ToString()
                    };
                    db.Students.InsertOnSubmit(newStudent);
                    db.SubmitChanges();
                }
                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadStudents();
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
                    var existing = db.Students.FirstOrDefault(s => s.StudentID == txtStudentID.Text.Trim());
                    if (existing == null) return;

                    existing.FullName = txtFullName.Text.Trim();
                    existing.DateOfBirth = dtpDOB.Value.Date;
                    existing.Gender = cboGender.SelectedItem.ToString();
                    existing.ClassID = cboClass.SelectedValue.ToString();
                    db.SubmitChanges();
                }
                MessageBox.Show("Cập nhật sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadStudents();
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
                    var existing = db.Students.FirstOrDefault(s => s.StudentID == txtStudentID.Text.Trim());
                    if (existing == null) return;

                    var result = MessageBox.Show("Bạn có chắc muốn xóa sinh viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result != DialogResult.Yes) return;

                    db.Students.DeleteOnSubmit(existing);
                    db.SubmitChanges();
                }
                MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadStudents();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearForm();
    }
}
