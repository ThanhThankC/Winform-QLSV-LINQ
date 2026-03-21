namespace QuanLySinhVienApp
{
    partial class usClasses
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.labelClassName = new System.Windows.Forms.Label();
            this.dgvClasses = new System.Windows.Forms.DataGridView();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtClassID = new System.Windows.Forms.TextBox();
            this.lblClassID = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasses)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.SystemColors.Menu;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(268, 69);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(573, 27);
            this.txtSearch.TabIndex = 28;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblSearch.Location = new System.Drawing.Point(163, 71);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(85, 23);
            this.lblSearch.TabIndex = 27;
            this.lblSearch.Text = "Tìm kiếm";
            // 
            // txtClassName
            // 
            this.txtClassName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClassName.Location = new System.Drawing.Point(582, 124);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(259, 30);
            this.txtClassName.TabIndex = 26;
            this.txtClassName.TextChanged += new System.EventHandler(this.txtClassName_TextChanged);
            // 
            // labelClassName
            // 
            this.labelClassName.AutoSize = true;
            this.labelClassName.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClassName.Location = new System.Drawing.Point(495, 127);
            this.labelClassName.Name = "labelClassName";
            this.labelClassName.Size = new System.Drawing.Size(81, 27);
            this.labelClassName.TabIndex = 25;
            this.labelClassName.Text = "Tên lớp";
            // 
            // dgvClasses
            // 
            this.dgvClasses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClasses.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvClasses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClasses.Location = new System.Drawing.Point(168, 256);
            this.dgvClasses.Name = "dgvClasses";
            this.dgvClasses.RowHeadersWidth = 51;
            this.dgvClasses.RowTemplate.Height = 24;
            this.dgvClasses.Size = new System.Drawing.Size(673, 209);
            this.dgvClasses.TabIndex = 24;
            this.dgvClasses.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClasses_CellClick);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(706, 179);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(135, 40);
            this.btnClear.TabIndex = 22;
            this.btnClear.Text = "Làm mới";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(532, 179);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(135, 40);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnEdit.Location = new System.Drawing.Point(350, 179);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(135, 40);
            this.btnEdit.TabIndex = 20;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnAdd.Location = new System.Drawing.Point(168, 179);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(135, 40);
            this.btnAdd.TabIndex = 19;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtClassID
            // 
            this.txtClassID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClassID.Location = new System.Drawing.Point(250, 123);
            this.txtClassID.Name = "txtClassID";
            this.txtClassID.Size = new System.Drawing.Size(216, 30);
            this.txtClassID.TabIndex = 18;
            this.txtClassID.TextChanged += new System.EventHandler(this.txtClassID_TextChanged);
            // 
            // lblClassID
            // 
            this.lblClassID.AutoSize = true;
            this.lblClassID.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassID.Location = new System.Drawing.Point(163, 126);
            this.lblClassID.Name = "lblClassID";
            this.lblClassID.Size = new System.Drawing.Size(78, 27);
            this.lblClassID.TabIndex = 17;
            this.lblClassID.Text = "Mã lớp";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(358, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(288, 39);
            this.lblTitle.TabIndex = 16;
            this.lblTitle.Text = "QUẢN LÝ LỚP HỌC";
            // 
            // usClasses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtClassName);
            this.Controls.Add(this.labelClassName);
            this.Controls.Add(this.dgvClasses);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtClassID);
            this.Controls.Add(this.lblClassID);
            this.Controls.Add(this.lblTitle);
            this.Name = "usClasses";
            this.Size = new System.Drawing.Size(931, 544);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Label labelClassName;
        private System.Windows.Forms.DataGridView dgvClasses;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtClassID;
        private System.Windows.Forms.Label lblClassID;
        private System.Windows.Forms.Label lblTitle;
    }
}
