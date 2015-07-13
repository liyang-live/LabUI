namespace VietBaIT.LABLink.Reports.Forms
{
    partial class frm_BaoCaoDanhSachBenhNhan_TestType
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
            Janus.Windows.GridEX.GridEXLayout gridResult_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_BaoCaoDanhSachBenhNhan_TestType));
            this.gridResult = new Janus.Windows.GridEX.GridEX();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.uiGroupBox2 = new Janus.Windows.EditControls.UIGroupBox();
            this.chkTongBNHoanTatXN = new Janus.Windows.EditControls.UICheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPrint = new Janus.Windows.EditControls.UIButton();
            this.label4 = new System.Windows.Forms.Label();
            this.dtCreatePrint = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTestType = new System.Windows.Forms.ComboBox();
            this.cmdCancel = new Janus.Windows.EditControls.UIButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdReport = new Janus.Windows.EditControls.UIButton();
            this.dtpToDate = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.dtpFromDate = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.sysColor = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridResult)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).BeginInit();
            this.uiGroupBox2.SuspendLayout();
            this.sysColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridResult
            // 
            this.gridResult.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gridResult.DefaultFilterRowComparison = Janus.Windows.GridEX.FilterConditionOperator.Contains;
            gridResult_DesignTimeLayout.LayoutString = resources.GetString("gridResult_DesignTimeLayout.LayoutString");
            this.gridResult.DesignTimeLayout = gridResult_DesignTimeLayout;
            this.gridResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridResult.DynamicFiltering = true;
            this.gridResult.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gridResult.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.gridResult.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.gridResult.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridResult.FrozenColumns = 2;
            this.gridResult.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gridResult.GroupByBoxVisible = false;
            this.gridResult.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.gridResult.Location = new System.Drawing.Point(0, 218);
            this.gridResult.Name = "gridResult";
            this.gridResult.RecordNavigator = true;
            this.gridResult.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gridResult.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridResult.Size = new System.Drawing.Size(875, 309);
            this.gridResult.TabIndex = 25;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.uiGroupBox2);
            this.groupBox2.Controls.Add(this.sysColor);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(875, 218);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.chkTongBNHoanTatXN);
            this.uiGroupBox2.Controls.Add(this.label5);
            this.uiGroupBox2.Controls.Add(this.btnPrint);
            this.uiGroupBox2.Controls.Add(this.label4);
            this.uiGroupBox2.Controls.Add(this.dtCreatePrint);
            this.uiGroupBox2.Controls.Add(this.label1);
            this.uiGroupBox2.Controls.Add(this.label3);
            this.uiGroupBox2.Controls.Add(this.cboTestType);
            this.uiGroupBox2.Controls.Add(this.cmdCancel);
            this.uiGroupBox2.Controls.Add(this.label2);
            this.uiGroupBox2.Controls.Add(this.cmdReport);
            this.uiGroupBox2.Controls.Add(this.dtpToDate);
            this.uiGroupBox2.Controls.Add(this.dtpFromDate);
            this.uiGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiGroupBox2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiGroupBox2.Image = ((System.Drawing.Image)(resources.GetObject("uiGroupBox2.Image")));
            this.uiGroupBox2.Location = new System.Drawing.Point(3, 73);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Size = new System.Drawing.Size(869, 142);
            this.uiGroupBox2.TabIndex = 86;
            this.uiGroupBox2.Text = "Thông tin tìm kiếm";
            // 
            // chkTongBNHoanTatXN
            // 
            this.chkTongBNHoanTatXN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTongBNHoanTatXN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.chkTongBNHoanTatXN.Location = new System.Drawing.Point(76, 74);
            this.chkTongBNHoanTatXN.Name = "chkTongBNHoanTatXN";
            this.chkTongBNHoanTatXN.Size = new System.Drawing.Size(323, 25);
            this.chkTongBNHoanTatXN.TabIndex = 80;
            this.chkTongBNHoanTatXN.Text = "Báo cáo danh sách bệnh nhân đã hoàn tất XN";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(542, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(232, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "(Chọn loại xét nghiệm để thống kê)";
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageSize = new System.Drawing.Size(24, 24);
            this.btnPrint.Location = new System.Drawing.Point(238, 103);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(157, 29);
            this.btnPrint.TabIndex = 67;
            this.btnPrint.Text = "In Báo cáo (F2)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 66;
            this.label4.Text = "Ngày in";
            // 
            // dtCreatePrint
            // 
            this.dtCreatePrint.CustomFormat = "dd/MM/yyyy";
            this.dtCreatePrint.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtCreatePrint.DropDownCalendar.Name = "";
            this.dtCreatePrint.Location = new System.Drawing.Point(76, 49);
            this.dtCreatePrint.Name = "dtCreatePrint";
            this.dtCreatePrint.ShowUpDown = true;
            this.dtCreatePrint.Size = new System.Drawing.Size(175, 22);
            this.dtCreatePrint.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(255, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 75;
            this.label1.Text = "Loại xét nghiệm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(292, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 79;
            this.label3.Text = "Đến ngày";
            // 
            // cboTestType
            // 
            this.cboTestType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTestType.FormattingEnabled = true;
            this.cboTestType.Location = new System.Drawing.Point(361, 45);
            this.cboTestType.Name = "cboTestType";
            this.cboTestType.Size = new System.Drawing.Size(175, 24);
            this.cboTestType.TabIndex = 74;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.ImageSize = new System.Drawing.Size(24, 24);
            this.cmdCancel.Location = new System.Drawing.Point(401, 103);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(157, 29);
            this.cmdCancel.TabIndex = 14;
            this.cmdCancel.Text = "Thoát (Esc)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 78;
            this.label2.Text = "Từ ngày";
            // 
            // cmdReport
            // 
            this.cmdReport.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdReport.Image = ((System.Drawing.Image)(resources.GetObject("cmdReport.Image")));
            this.cmdReport.ImageSize = new System.Drawing.Size(24, 24);
            this.cmdReport.Location = new System.Drawing.Point(75, 103);
            this.cmdReport.Name = "cmdReport";
            this.cmdReport.Size = new System.Drawing.Size(157, 29);
            this.cmdReport.TabIndex = 13;
            this.cmdReport.Text = "Xem Báo cáo (F1)";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtpToDate.DropDownCalendar.Name = "";
            this.dtpToDate.Location = new System.Drawing.Point(361, 19);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.ShowUpDown = true;
            this.dtpToDate.Size = new System.Drawing.Size(175, 22);
            this.dtpToDate.TabIndex = 77;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtpFromDate.DropDownCalendar.Name = "";
            this.dtpFromDate.Location = new System.Drawing.Point(76, 21);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.ShowUpDown = true;
            this.dtpFromDate.Size = new System.Drawing.Size(175, 22);
            this.dtpFromDate.TabIndex = 76;
            // 
            // sysColor
            // 
            this.sysColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.sysColor.Controls.Add(this.pictureBox1);
            this.sysColor.Controls.Add(this.label6);
            this.sysColor.Controls.Add(this.label7);
            this.sysColor.Dock = System.Windows.Forms.DockStyle.Top;
            this.sysColor.Location = new System.Drawing.Point(3, 18);
            this.sysColor.Name = "sysColor";
            this.sysColor.Size = new System.Drawing.Size(869, 55);
            this.sysColor.TabIndex = 82;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(350, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(213, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Bạn có thể dùng phím tắt để thao tác )";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(217, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(437, 32);
            this.label7.TabIndex = 1;
            this.label7.Text = "DANH SÁCH BỆNH NHÂN THEO XÉT NGHIỆM";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 52);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // frm_BaoCaoDanhSachBenhNhan_TestType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 527);
            this.Controls.Add(this.gridResult);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_BaoCaoDanhSachBenhNhan_TestType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo số lượng bệnh nhân";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_DanhSachBenhNhan_TestType_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_DanhSachBenhNhan_TestType_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridResult)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).EndInit();
            this.uiGroupBox2.ResumeLayout(false);
            this.uiGroupBox2.PerformLayout();
            this.sysColor.ResumeLayout(false);
            this.sysColor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.GridEX.GridEX gridResult;
        private System.Windows.Forms.GroupBox groupBox2;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox2;
        private Janus.Windows.EditControls.UICheckBox chkTongBNHoanTatXN;
        private System.Windows.Forms.Label label5;
        private Janus.Windows.EditControls.UIButton btnPrint;
        private System.Windows.Forms.Label label4;
        private Janus.Windows.CalendarCombo.CalendarCombo dtCreatePrint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboTestType;
        private Janus.Windows.EditControls.UIButton cmdCancel;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.EditControls.UIButton cmdReport;
        private Janus.Windows.CalendarCombo.CalendarCombo dtpToDate;
        private Janus.Windows.CalendarCombo.CalendarCombo dtpFromDate;
        private System.Windows.Forms.Panel sysColor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;




    }
}