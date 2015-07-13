namespace VietBaIT.LABLink.List.UI.Forms
{
    partial class frmGeneralList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGeneralList));
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel3 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel4 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.GridEX.GridEXLayout grdTestType_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdManufacturer_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdDevice_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdObject_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdDepartment_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdDoctor_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cmdSave = new System.Windows.Forms.ToolStripButton();
            this.cmdUpdate = new System.Windows.Forms.ToolStripButton();
            this.cmdDelete = new System.Windows.Forms.ToolStripButton();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.cmdExit = new System.Windows.Forms.ToolStripButton();
            this.uiStatusBar1 = new Janus.Windows.UI.StatusBar.UIStatusBar();
            this.tabGeneralList = new Janus.Windows.UI.Tab.UITab();
            this.tabTestType = new Janus.Windows.UI.Tab.UITabPage();
            this.grdTestType = new Janus.Windows.GridEX.GridEX();
            this.tabManufacturer = new Janus.Windows.UI.Tab.UITabPage();
            this.grdManufacturer = new Janus.Windows.GridEX.GridEX();
            this.tabDevice = new Janus.Windows.UI.Tab.UITabPage();
            this.grdDevice = new Janus.Windows.GridEX.GridEX();
            this.tabObject = new Janus.Windows.UI.Tab.UITabPage();
            this.grdObject = new Janus.Windows.GridEX.GridEX();
            this.tabDepartment = new Janus.Windows.UI.Tab.UITabPage();
            this.grdDepartment = new Janus.Windows.GridEX.GridEX();
            this.tabDoctor = new Janus.Windows.UI.Tab.UITabPage();
            this.grdDoctor = new Janus.Windows.GridEX.GridEX();
            this.GrdListExporter = new Janus.Windows.GridEX.Export.GridEXExporter(this.components);
            this.ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabGeneralList)).BeginInit();
            this.tabGeneralList.SuspendLayout();
            this.tabTestType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTestType)).BeginInit();
            this.tabManufacturer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdManufacturer)).BeginInit();
            this.tabDevice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDevice)).BeginInit();
            this.tabObject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdObject)).BeginInit();
            this.tabDepartment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDepartment)).BeginInit();
            this.tabDoctor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDoctor)).BeginInit();
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
            this.btnExportToExcel,
            this.cmdExit});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(1006, 39);
            this.ToolStrip1.TabIndex = 6;
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
            // btnExportToExcel
            // 
            this.btnExportToExcel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportToExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportToExcel.Image")));
            this.btnExportToExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(148, 36);
            this.btnExportToExcel.Text = "Xuất Excel (Ctrl+E)";
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
            this.uiStatusBar1.Location = new System.Drawing.Point(0, 652);
            this.uiStatusBar1.Name = "uiStatusBar1";
            uiStatusBarPanel3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel3.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel3.Key = "";
            uiStatusBarPanel3.ProgressBarValue = 0;
            uiStatusBarPanel3.Text = "Ô Màu Vàng:  Tìm kiếm nhanh";
            uiStatusBarPanel3.Width = 234;
            uiStatusBarPanel4.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel4.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel4.Key = "";
            uiStatusBarPanel4.ProgressBarValue = 0;
            uiStatusBarPanel4.Text = "Ctrl+Tab: Chuyển Tab";
            uiStatusBarPanel4.Width = 175;
            this.uiStatusBar1.Panels.AddRange(new Janus.Windows.UI.StatusBar.UIStatusBarPanel[] {
            uiStatusBarPanel3,
            uiStatusBarPanel4});
            this.uiStatusBar1.Size = new System.Drawing.Size(1006, 23);
            this.uiStatusBar1.TabIndex = 8;
            this.uiStatusBar1.VisualStyle = Janus.Windows.UI.VisualStyle.OfficeXP;
            // 
            // tabGeneralList
            // 
            this.tabGeneralList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabGeneralList.Location = new System.Drawing.Point(0, 39);
            this.tabGeneralList.Name = "tabGeneralList";
            this.tabGeneralList.Size = new System.Drawing.Size(1006, 613);
            this.tabGeneralList.TabIndex = 9;
            this.tabGeneralList.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.tabTestType,
            this.tabManufacturer,
            this.tabDevice,
            this.tabObject,
            this.tabDepartment,
            this.tabDoctor});
            this.tabGeneralList.SelectedTabChanged += new Janus.Windows.UI.Tab.TabEventHandler(this.tabGeneralList_SelectedTabChanged);
            // 
            // tabTestType
            // 
            this.tabTestType.Controls.Add(this.grdTestType);
            this.tabTestType.Location = new System.Drawing.Point(1, 25);
            this.tabTestType.Name = "tabTestType";
            this.tabTestType.Size = new System.Drawing.Size(1002, 585);
            this.tabTestType.TabStop = true;
            this.tabTestType.Text = "Loại Xét Nghiệm";
            // 
            // grdTestType
            // 
            this.grdTestType.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            grdTestType_DesignTimeLayout.LayoutString = resources.GetString("grdTestType_DesignTimeLayout.LayoutString");
            this.grdTestType.DesignTimeLayout = grdTestType_DesignTimeLayout;
            this.grdTestType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTestType.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdTestType.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdTestType.FilterRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grdTestType.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdTestType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdTestType.GroupByBoxVisible = false;
            this.grdTestType.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdTestType.Location = new System.Drawing.Point(0, 0);
            this.grdTestType.Name = "grdTestType";
            this.grdTestType.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdTestType.Size = new System.Drawing.Size(1002, 585);
            this.grdTestType.TabIndex = 2;
            // 
            // tabManufacturer
            // 
            this.tabManufacturer.Controls.Add(this.grdManufacturer);
            this.tabManufacturer.Location = new System.Drawing.Point(1, 27);
            this.tabManufacturer.Name = "tabManufacturer";
            this.tabManufacturer.Size = new System.Drawing.Size(1002, 583);
            this.tabManufacturer.TabStop = true;
            this.tabManufacturer.Text = "Hãng Sản Xuất";
            // 
            // grdManufacturer
            // 
            this.grdManufacturer.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            grdManufacturer_DesignTimeLayout.LayoutString = resources.GetString("grdManufacturer_DesignTimeLayout.LayoutString");
            this.grdManufacturer.DesignTimeLayout = grdManufacturer_DesignTimeLayout;
            this.grdManufacturer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdManufacturer.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdManufacturer.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdManufacturer.FilterRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grdManufacturer.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdManufacturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.grdManufacturer.GroupByBoxVisible = false;
            this.grdManufacturer.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdManufacturer.Location = new System.Drawing.Point(0, 0);
            this.grdManufacturer.Name = "grdManufacturer";
            this.grdManufacturer.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdManufacturer.Size = new System.Drawing.Size(1002, 583);
            this.grdManufacturer.TabIndex = 3;
            // 
            // tabDevice
            // 
            this.tabDevice.Controls.Add(this.grdDevice);
            this.tabDevice.Location = new System.Drawing.Point(1, 25);
            this.tabDevice.Name = "tabDevice";
            this.tabDevice.Size = new System.Drawing.Size(1002, 585);
            this.tabDevice.TabStop = true;
            this.tabDevice.Text = "Thiết bị";
            // 
            // grdDevice
            // 
            this.grdDevice.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            grdDevice_DesignTimeLayout.LayoutString = resources.GetString("grdDevice_DesignTimeLayout.LayoutString");
            this.grdDevice.DesignTimeLayout = grdDevice_DesignTimeLayout;
            this.grdDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDevice.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdDevice.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdDevice.FilterRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grdDevice.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.grdDevice.GroupByBoxVisible = false;
            this.grdDevice.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdDevice.Location = new System.Drawing.Point(0, 0);
            this.grdDevice.Name = "grdDevice";
            this.grdDevice.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdDevice.Size = new System.Drawing.Size(1002, 585);
            this.grdDevice.TabIndex = 9;
            // 
            // tabObject
            // 
            this.tabObject.Controls.Add(this.grdObject);
            this.tabObject.Location = new System.Drawing.Point(1, 27);
            this.tabObject.Name = "tabObject";
            this.tabObject.Size = new System.Drawing.Size(1002, 583);
            this.tabObject.TabStop = true;
            this.tabObject.Text = "Đối Tượng";
            // 
            // grdObject
            // 
            this.grdObject.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            grdObject_DesignTimeLayout.LayoutString = resources.GetString("grdObject_DesignTimeLayout.LayoutString");
            this.grdObject.DesignTimeLayout = grdObject_DesignTimeLayout;
            this.grdObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdObject.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdObject.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdObject.FilterRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grdObject.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdObject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.grdObject.GroupByBoxVisible = false;
            this.grdObject.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdObject.Location = new System.Drawing.Point(0, 0);
            this.grdObject.Name = "grdObject";
            this.grdObject.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdObject.Size = new System.Drawing.Size(1002, 583);
            this.grdObject.TabIndex = 4;
            // 
            // tabDepartment
            // 
            this.tabDepartment.Controls.Add(this.grdDepartment);
            this.tabDepartment.Location = new System.Drawing.Point(1, 27);
            this.tabDepartment.Name = "tabDepartment";
            this.tabDepartment.Size = new System.Drawing.Size(1002, 583);
            this.tabDepartment.TabStop = true;
            this.tabDepartment.Text = "Khoa Phòng";
            // 
            // grdDepartment
            // 
            this.grdDepartment.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            grdDepartment_DesignTimeLayout.LayoutString = resources.GetString("grdDepartment_DesignTimeLayout.LayoutString");
            this.grdDepartment.DesignTimeLayout = grdDepartment_DesignTimeLayout;
            this.grdDepartment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDepartment.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdDepartment.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdDepartment.FilterRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grdDepartment.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.grdDepartment.GroupByBoxVisible = false;
            this.grdDepartment.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdDepartment.Location = new System.Drawing.Point(0, 0);
            this.grdDepartment.Name = "grdDepartment";
            this.grdDepartment.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdDepartment.Size = new System.Drawing.Size(1002, 583);
            this.grdDepartment.TabIndex = 5;
            // 
            // tabDoctor
            // 
            this.tabDoctor.Controls.Add(this.grdDoctor);
            this.tabDoctor.Location = new System.Drawing.Point(1, 27);
            this.tabDoctor.Name = "tabDoctor";
            this.tabDoctor.Size = new System.Drawing.Size(1002, 583);
            this.tabDoctor.TabStop = true;
            this.tabDoctor.Text = "Bác Sỹ";
            // 
            // grdDoctor
            // 
            this.grdDoctor.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            grdDoctor_DesignTimeLayout.LayoutString = resources.GetString("grdDoctor_DesignTimeLayout.LayoutString");
            this.grdDoctor.DesignTimeLayout = grdDoctor_DesignTimeLayout;
            this.grdDoctor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDoctor.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdDoctor.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdDoctor.FilterRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grdDoctor.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.grdDoctor.GroupByBoxVisible = false;
            this.grdDoctor.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdDoctor.Location = new System.Drawing.Point(0, 0);
            this.grdDoctor.Name = "grdDoctor";
            this.grdDoctor.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdDoctor.Size = new System.Drawing.Size(1002, 583);
            this.grdDoctor.TabIndex = 6;
            // 
            // frmGeneralList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 675);
            this.Controls.Add(this.tabGeneralList);
            this.Controls.Add(this.uiStatusBar1);
            this.Controls.Add(this.ToolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmGeneralList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DANH MỤC CHUNG";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmGeneralList_KeyDown);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabGeneralList)).EndInit();
            this.tabGeneralList.ResumeLayout(false);
            this.tabTestType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTestType)).EndInit();
            this.tabManufacturer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdManufacturer)).EndInit();
            this.tabDevice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDevice)).EndInit();
            this.tabObject.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdObject)).EndInit();
            this.tabDepartment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDepartment)).EndInit();
            this.tabDoctor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDoctor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton cmdSave;
        internal System.Windows.Forms.ToolStripButton cmdUpdate;
        internal System.Windows.Forms.ToolStripButton cmdDelete;
        internal System.Windows.Forms.ToolStripButton btnExportToExcel;
        internal System.Windows.Forms.ToolStripButton cmdExit;
        private Janus.Windows.UI.StatusBar.UIStatusBar uiStatusBar1;
        private Janus.Windows.UI.Tab.UITab tabGeneralList;
        private Janus.Windows.UI.Tab.UITabPage tabTestType;
        private Janus.Windows.GridEX.GridEX grdTestType;
        private Janus.Windows.UI.Tab.UITabPage tabManufacturer;
        private Janus.Windows.GridEX.GridEX grdManufacturer;
        private Janus.Windows.UI.Tab.UITabPage tabDevice;
        private Janus.Windows.GridEX.GridEX grdDevice;
        private Janus.Windows.UI.Tab.UITabPage tabObject;
        private Janus.Windows.UI.Tab.UITabPage tabDepartment;
        private Janus.Windows.UI.Tab.UITabPage tabDoctor;
        private Janus.Windows.GridEX.GridEX grdObject;
        private Janus.Windows.GridEX.GridEX grdDepartment;
        private Janus.Windows.GridEX.GridEX grdDoctor;
        private Janus.Windows.GridEX.Export.GridEXExporter GrdListExporter;
    }
}