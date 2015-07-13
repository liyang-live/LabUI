namespace VietBaIT.LABLink.List.UI
{
    partial class frmDataControlList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDataControlList));
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel1 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.GridEX.GridEXLayout grdTestData_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdDataControl_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cmdSave = new System.Windows.Forms.ToolStripButton();
            this.cmdUpdate = new System.Windows.Forms.ToolStripButton();
            this.cmdDelete = new System.Windows.Forms.ToolStripButton();
            this.cmdExit = new System.Windows.Forms.ToolStripButton();
            this.statusBar = new Janus.Windows.UI.StatusBar.UIStatusBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUpdateStandardData = new Janus.Windows.EditControls.UIButton();
            this.grdTestData = new Janus.Windows.GridEX.GridEX();
            this.grdDataControl = new Janus.Windows.GridEX.GridEX();
            this.ToolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTestData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDataControl)).BeginInit();
            this.SuspendLayout();
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
            this.ToolStrip1.TabIndex = 5;
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
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 370);
            this.statusBar.Name = "statusBar";
            uiStatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel1.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel1.Key = "";
            uiStatusBarPanel1.ProgressBarValue = 0;
            uiStatusBarPanel1.Text = "Mũi Tên: Cập Nhật Thông Tin Điều Khiển Chuẩn";
            uiStatusBarPanel1.ToolTipText = "Thêm mới thông tin";
            uiStatusBarPanel1.Width = 320;
            this.statusBar.Panels.AddRange(new Janus.Windows.UI.StatusBar.UIStatusBarPanel[] {
            uiStatusBarPanel1});
            this.statusBar.Size = new System.Drawing.Size(1067, 23);
            this.statusBar.TabIndex = 6;
            this.statusBar.VisualStyle = Janus.Windows.UI.VisualStyle.OfficeXP;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnUpdateStandardData);
            this.panel1.Controls.Add(this.grdTestData);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(722, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(345, 331);
            this.panel1.TabIndex = 12;
            // 
            // btnUpdateStandardData
            // 
            this.btnUpdateStandardData.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnUpdateStandardData.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateStandardData.Image")));
            this.btnUpdateStandardData.ImageSize = new System.Drawing.Size(32, 32);
            this.btnUpdateStandardData.Location = new System.Drawing.Point(6, 146);
            this.btnUpdateStandardData.Name = "btnUpdateStandardData";
            this.btnUpdateStandardData.Size = new System.Drawing.Size(61, 37);
            this.btnUpdateStandardData.TabIndex = 13;
            this.btnUpdateStandardData.Click += new System.EventHandler(this.btnUpdateStandardData_Click);
            // 
            // grdTestData
            // 
            this.grdTestData.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            grdTestData_DesignTimeLayout.LayoutString = resources.GetString("grdTestData_DesignTimeLayout.LayoutString");
            this.grdTestData.DesignTimeLayout = grdTestData_DesignTimeLayout;
            this.grdTestData.Dock = System.Windows.Forms.DockStyle.Right;
            this.grdTestData.DynamicFiltering = true;
            this.grdTestData.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdTestData.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdTestData.GroupByBoxVisible = false;
            this.grdTestData.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdTestData.Location = new System.Drawing.Point(73, 0);
            this.grdTestData.Name = "grdTestData";
            this.grdTestData.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdTestData.Size = new System.Drawing.Size(272, 331);
            this.grdTestData.TabIndex = 12;
            // 
            // grdDataControl
            // 
            grdDataControl_DesignTimeLayout.LayoutString = resources.GetString("grdDataControl_DesignTimeLayout.LayoutString");
            this.grdDataControl.DesignTimeLayout = grdDataControl_DesignTimeLayout;
            this.grdDataControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDataControl.DynamicFiltering = true;
            this.grdDataControl.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdDataControl.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdDataControl.FilterRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grdDataControl.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdDataControl.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.grdDataControl.GroupByBoxVisible = false;
            this.grdDataControl.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdDataControl.Location = new System.Drawing.Point(0, 39);
            this.grdDataControl.Name = "grdDataControl";
            this.grdDataControl.RecordNavigator = true;
            this.grdDataControl.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdDataControl.Size = new System.Drawing.Size(722, 331);
            this.grdDataControl.TabIndex = 13;
            this.grdDataControl.CellValueChanged += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdDataControl_CellValueChanged);
            this.grdDataControl.DoubleClick += new System.EventHandler(this.grdDataControl_DoubleClick);
            // 
            // frmDataControlList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 393);
            this.Controls.Add(this.grdDataControl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.ToolStrip1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDataControlList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DANH MỤC CÁC CHI TIẾT XÉT NGHIỆM MẪU";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTestDataList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTestDataList_KeyDown);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTestData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDataControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton cmdSave;
        internal System.Windows.Forms.ToolStripButton cmdDelete;
        internal System.Windows.Forms.ToolStripButton cmdExit;
        internal System.Windows.Forms.ToolStripButton cmdUpdate;
        private Janus.Windows.UI.StatusBar.UIStatusBar statusBar;
        private System.Windows.Forms.Panel panel1;
        private Janus.Windows.EditControls.UIButton btnUpdateStandardData;
        private Janus.Windows.GridEX.GridEX grdTestData;
        private Janus.Windows.GridEX.GridEX grdDataControl;
    }
}

