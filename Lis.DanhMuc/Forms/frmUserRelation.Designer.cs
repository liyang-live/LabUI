namespace VietBaIT.LABLink.List.UI.Forms
{
    partial class frmUserRelation
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
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel2 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.GridEX.GridEXLayout grdTestType_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserRelation));
            Janus.Windows.GridEX.GridEXLayout grdControl_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdUser_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.uiStatusBar1 = new Janus.Windows.UI.StatusBar.UIStatusBar();
            this.uiTab1 = new Janus.Windows.UI.Tab.UITab();
            this.tabTestType = new Janus.Windows.UI.Tab.UITabPage();
            this.grdTestType = new Janus.Windows.GridEX.GridEX();
            this.tabControl = new Janus.Windows.UI.Tab.UITabPage();
            this.grdControl = new Janus.Windows.GridEX.GridEX();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnUpdate = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.grdUser = new Janus.Windows.GridEX.GridEX();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).BeginInit();
            this.uiTab1.SuspendLayout();
            this.tabTestType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTestType)).BeginInit();
            this.tabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdControl)).BeginInit();
            this.ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUser)).BeginInit();
            this.SuspendLayout();
            // 
            // uiStatusBar1
            // 
            this.uiStatusBar1.Location = new System.Drawing.Point(0, 652);
            this.uiStatusBar1.Name = "uiStatusBar1";
            uiStatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel1.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel1.Key = "";
            uiStatusBarPanel1.ProgressBarValue = 0;
            uiStatusBarPanel1.Text = "Tick để tạo quan hệ";
            uiStatusBarPanel1.Width = 141;
            uiStatusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel2.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel2.Key = "";
            uiStatusBarPanel2.ProgressBarValue = 0;
            uiStatusBarPanel2.Text = "Esc: Thoát";
            uiStatusBarPanel2.Width = 80;
            this.uiStatusBar1.Panels.AddRange(new Janus.Windows.UI.StatusBar.UIStatusBarPanel[] {
            uiStatusBarPanel1,
            uiStatusBarPanel2});
            this.uiStatusBar1.Size = new System.Drawing.Size(1233, 23);
            this.uiStatusBar1.TabIndex = 0;
            this.uiStatusBar1.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            // 
            // uiTab1
            // 
            this.uiTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTab1.Location = new System.Drawing.Point(383, 0);
            this.uiTab1.Name = "uiTab1";
            this.uiTab1.Size = new System.Drawing.Size(850, 652);
            this.uiTab1.TabIndex = 3;
            this.uiTab1.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.tabTestType,
            this.tabControl});
            this.uiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.VS2005;
            this.uiTab1.SelectedTabChanged += new Janus.Windows.UI.Tab.TabEventHandler(this.uiTab1_SelectedTabChanged);
            // 
            // tabTestType
            // 
            this.tabTestType.Controls.Add(this.grdTestType);
            this.tabTestType.Location = new System.Drawing.Point(1, 27);
            this.tabTestType.Name = "tabTestType";
            this.tabTestType.Size = new System.Drawing.Size(848, 624);
            this.tabTestType.TabStop = true;
            this.tabTestType.Text = "Loại Xét Nghiệm";
            // 
            // grdTestType
            // 
            this.grdTestType.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            grdTestType_DesignTimeLayout.LayoutString = resources.GetString("grdTestType_DesignTimeLayout.LayoutString");
            this.grdTestType.DesignTimeLayout = grdTestType_DesignTimeLayout;
            this.grdTestType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTestType.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdTestType.GroupByBoxVisible = false;
            this.grdTestType.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdTestType.Location = new System.Drawing.Point(0, 0);
            this.grdTestType.Margin = new System.Windows.Forms.Padding(4);
            this.grdTestType.Name = "grdTestType";
            this.grdTestType.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdTestType.Size = new System.Drawing.Size(848, 624);
            this.grdTestType.TabIndex = 1;
            this.grdTestType.RowCheckStateChanged += new Janus.Windows.GridEX.RowCheckStateChangeEventHandler(this.grdTestType_RowCheckStateChanged);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.grdControl);
            this.tabControl.Controls.Add(this.ToolStrip1);
            this.tabControl.Location = new System.Drawing.Point(1, 31);
            this.tabControl.Name = "tabControl";
            this.tabControl.Size = new System.Drawing.Size(848, 620);
            this.tabControl.TabStop = true;
            this.tabControl.Text = "Chức Năng";
            // 
            // grdControl
            // 
            this.grdControl.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            grdControl_DesignTimeLayout.LayoutString = resources.GetString("grdControl_DesignTimeLayout.LayoutString");
            this.grdControl.DesignTimeLayout = grdControl_DesignTimeLayout;
            this.grdControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdControl.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.grdControl.GroupByBoxVisible = false;
            this.grdControl.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdControl.Location = new System.Drawing.Point(0, 39);
            this.grdControl.Margin = new System.Windows.Forms.Padding(4);
            this.grdControl.Name = "grdControl";
            this.grdControl.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdControl.Size = new System.Drawing.Size(848, 581);
            this.grdControl.TabIndex = 3;
            this.grdControl.RowCheckStateChanged += new Janus.Windows.GridEX.RowCheckStateChangeEventHandler(this.grdControl_RowCheckStateChanged);
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnUpdate,
            this.btnDelete});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(848, 39);
            this.ToolStrip1.TabIndex = 2;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(109, 36);
            this.btnAdd.Tag = "";
            this.btnAdd.Text = "Thêm mới";
            this.btnAdd.ToolTipText = "Thêm BN (Ctrl+N)";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(93, 36);
            this.btnUpdate.Tag = "";
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.ToolTipText = "Cập nhật BN (Ctrl+U)";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(69, 36);
            this.btnDelete.Tag = "";
            this.btnDelete.Text = "Xóa";
            this.btnDelete.ToolTipText = "Thoát (Esc)";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // grdUser
            // 
            this.grdUser.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdUser.ColumnAutoResize = true;
            grdUser_DesignTimeLayout.LayoutString = resources.GetString("grdUser_DesignTimeLayout.LayoutString");
            this.grdUser.DesignTimeLayout = grdUser_DesignTimeLayout;
            this.grdUser.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdUser.GroupByBoxVisible = false;
            this.grdUser.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdUser.Location = new System.Drawing.Point(0, 0);
            this.grdUser.Margin = new System.Windows.Forms.Padding(4);
            this.grdUser.Name = "grdUser";
            this.grdUser.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdUser.Size = new System.Drawing.Size(383, 652);
            this.grdUser.TabIndex = 2;
            this.grdUser.SelectionChanged += new System.EventHandler(this.grdUser_SelectionChanged);
            // 
            // frmUserRelation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 675);
            this.Controls.Add(this.uiTab1);
            this.Controls.Add(this.grdUser);
            this.Controls.Add(this.uiStatusBar1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmUserRelation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "QUAN HỆ NGƯỜI SỬ DỤNG";
            this.Load += new System.EventHandler(this.frmUserRelation_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmUserRelation_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).EndInit();
            this.uiTab1.ResumeLayout(false);
            this.tabTestType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTestType)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdControl)).EndInit();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.StatusBar.UIStatusBar uiStatusBar1;
        private Janus.Windows.UI.Tab.UITab uiTab1;
        private Janus.Windows.UI.Tab.UITabPage tabTestType;
        private Janus.Windows.GridEX.GridEX grdTestType;
        private Janus.Windows.UI.Tab.UITabPage tabControl;
        private Janus.Windows.GridEX.GridEX grdControl;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton btnAdd;
        internal System.Windows.Forms.ToolStripButton btnUpdate;
        internal System.Windows.Forms.ToolStripButton btnDelete;
        private Janus.Windows.GridEX.GridEX grdUser;

    }
}