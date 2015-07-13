namespace Vietbait.Lablink.TestInformation.UI.Forms
{
    partial class frm_PrintMany
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PrintMany));
            Janus.Windows.GridEX.GridEXLayout grdPatients_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdPrintingStatus_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdTestType_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel9 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel10 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel11 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel12 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdPatients = new Janus.Windows.GridEX.GridEX();
            this.grbPrinting = new System.Windows.Forms.GroupBox();
            this.grdPrintingStatus = new Janus.Windows.GridEX.GridEX();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gbDate = new System.Windows.Forms.GroupBox();
            this.dtpToDate = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.dtpFromDate = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboDate = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.grdTestType = new Janus.Windows.GridEX.GridEX();
            this.cbDuKQ = new Janus.Windows.EditControls.UICheckBox();
            this.cbNotPrint = new Janus.Windows.EditControls.UICheckBox();
            this.uiStatusBar1 = new Janus.Windows.UI.StatusBar.UIStatusBar();
            this.cmdSearch = new Janus.Windows.EditControls.UIButton();
            this.cmdPrint = new Janus.Windows.EditControls.UIButton();
            this.cboPrinter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dtpPrintDate = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label4 = new System.Windows.Forms.Label();
            this.rboA4 = new Janus.Windows.EditControls.UICheckBox();
            this.rboA5 = new Janus.Windows.EditControls.UICheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPatients)).BeginInit();
            this.grbPrinting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPrintingStatus)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.gbDate.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTestType)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.grdPatients);
            this.groupBox1.Location = new System.Drawing.Point(12, 169);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(704, 438);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // grdPatients
            // 
            this.grdPatients.AllowDrop = true;
            this.grdPatients.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdPatients.BuiltInTextsData = resources.GetString("grdPatients.BuiltInTextsData");
            this.grdPatients.ControlStyle.HoverBaseColor = System.Drawing.SystemColors.HighlightText;
            grdPatients_DesignTimeLayout.LayoutString = resources.GetString("grdPatients_DesignTimeLayout.LayoutString");
            this.grdPatients.DesignTimeLayout = grdPatients_DesignTimeLayout;
            this.grdPatients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPatients.DynamicFiltering = true;
            this.grdPatients.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdPatients.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdPatients.FilterRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grdPatients.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdPatients.FocusCellFormatStyle.BackColor = System.Drawing.SystemColors.Control;
            this.grdPatients.FocusCellFormatStyle.BackColorGradient = System.Drawing.SystemColors.Control;
            this.grdPatients.FocusCellFormatStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdPatients.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdPatients.GroupByBoxVisible = false;
            this.grdPatients.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdPatients.LinkFormatStyle.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.grdPatients.Location = new System.Drawing.Point(3, 16);
            this.grdPatients.Name = "grdPatients";
            this.grdPatients.RecordNavigator = true;
            this.grdPatients.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdPatients.SelectedFormatStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdPatients.Size = new System.Drawing.Size(698, 419);
            this.grdPatients.TabIndex = 2;
            this.grdPatients.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.grdPatients_RowDoubleClick);
            this.grdPatients.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdPatients_ColumnButtonClick);
            // 
            // grbPrinting
            // 
            this.grbPrinting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbPrinting.Controls.Add(this.grdPrintingStatus);
            this.grbPrinting.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbPrinting.Location = new System.Drawing.Point(719, 169);
            this.grbPrinting.Name = "grbPrinting";
            this.grbPrinting.Size = new System.Drawing.Size(540, 438);
            this.grbPrinting.TabIndex = 1;
            this.grbPrinting.TabStop = false;
            this.grbPrinting.Text = "Đang in";
            // 
            // grdPrintingStatus
            // 
            grdPrintingStatus_DesignTimeLayout.LayoutString = resources.GetString("grdPrintingStatus_DesignTimeLayout.LayoutString");
            this.grdPrintingStatus.DesignTimeLayout = grdPrintingStatus_DesignTimeLayout;
            this.grdPrintingStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPrintingStatus.DynamicFiltering = true;
            this.grdPrintingStatus.FilterMode = Janus.Windows.GridEX.FilterMode.Manual;
            this.grdPrintingStatus.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdPrintingStatus.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdPrintingStatus.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdPrintingStatus.GroupByBoxVisible = false;
            this.grdPrintingStatus.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdPrintingStatus.Location = new System.Drawing.Point(3, 18);
            this.grdPrintingStatus.Name = "grdPrintingStatus";
            this.grdPrintingStatus.RecordNavigator = true;
            this.grdPrintingStatus.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdPrintingStatus.Size = new System.Drawing.Size(534, 417);
            this.grdPrintingStatus.TabIndex = 0;
            this.grdPrintingStatus.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdPrintingStatus_ColumnButtonClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.dtpPrintDate);
            this.groupBox3.Controls.Add(this.gbDate);
            this.groupBox3.Controls.Add(this.cboDate);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(262, 154);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ngày";
            // 
            // gbDate
            // 
            this.gbDate.Controls.Add(this.dtpToDate);
            this.gbDate.Controls.Add(this.dtpFromDate);
            this.gbDate.Controls.Add(this.label2);
            this.gbDate.Controls.Add(this.label1);
            this.gbDate.Enabled = false;
            this.gbDate.Location = new System.Drawing.Point(3, 46);
            this.gbDate.Name = "gbDate";
            this.gbDate.Size = new System.Drawing.Size(253, 80);
            this.gbDate.TabIndex = 5;
            this.gbDate.TabStop = false;
            // 
            // dtpToDate
            // 
            // 
            // 
            // 
            this.dtpToDate.DropDownCalendar.Name = "";
            this.dtpToDate.Location = new System.Drawing.Point(51, 48);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(200, 22);
            this.dtpToDate.TabIndex = 8;
            // 
            // dtpFromDate
            // 
            // 
            // 
            // 
            this.dtpFromDate.DropDownCalendar.Name = "";
            this.dtpFromDate.Location = new System.Drawing.Point(51, 14);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(200, 22);
            this.dtpFromDate.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "&Đến";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "&Từ";
            // 
            // cboDate
            // 
            this.cboDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDate.FormattingEnabled = true;
            this.cboDate.Items.AddRange(new object[] {
            "Hôm nay",
            "Hôm qua",
            "Tùy chọn"});
            this.cboDate.Location = new System.Drawing.Point(9, 21);
            this.cboDate.Name = "cboDate";
            this.cboDate.Size = new System.Drawing.Size(247, 24);
            this.cboDate.TabIndex = 0;
            this.cboDate.SelectedIndexChanged += new System.EventHandler(this.cboDate_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.grdTestType);
            this.groupBox4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(280, 9);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(236, 154);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Loại xét nghiệm";
            // 
            // grdTestType
            // 
            this.grdTestType.AllowDrop = true;
            this.grdTestType.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdTestType.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><RecordNavigator>Số lư" +
    "ợng: | Of</RecordNavigator><FilterRowInfoText>Lọc thông tin bệnh nhân</FilterRow" +
    "InfoText></LocalizableData>";
            this.grdTestType.ColumnAutoResize = true;
            this.grdTestType.ColumnHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
            grdTestType_DesignTimeLayout.LayoutString = resources.GetString("grdTestType_DesignTimeLayout.LayoutString");
            this.grdTestType.DesignTimeLayout = grdTestType_DesignTimeLayout;
            this.grdTestType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTestType.DynamicFiltering = true;
            this.grdTestType.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdTestType.FilterRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grdTestType.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdTestType.FocusCellFormatStyle.BackColor = System.Drawing.SystemColors.Highlight;
            this.grdTestType.FocusCellFormatStyle.BackColorGradient = System.Drawing.SystemColors.Highlight;
            this.grdTestType.FocusCellFormatStyle.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdTestType.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdTestType.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.grdTestType.GroupByBoxVisible = false;
            this.grdTestType.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdTestType.Location = new System.Drawing.Point(3, 18);
            this.grdTestType.Name = "grdTestType";
            this.grdTestType.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowPosition;
            this.grdTestType.SelectedFormatStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdTestType.Size = new System.Drawing.Size(230, 133);
            this.grdTestType.TabIndex = 42;
            // 
            // cbDuKQ
            // 
            this.cbDuKQ.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDuKQ.Location = new System.Drawing.Point(6, 27);
            this.cbDuKQ.Name = "cbDuKQ";
            this.cbDuKQ.Size = new System.Drawing.Size(104, 23);
            this.cbDuKQ.TabIndex = 41;
            this.cbDuKQ.Text = "Đủ kết quả";
            // 
            // cbNotPrint
            // 
            this.cbNotPrint.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNotPrint.Location = new System.Drawing.Point(107, 27);
            this.cbNotPrint.Name = "cbNotPrint";
            this.cbNotPrint.Size = new System.Drawing.Size(78, 23);
            this.cbNotPrint.TabIndex = 40;
            this.cbNotPrint.Text = "Chưa in";
            // 
            // uiStatusBar1
            // 
            this.uiStatusBar1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiStatusBar1.Location = new System.Drawing.Point(0, 613);
            this.uiStatusBar1.Name = "uiStatusBar1";
            uiStatusBarPanel9.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel9.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel9.Key = "";
            uiStatusBarPanel9.ProgressBarValue = 0;
            uiStatusBarPanel9.Text = "Ctrl + X : Hủy hết lệnh in";
            uiStatusBarPanel9.Width = 171;
            uiStatusBarPanel10.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel10.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel10.Key = "";
            uiStatusBarPanel10.ProgressBarValue = 0;
            uiStatusBarPanel10.Text = "Ctrl + Y : Xem tất cả kết quả";
            uiStatusBarPanel10.Width = 193;
            uiStatusBarPanel11.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel11.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel11.Key = "";
            uiStatusBarPanel11.ProgressBarValue = 0;
            uiStatusBarPanel11.Text = "Ctrl + A : Chọn tất cả bệnh nhân trên lưới";
            uiStatusBarPanel11.Width = 278;
            uiStatusBarPanel12.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel12.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel12.Key = "";
            uiStatusBarPanel12.ProgressBarValue = 0;
            uiStatusBarPanel12.Text = "Ctrl + U : Bỏ chọn tất cả bệnh nhân trên lưới";
            uiStatusBarPanel12.Width = 297;
            this.uiStatusBar1.Panels.AddRange(new Janus.Windows.UI.StatusBar.UIStatusBarPanel[] {
            uiStatusBarPanel9,
            uiStatusBarPanel10,
            uiStatusBarPanel11,
            uiStatusBarPanel12});
            this.uiStatusBar1.Size = new System.Drawing.Size(1271, 25);
            this.uiStatusBar1.TabIndex = 40;
            this.uiStatusBar1.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            // 
            // cmdSearch
            // 
            this.cmdSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSearch.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.ImageSize = new System.Drawing.Size(32, 32);
            this.cmdSearch.Location = new System.Drawing.Point(16, 69);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(252, 78);
            this.cmdSearch.TabIndex = 36;
            this.cmdSearch.Text = "Tìm kiếm (F3)";
            this.cmdSearch.ToolTipText = "Tìm kiếm thông tin bệnh nhân hoặc nhấn phím tắt F3";
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // cmdPrint
            // 
            this.cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdPrint.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPrint.Image = ((System.Drawing.Image)(resources.GetObject("cmdPrint.Image")));
            this.cmdPrint.ImageSize = new System.Drawing.Size(32, 32);
            this.cmdPrint.Location = new System.Drawing.Point(274, 68);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(254, 80);
            this.cmdPrint.TabIndex = 37;
            this.cmdPrint.Text = "In (F4)";
            this.cmdPrint.ToolTipText = "Tìm kiếm thông tin bệnh nhân hoặc nhấn phím tắt F3";
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // cboPrinter
            // 
            this.cboPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrinter.FormattingEnabled = true;
            this.cboPrinter.Location = new System.Drawing.Point(107, 24);
            this.cboPrinter.Name = "cboPrinter";
            this.cboPrinter.Size = new System.Drawing.Size(421, 21);
            this.cboPrinter.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 41;
            this.label3.Text = "Chọn máy in";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cboPrinter);
            this.groupBox2.Controls.Add(this.cmdPrint);
            this.groupBox2.Controls.Add(this.cmdSearch);
            this.groupBox2.Location = new System.Drawing.Point(719, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(534, 154);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.rboA5);
            this.groupBox5.Controls.Add(this.rboA4);
            this.groupBox5.Controls.Add(this.cbNotPrint);
            this.groupBox5.Controls.Add(this.cbDuKQ);
            this.groupBox5.Location = new System.Drawing.Point(522, 9);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(191, 154);
            this.groupBox5.TabIndex = 43;
            this.groupBox5.TabStop = false;
            // 
            // dtpPrintDate
            // 
            // 
            // 
            // 
            this.dtpPrintDate.DropDownCalendar.Name = "";
            this.dtpPrintDate.Location = new System.Drawing.Point(54, 129);
            this.dtpPrintDate.Name = "dtpPrintDate";
            this.dtpPrintDate.Size = new System.Drawing.Size(200, 22);
            this.dtpPrintDate.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-2, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "&Ngày in";
            // 
            // rboA4
            // 
            this.rboA4.Location = new System.Drawing.Point(7, 85);
            this.rboA4.Name = "rboA4";
            this.rboA4.Size = new System.Drawing.Size(41, 23);
            this.rboA4.TabIndex = 42;
            this.rboA4.Text = "A4";
            this.rboA4.CheckedChanged += new System.EventHandler(this.rboA4_CheckedChanged);
            // 
            // rboA5
            // 
            this.rboA5.Location = new System.Drawing.Point(107, 85);
            this.rboA5.Name = "rboA5";
            this.rboA5.Size = new System.Drawing.Size(41, 23);
            this.rboA5.TabIndex = 43;
            this.rboA5.Text = "A5";
            this.rboA5.CheckedChanged += new System.EventHandler(this.rboA5_CheckedChanged);
            // 
            // frm_PrintMany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 638);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.uiStatusBar1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grbPrinting);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "frm_PrintMany";
            this.Text = "IN HÀNG LOẠT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_PrintMany_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_PrintMany_KeyDown);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPatients)).EndInit();
            this.grbPrinting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPrintingStatus)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbDate.ResumeLayout(false);
            this.gbDate.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTestType)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grbPrinting;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboDate;
        private System.Windows.Forms.GroupBox groupBox4;
        internal Janus.Windows.GridEX.GridEX grdPatients;
        private Janus.Windows.EditControls.UICheckBox cbDuKQ;
        private Janus.Windows.EditControls.UICheckBox cbNotPrint;
        internal Janus.Windows.GridEX.GridEX grdTestType;
        private System.Windows.Forms.GroupBox gbDate;
        private Janus.Windows.CalendarCombo.CalendarCombo dtpToDate;
        private Janus.Windows.CalendarCombo.CalendarCombo dtpFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.GridEX.GridEX grdPrintingStatus;
        private Janus.Windows.UI.StatusBar.UIStatusBar uiStatusBar1;
        internal Janus.Windows.EditControls.UIButton cmdSearch;
        internal Janus.Windows.EditControls.UIButton cmdPrint;
        private System.Windows.Forms.ComboBox cboPrinter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label4;
        private Janus.Windows.CalendarCombo.CalendarCombo dtpPrintDate;
        private Janus.Windows.EditControls.UICheckBox rboA5;
        private Janus.Windows.EditControls.UICheckBox rboA4;

    }
}