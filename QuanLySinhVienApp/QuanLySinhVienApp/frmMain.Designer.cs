namespace QuanLySinhVienApp
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabStudents = new System.Windows.Forms.TabPage();
            this.usStudents2 = new QuanLySinhVienApp.usStudents();
            this.tabClasses = new System.Windows.Forms.TabPage();
            this.usClasses1 = new QuanLySinhVienApp.usClasses();
            this.tabSubject = new System.Windows.Forms.TabPage();
            this.tabGrade = new System.Windows.Forms.TabPage();
            this.tabLogout = new System.Windows.Forms.TabPage();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.tabMain.SuspendLayout();
            this.tabStudents.SuspendLayout();
            this.tabClasses.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Controls.Add(this.tabStudents);
            this.tabMain.Controls.Add(this.tabClasses);
            this.tabMain.Controls.Add(this.tabSubject);
            this.tabMain.Controls.Add(this.tabGrade);
            this.tabMain.Controls.Add(this.tabLogout);
            this.tabMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMain.ItemSize = new System.Drawing.Size(200, 45);
            this.tabMain.Location = new System.Drawing.Point(0, 28);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1547, 818);
            this.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMain.TabIndex = 8;
            this.tabMain.SelectedIndexChanged += new System.EventHandler(this.tabMain_SelectedIndexChanged);
            // 
            // tabStudents
            // 
            this.tabStudents.Controls.Add(this.usStudents2);
            this.tabStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabStudents.Location = new System.Drawing.Point(4, 49);
            this.tabStudents.Name = "tabStudents";
            this.tabStudents.Padding = new System.Windows.Forms.Padding(3);
            this.tabStudents.Size = new System.Drawing.Size(1539, 765);
            this.tabStudents.TabIndex = 0;
            this.tabStudents.Text = "Sinh viên";
            this.tabStudents.UseVisualStyleBackColor = true;
            // 
            // usStudents2
            // 
            this.usStudents2.Location = new System.Drawing.Point(115, 142);
            this.usStudents2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.usStudents2.Name = "usStudents2";
            this.usStudents2.Size = new System.Drawing.Size(1472, 895);
            this.usStudents2.TabIndex = 0;
            // 
            // tabClasses
            // 
            this.tabClasses.Controls.Add(this.usClasses1);
            this.tabClasses.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabClasses.Location = new System.Drawing.Point(4, 49);
            this.tabClasses.Name = "tabClasses";
            this.tabClasses.Padding = new System.Windows.Forms.Padding(3);
            this.tabClasses.Size = new System.Drawing.Size(1539, 765);
            this.tabClasses.TabIndex = 1;
            this.tabClasses.Text = "Lớp học";
            this.tabClasses.UseVisualStyleBackColor = true;
            // 
            // usClasses1
            // 
            this.usClasses1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usClasses1.Location = new System.Drawing.Point(3, 3);
            this.usClasses1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.usClasses1.Name = "usClasses1";
            this.usClasses1.Padding = new System.Windows.Forms.Padding(100, 0, 100, 0);
            this.usClasses1.Size = new System.Drawing.Size(1533, 759);
            this.usClasses1.TabIndex = 0;
            // 
            // tabSubject
            // 
            this.tabSubject.Location = new System.Drawing.Point(4, 49);
            this.tabSubject.Name = "tabSubject";
            this.tabSubject.Size = new System.Drawing.Size(1539, 765);
            this.tabSubject.TabIndex = 3;
            this.tabSubject.Text = "Môn Học";
            this.tabSubject.UseVisualStyleBackColor = true;
            // 
            // tabGrade
            // 
            this.tabGrade.Location = new System.Drawing.Point(4, 49);
            this.tabGrade.Name = "tabGrade";
            this.tabGrade.Size = new System.Drawing.Size(1539, 765);
            this.tabGrade.TabIndex = 4;
            this.tabGrade.Text = "Bảng Điểm";
            this.tabGrade.UseVisualStyleBackColor = true;
            // 
            // tabLogout
            // 
            this.tabLogout.Location = new System.Drawing.Point(4, 49);
            this.tabLogout.Name = "tabLogout";
            this.tabLogout.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogout.Size = new System.Drawing.Size(1539, 765);
            this.tabLogout.TabIndex = 2;
            this.tabLogout.Text = "Đăng xuất";
            this.tabLogout.UseVisualStyleBackColor = true;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(0, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(114, 25);
            this.lblWelcome.TabIndex = 9;
            this.lblWelcome.Text = "Xin chào, ...";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1547, 846);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.tabMain);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabMain.ResumeLayout(false);
            this.tabStudents.ResumeLayout(false);
            this.tabClasses.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabStudents;
        private System.Windows.Forms.TabPage tabClasses;
        private System.Windows.Forms.TabPage tabLogout;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.TabPage tabSubject;
        private System.Windows.Forms.TabPage tabGrade;
        private usClasses usClasses1;
        private usStudents usStudents2;
    }
}