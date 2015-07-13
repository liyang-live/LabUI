namespace VietBaIT.LABLink.List.UI.Forms
{
    partial class frmHardwareManagement
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
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel1 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHardwareManagement));
            Janus.Windows.GridEX.GridEXLayout grdDevice_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdPort_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.statusBar = new Janus.Windows.UI.StatusBar.UIStatusBar();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cmdSave = new System.Windows.Forms.ToolStripButton();
            this.cmdUpdate = new System.Windows.Forms.ToolStripButton();
            this.cmdDelete = new System.Windows.Forms.ToolStripButton();
            this.cmdExit = new System.Windows.Forms.ToolStripButton();
            this.grdDevice = new Janus.Windows.GridEX.GridEX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grdPort = new Janus.Windows.GridEX.GridEX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnUpdate = new Janus.Windows.EditControls.UIButton();
            this.btnClear = new Janus.Windows.EditControls.UIButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cboList = new System.Windows.Forms.ToolStripComboBox();
            this.ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDevice)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPort)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 541);
            this.statusBar.Name = "statusBar";
            uiStatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel1.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel1.Key = "";
            uiStatusBarPanel1.ProgressBarValue = 0;
            uiStatusBarPanel1.Text = "Mũi Tên: Cập Nhật Thông Tin Điều Khiển Chuẩn";
            uiStatusBarPanel1.ToolTipText = "Thêm mới thông tin";
            uiStatusBarPanel1.Width = 388;
            this.statusBar.Panels.AddRange(new Janus.Windows.UI.StatusBar.UIStatusBarPanel[] {
            uiStatusBarPanel1});
            this.statusBar.Size = new System.Drawing.Size(1124, 23);
            this.statusBar.TabIndex = 7;
            this.statusBar.VisualStyle = Janus.Windows.UI.VisualStyle.OfficeXP;
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.ToolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cboList,
            this.toolStripSeparator1,
            this.cmdSave,
            this.cmdUpdate,
            this.cmdDelete,
            this.cmdExit});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(1124, 39);
            this.ToolStrip1.TabIndex = 8;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // cmdSave
            // 
            this.cmdSave.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(176, 36);
            this.cmdSave.Text = "Thêm Mới (Ctrl+N)";
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdUpdate.Image = ((System.Drawing.Image)(resources.GetObject("cmdUpdate.Image")));
            this.cmdUpdate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(169, 36);
            this.cmdUpdate.Text = "Cập Nhật (Ctrl+U)";
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(109, 36);
            this.cmdDelete.Text = "Xóa (Del)";
            // 
            // cmdExit
            // 
            this.cmdExit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExit.Image = ((System.Drawing.Image)(resources.GetObject("cmdExit.Image")));
            this.cmdExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(125, 36);
            this.cmdExit.Text = "Thoát (Esc)";
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // grdDevice
            // 
            grdDevice_DesignTimeLayout.LayoutString = resources.GetString("grdDevice_DesignTimeLayout.LayoutString");
            this.grdDevice.DesignTimeLayout = grdDevice_DesignTimeLayout;
            this.grdDevice.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdDevice.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdDevice.FilterRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grdDevice.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdDevice.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.grdDevice.GroupByBoxVisible = false;
            this.grdDevice.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdDevice.Location = new System.Drawing.Point(0, 39);
            this.grdDevice.Name = "grdDevice";
            this.grdDevice.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdDevice.Size = new System.Drawing.Size(640, 502);
            this.grdDevice.TabIndex = 14;
            this.grdDevice.CellValueChanged += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdDevice_CellValueChanged);
            this.grdDevice.SelectionChanged += new System.EventHandler(this.grdDevice_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grdPort);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(640, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 502);
            this.panel1.TabIndex = 15;
            // 
            // grdPort
            // 
            this.grdPort.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdPort.CellSelectionMode = Janus.Windows.GridEX.CellSelectionMode.SingleCell;
            grdPort_DesignTimeLayout.LayoutString = resources.GetString("grdPort_DesignTimeLayout.LayoutString");
            this.grdPort.DesignTimeLayout = grdPort_DesignTimeLayout;
            this.grdPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPort.DynamicFiltering = true;
            this.grdPort.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdPort.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.grdPort.GroupByBoxVisible = false;
            this.grdPort.GroupRowFormatStyle.BackColor = System.Drawing.Color.Empty;
            this.grdPort.GroupRowFormatStyle.BackColorGradient = System.Drawing.Color.Empty;
            this.grdPort.Location = new System.Drawing.Point(73, 0);
            this.grdPort.Name = "grdPort";
            this.grdPort.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdPort.SelectedFormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.grdPort.SelectedFormatStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdPort.Size = new System.Drawing.Size(411, 502);
            this.grdPort.TabIndex = 12;
            this.grdPort.DoubleClick += new System.EventHandler(this.grdPort_DoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(73, 502);
            this.panel2.TabIndex = 15;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageSize = new System.Drawing.Size(32, 32);
            this.btnUpdate.Location = new System.Drawing.Point(6, 210);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(61, 37);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.ToolTipText = "Kết nối";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageSize = new System.Drawing.Size(32, 32);
            this.btnClear.Location = new System.Drawing.Point(6, 253);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(61, 37);
            this.btnClear.TabIndex = 14;
            this.btnClear.ToolTipText = "Ngắt kết nối";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // cboList
            // 
            this.cboList.Items.AddRange(new object[] {
            "THIẾT BỊ",
            "PORT"});
            this.cboList.Name = "cboList";
            this.cboList.Size = new System.Drawing.Size(121, 39);
            // 
            // frmHardwareManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 564);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grdDevice);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.statusBar);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmHardwareManagement";
            this.Text = "QUẢN LÝ THIẾT BỊ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHardwareManagement_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmHardwareManagement_KeyDown);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDevice)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPort)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Janus.Windows.UI.StatusBar.UIStatusBar statusBar;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton cmdSave;
        internal System.Windows.Forms.ToolStripButton cmdUpdate;
        internal System.Windows.Forms.ToolStripButton cmdDelete;
        internal System.Windows.Forms.ToolStripButton cmdExit;
        private Janus.Windows.GridEX.GridEX grdDevice;
        private System.Windows.Forms.Panel panel1;
        private Janus.Windows.GridEX.GridEX grdPort;
        private System.Windows.Forms.Panel panel2;
        private Janus.Windows.EditControls.UIButton btnUpdate;
        private Janus.Windows.EditControls.UIButton btnClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox cboList;


    }
}