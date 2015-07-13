namespace VietBaIT.LABLink.Reports.Forms
{
    partial class frmAllPatientInfoAndResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAllPatientInfoAndResult));
            Janus.Windows.GridEX.GridEXLayout grdAllPatientInfoAndResult_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.sysColor = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpCreatePrint = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.cmdINPHIEU = new Janus.Windows.EditControls.UIButton();
            this.cmdExit = new Janus.Windows.EditControls.UIButton();
            this.dtpFromDate = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.dtpToDate = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.cboTestType = new Janus.Windows.EditControls.UIComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboDevices = new Janus.Windows.EditControls.UIComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboDepartment = new Janus.Windows.EditControls.UIComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboObjectType = new Janus.Windows.EditControls.UIComboBox();
            this.btnExportExcel = new Janus.Windows.EditControls.UIButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grdAllPatientInfoAndResult = new Janus.Windows.GridEX.GridEX();
            this.sysColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAllPatientInfoAndResult)).BeginInit();
            this.SuspendLayout();
            // 
            // sysColor
            // 
            this.sysColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sysColor.Controls.Add(this.label3);
            this.sysColor.Controls.Add(this.lblMessage);
            this.sysColor.Controls.Add(this.pictureBox1);
            this.sysColor.Dock = System.Windows.Forms.DockStyle.Top;
            this.sysColor.Location = new System.Drawing.Point(0, 0);
            this.sysColor.Name = "sysColor";
            this.sysColor.Size = new System.Drawing.Size(1000, 75);
            this.sysColor.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(397, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(250, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Bạn có thể dùng phím tắt để thao tác )";
            // 
            // lblMessage
            // 
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(80, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(920, 26);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "BÁO CÁO CHI TIẾT THÔNG TIN BỆNH NHÂN VÀ KẾT QUẢ";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 75);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 15);
            this.label7.TabIndex = 21;
            this.label7.Text = "&Chọn ngày in ";
            // 
            // dtpCreatePrint
            // 
            this.dtpCreatePrint.CustomFormat = "dd/MM/yyyy";
            this.dtpCreatePrint.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtpCreatePrint.DropDownCalendar.Name = "";
            this.dtpCreatePrint.Location = new System.Drawing.Point(102, 188);
            this.dtpCreatePrint.Name = "dtpCreatePrint";
            this.dtpCreatePrint.ShowUpDown = true;
            this.dtpCreatePrint.Size = new System.Drawing.Size(152, 21);
            this.dtpCreatePrint.TabIndex = 20;
            // 
            // cmdINPHIEU
            // 
            this.cmdINPHIEU.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdINPHIEU.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdINPHIEU.Image = ((System.Drawing.Image)(resources.GetObject("cmdINPHIEU.Image")));
            this.cmdINPHIEU.ImageSize = new System.Drawing.Size(24, 24);
            this.cmdINPHIEU.Location = new System.Drawing.Point(32, 274);
            this.cmdINPHIEU.Name = "cmdINPHIEU";
            this.cmdINPHIEU.Size = new System.Drawing.Size(195, 32);
            this.cmdINPHIEU.TabIndex = 18;
            this.cmdINPHIEU.Text = "&Xem báo cáo(F4)";
            this.cmdINPHIEU.ToolTipText = "In báo (Bạn có thể nhấn F4 thực hiện in báo cáo)";
            this.cmdINPHIEU.Click += new System.EventHandler(this.cmdINPHIEU_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExit.Image = ((System.Drawing.Image)(resources.GetObject("cmdExit.Image")));
            this.cmdExit.ImageSize = new System.Drawing.Size(24, 24);
            this.cmdExit.Location = new System.Drawing.Point(32, 350);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(195, 32);
            this.cmdExit.TabIndex = 19;
            this.cmdExit.Text = "&Thoát(Esc)";
            this.cmdExit.ToolTipText = "Thoát khỏi Form hiện tại";
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtpFromDate.DropDownCalendar.Name = "";
            this.dtpFromDate.DropDownCalendar.Visible = false;
            this.dtpFromDate.Location = new System.Drawing.Point(102, 48);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.ShowUpDown = true;
            this.dtpFromDate.Size = new System.Drawing.Size(152, 21);
            this.dtpFromDate.TabIndex = 8;
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtpToDate.DropDownCalendar.Name = "";
            this.dtpToDate.DropDownCalendar.Visible = false;
            this.dtpToDate.Location = new System.Drawing.Point(102, 76);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.ShowUpDown = true;
            this.dtpToDate.Size = new System.Drawing.Size(152, 21);
            this.dtpToDate.TabIndex = 9;
            // 
            // cboTestType
            // 
            this.cboTestType.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cboTestType.Location = new System.Drawing.Point(102, 20);
            this.cboTestType.Name = "cboTestType";
            this.cboTestType.Size = new System.Drawing.Size(152, 21);
            this.cboTestType.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "&Loại XN";
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.label8);
            this.uiGroupBox1.Controls.Add(this.cboDevices);
            this.uiGroupBox1.Controls.Add(this.label6);
            this.uiGroupBox1.Controls.Add(this.cboDepartment);
            this.uiGroupBox1.Controls.Add(this.label5);
            this.uiGroupBox1.Controls.Add(this.cboObjectType);
            this.uiGroupBox1.Controls.Add(this.btnExportExcel);
            this.uiGroupBox1.Controls.Add(this.cmdExit);
            this.uiGroupBox1.Controls.Add(this.cmdINPHIEU);
            this.uiGroupBox1.Controls.Add(this.label7);
            this.uiGroupBox1.Controls.Add(this.label4);
            this.uiGroupBox1.Controls.Add(this.dtpCreatePrint);
            this.uiGroupBox1.Controls.Add(this.label2);
            this.uiGroupBox1.Controls.Add(this.label1);
            this.uiGroupBox1.Controls.Add(this.cboTestType);
            this.uiGroupBox1.Controls.Add(this.dtpToDate);
            this.uiGroupBox1.Controls.Add(this.dtpFromDate);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiGroupBox1.Image = ((System.Drawing.Image)(resources.GetObject("uiGroupBox1.Image")));
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 75);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(265, 394);
            this.uiGroupBox1.TabIndex = 17;
            this.uiGroupBox1.Text = "&Thông tin điều kiện tìm kiếm";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 15);
            this.label8.TabIndex = 28;
            this.label8.Text = "&Thiết bị";
            // 
            // cboDevices
            // 
            this.cboDevices.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cboDevices.Location = new System.Drawing.Point(102, 160);
            this.cboDevices.Name = "cboDevices";
            this.cboDevices.Size = new System.Drawing.Size(152, 21);
            this.cboDevices.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 15);
            this.label6.TabIndex = 26;
            this.label6.Text = "&Khoa";
            // 
            // cboDepartment
            // 
            this.cboDepartment.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cboDepartment.Location = new System.Drawing.Point(102, 132);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(152, 21);
            this.cboDepartment.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 15);
            this.label5.TabIndex = 24;
            this.label5.Text = "&Đối tượng";
            // 
            // cboObjectType
            // 
            this.cboObjectType.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cboObjectType.Location = new System.Drawing.Point(102, 104);
            this.cboObjectType.Name = "cboObjectType";
            this.cboObjectType.Size = new System.Drawing.Size(152, 21);
            this.cboObjectType.TabIndex = 23;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportExcel.Image")));
            this.btnExportExcel.ImageSize = new System.Drawing.Size(24, 24);
            this.btnExportExcel.Location = new System.Drawing.Point(32, 312);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(195, 32);
            this.btnExportExcel.TabIndex = 22;
            this.btnExportExcel.Text = "&Xuất Excel (F5)";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 15);
            this.label4.TabIndex = 19;
            this.label4.Text = "&Đến Ngày";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "&Từ Ngày";
            // 
            // grdAllPatientInfoAndResult
            // 
            this.grdAllPatientInfoAndResult.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdAllPatientInfoAndResult.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><RecordNavigator>Vị Tr" +
    "í: |Tống Số:</RecordNavigator></LocalizableData>";
            this.grdAllPatientInfoAndResult.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet;
            grdAllPatientInfoAndResult_DesignTimeLayout.LayoutString = resources.GetString("grdAllPatientInfoAndResult_DesignTimeLayout.LayoutString");
            this.grdAllPatientInfoAndResult.DesignTimeLayout = grdAllPatientInfoAndResult_DesignTimeLayout;
            this.grdAllPatientInfoAndResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAllPatientInfoAndResult.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdAllPatientInfoAndResult.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdAllPatientInfoAndResult.FilterRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grdAllPatientInfoAndResult.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdAllPatientInfoAndResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.grdAllPatientInfoAndResult.FrozenColumns = 1;
            this.grdAllPatientInfoAndResult.GroupByBoxVisible = false;
            this.grdAllPatientInfoAndResult.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdAllPatientInfoAndResult.Location = new System.Drawing.Point(265, 75);
            this.grdAllPatientInfoAndResult.Name = "grdAllPatientInfoAndResult";
            this.grdAllPatientInfoAndResult.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.grdAllPatientInfoAndResult.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdAllPatientInfoAndResult.Size = new System.Drawing.Size(735, 394);
            this.grdAllPatientInfoAndResult.TabIndex = 18;
            this.grdAllPatientInfoAndResult.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdAllPatientInfoAndResult.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.grdAllPatientInfoAndResult.TotalRowFormatStyle.FontName = "Tổng số Các Xét Nghiệm:";
            this.grdAllPatientInfoAndResult.TotalRowFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far;
            this.grdAllPatientInfoAndResult.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grdAllPatientInfoAndResult.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdAllPatientInfoAndResult_FormattingRow);
            this.grdAllPatientInfoAndResult.LoadingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdAllPatientInfoAndResult_LoadingRow);
            // 
            // frmAllPatientInfoAndResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 469);
            this.Controls.Add(this.grdAllPatientInfoAndResult);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.sysColor);
            this.KeyPreview = true;
            this.Name = "frmAllPatientInfoAndResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BÁO CÁO CHI TIẾT THÔNG TIN BỆNH NHÂN VÀ KẾT QUẢ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmArchiverReport_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmArchiverReport_KeyDown);
            this.sysColor.ResumeLayout(false);
            this.sysColor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAllPatientInfoAndResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel sysColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private Janus.Windows.CalendarCombo.CalendarCombo dtpCreatePrint;
        private Janus.Windows.EditControls.UIButton cmdINPHIEU;
        private Janus.Windows.EditControls.UIButton cmdExit;
        private Janus.Windows.CalendarCombo.CalendarCombo dtpFromDate;
        private Janus.Windows.CalendarCombo.CalendarCombo dtpToDate;
        private Janus.Windows.EditControls.UIComboBox cboTestType;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.EditControls.UIButton btnExportExcel;
        private System.Windows.Forms.Label label4;
        private Janus.Windows.GridEX.GridEX grdAllPatientInfoAndResult;
        private System.Windows.Forms.Label label6;
        private Janus.Windows.EditControls.UIComboBox cboDepartment;
        private System.Windows.Forms.Label label5;
        private Janus.Windows.EditControls.UIComboBox cboObjectType;
        private System.Windows.Forms.Label label8;
        private Janus.Windows.EditControls.UIComboBox cboDevices;

    }
}