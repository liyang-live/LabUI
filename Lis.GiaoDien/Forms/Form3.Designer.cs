namespace Lis.GiaoDien.Forms
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            Janus.Windows.GridEX.GridEXLayout grdResultDetail_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.pnlDate = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.dtpTestDateTo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.dtpTestDateFrom = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.grbDateSelector = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.calendarCombo1 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.calendarCombo2 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cboDate = new System.Windows.Forms.ComboBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.cboSex = new System.Windows.Forms.ComboBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtPID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.txtMaHis = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboObjectType = new System.Windows.Forms.ComboBox();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.ckbHasResult = new Janus.Windows.EditControls.UICheckBox();
            this.cmdSearch = new Janus.Windows.EditControls.UIButton();
            this.rbtTatCa = new System.Windows.Forms.RadioButton();
            this.rbtChuaIn = new System.Windows.Forms.RadioButton();
            this.rbtDaIn = new System.Windows.Forms.RadioButton();
            this.chkIsFinal = new Janus.Windows.EditControls.UICheckBox();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cmdAddPatient = new System.Windows.Forms.ToolStripButton();
            this.cmdUpdatePatient = new System.Windows.Forms.ToolStripButton();
            this.cmdDeletePatient = new System.Windows.Forms.ToolStripButton();
            this.cmdTestTypeReg = new System.Windows.Forms.ToolStripButton();
            this.btnPrintBarcode = new System.Windows.Forms.ToolStripButton();
            this.cmd_InPhieu_ChiDinh = new System.Windows.Forms.ToolStripButton();
            this.cmd_InPhieu_XetNghiem_TongHop = new System.Windows.Forms.ToolStripButton();
            this.cmdValidate = new System.Windows.Forms.ToolStripButton();
            this.cmdUnValidate = new System.Windows.Forms.ToolStripButton();
            this.cmdEscape = new System.Windows.Forms.ToolStripButton();
            this.grdResultDetail = new Janus.Windows.GridEX.GridEX();
            this.pnlDate.SuspendLayout();
            this.grbDateSelector.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDate
            // 
            this.pnlDate.Controls.Add(this.progressBar);
            this.pnlDate.Controls.Add(this.dtpTestDateTo);
            this.pnlDate.Controls.Add(this.dtpTestDateFrom);
            this.pnlDate.Controls.Add(this.Label8);
            this.pnlDate.Controls.Add(this.Label1);
            this.pnlDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDate.Location = new System.Drawing.Point(3, 16);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Size = new System.Drawing.Size(201, 63);
            this.pnlDate.TabIndex = 1;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(0, 0);
            this.progressBar.MarqueeAnimationSpeed = 30;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(201, 63);
            this.progressBar.TabIndex = 39;
            this.progressBar.Visible = false;
            // 
            // dtpTestDateTo
            // 
            this.dtpTestDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtpTestDateTo.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtpTestDateTo.DropDownCalendar.Name = "";
            this.dtpTestDateTo.DropDownCalendar.Visible = false;
            this.dtpTestDateTo.Location = new System.Drawing.Point(59, 33);
            this.dtpTestDateTo.Name = "dtpTestDateTo";
            this.dtpTestDateTo.ShowUpDown = true;
            this.dtpTestDateTo.Size = new System.Drawing.Size(132, 20);
            this.dtpTestDateTo.TabIndex = 38;
            this.dtpTestDateTo.Value = new System.DateTime(2015, 4, 15, 0, 0, 0, 0);
            // 
            // dtpTestDateFrom
            // 
            this.dtpTestDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpTestDateFrom.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtpTestDateFrom.DropDownCalendar.Name = "";
            this.dtpTestDateFrom.DropDownCalendar.Visible = false;
            this.dtpTestDateFrom.Location = new System.Drawing.Point(59, 5);
            this.dtpTestDateFrom.Name = "dtpTestDateFrom";
            this.dtpTestDateFrom.ShowUpDown = true;
            this.dtpTestDateFrom.Size = new System.Drawing.Size(132, 20);
            this.dtpTestDateFrom.TabIndex = 35;
            this.dtpTestDateFrom.Value = new System.DateTime(2015, 4, 15, 0, 0, 0, 0);
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
            // grbDateSelector
            // 
            this.grbDateSelector.Controls.Add(this.groupBox1);
            this.grbDateSelector.Controls.Add(this.pnlDate);
            this.grbDateSelector.Dock = System.Windows.Forms.DockStyle.Left;
            this.grbDateSelector.Location = new System.Drawing.Point(0, 0);
            this.grbDateSelector.Name = "grbDateSelector";
            this.grbDateSelector.Size = new System.Drawing.Size(207, 517);
            this.grbDateSelector.TabIndex = 37;
            this.grbDateSelector.TabStop = false;
            this.grbDateSelector.Text = "Ngày";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.cboDate);
            this.groupBox1.Location = new System.Drawing.Point(22, 153);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(203, 84);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ngày";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.calendarCombo1);
            this.panel1.Controls.Add(this.calendarCombo2);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(197, 63);
            this.panel1.TabIndex = 1;
            // 
            // calendarCombo1
            // 
            this.calendarCombo1.CustomFormat = "dd/MM/yyyy";
            this.calendarCombo1.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calendarCombo1.DropDownCalendar.Name = "";
            this.calendarCombo1.DropDownCalendar.Visible = false;
            this.calendarCombo1.Location = new System.Drawing.Point(59, 33);
            this.calendarCombo1.Name = "calendarCombo1";
            this.calendarCombo1.ShowUpDown = true;
            this.calendarCombo1.Size = new System.Drawing.Size(132, 20);
            this.calendarCombo1.TabIndex = 38;
            this.calendarCombo1.Value = new System.DateTime(2012, 7, 19, 0, 0, 0, 0);
            // 
            // calendarCombo2
            // 
            this.calendarCombo2.CustomFormat = "dd/MM/yyyy";
            this.calendarCombo2.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.calendarCombo2.DropDownCalendar.Name = "";
            this.calendarCombo2.DropDownCalendar.Visible = false;
            this.calendarCombo2.Location = new System.Drawing.Point(59, 5);
            this.calendarCombo2.Name = "calendarCombo2";
            this.calendarCombo2.ShowUpDown = true;
            this.calendarCombo2.Size = new System.Drawing.Size(132, 20);
            this.calendarCombo2.TabIndex = 35;
            this.calendarCombo2.Value = new System.DateTime(2012, 7, 19, 0, 0, 0, 0);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Navy;
            this.label10.Location = new System.Drawing.Point(3, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 20);
            this.label10.TabIndex = 37;
            this.label10.Text = "&Đến";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Navy;
            this.label11.Location = new System.Drawing.Point(3, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 20);
            this.label11.TabIndex = 36;
            this.label11.Text = "&Từ ";
            // 
            // cboDate
            // 
            this.cboDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDate.Items.AddRange(new object[] {
            "Hôm Nay",
            "Hôm Qua",
            "Tùy Chọn"});
            this.cboDate.Location = new System.Drawing.Point(3, 342);
            this.cboDate.Name = "cboDate";
            this.cboDate.Size = new System.Drawing.Size(187, 21);
            this.cboDate.TabIndex = 0;
            // 
            // Label6
            // 
            this.Label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label6.Location = new System.Drawing.Point(150, 52);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(74, 19);
            this.Label6.TabIndex = 2;
            this.Label6.Text = "Giới tính:";
            // 
            // cboSex
            // 
            this.cboSex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSex.Location = new System.Drawing.Point(221, 49);
            this.cboSex.Name = "cboSex";
            this.cboSex.Size = new System.Drawing.Size(66, 21);
            this.cboSex.TabIndex = 3;
            // 
            // txtAge
            // 
            this.txtAge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAge.Location = new System.Drawing.Point(72, 50);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(63, 20);
            this.txtAge.TabIndex = 1;
            // 
            // txtPID
            // 
            this.txtPID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPID.Location = new System.Drawing.Point(72, 80);
            this.txtPID.Name = "txtPID";
            this.txtPID.Size = new System.Drawing.Size(215, 20);
            this.txtPID.TabIndex = 4;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(72, 19);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(215, 20);
            this.txtName.TabIndex = 0;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBarcode.Location = new System.Drawing.Point(72, 110);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(72, 20);
            this.txtBarcode.TabIndex = 5;
            // 
            // Label7
            // 
            this.Label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Label7.Location = new System.Drawing.Point(6, 117);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(63, 19);
            this.Label7.TabIndex = 6;
            this.Label7.Text = "&Barcode";
            // 
            // txtMaHis
            // 
            this.txtMaHis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaHis.Location = new System.Drawing.Point(208, 109);
            this.txtMaHis.Name = "txtMaHis";
            this.txtMaHis.Size = new System.Drawing.Size(79, 20);
            this.txtMaHis.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(150, 116);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "Mã HIS";
            // 
            // Label2
            // 
            this.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Label2.Location = new System.Drawing.Point(6, 85);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(40, 23);
            this.Label2.TabIndex = 12;
            this.Label2.Text = "PID";
            // 
            // Label5
            // 
            this.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Label5.Location = new System.Drawing.Point(6, 54);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(52, 20);
            this.Label5.TabIndex = 16;
            this.Label5.Text = "Tuổi";
            // 
            // Label3
            // 
            this.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Label3.Location = new System.Drawing.Point(6, 23);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(52, 21);
            this.Label3.TabIndex = 14;
            this.Label3.Text = "Họ tên";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.Location = new System.Drawing.Point(293, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "Khoa";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.Location = new System.Drawing.Point(293, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 21);
            this.label4.TabIndex = 17;
            this.label4.Text = "Đối tượng";
            // 
            // cboObjectType
            // 
            this.cboObjectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboObjectType.Location = new System.Drawing.Point(370, 18);
            this.cboObjectType.Name = "cboObjectType";
            this.cboObjectType.Size = new System.Drawing.Size(215, 21);
            this.cboObjectType.TabIndex = 19;
            // 
            // cboDepartment
            // 
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.Location = new System.Drawing.Point(370, 49);
            this.cboDepartment.MaxDropDownItems = 20;
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(215, 21);
            this.cboDepartment.TabIndex = 20;
            // 
            // ckbHasResult
            // 
            this.ckbHasResult.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbHasResult.ForeColor = System.Drawing.Color.Red;
            this.ckbHasResult.Location = new System.Drawing.Point(370, 96);
            this.ckbHasResult.Name = "ckbHasResult";
            this.ckbHasResult.Size = new System.Drawing.Size(213, 23);
            this.ckbHasResult.TabIndex = 21;
            this.ckbHasResult.Text = "Bệnh nhân không có KQ";
            // 
            // cmdSearch
            // 
            this.cmdSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.Location = new System.Drawing.Point(370, 120);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(215, 38);
            this.cmdSearch.TabIndex = 35;
            this.cmdSearch.Text = "Tìm kiếm (F3)";
            this.cmdSearch.ToolTipText = "Tìm kiếm thông tin bệnh nhân hoặc nhấn phím tắt F3";
            // 
            // rbtTatCa
            // 
            this.rbtTatCa.AutoSize = true;
            this.rbtTatCa.Checked = true;
            this.rbtTatCa.Location = new System.Drawing.Point(9, 137);
            this.rbtTatCa.Name = "rbtTatCa";
            this.rbtTatCa.Size = new System.Drawing.Size(57, 17);
            this.rbtTatCa.TabIndex = 36;
            this.rbtTatCa.TabStop = true;
            this.rbtTatCa.Text = "Tất Cả";
            this.rbtTatCa.UseVisualStyleBackColor = true;
            // 
            // rbtChuaIn
            // 
            this.rbtChuaIn.AutoSize = true;
            this.rbtChuaIn.Location = new System.Drawing.Point(74, 138);
            this.rbtChuaIn.Name = "rbtChuaIn";
            this.rbtChuaIn.Size = new System.Drawing.Size(62, 17);
            this.rbtChuaIn.TabIndex = 36;
            this.rbtChuaIn.Text = "Chưa In";
            this.rbtChuaIn.UseVisualStyleBackColor = true;
            // 
            // rbtDaIn
            // 
            this.rbtDaIn.AutoSize = true;
            this.rbtDaIn.Location = new System.Drawing.Point(152, 138);
            this.rbtDaIn.Name = "rbtDaIn";
            this.rbtDaIn.Size = new System.Drawing.Size(51, 17);
            this.rbtDaIn.TabIndex = 36;
            this.rbtDaIn.Text = "Đã In";
            this.rbtDaIn.UseVisualStyleBackColor = true;
            // 
            // chkIsFinal
            // 
            this.chkIsFinal.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsFinal.ForeColor = System.Drawing.Color.Blue;
            this.chkIsFinal.Location = new System.Drawing.Point(370, 75);
            this.chkIsFinal.Name = "chkIsFinal";
            this.chkIsFinal.Size = new System.Drawing.Size(213, 23);
            this.chkIsFinal.TabIndex = 37;
            this.chkIsFinal.Text = "Bệnh nhân hoàn tất";
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.chkIsFinal);
            this.GroupBox4.Controls.Add(this.rbtDaIn);
            this.GroupBox4.Controls.Add(this.rbtChuaIn);
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
            this.GroupBox4.Location = new System.Drawing.Point(454, 0);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(594, 527);
            this.GroupBox4.TabIndex = 36;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Thông Tin Bệnh Nhân";
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdAddPatient,
            this.cmdUpdatePatient,
            this.cmdDeletePatient,
            this.cmdTestTypeReg,
            this.btnPrintBarcode,
            this.cmd_InPhieu_ChiDinh,
            this.cmd_InPhieu_XetNghiem_TongHop,
            this.cmdValidate,
            this.cmdUnValidate,
            this.cmdEscape});
            this.ToolStrip1.Location = new System.Drawing.Point(207, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(841, 39);
            this.ToolStrip1.TabIndex = 38;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // cmdAddPatient
            // 
            this.cmdAddPatient.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddPatient.Image = ((System.Drawing.Image)(resources.GetObject("cmdAddPatient.Image")));
            this.cmdAddPatient.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdAddPatient.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdAddPatient.Name = "cmdAddPatient";
            this.cmdAddPatient.Size = new System.Drawing.Size(36, 36);
            this.cmdAddPatient.Tag = "";
            this.cmdAddPatient.ToolTipText = "Thêm BN (Ctrl+N)";
            // 
            // cmdUpdatePatient
            // 
            this.cmdUpdatePatient.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdUpdatePatient.Image = ((System.Drawing.Image)(resources.GetObject("cmdUpdatePatient.Image")));
            this.cmdUpdatePatient.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdUpdatePatient.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdUpdatePatient.Name = "cmdUpdatePatient";
            this.cmdUpdatePatient.Size = new System.Drawing.Size(36, 36);
            this.cmdUpdatePatient.Tag = "";
            this.cmdUpdatePatient.ToolTipText = "Cập nhật BN (Ctrl+U)";
            // 
            // cmdDeletePatient
            // 
            this.cmdDeletePatient.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDeletePatient.Image = ((System.Drawing.Image)(resources.GetObject("cmdDeletePatient.Image")));
            this.cmdDeletePatient.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdDeletePatient.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdDeletePatient.Name = "cmdDeletePatient";
            this.cmdDeletePatient.Size = new System.Drawing.Size(36, 36);
            this.cmdDeletePatient.ToolTipText = "Xóa bệnh nhân (Ctrl+X)";
            // 
            // cmdTestTypeReg
            // 
            this.cmdTestTypeReg.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdTestTypeReg.Image = ((System.Drawing.Image)(resources.GetObject("cmdTestTypeReg.Image")));
            this.cmdTestTypeReg.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdTestTypeReg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdTestTypeReg.Name = "cmdTestTypeReg";
            this.cmdTestTypeReg.Size = new System.Drawing.Size(36, 36);
            this.cmdTestTypeReg.ToolTipText = "Đăng ký chi tiết (Ctrl+T)";
            // 
            // btnPrintBarcode
            // 
            this.btnPrintBarcode.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintBarcode.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintBarcode.Image")));
            this.btnPrintBarcode.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPrintBarcode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintBarcode.Name = "btnPrintBarcode";
            this.btnPrintBarcode.Size = new System.Drawing.Size(36, 36);
            this.btnPrintBarcode.Tag = "";
            this.btnPrintBarcode.ToolTipText = "In Barcode (F9)";
            // 
            // cmd_InPhieu_ChiDinh
            // 
            this.cmd_InPhieu_ChiDinh.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_InPhieu_ChiDinh.Image = ((System.Drawing.Image)(resources.GetObject("cmd_InPhieu_ChiDinh.Image")));
            this.cmd_InPhieu_ChiDinh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmd_InPhieu_ChiDinh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmd_InPhieu_ChiDinh.Name = "cmd_InPhieu_ChiDinh";
            this.cmd_InPhieu_ChiDinh.Size = new System.Drawing.Size(36, 36);
            this.cmd_InPhieu_ChiDinh.Tag = "";
            this.cmd_InPhieu_ChiDinh.ToolTipText = "In Phiếu Chỉ Định (F4)";
            // 
            // cmd_InPhieu_XetNghiem_TongHop
            // 
            this.cmd_InPhieu_XetNghiem_TongHop.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_InPhieu_XetNghiem_TongHop.Image = ((System.Drawing.Image)(resources.GetObject("cmd_InPhieu_XetNghiem_TongHop.Image")));
            this.cmd_InPhieu_XetNghiem_TongHop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmd_InPhieu_XetNghiem_TongHop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmd_InPhieu_XetNghiem_TongHop.Name = "cmd_InPhieu_XetNghiem_TongHop";
            this.cmd_InPhieu_XetNghiem_TongHop.Size = new System.Drawing.Size(36, 36);
            this.cmd_InPhieu_XetNghiem_TongHop.Tag = "";
            this.cmd_InPhieu_XetNghiem_TongHop.ToolTipText = "In Phiếu Kết Quả Tổng Hợp (F4)";
            // 
            // cmdValidate
            // 
            this.cmdValidate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdValidate.Image = ((System.Drawing.Image)(resources.GetObject("cmdValidate.Image")));
            this.cmdValidate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdValidate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdValidate.Name = "cmdValidate";
            this.cmdValidate.Size = new System.Drawing.Size(36, 36);
            this.cmdValidate.Tag = "";
            this.cmdValidate.ToolTipText = "Hoàn tất (F9)";
            // 
            // cmdUnValidate
            // 
            this.cmdUnValidate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdUnValidate.Image = ((System.Drawing.Image)(resources.GetObject("cmdUnValidate.Image")));
            this.cmdUnValidate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdUnValidate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdUnValidate.Name = "cmdUnValidate";
            this.cmdUnValidate.Size = new System.Drawing.Size(36, 36);
            this.cmdUnValidate.Tag = "";
            this.cmdUnValidate.ToolTipText = "Hủy hoàn tất (F10)";
            // 
            // cmdEscape
            // 
            this.cmdEscape.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEscape.Image = ((System.Drawing.Image)(resources.GetObject("cmdEscape.Image")));
            this.cmdEscape.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdEscape.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdEscape.Name = "cmdEscape";
            this.cmdEscape.Size = new System.Drawing.Size(36, 36);
            this.cmdEscape.Tag = "";
            this.cmdEscape.ToolTipText = "Thoát (Esc)";
            // 
            // grdResultDetail
            // 
            this.grdResultDetail.AutomaticSort = false;
            this.grdResultDetail.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><RecordNavigator>Số lư" +
    "ợng:| Of</RecordNavigator></LocalizableData>";
            grdResultDetail_DesignTimeLayout.LayoutString = resources.GetString("grdResultDetail_DesignTimeLayout.LayoutString");
            this.grdResultDetail.DesignTimeLayout = grdResultDetail_DesignTimeLayout;
            this.grdResultDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdResultDetail.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdResultDetail.GroupByBoxVisible = false;
            this.grdResultDetail.Location = new System.Drawing.Point(207, 39);
            this.grdResultDetail.Name = "grdResultDetail";
            this.grdResultDetail.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Blue;
            this.grdResultDetail.Office2007CustomColor = System.Drawing.SystemColors.Highlight;
            this.grdResultDetail.RecordNavigator = true;
            this.grdResultDetail.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdResultDetail.SelectedFormatStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdResultDetail.SettingsKey = "grdResultDetail";
            this.grdResultDetail.Size = new System.Drawing.Size(841, 478);
            this.grdResultDetail.TabIndex = 39;
            this.grdResultDetail.TotalRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grdResultDetail.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 517);
            this.Controls.Add(this.grdResultDetail);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.grbDateSelector);
            this.Controls.Add(this.GroupBox4);
            this.Name = "Form3";
            this.Text = "Form3";
            this.pnlDate.ResumeLayout(false);
            this.pnlDate.PerformLayout();
            this.grbDateSelector.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlDate;
        internal Janus.Windows.CalendarCombo.CalendarCombo dtpTestDateTo;
        internal Janus.Windows.CalendarCombo.CalendarCombo dtpTestDateFrom;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.GroupBox grbDateSelector;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.ComboBox cboSex;
        internal System.Windows.Forms.TextBox txtAge;
        internal System.Windows.Forms.TextBox txtPID;
        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.TextBox txtBarcode;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.TextBox txtMaHis;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox cboObjectType;
        internal System.Windows.Forms.ComboBox cboDepartment;
        internal Janus.Windows.EditControls.UICheckBox ckbHasResult;
        internal Janus.Windows.EditControls.UIButton cmdSearch;
        private System.Windows.Forms.RadioButton rbtTatCa;
        private System.Windows.Forms.RadioButton rbtChuaIn;
        private System.Windows.Forms.RadioButton rbtDaIn;
        internal Janus.Windows.EditControls.UICheckBox chkIsFinal;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton cmdAddPatient;
        internal System.Windows.Forms.ToolStripButton cmdUpdatePatient;
        internal System.Windows.Forms.ToolStripButton cmdDeletePatient;
        internal System.Windows.Forms.ToolStripButton cmdTestTypeReg;
        internal System.Windows.Forms.ToolStripButton btnPrintBarcode;
        internal System.Windows.Forms.ToolStripButton cmd_InPhieu_ChiDinh;
        internal System.Windows.Forms.ToolStripButton cmd_InPhieu_XetNghiem_TongHop;
        internal System.Windows.Forms.ToolStripButton cmdValidate;
        internal System.Windows.Forms.ToolStripButton cmdUnValidate;
        internal System.Windows.Forms.ToolStripButton cmdEscape;
        internal Janus.Windows.GridEX.GridEX grdResultDetail;
        private System.Windows.Forms.ProgressBar progressBar;
        internal System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        internal Janus.Windows.CalendarCombo.CalendarCombo calendarCombo1;
        internal Janus.Windows.CalendarCombo.CalendarCombo calendarCombo2;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.ComboBox cboDate;
    }
}