namespace VietBaIT.LABLink.Reports.Form_GTVT
{
    partial class frm_GTVT_BAOCAO_SOLUONG_LOAIXETNGHIEM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_GTVT_BAOCAO_SOLUONG_LOAIXETNGHIEM));
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem4 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem5 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem6 = new Janus.Windows.EditControls.UIComboBoxItem();
            this.sysColor = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmdINPHIEU = new Janus.Windows.EditControls.UIButton();
            this.cmdExit = new Janus.Windows.EditControls.UIButton();
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.chkTongLoaiXN = new Janus.Windows.EditControls.UICheckBox();
            this.chkTongKhoa = new Janus.Windows.EditControls.UICheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboLoaiXetnghiem = new System.Windows.Forms.ComboBox();
            this.cboHos_Status = new Janus.Windows.EditControls.UIComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboObjectType = new System.Windows.Forms.ComboBox();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.dtToDate = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.dtFromDate = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.chkFormDate = new Janus.Windows.EditControls.UICheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtCreatePrint = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.sysColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sysColor
            // 
            this.sysColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.sysColor.Controls.Add(this.label3);
            this.sysColor.Controls.Add(this.lblMessage);
            this.sysColor.Controls.Add(this.pictureBox1);
            this.sysColor.Dock = System.Windows.Forms.DockStyle.Top;
            this.sysColor.Location = new System.Drawing.Point(0, 0);
            this.sysColor.Name = "sysColor";
            this.sysColor.Size = new System.Drawing.Size(466, 71);
            this.sysColor.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(130, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(250, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Bạn có thể dùng phím tắt để thao tác )";
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(73, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(393, 52);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "BÁO CÁO TỔNG HỢP  SỐ LƯỢNG LOẠI XÉT NGHIỆM";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 52);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // cmdINPHIEU
            // 
            this.cmdINPHIEU.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdINPHIEU.Image = ((System.Drawing.Image)(resources.GetObject("cmdINPHIEU.Image")));
            this.cmdINPHIEU.Location = new System.Drawing.Point(144, 294);
            this.cmdINPHIEU.Name = "cmdINPHIEU";
            this.cmdINPHIEU.Size = new System.Drawing.Size(129, 30);
            this.cmdINPHIEU.TabIndex = 12;
            this.cmdINPHIEU.Text = "&In báo cáo(F4)";
            this.cmdINPHIEU.ToolTipText = "In báo (Bạn có thể nhấn F4 thực hiện in báo cáo)";
            this.cmdINPHIEU.Click += new System.EventHandler(this.cmdINPHIEU_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExit.Image = ((System.Drawing.Image)(resources.GetObject("cmdExit.Image")));
            this.cmdExit.Location = new System.Drawing.Point(279, 294);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(119, 30);
            this.cmdExit.TabIndex = 13;
            this.cmdExit.Text = "&Thoát(Esc)";
            this.cmdExit.ToolTipText = "Thoát khỏi Form hiện tại";
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.label7);
            this.uiGroupBox1.Controls.Add(this.dtCreatePrint);
            this.uiGroupBox1.Controls.Add(this.dtToDate);
            this.uiGroupBox1.Controls.Add(this.dtFromDate);
            this.uiGroupBox1.Controls.Add(this.chkFormDate);
            this.uiGroupBox1.Controls.Add(this.cboDepartment);
            this.uiGroupBox1.Controls.Add(this.chkTongLoaiXN);
            this.uiGroupBox1.Controls.Add(this.chkTongKhoa);
            this.uiGroupBox1.Controls.Add(this.label2);
            this.uiGroupBox1.Controls.Add(this.cboLoaiXetnghiem);
            this.uiGroupBox1.Controls.Add(this.cboHos_Status);
            this.uiGroupBox1.Controls.Add(this.label6);
            this.uiGroupBox1.Controls.Add(this.label1);
            this.uiGroupBox1.Controls.Add(this.label5);
            this.uiGroupBox1.Controls.Add(this.cboObjectType);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiGroupBox1.Image = ((System.Drawing.Image)(resources.GetObject("uiGroupBox1.Image")));
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 71);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(466, 215);
            this.uiGroupBox1.TabIndex = 16;
            this.uiGroupBox1.Text = "&Thông tin điều kiện tìm kiếm";
            // 
            // chkTongLoaiXN
            // 
            this.chkTongLoaiXN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTongLoaiXN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.chkTongLoaiXN.Location = new System.Drawing.Point(144, 160);
            this.chkTongLoaiXN.Name = "chkTongLoaiXN";
            this.chkTongLoaiXN.Size = new System.Drawing.Size(310, 23);
            this.chkTongLoaiXN.TabIndex = 19;
            this.chkTongLoaiXN.Text = "&Báo cáo theo tổng loại xét nghiệm";
            // 
            // chkTongKhoa
            // 
            this.chkTongKhoa.ForeColor = System.Drawing.Color.Red;
            this.chkTongKhoa.Location = new System.Drawing.Point(306, 185);
            this.chkTongKhoa.Name = "chkTongKhoa";
            this.chkTongKhoa.Size = new System.Drawing.Size(152, 23);
            this.chkTongKhoa.TabIndex = 17;
            this.chkTongKhoa.Text = "&Báo cáo theo tổng";
            this.chkTongKhoa.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "&Loại xét nghiệm";
            // 
            // cboLoaiXetnghiem
            // 
            this.cboLoaiXetnghiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiXetnghiem.FormattingEnabled = true;
            this.cboLoaiXetnghiem.Location = new System.Drawing.Point(144, 105);
            this.cboLoaiXetnghiem.Name = "cboLoaiXetnghiem";
            this.cboLoaiXetnghiem.Size = new System.Drawing.Size(315, 23);
            this.cboLoaiXetnghiem.TabIndex = 17;
            // 
            // cboHos_Status
            // 
            this.cboHos_Status.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            uiComboBoxItem4.FormatStyle.Alpha = 0;
            uiComboBoxItem4.IsSeparator = false;
            uiComboBoxItem4.Text = "Ngoại trú";
            uiComboBoxItem4.Value = 0;
            uiComboBoxItem5.FormatStyle.Alpha = 0;
            uiComboBoxItem5.IsSeparator = false;
            uiComboBoxItem5.Text = "Nội trú";
            uiComboBoxItem5.Value = 1;
            uiComboBoxItem6.FormatStyle.Alpha = 0;
            uiComboBoxItem6.IsSeparator = false;
            uiComboBoxItem6.Text = "Tất cả";
            uiComboBoxItem6.Value = -1;
            this.cboHos_Status.Items.AddRange(new Janus.Windows.EditControls.UIComboBoxItem[] {
            uiComboBoxItem4,
            uiComboBoxItem5,
            uiComboBoxItem6});
            this.cboHos_Status.Location = new System.Drawing.Point(144, 134);
            this.cboHos_Status.Name = "cboHos_Status";
            this.cboHos_Status.Size = new System.Drawing.Size(315, 21);
            this.cboHos_Status.TabIndex = 16;
            this.cboHos_Status.Text = "Tình trạng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(68, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "&Tình trạng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(100, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "&Khoa";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(71, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "&Đối tượng";
            // 
            // cboObjectType
            // 
            this.cboObjectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboObjectType.FormattingEnabled = true;
            this.cboObjectType.Location = new System.Drawing.Point(144, 76);
            this.cboObjectType.Name = "cboObjectType";
            this.cboObjectType.Size = new System.Drawing.Size(315, 23);
            this.cboObjectType.TabIndex = 5;
            // 
            // cboDepartment
            // 
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(144, 49);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(315, 23);
            this.cboDepartment.TabIndex = 20;
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd/MM/yyyy";
            this.dtToDate.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtToDate.DropDownCalendar.Name = "";
            this.dtToDate.Location = new System.Drawing.Point(302, 22);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.ShowUpDown = true;
            this.dtToDate.Size = new System.Drawing.Size(157, 21);
            this.dtToDate.TabIndex = 23;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtFromDate.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtFromDate.DropDownCalendar.Name = "";
            this.dtFromDate.Location = new System.Drawing.Point(144, 22);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.ShowUpDown = true;
            this.dtFromDate.Size = new System.Drawing.Size(152, 21);
            this.dtFromDate.TabIndex = 22;
            // 
            // chkFormDate
            // 
            this.chkFormDate.Checked = true;
            this.chkFormDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFormDate.Image = ((System.Drawing.Image)(resources.GetObject("chkFormDate.Image")));
            this.chkFormDate.Location = new System.Drawing.Point(48, 22);
            this.chkFormDate.Name = "chkFormDate";
            this.chkFormDate.Size = new System.Drawing.Size(92, 23);
            this.chkFormDate.TabIndex = 21;
            this.chkFormDate.Text = "&Từ ngày";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(60, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 15);
            this.label7.TabIndex = 25;
            this.label7.Text = "&Chọn ngày in ";
            // 
            // dtCreatePrint
            // 
            this.dtCreatePrint.CustomFormat = "dd/MM/yyyy";
            this.dtCreatePrint.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtCreatePrint.DropDownCalendar.Name = "";
            this.dtCreatePrint.Location = new System.Drawing.Point(147, 185);
            this.dtCreatePrint.Name = "dtCreatePrint";
            this.dtCreatePrint.ShowUpDown = true;
            this.dtCreatePrint.Size = new System.Drawing.Size(152, 21);
            this.dtCreatePrint.TabIndex = 24;
            // 
            // frm_GTVT_BAOCAO_SOLUONG_LOAIXETNGHIEM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 330);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.cmdINPHIEU);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.sysColor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_GTVT_BAOCAO_SOLUONG_LOAIXETNGHIEM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BÁO CÁO THEO SỐ LƯỢNG LOẠI XÉT NGHIỆM";
            this.Load += new System.EventHandler(this.frm_GTVT_BAOCAO_SOLUONG_LOAIXETNGHIEM_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_GTVT_BAOCAO_SOLUONG_LOAIXETNGHIEM_KeyDown);
            this.sysColor.ResumeLayout(false);
            this.sysColor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel sysColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Janus.Windows.EditControls.UIButton cmdINPHIEU;
        private Janus.Windows.EditControls.UIButton cmdExit;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private Janus.Windows.EditControls.UIComboBox cboHos_Status;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboObjectType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboLoaiXetnghiem;
        private Janus.Windows.EditControls.UICheckBox chkTongKhoa;
        private Janus.Windows.EditControls.UICheckBox chkTongLoaiXN;
        private System.Windows.Forms.ComboBox cboDepartment;
        private Janus.Windows.CalendarCombo.CalendarCombo dtToDate;
        private Janus.Windows.CalendarCombo.CalendarCombo dtFromDate;
        private Janus.Windows.EditControls.UICheckBox chkFormDate;
        private System.Windows.Forms.Label label7;
        private Janus.Windows.CalendarCombo.CalendarCombo dtCreatePrint;
    }
}