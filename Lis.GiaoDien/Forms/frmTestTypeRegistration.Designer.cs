namespace Vietbait.Lablink.TestInformation.UI.Forms
{
    partial class frmTestTypeRegistration
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
            this.components = new System.ComponentModel.Container();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel4 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel5 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel6 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTestTypeRegistration));
            Janus.Windows.GridEX.GridEXLayout grdTestInfo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.statusBar = new Janus.Windows.UI.StatusBar.UIStatusBar();
            this.uiGroupBox3 = new Janus.Windows.EditControls.UIGroupBox();
            this.btnPrintBarcode = new Janus.Windows.EditControls.UIButton();
            this.btnPrint = new Janus.Windows.EditControls.UIButton();
            this.cboSortType = new System.Windows.Forms.CheckBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtSex = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.flpTestType = new System.Windows.Forms.FlowLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.uiGroupBox2 = new Janus.Windows.EditControls.UIGroupBox();
            this.grdTestInfo = new Janus.Windows.GridEX.GridEX();
            this.cmsTestInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmUpdateBarcode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDelTestInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.spcStandardTest = new System.Windows.Forms.SplitContainer();
            this.uiGroupBox5 = new Janus.Windows.EditControls.UIGroupBox();
            this.flpTestGroup = new System.Windows.Forms.FlowLayoutPanel();
            this.uiGroupBox4 = new Janus.Windows.EditControls.UIGroupBox();
            this.flpStandardTest = new System.Windows.Forms.FlowLayoutPanel();
            this.imgAdminnistration = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cboAssignDoctor = new System.Windows.Forms.ComboBox();
            this.btnSaveAssignDoctor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox3)).BeginInit();
            this.uiGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).BeginInit();
            this.uiGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTestInfo)).BeginInit();
            this.cmsTestInfo.SuspendLayout();
            this.spcStandardTest.Panel1.SuspendLayout();
            this.spcStandardTest.Panel2.SuspendLayout();
            this.spcStandardTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox5)).BeginInit();
            this.uiGroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox4)).BeginInit();
            this.uiGroupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 653);
            this.statusBar.Name = "statusBar";
            uiStatusBarPanel4.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel4.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel4.Key = "";
            uiStatusBarPanel4.ProgressBarValue = 0;
            uiStatusBarPanel4.Text = "Ctrl+A: Chọn Tất Cả Chi Tiết";
            uiStatusBarPanel4.Width = 241;
            uiStatusBarPanel5.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel5.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel5.Key = "";
            uiStatusBarPanel5.ProgressBarValue = 0;
            uiStatusBarPanel5.Text = "Ctrl+U: Hủy Tất Cả Chi Tiết";
            uiStatusBarPanel5.Width = 231;
            uiStatusBarPanel6.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel6.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel6.Key = "";
            uiStatusBarPanel6.ProgressBarValue = 0;
            uiStatusBarPanel6.Text = "Esc: Thoát";
            uiStatusBarPanel6.Width = 102;
            this.statusBar.Panels.AddRange(new Janus.Windows.UI.StatusBar.UIStatusBarPanel[] {
            uiStatusBarPanel4,
            uiStatusBarPanel5,
            uiStatusBarPanel6});
            this.statusBar.Size = new System.Drawing.Size(1008, 29);
            this.statusBar.TabIndex = 1;
            this.statusBar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            // 
            // uiGroupBox3
            // 
            this.uiGroupBox3.Controls.Add(this.btnPrintBarcode);
            this.uiGroupBox3.Controls.Add(this.btnPrint);
            this.uiGroupBox3.Controls.Add(this.cboSortType);
            this.uiGroupBox3.Controls.Add(this.txtAge);
            this.uiGroupBox3.Controls.Add(this.Label4);
            this.uiGroupBox3.Controls.Add(this.txtPatientName);
            this.uiGroupBox3.Controls.Add(this.Label3);
            this.uiGroupBox3.Controls.Add(this.txtSex);
            this.uiGroupBox3.Controls.Add(this.Label2);
            this.uiGroupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiGroupBox3.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox3.Name = "uiGroupBox3";
            this.uiGroupBox3.Size = new System.Drawing.Size(1008, 88);
            this.uiGroupBox3.TabIndex = 1;
            this.uiGroupBox3.Text = "Thông Tin Bệnh Nhân";
            // 
            // btnPrintBarcode
            // 
            this.btnPrintBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintBarcode.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintBarcode.Image")));
            this.btnPrintBarcode.ImageSize = new System.Drawing.Size(32, 32);
            this.btnPrintBarcode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.btnPrintBarcode.Location = new System.Drawing.Point(716, 19);
            this.btnPrintBarcode.Name = "btnPrintBarcode";
            this.btnPrintBarcode.Size = new System.Drawing.Size(137, 39);
            this.btnPrintBarcode.TabIndex = 10;
            this.btnPrintBarcode.Text = "In Barcode (F9)";
            this.btnPrintBarcode.Click += new System.EventHandler(this.btnPrintBarcode_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageSize = new System.Drawing.Size(32, 32);
            this.btnPrint.Location = new System.Drawing.Point(859, 19);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(137, 39);
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Text = "In Phiếu (F4)";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cboSortType
            // 
            this.cboSortType.AutoSize = true;
            this.cboSortType.Location = new System.Drawing.Point(297, 57);
            this.cboSortType.Name = "cboSortType";
            this.cboSortType.Size = new System.Drawing.Size(386, 20);
            this.cboSortType.TabIndex = 9;
            this.cboSortType.Text = "Sắp xếp theo ABC (nút chỉ có tác dụng khi chạy lại form)";
            this.cboSortType.UseVisualStyleBackColor = true;
            this.cboSortType.Visible = false;
            // 
            // txtAge
            // 
            this.txtAge.Enabled = false;
            this.txtAge.Location = new System.Drawing.Point(333, 26);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(85, 22);
            this.txtAge.TabIndex = 8;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(294, 29);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(39, 16);
            this.Label4.TabIndex = 7;
            this.Label4.Text = "Tuổi:";
            // 
            // txtPatientName
            // 
            this.txtPatientName.Enabled = false;
            this.txtPatientName.Location = new System.Drawing.Point(97, 23);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(191, 22);
            this.txtPatientName.TabIndex = 6;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(20, 26);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(72, 16);
            this.Label3.TabIndex = 5;
            this.Label3.Text = "Họ và tên:";
            // 
            // txtSex
            // 
            this.txtSex.Enabled = false;
            this.txtSex.Location = new System.Drawing.Point(97, 51);
            this.txtSex.Name = "txtSex";
            this.txtSex.Size = new System.Drawing.Size(191, 22);
            this.txtSex.TabIndex = 2;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(20, 54);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(71, 16);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Giới Tính:";
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.btnSaveAssignDoctor);
            this.uiGroupBox1.Controls.Add(this.cboAssignDoctor);
            this.uiGroupBox1.Controls.Add(this.flpTestType);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 88);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(196, 565);
            this.uiGroupBox1.TabIndex = 5;
            this.uiGroupBox1.Text = "Đăng Ký Loại Xét Nghiệm";
            // 
            // flpTestType
            // 
            this.flpTestType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpTestType.AutoScroll = true;
            this.flpTestType.Location = new System.Drawing.Point(3, 49);
            this.flpTestType.Name = "flpTestType";
            this.flpTestType.Size = new System.Drawing.Size(190, 513);
            this.flpTestType.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(196, 88);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.uiGroupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.spcStandardTest);
            this.splitContainer1.Size = new System.Drawing.Size(812, 565);
            this.splitContainer1.SplitterDistance = 183;
            this.splitContainer1.TabIndex = 6;
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.grdTestInfo);
            this.uiGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Size = new System.Drawing.Size(812, 183);
            this.uiGroupBox2.TabIndex = 0;
            this.uiGroupBox2.Text = "Loại Xét Nghiệm Đã Đăng Ký";
            // 
            // grdTestInfo
            // 
            this.grdTestInfo.ColumnAutoResize = true;
            this.grdTestInfo.ContextMenuStrip = this.cmsTestInfo;
            grdTestInfo_DesignTimeLayout.LayoutString = resources.GetString("grdTestInfo_DesignTimeLayout.LayoutString");
            this.grdTestInfo.DesignTimeLayout = grdTestInfo_DesignTimeLayout;
            this.grdTestInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTestInfo.FocusCellFormatStyle.BackColor = System.Drawing.SystemColors.Control;
            this.grdTestInfo.FocusCellFormatStyle.BackColorGradient = System.Drawing.SystemColors.Control;
            this.grdTestInfo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdTestInfo.FrozenColumns = 2;
            this.grdTestInfo.GroupByBoxVisible = false;
            this.grdTestInfo.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdTestInfo.Location = new System.Drawing.Point(3, 18);
            this.grdTestInfo.Name = "grdTestInfo";
            this.grdTestInfo.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowPosition;
            this.grdTestInfo.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdTestInfo.Size = new System.Drawing.Size(806, 162);
            this.grdTestInfo.TabIndex = 3;
            this.grdTestInfo.SelectionChanged += new System.EventHandler(this.grdTestInfo_SelectionChanged);
            // 
            // cmsTestInfo
            // 
            this.cmsTestInfo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsTestInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmUpdateBarcode,
            this.tsmDelTestInfo});
            this.cmsTestInfo.Name = "contextMenuStrip1";
            this.cmsTestInfo.ShowImageMargin = false;
            this.cmsTestInfo.Size = new System.Drawing.Size(233, 48);
            this.cmsTestInfo.Text = "VietBaIT JSC.,";
            // 
            // tsmUpdateBarcode
            // 
            this.tsmUpdateBarcode.Name = "tsmUpdateBarcode";
            this.tsmUpdateBarcode.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.tsmUpdateBarcode.Size = new System.Drawing.Size(232, 22);
            this.tsmUpdateBarcode.Text = "Cập nhật Barcode";
            this.tsmUpdateBarcode.Click += new System.EventHandler(this.tsmUpdateBarcode_Click);
            // 
            // tsmDelTestInfo
            // 
            this.tsmDelTestInfo.Name = "tsmDelTestInfo";
            this.tsmDelTestInfo.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.tsmDelTestInfo.Size = new System.Drawing.Size(232, 22);
            this.tsmDelTestInfo.Text = "Xóa đăng ký loại xét nghiệm";
            this.tsmDelTestInfo.Click += new System.EventHandler(this.tsmDelTestInfo_Click);
            // 
            // spcStandardTest
            // 
            this.spcStandardTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcStandardTest.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcStandardTest.IsSplitterFixed = true;
            this.spcStandardTest.Location = new System.Drawing.Point(0, 0);
            this.spcStandardTest.Name = "spcStandardTest";
            // 
            // spcStandardTest.Panel1
            // 
            this.spcStandardTest.Panel1.Controls.Add(this.uiGroupBox5);
            // 
            // spcStandardTest.Panel2
            // 
            this.spcStandardTest.Panel2.Controls.Add(this.uiGroupBox4);
            this.spcStandardTest.Size = new System.Drawing.Size(812, 378);
            this.spcStandardTest.SplitterDistance = 150;
            this.spcStandardTest.TabIndex = 0;
            // 
            // uiGroupBox5
            // 
            this.uiGroupBox5.Controls.Add(this.flpTestGroup);
            this.uiGroupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox5.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox5.Name = "uiGroupBox5";
            this.uiGroupBox5.Size = new System.Drawing.Size(150, 378);
            this.uiGroupBox5.TabIndex = 0;
            this.uiGroupBox5.Text = "Nhóm Chi Tiết";
            // 
            // flpTestGroup
            // 
            this.flpTestGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTestGroup.Location = new System.Drawing.Point(3, 18);
            this.flpTestGroup.Name = "flpTestGroup";
            this.flpTestGroup.Size = new System.Drawing.Size(144, 357);
            this.flpTestGroup.TabIndex = 2;
            // 
            // uiGroupBox4
            // 
            this.uiGroupBox4.Controls.Add(this.flpStandardTest);
            this.uiGroupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox4.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox4.Name = "uiGroupBox4";
            this.uiGroupBox4.Size = new System.Drawing.Size(658, 378);
            this.uiGroupBox4.TabIndex = 0;
            this.uiGroupBox4.Text = "Chi Tiết Xét Nghiệm";
            // 
            // flpStandardTest
            // 
            this.flpStandardTest.AutoScroll = true;
            this.flpStandardTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpStandardTest.Location = new System.Drawing.Point(3, 18);
            this.flpStandardTest.Name = "flpStandardTest";
            this.flpStandardTest.Size = new System.Drawing.Size(652, 357);
            this.flpStandardTest.TabIndex = 1;
            // 
            // imgAdminnistration
            // 
            this.imgAdminnistration.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgAdminnistration.ImageStream")));
            this.imgAdminnistration.TransparentColor = System.Drawing.Color.Transparent;
            this.imgAdminnistration.Images.SetKeyName(0, "kopeteavailable.png");
            this.imgAdminnistration.Images.SetKeyName(1, "clean.png");
            this.imgAdminnistration.Images.SetKeyName(2, "flag.png");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(36, 4);
            this.contextMenuStrip1.Text = "Chọn Thiết Bị";
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // cboAssignDoctor
            // 
            this.cboAssignDoctor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboAssignDoctor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAssignDoctor.FormattingEnabled = true;
            this.cboAssignDoctor.Location = new System.Drawing.Point(6, 21);
            this.cboAssignDoctor.Name = "cboAssignDoctor";
            this.cboAssignDoctor.Size = new System.Drawing.Size(129, 24);
            this.cboAssignDoctor.TabIndex = 1;
            this.cboAssignDoctor.SelectedIndexChanged += new System.EventHandler(this.cboAssignDoctor_SelectedIndexChanged);
            // 
            // btnSaveAssignDoctor
            // 
            this.btnSaveAssignDoctor.Enabled = false;
            this.btnSaveAssignDoctor.Location = new System.Drawing.Point(141, 21);
            this.btnSaveAssignDoctor.Name = "btnSaveAssignDoctor";
            this.btnSaveAssignDoctor.Size = new System.Drawing.Size(49, 23);
            this.btnSaveAssignDoctor.TabIndex = 11;
            this.btnSaveAssignDoctor.Text = "Lưu";
            this.btnSaveAssignDoctor.UseVisualStyleBackColor = true;
            this.btnSaveAssignDoctor.Click += new System.EventHandler(this.btnSaveAssignDoctor_Click);
            // 
            // frmTestTypeRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 682);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.uiGroupBox3);
            this.Controls.Add(this.statusBar);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTestTypeRegistration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "THÔNG TIN KẾT QUẢ XÉT NGHIỆM";
            this.Load += new System.EventHandler(this.frmTestTypeRegistration_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTestTypeRegistration_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox3)).EndInit();
            this.uiGroupBox3.ResumeLayout(false);
            this.uiGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).EndInit();
            this.uiGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTestInfo)).EndInit();
            this.cmsTestInfo.ResumeLayout(false);
            this.spcStandardTest.Panel1.ResumeLayout(false);
            this.spcStandardTest.Panel2.ResumeLayout(false);
            this.spcStandardTest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox5)).EndInit();
            this.uiGroupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox4)).EndInit();
            this.uiGroupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.StatusBar.UIStatusBar statusBar;
        internal Janus.Windows.EditControls.UIGroupBox uiGroupBox3;
        internal System.Windows.Forms.CheckBox cboSortType;
        internal System.Windows.Forms.TextBox txtAge;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtPatientName;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtSex;
        internal System.Windows.Forms.Label Label2;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox2;
        internal Janus.Windows.GridEX.GridEX grdTestInfo;
        internal System.Windows.Forms.ImageList imgAdminnistration;
        private System.Windows.Forms.FlowLayoutPanel flpTestType;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox4;
        private System.Windows.Forms.SplitContainer spcStandardTest;
        private System.Windows.Forms.FlowLayoutPanel flpStandardTest;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox5;
        private System.Windows.Forms.FlowLayoutPanel flpTestGroup;
        private Janus.Windows.EditControls.UIButton btnPrint;
        private Janus.Windows.EditControls.UIButton btnPrintBarcode;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip cmsTestInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmUpdateBarcode;
        private System.Windows.Forms.ToolStripMenuItem tsmDelTestInfo;
        private System.Windows.Forms.ComboBox cboAssignDoctor;
        private System.Windows.Forms.Button btnSaveAssignDoctor;


    }
}