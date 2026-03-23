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
    public partial class ucGrade : UserControl
    {
        public ucGrade()
        {
            InitializeComponent();
        }

        private void ucGrade_Load_1(object sender, EventArgs e)
        {
            LoadClasses();
            LoadSubjects();
            dgvGrade.AutoGenerateColumns = false;
        }

        private void LoadClasses()
        {
            try
            {
                using (var db = new DataClasses1DataContext())
                {
                    cboClass.DataSource = db.Classes.Select(c => new { c.ClassID, c.ClassName }).ToList();
                    cboClass.DisplayMember = "ClassName";
                    cboClass.ValueMember = "ClassID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSubjects()
        {
            try
            {
                using (var db = new DataClasses1DataContext())
                {
                    cboSubject.DataSource = db.Subjects.Select(s => new { s.SubjectID, s.SubjectName }).ToList();
                    cboSubject.DisplayMember = "SubjectName";
                    cboSubject.ValueMember = "SubjectID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (cboClass.SelectedValue == null || cboSubject.SelectedValue == null) return;

            string classID = cboClass.SelectedValue.ToString();
            string subjectID = cboSubject.SelectedValue.ToString();

            try
            {
                using (var db = new DataClasses1DataContext())
                {
                    // Lấy tất cả sinh viên của lớp
                    var students = db.Students
                        .Where(s => s.ClassID == classID)
                        .Select(s => new { s.StudentID, s.FullName })
                        .ToList();

                    // Lấy điểm đã có của môn học đó
                    var grades = db.Grades
                        .Where(g => g.SubjectID == subjectID)
                        .Select(g => new { g.StudentID, g.MidtermScore, g.FinalScore })
                        .ToList();

                    // Ghép lại: sinh viên chưa có điểm thì để null
                    var data = students.Select(s =>
                    {
                        var grade = grades.FirstOrDefault(g => g.StudentID == s.StudentID);
                        decimal? midterm = grade?.MidtermScore;
                        decimal? final = grade?.FinalScore;
                        decimal? total = (midterm.HasValue && final.HasValue)
                            ? Math.Round(midterm.Value * 0.4m + final.Value * 0.6m, 2)
                            : (decimal?)null;

                        return new
                        {
                            s.StudentID,
                            s.FullName,
                            MidtermScore = midterm,
                            FinalScore = final,
                            TotalScore = total
                        };
                    }).ToList();

                    //dgvGrade.DataSource = data;

                    dgvGrade.Rows.Clear();
                    foreach (var item in data)
                    {
                        int idx = dgvGrade.Rows.Add();
                        dgvGrade.Rows[idx].Cells["StudentID"].Value = item.StudentID;
                        dgvGrade.Rows[idx].Cells["FullName"].Value = item.FullName;
                        dgvGrade.Rows[idx].Cells["MidtermScore"].Value = item.MidtermScore;
                        dgvGrade.Rows[idx].Cells["FinalScore"].Value = item.FinalScore;
                        dgvGrade.Rows[idx].Cells["TotalScore"].Value = item.TotalScore;

                        // Tô màu theo điểm tổng kết
                        ColorRow(dgvGrade.Rows[idx], item.TotalScore);
                    }
                }

                btnSave.Enabled = true;
                btnStats.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ColorRow(DataGridViewRow row, decimal? total)
        {
            if (total == null) { row.DefaultCellStyle.BackColor = Color.White; return; }
            row.DefaultCellStyle.BackColor = total < 5 ? Color.LightCoral : Color.LightGreen;
        }

        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnLoad_Click(sender, e);
        }

        private void cboSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnLoad_Click(sender, e);   
        }

        private void pnlList_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvGrade_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvGrade.Rows[e.RowIndex];
            string colName = dgvGrade.Columns[e.ColumnIndex].Name;

            if (colName != "MidtermScore" && colName != "FinalScore") return;

            // Validate giá trị vừa nhập
            var cell = row.Cells[e.ColumnIndex];
            if (cell.Value == null || cell.Value.ToString() == "")
            {
                cell.Value = null;
            }
            else if (decimal.TryParse(cell.Value.ToString(), out decimal val))
            {
                if (val < 0 || val > 10)
                {
                    MessageBox.Show("Điểm phải từ 0.0 đến 10.0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cell.Value = null;
                    return;
                }
            }
            else
            {
                MessageBox.Show("Điểm không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cell.Value = null;
                return;
            }

            RecalcTotal(row);
        }

        private void RecalcTotal(DataGridViewRow row)
        {
            bool hasMid = decimal.TryParse(row.Cells["MidtermScore"].Value?.ToString(), out decimal mid);
            bool hasFinal = decimal.TryParse(row.Cells["FinalScore"].Value?.ToString(), out decimal fin);

            if (hasMid && hasFinal)
            {
                decimal total = Math.Round(mid * 0.4m + fin * 0.6m, 2);
                row.Cells["TotalScore"].Value = total;
                ColorRow(row, total);
            }
            else
            {
                row.Cells["TotalScore"].Value = null;
                ColorRow(row, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboSubject.SelectedValue == null) return;
            string subjectID = cboSubject.SelectedValue.ToString();
            int savedCount = 0;

            try
            {
                using (var db = new DataClasses1DataContext())
                {
                    foreach (DataGridViewRow row in dgvGrade.Rows)
                    {
                        if (row.IsNewRow) continue;

                        if (!decimal.TryParse(row.Cells["MidtermScore"].Value?.ToString(), out decimal mid)) continue;
                        if (!decimal.TryParse(row.Cells["FinalScore"].Value?.ToString(), out decimal fin)) continue;

                        string studentID = row.Cells["StudentID"].Value.ToString();

                        var existing = db.Grades.FirstOrDefault(g => g.StudentID == studentID && g.SubjectID == subjectID);

                        if (existing != null)
                        {
                            existing.MidtermScore = mid;
                            existing.FinalScore = fin;
                        }
                        else
                        {
                            // Insert
                            db.Grades.InsertOnSubmit(new Grade
                            {
                                StudentID = studentID,
                                SubjectID = subjectID,
                                MidtermScore = mid,
                                FinalScore = fin
                            });
                        }
                        savedCount++;
                    }
                    db.SubmitChanges();
                }
                MessageBox.Show($"Lưu thành công {savedCount} bản ghi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStats_Click(object sender, EventArgs e)
        {
            var scores = new List<decimal>();

            foreach (DataGridViewRow row in dgvGrade.Rows)
            {
                if (row.IsNewRow) continue;
                if (decimal.TryParse(row.Cells["TotalScore"].Value?.ToString(), out decimal total))
                    scores.Add(total);
            }

            if (scores.Count == 0)
            {
                MessageBox.Show("Chưa có điểm để thống kê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int pass = scores.Count(s => s >= 5);
            int fail = scores.Count(s => s < 5);
            decimal avg = Math.Round(scores.Average(), 2);
            decimal max = scores.Max();
            decimal min = scores.Min();

            // Tìm tên sinh viên cao nhất / thấp nhất
            string maxName = "", minName = "";
            foreach (DataGridViewRow row in dgvGrade.Rows)
            {
                if (row.IsNewRow) continue;
                if (!decimal.TryParse(row.Cells["TotalScore"].Value?.ToString(), out decimal s)) continue;
                if (s == max && maxName == "") maxName = row.Cells["FullName"].Value.ToString();
                if (s == min && minName == "") minName = row.Cells["FullName"].Value.ToString();
            }

            string msg = $"Lớp: {cboClass.Text} — Môn: {cboSubject.Text}\n\n"
                       + $"Số SV có điểm : {scores.Count}\n"
                       + $"Đạt (≥ 5)     : {pass} SV\n"
                       + $"Trượt (< 5)   : {fail} SV\n"
                       + $"Điểm TB       : {avg}\n"
                       + $"Cao nhất      : {max} — {maxName}\n"
                       + $"Thấp nhất     : {min} — {minName}";

            MessageBox.Show(msg, "Thống kê điểm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
