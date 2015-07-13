namespace VietBaIT.LABLink.List.UI.Forms
{
    partial class frmTestGroupList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTestGroupList));
            Janus.Windows.GridEX.GridEXLayout grdTestGroup_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdTestData_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.statusBar = new Janus.Windows.UI.StatusBar.UIStatusBar();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cmdSave = new System.Windows.Forms.ToolStripButton();
            this.cmdUpdate = new System.Windows.Forms.ToolStripButton();
            this.cmdDelete = new System.Windows.Forms.ToolStripButton();
            this.cmdExit = new System.Windows.Forms.ToolStripButton();
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.grdTestGroup = new Janus.Windows.GridEX.GridEX();
            this.uiGroupBox2 = new Janus.Windows.EditControls.UIGroupBox();
            this.grdTestData = new Janus.Windows.GridEX.GridEX();
            this.ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTestGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).BeginInit();
            this.uiGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTestData)).BeginInit();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 448);
            this.statusBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.statusBar.Name = "statusBar";
            uiStatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel1.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel1.Key = "";
            uiStatusBarPanel1.ProgressBarValue = 0;
            uiStatusBarPanel1.Text = "Mũi Tên: Cập Nhật Thông Tin Điều Khiển Chuẩn";
            uiStatusBarPanel1.ToolTipText = "Tick: Tạo quan hệ nhóm và chi tiết xét nghiệm";
            uiStatusBarPanel1.Width = 319;
            this.statusBar.Panels.AddRange(new Janus.Windows.UI.StatusBar.UIStatusBarPanel[] {
            uiStatusBarPanel1});
            this.statusBar.Size = new System.Drawing.Size(1067, 28);
            this.statusBar.TabIndex = 6;
            this.statusBar.VisualStyle = Janus.Windows.UI.VisualStyle.OfficeXP;
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.ToolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdSave,
            this.cmdUpdate,
            this.cmdDelete,
            this.cmdExit});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(1067, 39);
            this.ToolStrip1.TabIndex = 7;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // cmdSave
            // 
            this.cmdSave.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(146, 36);
            this.cmdSave.Tag = "Insert";
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
            this.cmdUpdate.Size = new System.Drawing.Size(140, 36);
            this.cmdUpdate.Tag = "Update";
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
            this.cmdDelete.Size = new System.Drawing.Size(94, 36);
            this.cmdDelete.Tag = "Delete";
            this.cmdDelete.Text = "Xóa (Del)";
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExit.Image = ((System.Drawing.Image)(resources.GetObject("cmdExit.Image")));
            this.cmdExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(107, 36);
            this.cmdExit.Text = "Thoát (Esc)";
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.grdTestGroup);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 39);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(521, 409);
            this.uiGroupBox1.TabIndex = 8;
            this.uiGroupBox1.Text = "Nhóm xét nghiệm";
            // 
            // grdTestGroup
            // 
            this.grdTestGroup.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            grdTestGroup_DesignTimeLayout.LayoutString = resources.GetString("grdTestGroup_DesignTimeLayout.LayoutString");
            this.grdTestGroup.DesignTimeLayout = grdTestGroup_DesignTimeLayout;
            this.grdTestGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTestGroup.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdTestGroup.GroupByBoxVisible = false;
            this.grdTestGroup.Location = new System.Drawing.Point(3, 22);
            this.grdTestGroup.Name = "grdTestGroup";
            this.grdTestGroup.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdTestGroup.Size = new System.Drawing.Size(515, 384);
            this.grdTestGroup.TabIndex = 9;
            this.grdTestGroup.SelectionChanged += new System.EventHandler(this.grdTestGroup_SelectionChanged);
            this.grdTestGroup.DoubleClick += new System.EventHandler(this.grdTestGroup_DoubleClick);
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.grdTestData);
            this.uiGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox2.Location = new System.Drawing.Point(521, 39);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Size = new System.Drawing.Size(546, 409);
            this.uiGroupBox2.TabIndex = 11;
            this.uiGroupBox2.Text = "Test xét nghiệm chuẩn";
            // 
            // grdTestData
            // 
            this.grdTestData.AllowDrop = true;
            this.grdTestData.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            grdTestData_DesignTimeLayout.LayoutString = resources.GetString("grdTestData_DesignTimeLayout.LayoutString");
            this.grdTestData.DesignTimeLayout = grdTestData_DesignTimeLayout;
            this.grdTestData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTestData.DynamicFiltering = true;
            this.grdTestData.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdTestData.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdTestData.GroupByBoxVisible = false;
            this.grdTestData.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.grdTestData.Location = new System.Drawing.Point(3, 22);
            this.grdTestData.Name = "grdTestData";
            this.grdTestData.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdTestData.Size = new System.Drawing.Size(540, 384);
            this.grdTestData.TabIndex = 9;
            this.grdTestData.RowCheckStateChanged += new Janus.Windows.GridEX.RowCheckStateChangeEventHandler(this.grdTestData_RowCheckStateChanged);
            // 
            // frmTestGroupList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 476);
            this.Controls.Add(this.uiGroupBox2);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.statusBar);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmTestGroupList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DANH MỤC CÁC CHI TIẾT XÉT NGHIỆM MẪU";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTestGroupList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTestGroupList_KeyDown);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTestGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).EndInit();
            this.uiGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTestData)).EndInit();
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
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private Janus.Windows.GridEX.GridEX grdTestGroup;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox2;
        private Janus.Windows.GridEX.GridEX grdTestData;
    }
}

