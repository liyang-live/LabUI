namespace VietBaIT.LABLink.Reports.Forms
{
    partial class Frm_PatientNoBarcode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_PatientNoBarcode));
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem1 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem2 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem3 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.GridEX.GridEXLayout grdPatient_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdTestResult_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.Panel7 = new System.Windows.Forms.Panel();
            this.PictureBox6 = new System.Windows.Forms.PictureBox();
            this.Label15 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pgbStatus = new System.Windows.Forms.ProgressBar();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboStatus = new Janus.Windows.EditControls.UIComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboTestTypeList = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grbDanhSachBenhNhan = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.grdPatient = new Janus.Windows.GridEX.GridEX();
            this.grbResult = new System.Windows.Forms.GroupBox();
            this.grdTestResult = new Janus.Windows.GridEX.GridEX();
            this.Panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox6)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grbDanhSachBenhNhan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPatient)).BeginInit();
            this.grbResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTestResult)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel7
            // 
            this.Panel7.BackColor = System.Drawing.Color.Linen;
            this.Panel7.Controls.Add(this.PictureBox6);
            this.Panel7.Controls.Add(this.Label15);
            this.Panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel7.Location = new System.Drawing.Point(0, 0);
            this.Panel7.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Panel7.Name = "Panel7";
            this.Panel7.Size = new System.Drawing.Size(1006, 55);
            this.Panel7.TabIndex = 62;
            // 
            // PictureBox6
            // 
            this.PictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox6.Image")));
            this.PictureBox6.Location = new System.Drawing.Point(16, 2);
            this.PictureBox6.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.PictureBox6.Name = "PictureBox6";
            this.PictureBox6.Size = new System.Drawing.Size(59, 50);
            this.PictureBox6.TabIndex = 113;
            this.PictureBox6.TabStop = false;
            // 
            // Label15
            // 
            this.Label15.BackColor = System.Drawing.Color.Linen;
            this.Label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label15.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Label15.Location = new System.Drawing.Point(0, 0);
            this.Label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(1006, 55);
            this.Label15.TabIndex = 31;
            this.Label15.Text = "THỐNG KÊ SỐ LƯỢNG MẪU";
            this.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pgbStatus);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cboStatus);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.cboTestTypeList);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 55);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(1006, 61);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm Kiếm";
            // 
            // pgbStatus
            // 
            this.pgbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pgbStatus.Location = new System.Drawing.Point(262, 35);
            this.pgbStatus.MarqueeAnimationSpeed = 50;
            this.pgbStatus.Name = "pgbStatus";
            this.pgbStatus.Size = new System.Drawing.Size(635, 20);
            this.pgbStatus.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgbStatus.TabIndex = 9;
            this.pgbStatus.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(166, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "XN Chưa đăng ký";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "BN Chưa đăng ký";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.BackColor = System.Drawing.Color.Gainsboro;
            this.label6.Location = new System.Drawing.Point(142, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 20);
            this.label6.TabIndex = 4;
            // 
            // cboStatus
            // 
            this.cboStatus.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            uiComboBoxItem1.FormatStyle.Alpha = 0;
            uiComboBoxItem1.IsSeparator = false;
            uiComboBoxItem1.Text = "Tất Cả";
            uiComboBoxItem1.Value = -1;
            uiComboBoxItem2.FormatStyle.Alpha = 0;
            uiComboBoxItem2.IsSeparator = false;
            uiComboBoxItem2.Text = "Các XN chưa đăng ký";
            uiComboBoxItem2.Value = 0;
            uiComboBoxItem3.FormatStyle.Alpha = 0;
            uiComboBoxItem3.IsSeparator = false;
            uiComboBoxItem3.Text = "Các XN đã đăng ký";
            uiComboBoxItem3.Value = 1;
            this.cboStatus.Items.AddRange(new Janus.Windows.EditControls.UIComboBoxItem[] {
            uiComboBoxItem1,
            uiComboBoxItem2,
            uiComboBoxItem3});
            this.cboStatus.Location = new System.Drawing.Point(414, 13);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(107, 21);
            this.cboStatus.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.BackColor = System.Drawing.Color.Wheat;
            this.label5.Location = new System.Drawing.Point(9, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 20);
            this.label5.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(902, 12);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(99, 41);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Tìm Kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboTestTypeList
            // 
            this.cboTestTypeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTestTypeList.DropDownWidth = 250;
            this.cboTestTypeList.FormattingEnabled = true;
            this.cboTestTypeList.Location = new System.Drawing.Point(616, 13);
            this.cboTestTypeList.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboTestTypeList.Name = "cboTestTypeList";
            this.cboTestTypeList.Size = new System.Drawing.Size(125, 21);
            this.cboTestTypeList.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(529, 17);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Loại Xét Nghiệm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(327, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Trạng Thái Mẫu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Đến Ngày";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(224, 13);
            this.dtpToDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(99, 21);
            this.dtpToDate.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Từ Ngày";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(61, 13);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(101, 21);
            this.dtpFromDate.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 116);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grbDanhSachBenhNhan);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grbResult);
            this.splitContainer1.Size = new System.Drawing.Size(1006, 357);
            this.splitContainer1.SplitterDistance = 491;
            this.splitContainer1.TabIndex = 64;
            // 
            // grbDanhSachBenhNhan
            // 
            this.grbDanhSachBenhNhan.Controls.Add(this.btnPrint);
            this.grbDanhSachBenhNhan.Controls.Add(this.btnExport);
            this.grbDanhSachBenhNhan.Controls.Add(this.grdPatient);
            this.grbDanhSachBenhNhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbDanhSachBenhNhan.Location = new System.Drawing.Point(0, 0);
            this.grbDanhSachBenhNhan.Name = "grbDanhSachBenhNhan";
            this.grbDanhSachBenhNhan.Size = new System.Drawing.Size(491, 357);
            this.grbDanhSachBenhNhan.TabIndex = 0;
            this.grbDanhSachBenhNhan.TabStop = false;
            this.grbDanhSachBenhNhan.Text = "Danh Sách Bệnh Nhân";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(218, 330);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(129, 26);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "In Báo Cáo";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(351, 330);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(131, 26);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Export to Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // grdPatient
            // 
            this.grdPatient.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdPatient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            grdPatient_DesignTimeLayout.LayoutString = resources.GetString("grdPatient_DesignTimeLayout.LayoutString");
            this.grdPatient.DesignTimeLayout = grdPatient_DesignTimeLayout;
            this.grdPatient.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdPatient.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdPatient.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.grdPatient.GroupByBoxVisible = false;
            this.grdPatient.GroupRowFormatStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdPatient.GroupRowFormatStyle.ForeColor = System.Drawing.Color.Maroon;
            this.grdPatient.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdPatient.Location = new System.Drawing.Point(3, 17);
            this.grdPatient.Name = "grdPatient";
            this.grdPatient.RecordNavigator = true;
            this.grdPatient.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.grdPatient.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdPatient.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelectionSameTable;
            this.grdPatient.Size = new System.Drawing.Size(482, 312);
            this.grdPatient.TabIndex = 2;
            this.grdPatient.SelectionChanged += new System.EventHandler(this.grdPatient_SelectionChanged);
            // 
            // grbResult
            // 
            this.grbResult.Controls.Add(this.grdTestResult);
            this.grbResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbResult.Location = new System.Drawing.Point(0, 0);
            this.grbResult.Name = "grbResult";
            this.grbResult.Size = new System.Drawing.Size(511, 357);
            this.grbResult.TabIndex = 1;
            this.grbResult.TabStop = false;
            this.grbResult.Text = "Kết Quả";
            // 
            // grdTestResult
            // 
            this.grdTestResult.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdTestResult.AlternatingColors = true;
            grdTestResult_DesignTimeLayout.LayoutString = resources.GetString("grdTestResult_DesignTimeLayout.LayoutString");
            this.grdTestResult.DesignTimeLayout = grdTestResult_DesignTimeLayout;
            this.grdTestResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTestResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdTestResult.GroupByBoxVisible = false;
            this.grdTestResult.GroupRowFormatStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdTestResult.GroupRowFormatStyle.ForeColor = System.Drawing.Color.Maroon;
            this.grdTestResult.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdTestResult.Location = new System.Drawing.Point(3, 17);
            this.grdTestResult.Name = "grdTestResult";
            this.grdTestResult.RecordNavigator = true;
            this.grdTestResult.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.grdTestResult.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdTestResult.Size = new System.Drawing.Size(505, 337);
            this.grdTestResult.TabIndex = 3;
            this.grdTestResult.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.grdTestResult_FormattingRow);
            // 
            // Frm_PatientNoBarcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 473);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Panel7);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MinimumSize = new System.Drawing.Size(749, 303);
            this.Name = "Frm_PatientNoBarcode";
            this.Text = "Thống kê số lượng mẫu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_PatientNoBarcode_Load);
            this.Panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox6)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.grbDanhSachBenhNhan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPatient)).EndInit();
            this.grbResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTestResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel7;
        internal System.Windows.Forms.Label Label15;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.ComboBox cboTestTypeList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label4;
        private Janus.Windows.EditControls.UIComboBox cboStatus;
        internal System.Windows.Forms.PictureBox PictureBox6;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grbDanhSachBenhNhan;
        private System.Windows.Forms.GroupBox grbResult;
        private Janus.Windows.GridEX.GridEX grdPatient;
        private Janus.Windows.GridEX.GridEX grdTestResult;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ProgressBar pgbStatus;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnPrint;
    }
}