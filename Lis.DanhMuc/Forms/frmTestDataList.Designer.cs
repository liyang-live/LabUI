namespace VietBaIT.LABLink.List.UI
{
    partial class frmTestDataList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTestDataList));
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel1 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.GridEX.GridEXLayout grdTestData_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cmdSave = new System.Windows.Forms.ToolStripButton();
            this.cmdUpdate = new System.Windows.Forms.ToolStripButton();
            this.cmdDelete = new System.Windows.Forms.ToolStripButton();
            this.btnQuickReOrder = new System.Windows.Forms.ToolStripButton();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.cmdExit = new System.Windows.Forms.ToolStripButton();
            this.uiStatusBar1 = new Janus.Windows.UI.StatusBar.UIStatusBar();
            this.grdTestData = new Janus.Windows.GridEX.GridEX();
            this.GrdListExporter = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTestData)).BeginInit();
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
            this.btnQuickReOrder,
            this.btnExportToExcel,
            this.cmdExit});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(933, 39);
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
            // btnQuickReOrder
            // 
            this.btnQuickReOrder.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuickReOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnQuickReOrder.Image")));
            this.btnQuickReOrder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnQuickReOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQuickReOrder.Name = "btnQuickReOrder";
            this.btnQuickReOrder.Size = new System.Drawing.Size(129, 36);
            this.btnQuickReOrder.Text = "Sắp Xếp Nhanh";
            this.btnQuickReOrder.ToolTipText = "Sắp xếp nhanh thứ tự các loại xét nghiệm";
            this.btnQuickReOrder.Click += new System.EventHandler(this.btnQuickReOrder_Click);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportToExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportToExcel.Image")));
            this.btnExportToExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(103, 36);
            this.btnExportToExcel.Text = "Xuất Excel";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
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
            // uiStatusBar1
            // 
            this.uiStatusBar1.Location = new System.Drawing.Point(0, 372);
            this.uiStatusBar1.Name = "uiStatusBar1";
            uiStatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel1.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel1.Key = "";
            uiStatusBarPanel1.ProgressBarValue = 0;
            uiStatusBarPanel1.Text = "Ctrl+N: Thêm mới";
            uiStatusBarPanel1.ToolTipText = "Thêm mới thông tin";
            uiStatusBarPanel1.Width = 128;
            this.uiStatusBar1.Panels.AddRange(new Janus.Windows.UI.StatusBar.UIStatusBarPanel[] {
            uiStatusBarPanel1});
            this.uiStatusBar1.Size = new System.Drawing.Size(933, 23);
            this.uiStatusBar1.TabIndex = 6;
            this.uiStatusBar1.VisualStyle = Janus.Windows.UI.VisualStyle.OfficeXP;
            // 
            // grdTestData
            // 
            this.grdTestData.AllowDrop = true;
            this.grdTestData.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            grdTestData_DesignTimeLayout.LayoutString = resources.GetString("grdTestData_DesignTimeLayout.LayoutString");
            this.grdTestData.DesignTimeLayout = grdTestData_DesignTimeLayout;
            this.grdTestData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTestData.DynamicFiltering = true;
            this.grdTestData.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdTestData.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdTestData.FilterRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grdTestData.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdTestData.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.grdTestData.GroupByBoxVisible = false;
            this.grdTestData.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.grdTestData.Location = new System.Drawing.Point(0, 39);
            this.grdTestData.Name = "grdTestData";
            this.grdTestData.RecordNavigator = true;
            this.grdTestData.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdTestData.Size = new System.Drawing.Size(933, 333);
            this.grdTestData.TabIndex = 8;
            this.grdTestData.DoubleClick += new System.EventHandler(this.grdTestData_DoubleClick);
            // 
            // GrdListExporter
            // 
            this.GrdListExporter.GridEX = this.grdTestData;
            // 
            // frmTestDataList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 395);
            this.Controls.Add(this.grdTestData);
            this.Controls.Add(this.uiStatusBar1);
            this.Controls.Add(this.ToolStrip1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTestDataList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DANH MỤC CÁC THÔNG SỐ XÉT NGHIỆM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTestDataList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTestDataList_KeyDown);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTestData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton cmdSave;
        internal System.Windows.Forms.ToolStripButton cmdDelete;
        internal System.Windows.Forms.ToolStripButton cmdExit;
        internal System.Windows.Forms.ToolStripButton cmdUpdate;
        private Janus.Windows.UI.StatusBar.UIStatusBar uiStatusBar1;
        private Janus.Windows.GridEX.GridEX grdTestData;
        internal Janus.Windows.GridEX.Export.GridEXExporter GrdListExporter;
        internal System.Windows.Forms.ToolStripButton btnExportToExcel;
        internal System.Windows.Forms.ToolStripButton btnQuickReOrder;
    }
}

