namespace Lis.GiaoDien.Forms
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.txtAge = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtSex = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.cmdUpdatePatient = new System.Windows.Forms.ToolStripButton();
            this.cmdPrintbarcode = new System.Windows.Forms.ToolStripButton();
            this.cmd_InPhieu_ChiDinh = new System.Windows.Forms.ToolStripButton();
            this.cmdEscape = new System.Windows.Forms.ToolStripButton();
            this.dtpDatePrint = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label1 = new System.Windows.Forms.Label();
            this.chkA5 = new System.Windows.Forms.CheckBox();
            this.chkA4 = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAge
            // 
            this.txtAge.Enabled = false;
            this.txtAge.Location = new System.Drawing.Point(677, 331);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(85, 20);
            this.txtAge.TabIndex = 22;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(638, 334);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(31, 13);
            this.Label4.TabIndex = 21;
            this.Label4.Text = "Tuổi:";
            // 
            // txtPatientName
            // 
            this.txtPatientName.Enabled = false;
            this.txtPatientName.Location = new System.Drawing.Point(441, 328);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(191, 20);
            this.txtPatientName.TabIndex = 20;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(363, 328);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(57, 13);
            this.Label3.TabIndex = 19;
            this.Label3.Text = "Họ và tên:";
            // 
            // txtSex
            // 
            this.txtSex.Enabled = false;
            this.txtSex.Location = new System.Drawing.Point(441, 356);
            this.txtSex.Name = "txtSex";
            this.txtSex.Size = new System.Drawing.Size(191, 20);
            this.txtSex.TabIndex = 18;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(364, 359);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(54, 13);
            this.Label2.TabIndex = 17;
            this.Label2.Text = "Giới Tính:";
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.cmdUpdatePatient,
            this.cmdPrintbarcode,
            this.cmd_InPhieu_ChiDinh,
            this.cmdEscape});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(1125, 39);
            this.ToolStrip1.TabIndex = 23;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(172, 36);
            this.btnSave.Tag = "";
            this.btnSave.Text = "Lưu thông tin (Ctrl+S)";
            this.btnSave.ToolTipText = "Lưu thông tin (Ctrl+S)";
            // 
            // cmdUpdatePatient
            // 
            this.cmdUpdatePatient.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdUpdatePatient.Image = ((System.Drawing.Image)(resources.GetObject("cmdUpdatePatient.Image")));
            this.cmdUpdatePatient.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdUpdatePatient.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdUpdatePatient.Name = "cmdUpdatePatient";
            this.cmdUpdatePatient.Size = new System.Drawing.Size(150, 36);
            this.cmdUpdatePatient.Tag = "";
            this.cmdUpdatePatient.Text = "Cập nhật BN (Ctrl+U)";
            this.cmdUpdatePatient.ToolTipText = "Cập nhật BN (Ctrl+U)";
            // 
            // cmdPrintbarcode
            // 
            this.cmdPrintbarcode.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPrintbarcode.Image = ((System.Drawing.Image)(resources.GetObject("cmdPrintbarcode.Image")));
            this.cmdPrintbarcode.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdPrintbarcode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdPrintbarcode.Name = "cmdPrintbarcode";
            this.cmdPrintbarcode.Size = new System.Drawing.Size(128, 36);
            this.cmdPrintbarcode.Tag = "";
            this.cmdPrintbarcode.Text = "In Barcode (F9)";
            this.cmdPrintbarcode.ToolTipText = "In Barcode (F9)";
            // 
            // cmd_InPhieu_ChiDinh
            // 
            this.cmd_InPhieu_ChiDinh.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_InPhieu_ChiDinh.Image = ((System.Drawing.Image)(resources.GetObject("cmd_InPhieu_ChiDinh.Image")));
            this.cmd_InPhieu_ChiDinh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmd_InPhieu_ChiDinh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmd_InPhieu_ChiDinh.Name = "cmd_InPhieu_ChiDinh";
            this.cmd_InPhieu_ChiDinh.Size = new System.Drawing.Size(162, 36);
            this.cmd_InPhieu_ChiDinh.Tag = "";
            this.cmd_InPhieu_ChiDinh.Text = "In Phiếu Chỉ Định (F4)";
            this.cmd_InPhieu_ChiDinh.ToolTipText = "In Phiếu Chỉ Định (F4)";
            // 
            // cmdEscape
            // 
            this.cmdEscape.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEscape.Image = ((System.Drawing.Image)(resources.GetObject("cmdEscape.Image")));
            this.cmdEscape.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdEscape.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdEscape.Name = "cmdEscape";
            this.cmdEscape.Size = new System.Drawing.Size(105, 36);
            this.cmdEscape.Tag = "";
            this.cmdEscape.Text = "Thoát (Esc)";
            this.cmdEscape.ToolTipText = "Thoát (Esc)";
            // 
            // dtpDatePrint
            // 
            this.dtpDatePrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtpDatePrint.CustomFormat = "dd/MM/yyyy";
            this.dtpDatePrint.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtpDatePrint.DropDownCalendar.FirstMonth = new System.DateTime(2013, 12, 1, 0, 0, 0, 0);
            this.dtpDatePrint.DropDownCalendar.Name = "";
            this.dtpDatePrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDatePrint.Location = new System.Drawing.Point(642, 189);
            this.dtpDatePrint.Name = "dtpDatePrint";
            this.dtpDatePrint.ShowUpDown = true;
            this.dtpDatePrint.Size = new System.Drawing.Size(120, 23);
            this.dtpDatePrint.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(538, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 19);
            this.label1.TabIndex = 27;
            this.label1.Text = "Chọn ngày in:";
            // 
            // chkA5
            // 
            this.chkA5.AutoSize = true;
            this.chkA5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.chkA5.ForeColor = System.Drawing.Color.Blue;
            this.chkA5.Location = new System.Drawing.Point(484, 190);
            this.chkA5.Name = "chkA5";
            this.chkA5.Size = new System.Drawing.Size(45, 20);
            this.chkA5.TabIndex = 26;
            this.chkA5.Text = "A5";
            this.chkA5.UseVisualStyleBackColor = true;
            // 
            // chkA4
            // 
            this.chkA4.AutoSize = true;
            this.chkA4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.chkA4.Location = new System.Drawing.Point(442, 190);
            this.chkA4.Name = "chkA4";
            this.chkA4.Size = new System.Drawing.Size(45, 20);
            this.chkA4.TabIndex = 25;
            this.chkA4.Text = "A4";
            this.chkA4.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label14.Location = new System.Drawing.Point(346, 189);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 19);
            this.label14.TabIndex = 24;
            this.label14.Text = "Chọn khổ in:";
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 705);
            this.Controls.Add(this.dtpDatePrint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkA5);
            this.Controls.Add(this.chkA4);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.txtPatientName);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtSex);
            this.Controls.Add(this.Label2);
            this.Name = "Form5";
            this.Text = "Form5";
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtAge;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtPatientName;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtSex;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton btnSave;
        internal System.Windows.Forms.ToolStripButton cmdUpdatePatient;
        internal System.Windows.Forms.ToolStripButton cmdPrintbarcode;
        internal System.Windows.Forms.ToolStripButton cmd_InPhieu_ChiDinh;
        internal System.Windows.Forms.ToolStripButton cmdEscape;
        internal Janus.Windows.CalendarCombo.CalendarCombo dtpDatePrint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkA5;
        private System.Windows.Forms.CheckBox chkA4;
        private System.Windows.Forms.Label label14;




    }
}