namespace VietBaIT.LABLink.Reports.Forms
{
    partial class frmHIV_HBsAg_HCV
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
            Janus.Windows.GridEX.GridEXLayout grdResult_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHIV_HBsAg_HCV));
            Janus.Windows.GridEX.GridEXLayout grdStatistics_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem1 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem2 = new Janus.Windows.EditControls.UIComboBoxItem();
            Janus.Windows.EditControls.UIComboBoxItem uiComboBoxItem3 = new Janus.Windows.EditControls.UIComboBoxItem();
            this.uiStatusBar1 = new Janus.Windows.UI.StatusBar.UIStatusBar();
            this.uiGroupBox2 = new Janus.Windows.EditControls.UIGroupBox();
            this.grdResult = new Janus.Windows.GridEX.GridEX();
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.dtpToDate = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.dtpFromDate = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.btnStatisticsToExcel = new Janus.Windows.EditControls.UIButton();
            this.grdStatistics = new Janus.Windows.GridEX.GridEX();
            this.btnExit = new Janus.Windows.EditControls.UIButton();
            this.btnResultToExcel = new Janus.Windows.EditControls.UIButton();
            this.btnSearch = new Janus.Windows.EditControls.UIButton();
            this.label3 = new System.Windows.Forms.Label();
            this.cboSex = new Janus.Windows.EditControls.UIComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).BeginInit();
            this.uiGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStatistics)).BeginInit();
            this.SuspendLayout();
            // 
            // uiStatusBar1
            // 
            this.uiStatusBar1.Location = new System.Drawing.Point(0, 603);
            this.uiStatusBar1.Name = "uiStatusBar1";
            this.uiStatusBar1.Size = new System.Drawing.Size(1364, 23);
            this.uiStatusBar1.TabIndex = 3;
            this.uiStatusBar1.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.grdResult);
            this.uiGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox2.Location = new System.Drawing.Point(242, 0);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Size = new System.Drawing.Size(1122, 603);
            this.uiGroupBox2.TabIndex = 6;
            this.uiGroupBox2.Text = "Kết quả";
            // 
            // grdResult
            // 
            this.grdResult.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            grdResult_DesignTimeLayout.LayoutString = resources.GetString("grdResult_DesignTimeLayout.LayoutString");
            this.grdResult.DesignTimeLayout = grdResult_DesignTimeLayout;
            this.grdResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.grdResult.GroupByBoxVisible = false;
            this.grdResult.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdResult.Location = new System.Drawing.Point(3, 19);
            this.grdResult.Name = "grdResult";
            this.grdResult.RecordNavigator = true;
            this.grdResult.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdResult.Size = new System.Drawing.Size(1116, 581);
            this.grdResult.TabIndex = 1;
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.dtpToDate);
            this.uiGroupBox1.Controls.Add(this.dtpFromDate);
            this.uiGroupBox1.Controls.Add(this.btnStatisticsToExcel);
            this.uiGroupBox1.Controls.Add(this.grdStatistics);
            this.uiGroupBox1.Controls.Add(this.btnExit);
            this.uiGroupBox1.Controls.Add(this.btnResultToExcel);
            this.uiGroupBox1.Controls.Add(this.btnSearch);
            this.uiGroupBox1.Controls.Add(this.label3);
            this.uiGroupBox1.Controls.Add(this.cboSex);
            this.uiGroupBox1.Controls.Add(this.label2);
            this.uiGroupBox1.Controls.Add(this.label1);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(242, 603);
            this.uiGroupBox1.TabIndex = 5;
            this.uiGroupBox1.Text = "Thông tin tìm kiếm";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            // 
            // 
            // 
            this.dtpToDate.DropDownCalendar.Name = "";
            this.dtpToDate.Location = new System.Drawing.Point(102, 66);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(121, 23);
            this.dtpToDate.TabIndex = 10;
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpToDate_ValueChanged);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            // 
            // 
            // 
            this.dtpFromDate.DropDownCalendar.Name = "";
            this.dtpFromDate.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007;
            this.dtpFromDate.Location = new System.Drawing.Point(102, 30);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(121, 23);
            this.dtpFromDate.TabIndex = 2;
            this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
            // 
            // btnStatisticsToExcel
            // 
            this.btnStatisticsToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStatisticsToExcel.Location = new System.Drawing.Point(16, 499);
            this.btnStatisticsToExcel.Name = "btnStatisticsToExcel";
            this.btnStatisticsToExcel.Size = new System.Drawing.Size(207, 43);
            this.btnStatisticsToExcel.TabIndex = 9;
            this.btnStatisticsToExcel.Text = "Xuất thống kê ra excel (F5)";
            this.btnStatisticsToExcel.Click += new System.EventHandler(this.btnStatisticsToExcel_Click);
            // 
            // grdStatistics
            // 
            grdStatistics_DesignTimeLayout.LayoutString = resources.GetString("grdStatistics_DesignTimeLayout.LayoutString");
            this.grdStatistics.DesignTimeLayout = grdStatistics_DesignTimeLayout;
            this.grdStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdStatistics.GroupByBoxVisible = false;
            this.grdStatistics.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdStatistics.Location = new System.Drawing.Point(6, 134);
            this.grdStatistics.Name = "grdStatistics";
            this.grdStatistics.Size = new System.Drawing.Size(230, 106);
            this.grdStatistics.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Location = new System.Drawing.Point(16, 548);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(207, 43);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Thoát (Esc)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnResultToExcel
            // 
            this.btnResultToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnResultToExcel.Location = new System.Drawing.Point(16, 450);
            this.btnResultToExcel.Name = "btnResultToExcel";
            this.btnResultToExcel.Size = new System.Drawing.Size(207, 43);
            this.btnResultToExcel.TabIndex = 7;
            this.btnResultToExcel.Text = "Xuất kết quả ra excel (F4)";
            this.btnResultToExcel.Click += new System.EventHandler(this.btnResultToExcel_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSearch.Location = new System.Drawing.Point(16, 401);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(207, 43);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Tìm kiếm (F3)";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Giới tính";
            // 
            // cboSex
            // 
            this.cboSex.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            uiComboBoxItem1.FormatStyle.Alpha = 0;
            uiComboBoxItem1.IsSeparator = false;
            uiComboBoxItem1.Text = "Tất cả";
            uiComboBoxItem1.Value = ((short)(-1));
            uiComboBoxItem2.FormatStyle.Alpha = 0;
            uiComboBoxItem2.IsSeparator = false;
            uiComboBoxItem2.Text = "Nam";
            uiComboBoxItem2.Value = ((short)(1));
            uiComboBoxItem3.FormatStyle.Alpha = 0;
            uiComboBoxItem3.IsSeparator = false;
            uiComboBoxItem3.Text = "Nữ";
            uiComboBoxItem3.Value = ((short)(0));
            this.cboSex.Items.AddRange(new Janus.Windows.EditControls.UIComboBoxItem[] {
            uiComboBoxItem1,
            uiComboBoxItem2,
            uiComboBoxItem3});
            this.cboSex.Location = new System.Drawing.Point(102, 102);
            this.cboSex.Name = "cboSex";
            this.cboSex.Size = new System.Drawing.Size(121, 23);
            this.cboSex.TabIndex = 4;
            this.cboSex.Text = "uiComboBox1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Đến ngày";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày";
            // 
            // frmHIV_HBsAg_HCV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 626);
            this.Controls.Add(this.uiGroupBox2);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.uiStatusBar1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmHIV_HBsAg_HCV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BÁO CÁO HIV HBsAg HCV";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHIV_HBsAg_HCV_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmHIV_HBsAg_HCV_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).EndInit();
            this.uiGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStatistics)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.StatusBar.UIStatusBar uiStatusBar1;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox2;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private Janus.Windows.EditControls.UIButton btnExit;
        private Janus.Windows.EditControls.UIButton btnResultToExcel;
        private Janus.Windows.EditControls.UIButton btnSearch;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.EditControls.UIComboBox cboSex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.GridEX.GridEX grdResult;
        private Janus.Windows.GridEX.GridEX grdStatistics;
        private Janus.Windows.EditControls.UIButton btnStatisticsToExcel;
        private Janus.Windows.CalendarCombo.CalendarCombo dtpFromDate;
        private Janus.Windows.CalendarCombo.CalendarCombo dtpToDate;
    }
}