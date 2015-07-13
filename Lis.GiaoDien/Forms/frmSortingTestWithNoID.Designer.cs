namespace Vietbait.Lablink.TestInformation.UI.Forms
{
    partial class frmSortingTestWithNoID
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
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel5 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel6 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSortingTestWithNoID));
            Janus.Windows.GridEX.GridEXLayout grdPatients_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdTestInfo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.statusBar = new Janus.Windows.UI.StatusBar.UIStatusBar();
            this.btnUpdateStandardData = new Janus.Windows.EditControls.UIButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.grdPatients = new Janus.Windows.GridEX.GridEX();
            this.btnSearchPatient = new Janus.Windows.EditControls.UIButton();
            this.label1 = new System.Windows.Forms.Label();
            this.uiGroupBox2 = new Janus.Windows.EditControls.UIGroupBox();
            this.grdTestInfo = new Janus.Windows.GridEX.GridEX();
            this.btnSearchTest = new Janus.Windows.EditControls.UIButton();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpPatient = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.dtpTest = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPatients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).BeginInit();
            this.uiGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTestInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 383);
            this.statusBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.statusBar.Name = "statusBar";
            uiStatusBarPanel5.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel5.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel5.Key = "";
            uiStatusBarPanel5.ProgressBarValue = 0;
            uiStatusBarPanel5.Text = "Double+Click: Chuyển kết quả sang bệnh nhân được chọn";
            uiStatusBarPanel5.Width = 369;
            uiStatusBarPanel6.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel6.Key = "";
            uiStatusBarPanel6.ProgressBarValue = 0;
            uiStatusBarPanel6.Text = "Esc: Thoát";
            this.statusBar.Panels.AddRange(new Janus.Windows.UI.StatusBar.UIStatusBarPanel[] {
            uiStatusBarPanel5,
            uiStatusBarPanel6});
            this.statusBar.Size = new System.Drawing.Size(1145, 30);
            this.statusBar.TabIndex = 7;
            this.statusBar.VisualStyle = Janus.Windows.UI.VisualStyle.OfficeXP;
            // 
            // btnUpdateStandardData
            // 
            this.btnUpdateStandardData.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnUpdateStandardData.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateStandardData.Image")));
            this.btnUpdateStandardData.ImageSize = new System.Drawing.Size(32, 32);
            this.btnUpdateStandardData.Location = new System.Drawing.Point(512, 167);
            this.btnUpdateStandardData.Name = "btnUpdateStandardData";
            this.btnUpdateStandardData.Size = new System.Drawing.Size(61, 37);
            this.btnUpdateStandardData.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.uiGroupBox1);
            this.panel1.Controls.Add(this.btnUpdateStandardData);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(581, 383);
            this.panel1.TabIndex = 15;
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.dtpPatient);
            this.uiGroupBox1.Controls.Add(this.grdPatients);
            this.uiGroupBox1.Controls.Add(this.btnSearchPatient);
            this.uiGroupBox1.Controls.Add(this.label1);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(506, 383);
            this.uiGroupBox1.TabIndex = 9;
            this.uiGroupBox1.Text = "Danh sách bệnh nhân";
            // 
            // grdPatients
            // 
            this.grdPatients.AllowDrop = true;
            this.grdPatients.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdPatients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdPatients.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><RecordNavigator>Số lư" +
                "ợng: | Of</RecordNavigator><FilterRowInfoText>Lọc thông tin bệnh nhân</FilterRow" +
                "InfoText></LocalizableData>";
            grdPatients_DesignTimeLayout.LayoutString = resources.GetString("grdPatients_DesignTimeLayout.LayoutString");
            this.grdPatients.DesignTimeLayout = grdPatients_DesignTimeLayout;
            this.grdPatients.DynamicFiltering = true;
            this.grdPatients.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdPatients.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdPatients.FilterRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grdPatients.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdPatients.FocusCellFormatStyle.BackColor = System.Drawing.SystemColors.Highlight;
            this.grdPatients.FocusCellFormatStyle.BackColorGradient = System.Drawing.SystemColors.Highlight;
            this.grdPatients.FocusCellFormatStyle.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdPatients.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdPatients.GroupByBoxVisible = false;
            this.grdPatients.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdPatients.Location = new System.Drawing.Point(9, 54);
            this.grdPatients.Name = "grdPatients";
            this.grdPatients.RecordNavigator = true;
            this.grdPatients.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdPatients.SelectedFormatStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdPatients.Size = new System.Drawing.Size(488, 322);
            this.grdPatients.TabIndex = 3;
            // 
            // btnSearchPatient
            // 
            this.btnSearchPatient.Location = new System.Drawing.Point(196, 24);
            this.btnSearchPatient.Name = "btnSearchPatient";
            this.btnSearchPatient.Size = new System.Drawing.Size(112, 23);
            this.btnSearchPatient.TabIndex = 2;
            this.btnSearchPatient.Text = "Tìm kiếm (F3)";
            this.btnSearchPatient.Click += new System.EventHandler(this.btnSearchPatient_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ngày";
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.dtpTest);
            this.uiGroupBox2.Controls.Add(this.grdTestInfo);
            this.uiGroupBox2.Controls.Add(this.btnSearchTest);
            this.uiGroupBox2.Controls.Add(this.label2);
            this.uiGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox2.Location = new System.Drawing.Point(581, 0);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Size = new System.Drawing.Size(564, 383);
            this.uiGroupBox2.TabIndex = 16;
            this.uiGroupBox2.Text = "Kết quả xét nghiệm";
            // 
            // grdTestInfo
            // 
            this.grdTestInfo.AllowDrop = true;
            this.grdTestInfo.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdTestInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdTestInfo.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><RecordNavigator>Số lư" +
                "ợng: | Of</RecordNavigator><FilterRowInfoText>Lọc thông tin bệnh nhân</FilterRow" +
                "InfoText></LocalizableData>";
            grdTestInfo_DesignTimeLayout.LayoutString = resources.GetString("grdTestInfo_DesignTimeLayout.LayoutString");
            this.grdTestInfo.DesignTimeLayout = grdTestInfo_DesignTimeLayout;
            this.grdTestInfo.DynamicFiltering = true;
            this.grdTestInfo.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdTestInfo.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdTestInfo.FilterRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grdTestInfo.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdTestInfo.FocusCellFormatStyle.BackColor = System.Drawing.SystemColors.Highlight;
            this.grdTestInfo.FocusCellFormatStyle.BackColorGradient = System.Drawing.SystemColors.Highlight;
            this.grdTestInfo.FocusCellFormatStyle.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdTestInfo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdTestInfo.GroupByBoxVisible = false;
            this.grdTestInfo.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdTestInfo.Location = new System.Drawing.Point(9, 54);
            this.grdTestInfo.Name = "grdTestInfo";
            this.grdTestInfo.RecordNavigator = true;
            this.grdTestInfo.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdTestInfo.SelectedFormatStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdTestInfo.Size = new System.Drawing.Size(546, 322);
            this.grdTestInfo.TabIndex = 3;
            this.grdTestInfo.DoubleClick += new System.EventHandler(this.grdTestInfo_DoubleClick);
            // 
            // btnSearchTest
            // 
            this.btnSearchTest.Location = new System.Drawing.Point(196, 24);
            this.btnSearchTest.Name = "btnSearchTest";
            this.btnSearchTest.Size = new System.Drawing.Size(112, 23);
            this.btnSearchTest.TabIndex = 2;
            this.btnSearchTest.Text = "Tìm kiếm (F4)";
            this.btnSearchTest.Click += new System.EventHandler(this.btnSearchTest_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ngày";
            // 
            // dtpPatient
            // 
            this.dtpPatient.CustomFormat = "dd/MM/yyyy";
            this.dtpPatient.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtpPatient.DropDownCalendar.Name = "";
            this.dtpPatient.Location = new System.Drawing.Point(58, 23);
            this.dtpPatient.Name = "dtpPatient";
            this.dtpPatient.ShowUpDown = true;
            this.dtpPatient.Size = new System.Drawing.Size(132, 25);
            this.dtpPatient.TabIndex = 0;
            // 
            // dtpTest
            // 
            this.dtpTest.CustomFormat = "dd/MM/yyyy";
            this.dtpTest.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtpTest.DropDownCalendar.Name = "";
            this.dtpTest.Location = new System.Drawing.Point(58, 23);
            this.dtpTest.Name = "dtpTest";
            this.dtpTest.ShowUpDown = true;
            this.dtpTest.Size = new System.Drawing.Size(132, 25);
            this.dtpTest.TabIndex = 0;
            // 
            // frmSortingTestWithNoID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 413);
            this.Controls.Add(this.uiGroupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusBar);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmSortingTestWithNoID";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SẮP XẾP KẾT QUẢ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSortingTestWithNoID_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSortingTestWithNoID_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPatients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).EndInit();
            this.uiGroupBox2.ResumeLayout(false);
            this.uiGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTestInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.StatusBar.UIStatusBar statusBar;
        private Janus.Windows.EditControls.UIButton btnUpdateStandardData;
        private System.Windows.Forms.Panel panel1;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        internal Janus.Windows.GridEX.GridEX grdPatients;
        private Janus.Windows.EditControls.UIButton btnSearchPatient;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox2;
        internal Janus.Windows.GridEX.GridEX grdTestInfo;
        private Janus.Windows.EditControls.UIButton btnSearchTest;
        private System.Windows.Forms.Label label2;
        internal Janus.Windows.CalendarCombo.CalendarCombo dtpPatient;
        internal Janus.Windows.CalendarCombo.CalendarCombo dtpTest;

    }
}