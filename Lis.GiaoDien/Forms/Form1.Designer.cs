namespace Lis.GiaoDien.Forms
{
    partial class Form1
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
            Janus.Windows.GridEX.GridEXLayout grdTestType_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Janus.Windows.GridEX.GridEXLayout gridEX1_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.cboDate = new System.Windows.Forms.ComboBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.grdTestType = new Janus.Windows.GridEX.GridEX();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.grbDateSelector = new System.Windows.Forms.GroupBox();
            this.pnlDate = new System.Windows.Forms.Panel();
            this.dtpTestDateTo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.dtpTestDateFrom = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.UiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.txtMessageDisplay = new Janus.Windows.EditControls.UIButton();
            this.radChuaInPhieu = new Janus.Windows.EditControls.UIRadioButton();
            this.radDaIn = new Janus.Windows.EditControls.UIRadioButton();
            this.chkIsFinal = new Janus.Windows.EditControls.UICheckBox();
            this.rbtDaIn = new System.Windows.Forms.RadioButton();
            this.rbtChuaIn = new System.Windows.Forms.RadioButton();
            this.radTatCa = new Janus.Windows.EditControls.UIRadioButton();
            this.rbtTatCa = new System.Windows.Forms.RadioButton();
            this.cmdSearch = new Janus.Windows.EditControls.UIButton();
            this.ckbHasResult = new Janus.Windows.EditControls.UICheckBox();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.cboObjectType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtMaHis = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPID = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.cboSex = new System.Windows.Forms.ComboBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridEX1 = new Janus.Windows.GridEX.GridEX();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTestType)).BeginInit();
            this.GroupBox4.SuspendLayout();
            this.grbDateSelector.SuspendLayout();
            this.pnlDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBox1)).BeginInit();
            this.UiGroupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).BeginInit();
            this.SuspendLayout();
            // 
            // cboDate
            // 
            this.cboDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDate.Items.AddRange(new object[] {
            "Hôm Nay",
            "Hôm Qua",
            "Tùy Chọn"});
            this.cboDate.Location = new System.Drawing.Point(242, 85);
            this.cboDate.Name = "cboDate";
            this.cboDate.Size = new System.Drawing.Size(187, 21);
            this.cboDate.TabIndex = 1;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.grdTestType);
            this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.GroupBox1.Location = new System.Drawing.Point(0, 0);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(253, 550);
            this.GroupBox1.TabIndex = 35;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Loại Xét Nghiệm";
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
            this.grdTestType.Location = new System.Drawing.Point(3, 16);
            this.grdTestType.Name = "grdTestType";
            this.grdTestType.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowPosition;
            this.grdTestType.SelectedFormatStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdTestType.Size = new System.Drawing.Size(247, 531);
            this.grdTestType.TabIndex = 1;
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.grbDateSelector);
            this.GroupBox4.Controls.Add(this.UiGroupBox1);
            this.GroupBox4.Controls.Add(this.radChuaInPhieu);
            this.GroupBox4.Controls.Add(this.radDaIn);
            this.GroupBox4.Controls.Add(this.chkIsFinal);
            this.GroupBox4.Controls.Add(this.rbtDaIn);
            this.GroupBox4.Controls.Add(this.rbtChuaIn);
            this.GroupBox4.Controls.Add(this.radTatCa);
            this.GroupBox4.Controls.Add(this.rbtTatCa);
            this.GroupBox4.Controls.Add(this.cmdSearch);
            this.GroupBox4.Controls.Add(this.ckbHasResult);
            this.GroupBox4.Controls.Add(this.cboDepartment);
            this.GroupBox4.Controls.Add(this.cboObjectType);
            this.GroupBox4.Controls.Add(this.label4);
            this.GroupBox4.Controls.Add(this.label9);
            this.GroupBox4.Controls.Add(this.Label3);
            this.GroupBox4.Controls.Add(this.Label5);
            this.GroupBox4.Controls.Add(this.Label2);
            this.GroupBox4.Controls.Add(this.label14);
            this.GroupBox4.Controls.Add(this.txtMaHis);
            this.GroupBox4.Controls.Add(this.Label7);
            this.GroupBox4.Controls.Add(this.txtBarcode);
            this.GroupBox4.Controls.Add(this.txtName);
            this.GroupBox4.Controls.Add(this.txtPID);
            this.GroupBox4.Controls.Add(this.txtAge);
            this.GroupBox4.Controls.Add(this.cboSex);
            this.GroupBox4.Controls.Add(this.Label6);
            this.GroupBox4.Dock = System.Windows.Forms.DockStyle.Right;
            this.GroupBox4.Location = new System.Drawing.Point(498, 0);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(458, 550);
            this.GroupBox4.TabIndex = 38;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Thông Tin Bệnh Nhân";
            // 
            // grbDateSelector
            // 
            this.grbDateSelector.Controls.Add(this.pnlDate);
            this.grbDateSelector.Controls.Add(this.comboBox1);
            this.grbDateSelector.Location = new System.Drawing.Point(128, 217);
            this.grbDateSelector.Name = "grbDateSelector";
            this.grbDateSelector.Size = new System.Drawing.Size(203, 116);
            this.grbDateSelector.TabIndex = 44;
            this.grbDateSelector.TabStop = false;
            this.grbDateSelector.Text = "Ngày";
            // 
            // pnlDate
            // 
            this.pnlDate.Controls.Add(this.dtpTestDateTo);
            this.pnlDate.Controls.Add(this.dtpTestDateFrom);
            this.pnlDate.Controls.Add(this.Label8);
            this.pnlDate.Controls.Add(this.Label1);
            this.pnlDate.Location = new System.Drawing.Point(3, 50);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Size = new System.Drawing.Size(197, 63);
            this.pnlDate.TabIndex = 1;
            // 
            // dtpTestDateTo
            // 
            this.dtpTestDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtpTestDateTo.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtpTestDateTo.DropDownCalendar.Name = "";
            this.dtpTestDateTo.Location = new System.Drawing.Point(59, 33);
            this.dtpTestDateTo.Name = "dtpTestDateTo";
            this.dtpTestDateTo.ShowUpDown = true;
            this.dtpTestDateTo.Size = new System.Drawing.Size(132, 20);
            this.dtpTestDateTo.TabIndex = 38;
            this.dtpTestDateTo.Value = new System.DateTime(2012, 7, 19, 0, 0, 0, 0);
            // 
            // dtpTestDateFrom
            // 
            this.dtpTestDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpTestDateFrom.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtpTestDateFrom.DropDownCalendar.Name = "";
            this.dtpTestDateFrom.Location = new System.Drawing.Point(59, 5);
            this.dtpTestDateFrom.Name = "dtpTestDateFrom";
            this.dtpTestDateFrom.ShowUpDown = true;
            this.dtpTestDateFrom.Size = new System.Drawing.Size(132, 20);
            this.dtpTestDateFrom.TabIndex = 35;
            this.dtpTestDateFrom.Value = new System.DateTime(2012, 7, 19, 0, 0, 0, 0);
            // 
            // Label8
            // 
            this.Label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.ForeColor = System.Drawing.Color.Navy;
            this.Label8.Location = new System.Drawing.Point(3, 34);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(50, 20);
            this.Label8.TabIndex = 37;
            this.Label8.Text = "&Đến";
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Navy;
            this.Label1.Location = new System.Drawing.Point(3, 7);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(50, 20);
            this.Label1.TabIndex = 36;
            this.Label1.Text = "&Từ ";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Items.AddRange(new object[] {
            "Hôm Nay",
            "Hôm Qua",
            "Tùy Chọn"});
            this.comboBox1.Location = new System.Drawing.Point(7, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(187, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // UiGroupBox1
            // 
            this.UiGroupBox1.Controls.Add(this.txtMessageDisplay);
            this.UiGroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UiGroupBox1.Location = new System.Drawing.Point(3, 503);
            this.UiGroupBox1.Name = "UiGroupBox1";
            this.UiGroupBox1.Size = new System.Drawing.Size(452, 44);
            this.UiGroupBox1.TabIndex = 43;
            // 
            // txtMessageDisplay
            // 
            this.txtMessageDisplay.ActiveFormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.txtMessageDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessageDisplay.HighlightActiveButton = false;
            this.txtMessageDisplay.Image = ((System.Drawing.Image)(resources.GetObject("txtMessageDisplay.Image")));
            this.txtMessageDisplay.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near;
            this.txtMessageDisplay.ImageSize = new System.Drawing.Size(24, 24);
            this.txtMessageDisplay.Location = new System.Drawing.Point(3, 8);
            this.txtMessageDisplay.Name = "txtMessageDisplay";
            this.txtMessageDisplay.Size = new System.Drawing.Size(446, 33);
            this.txtMessageDisplay.TabIndex = 8;
            this.txtMessageDisplay.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near;
            this.txtMessageDisplay.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            // 
            // radChuaInPhieu
            // 
            this.radChuaInPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radChuaInPhieu.ForeColor = System.Drawing.Color.Navy;
            this.radChuaInPhieu.Location = new System.Drawing.Point(220, 78);
            this.radChuaInPhieu.Name = "radChuaInPhieu";
            this.radChuaInPhieu.Size = new System.Drawing.Size(88, 23);
            this.radChuaInPhieu.TabIndex = 42;
            this.radChuaInPhieu.Text = "&Chưa In phiếu";
            // 
            // radDaIn
            // 
            this.radDaIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radDaIn.ForeColor = System.Drawing.Color.Navy;
            this.radDaIn.Location = new System.Drawing.Point(126, 78);
            this.radDaIn.Name = "radDaIn";
            this.radDaIn.Size = new System.Drawing.Size(88, 23);
            this.radDaIn.TabIndex = 41;
            this.radDaIn.Text = "&Đã In phiếu";
            // 
            // chkIsFinal
            // 
            this.chkIsFinal.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsFinal.ForeColor = System.Drawing.Color.Blue;
            this.chkIsFinal.Location = new System.Drawing.Point(349, 16);
            this.chkIsFinal.Name = "chkIsFinal";
            this.chkIsFinal.Size = new System.Drawing.Size(213, 23);
            this.chkIsFinal.TabIndex = 37;
            this.chkIsFinal.Text = "Bệnh nhân hoàn tất";
            // 
            // rbtDaIn
            // 
            this.rbtDaIn.AutoSize = true;
            this.rbtDaIn.Location = new System.Drawing.Point(230, 24);
            this.rbtDaIn.Name = "rbtDaIn";
            this.rbtDaIn.Size = new System.Drawing.Size(51, 17);
            this.rbtDaIn.TabIndex = 36;
            this.rbtDaIn.Text = "Đã In";
            this.rbtDaIn.UseVisualStyleBackColor = true;
            // 
            // rbtChuaIn
            // 
            this.rbtChuaIn.AutoSize = true;
            this.rbtChuaIn.Location = new System.Drawing.Point(152, 24);
            this.rbtChuaIn.Name = "rbtChuaIn";
            this.rbtChuaIn.Size = new System.Drawing.Size(62, 17);
            this.rbtChuaIn.TabIndex = 36;
            this.rbtChuaIn.Text = "Chưa In";
            this.rbtChuaIn.UseVisualStyleBackColor = true;
            // 
            // radTatCa
            // 
            this.radTatCa.Checked = true;
            this.radTatCa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTatCa.ForeColor = System.Drawing.Color.Navy;
            this.radTatCa.Location = new System.Drawing.Point(32, 78);
            this.radTatCa.Name = "radTatCa";
            this.radTatCa.Size = new System.Drawing.Size(88, 23);
            this.radTatCa.TabIndex = 40;
            this.radTatCa.TabStop = true;
            this.radTatCa.Text = "&Tất cả";
            // 
            // rbtTatCa
            // 
            this.rbtTatCa.AutoSize = true;
            this.rbtTatCa.Checked = true;
            this.rbtTatCa.Location = new System.Drawing.Point(87, 23);
            this.rbtTatCa.Name = "rbtTatCa";
            this.rbtTatCa.Size = new System.Drawing.Size(57, 17);
            this.rbtTatCa.TabIndex = 36;
            this.rbtTatCa.TabStop = true;
            this.rbtTatCa.Text = "Tất Cả";
            this.rbtTatCa.UseVisualStyleBackColor = true;
            // 
            // cmdSearch
            // 
            this.cmdSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.Location = new System.Drawing.Point(232, 78);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(215, 38);
            this.cmdSearch.TabIndex = 35;
            this.cmdSearch.Text = "Tìm kiếm (F3)";
            this.cmdSearch.ToolTipText = "Tìm kiếm thông tin bệnh nhân hoặc nhấn phím tắt F3";
            // 
            // ckbHasResult
            // 
            this.ckbHasResult.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbHasResult.ForeColor = System.Drawing.Color.Red;
            this.ckbHasResult.Location = new System.Drawing.Point(209, 35);
            this.ckbHasResult.Name = "ckbHasResult";
            this.ckbHasResult.Size = new System.Drawing.Size(213, 23);
            this.ckbHasResult.TabIndex = 21;
            this.ckbHasResult.Text = "Bệnh nhân không có KQ";
            // 
            // cboDepartment
            // 
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.Location = new System.Drawing.Point(230, 47);
            this.cboDepartment.MaxDropDownItems = 20;
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(215, 21);
            this.cboDepartment.TabIndex = 20;
            // 
            // cboObjectType
            // 
            this.cboObjectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboObjectType.Location = new System.Drawing.Point(370, 18);
            this.cboObjectType.Name = "cboObjectType";
            this.cboObjectType.Size = new System.Drawing.Size(215, 21);
            this.cboObjectType.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.Location = new System.Drawing.Point(293, -6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 21);
            this.label4.TabIndex = 17;
            this.label4.Text = "Đối tượng";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.Location = new System.Drawing.Point(293, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "Khoa";
            // 
            // Label3
            // 
            this.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Label3.Location = new System.Drawing.Point(6, -6);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(52, 21);
            this.Label3.TabIndex = 14;
            this.Label3.Text = "Họ tên";
            // 
            // Label5
            // 
            this.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Label5.Location = new System.Drawing.Point(6, 25);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(52, 20);
            this.Label5.TabIndex = 16;
            this.Label5.Text = "Tuổi";
            // 
            // Label2
            // 
            this.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Label2.Location = new System.Drawing.Point(6, 56);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(40, 23);
            this.Label2.TabIndex = 12;
            this.Label2.Text = "PID";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(150, 308);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "Mã HIS";
            // 
            // txtMaHis
            // 
            this.txtMaHis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaHis.Location = new System.Drawing.Point(208, 109);
            this.txtMaHis.Name = "txtMaHis";
            this.txtMaHis.Size = new System.Drawing.Size(0, 20);
            this.txtMaHis.TabIndex = 5;
            // 
            // Label7
            // 
            this.Label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Label7.Location = new System.Drawing.Point(6, 309);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(63, 19);
            this.Label7.TabIndex = 6;
            this.Label7.Text = "&Barcode";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBarcode.Location = new System.Drawing.Point(72, 110);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(0, 20);
            this.txtBarcode.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(72, 19);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(79, 20);
            this.txtName.TabIndex = 0;
            // 
            // txtPID
            // 
            this.txtPID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPID.Location = new System.Drawing.Point(72, 80);
            this.txtPID.Name = "txtPID";
            this.txtPID.Size = new System.Drawing.Size(79, 20);
            this.txtPID.TabIndex = 4;
            // 
            // txtAge
            // 
            this.txtAge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAge.Location = new System.Drawing.Point(72, 50);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(0, 20);
            this.txtAge.TabIndex = 1;
            // 
            // cboSex
            // 
            this.cboSex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSex.Location = new System.Drawing.Point(85, 49);
            this.cboSex.Name = "cboSex";
            this.cboSex.Size = new System.Drawing.Size(66, 21);
            this.cboSex.TabIndex = 3;
            // 
            // Label6
            // 
            this.Label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label6.Location = new System.Drawing.Point(14, 52);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(74, 19);
            this.Label6.TabIndex = 2;
            this.Label6.Text = "Giới tính:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridEX1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(253, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 550);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Loại Xét Nghiệm";
            // 
            // gridEX1
            // 
            this.gridEX1.AllowDrop = true;
            this.gridEX1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gridEX1.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><RecordNavigator>Số lư" +
    "ợng: | Of</RecordNavigator><FilterRowInfoText>Lọc thông tin bệnh nhân</FilterRow" +
    "InfoText></LocalizableData>";
            this.gridEX1.ColumnAutoResize = true;
            this.gridEX1.ColumnHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
            gridEX1_DesignTimeLayout.LayoutString = resources.GetString("gridEX1_DesignTimeLayout.LayoutString");
            this.gridEX1.DesignTimeLayout = gridEX1_DesignTimeLayout;
            this.gridEX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEX1.DynamicFiltering = true;
            this.gridEX1.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.gridEX1.FilterRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridEX1.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.gridEX1.FocusCellFormatStyle.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridEX1.FocusCellFormatStyle.BackColorGradient = System.Drawing.SystemColors.Highlight;
            this.gridEX1.FocusCellFormatStyle.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.gridEX1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gridEX1.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gridEX1.GroupByBoxVisible = false;
            this.gridEX1.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.gridEX1.Location = new System.Drawing.Point(3, 16);
            this.gridEX1.Name = "gridEX1";
            this.gridEX1.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowPosition;
            this.gridEX1.SelectedFormatStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gridEX1.Size = new System.Drawing.Size(239, 531);
            this.gridEX1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 550);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.GroupBox4);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.cboDate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTestType)).EndInit();
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.grbDateSelector.ResumeLayout(false);
            this.pnlDate.ResumeLayout(false);
            this.pnlDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBox1)).EndInit();
            this.UiGroupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ComboBox cboDate;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal Janus.Windows.GridEX.GridEX grdTestType;
        internal System.Windows.Forms.GroupBox GroupBox4;
        private Janus.Windows.EditControls.UIRadioButton radChuaInPhieu;
        private Janus.Windows.EditControls.UIRadioButton radDaIn;
        internal Janus.Windows.EditControls.UICheckBox chkIsFinal;
        private System.Windows.Forms.RadioButton rbtDaIn;
        private System.Windows.Forms.RadioButton rbtChuaIn;
        private Janus.Windows.EditControls.UIRadioButton radTatCa;
        private System.Windows.Forms.RadioButton rbtTatCa;
        internal Janus.Windows.EditControls.UIButton cmdSearch;
        internal Janus.Windows.EditControls.UICheckBox ckbHasResult;
        internal System.Windows.Forms.ComboBox cboDepartment;
        internal System.Windows.Forms.ComboBox cboObjectType;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.TextBox txtMaHis;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.TextBox txtBarcode;
        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.TextBox txtPID;
        internal System.Windows.Forms.TextBox txtAge;
        internal System.Windows.Forms.ComboBox cboSex;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.GroupBox groupBox2;
        internal Janus.Windows.GridEX.GridEX gridEX1;
        internal Janus.Windows.EditControls.UIGroupBox UiGroupBox1;
        private Janus.Windows.EditControls.UIButton txtMessageDisplay;
        internal System.Windows.Forms.GroupBox grbDateSelector;
        private System.Windows.Forms.Panel pnlDate;
        internal Janus.Windows.CalendarCombo.CalendarCombo dtpTestDateTo;
        internal Janus.Windows.CalendarCombo.CalendarCombo dtpTestDateFrom;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox comboBox1;
    }
}