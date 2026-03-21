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
            this.tabClasses = new System.Windows.Forms.TabPage();
            this.tabLogout = new System.Windows.Forms.TabPage();
            this.usStudents1 = new QuanLySinhVienApp.usStudents();
            this.usClasses1 = new QuanLySinhVienApp.usClasses();
            this.tabMain.SuspendLayout();
            this.tabStudents.SuspendLayout();
            this.tabClasses.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabStudents);
            this.tabMain.Controls.Add(this.tabClasses);
            this.tabMain.Controls.Add(this.tabLogout);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.ItemSize = new System.Drawing.Size(200, 35);
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1052, 753);
            this.tabMain.TabIndex = 8;
            this.tabMain.SelectedIndexChanged += new System.EventHandler(this.tabMain_SelectedIndexChanged);
            // 
            // tabStudents
            // 
            this.tabStudents.Controls.Add(this.usStudents1);
            this.tabStudents.Location = new System.Drawing.Point(4, 39);
            this.tabStudents.Name = "tabStudents";
            this.tabStudents.Padding = new System.Windows.Forms.Padding(3);
            this.tabStudents.Size = new System.Drawing.Size(1044, 710);
            this.tabStudents.TabIndex = 0;
            this.tabStudents.Text = "Sinh viên";
            this.tabStudents.UseVisualStyleBackColor = true;
            // 
            // tabClasses
            // 
            this.tabClasses.Controls.Add(this.usClasses1);
            this.tabClasses.Location = new System.Drawing.Point(4, 39);
            this.tabClasses.Name = "tabClasses";
            this.tabClasses.Padding = new System.Windows.Forms.Padding(3);
            this.tabClasses.Size = new System.Drawing.Size(1044, 710);
            this.tabClasses.TabIndex = 1;
            this.tabClasses.Text = "Lớp học";
            this.tabClasses.UseVisualStyleBackColor = true;
            // 
            // tabLogout
            // 
            this.tabLogout.Location = new System.Drawing.Point(4, 39);
            this.tabLogout.Name = "tabLogout";
            this.tabLogout.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogout.Size = new System.Drawing.Size(1044, 710);
            this.tabLogout.TabIndex = 2;
            this.tabLogout.Text = "Đăng xuất";
            this.tabLogout.UseVisualStyleBackColor = true;
            // 
            // usStudents1
            // 
            this.usStudents1.Location = new System.Drawing.Point(0, 0);
            this.usStudents1.Name = "usStudents1";
            this.usStudents1.Size = new System.Drawing.Size(1044, 714);
            this.usStudents1.TabIndex = 0;
            // 
            // usClasses1
            // 
            this.usClasses1.Location = new System.Drawing.Point(0, 0);
            this.usClasses1.Name = "usClasses1";
            this.usClasses1.Size = new System.Drawing.Size(997, 588);
            this.usClasses1.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 753);
            this.Controls.Add(this.tabMain);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.tabMain.ResumeLayout(false);
            this.tabStudents.ResumeLayout(false);
            this.tabClasses.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabStudents;
        private System.Windows.Forms.TabPage tabClasses;
        private System.Windows.Forms.TabPage tabLogout;
        private usStudents usStudents1;
        private usClasses usClasses1;
    }
}