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
    public partial class ucSubject : UserControl
    {
        public ucSubject()
        {
            InitializeComponent();
        }

        private void ucSubject_Load(object sender, EventArgs e)
        {
            LoadTeachers();
            LoadSubjects();
        }

        private void LoadTeachers()
        {
            try
            {
                using (var db = new DataClasses1DataContext())
                {
                    cboTeacher.DataSource = db.Teachers.Select(t => new { t.TeacherID, t.FullName }).ToList();
                    cboTeacher.DisplayMember = "FullName";
                    cboTeacher.ValueMember = "TeacherID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSubjects(string keyword = "")
        {
            try
            {
                using (var db = new DataClasses1DataContext())
                {
                    var query = from s in db.Subjects
                                join t in db.Teachers on s.TeacherID equals t.TeacherID
                                where s.SubjectID.Contains(keyword) || s.SubjectName.Contains(keyword)
                                select new
                                {
                                    s.SubjectID,
                                    s.SubjectName,
                                    s.Credits,
                                    s.TeacherID,
                                    TeacherName = t.FullName
                                };

                    dgvSubject.DataSource = query.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => LoadSubjects(txtSearch.Text.Trim());

        private void dgvSubject_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txtSubjectID.Text = dgvSubject.Rows[e.RowIndex].Cells["SubjectID"].Value.ToString();
            txtSubjectName.Text = dgvSubject.Rows[e.RowIndex].Cells["SubjectName"].Value.ToString();
            nudCredits.Value = Convert.ToDecimal(dgvSubject.Rows[e.RowIndex].Cells["Credits"].Value);
            cboTeacher.SelectedValue = dgvSubject.Rows[e.RowIndex].Cells["TeacherID"].Value.ToString();

            UpdateButtons();
        }

        private void UpdateButtons()
        {
            bool isValid = txtSubjectID.Text.Trim().Length > 0 && txtSubjectName.Text.Trim().Length > 0;

            try
            {
                using (var db = new DataClasses1DataContext())
                {
                    bool exists = db.Subjects.Any(s => s.SubjectID == txtSubjectID.Text.Trim());
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

        private void txtSubjectID_TextChanged(object sender, EventArgs e) => UpdateButtons();
        private void txtSubjectName_TextChanged(object sender, EventArgs e) => UpdateButtons();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new DataClasses1DataContext())
                {
                    var newSubject = new Subject
                    {
                        SubjectID = txtSubjectID.Text.Trim(),
                        SubjectName = txtSubjectName.Text.Trim(),
                        Credits = (int)nudCredits.Value,
                        TeacherID = cboTeacher.SelectedValue.ToString()
                    };
                    db.Subjects.InsertOnSubmit(newSubject);
                    db.SubmitChanges();
                }
                MessageBox.Show("Thêm môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSubjects();
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
                    var existing = db.Subjects.FirstOrDefault(s => s.SubjectID == txtSubjectID.Text.Trim());
                    if (existing == null) return;

                    existing.SubjectName = txtSubjectName.Text.Trim();
                    existing.Credits = (int)nudCredits.Value;
                    existing.TeacherID = cboTeacher.SelectedValue.ToString();
                    db.SubmitChanges();
                }
                MessageBox.Show("Cập nhật môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSubjects();
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
                    bool hasGrades = db.Grades.Any(g => g.SubjectID == txtSubjectID.Text.Trim());
                    if (hasGrades)
                    {
                        MessageBox.Show("Không thể xóa! Môn học này đã có điểm sinh viên.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var existing = db.Subjects.FirstOrDefault(s => s.SubjectID == txtSubjectID.Text.Trim());
                    if (existing == null) return;

                    var result = MessageBox.Show("Bạn có chắc muốn xóa môn học này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result != DialogResult.Yes) return;

                    db.Subjects.DeleteOnSubmit(existing);
                    db.SubmitChanges();
                }
                MessageBox.Show("Xóa môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSubjects();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== LÀM MỚI =====
        private void btnClear_Click(object sender, EventArgs e) => ClearForm();

        private void ClearForm()
        {
            txtSubjectID.Clear();
            txtSubjectName.Clear();
            nudCredits.Value = 1;
            if (cboTeacher.Items.Count > 0) cboTeacher.SelectedIndex = 0;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }
    }
}
