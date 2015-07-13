namespace Lis.GiaoDien.Forms
{
    partial class Form4
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
            Janus.Windows.GridEX.GridEXLayout grdTestTypeRegList_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel2 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.GridEX.GridEXLayout grdResultDetail_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdTestInfo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout grdPatients_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabTestInfo = new Janus.Windows.UI.Tab.UITab();
            this.tabReg = new Janus.Windows.UI.Tab.UITabPage();
            this.btnConfig = new System.Windows.Forms.Button();
            this.grdTestTypeRegList = new Janus.Windows.GridEX.GridEX();
            this.uiStatusBar1 = new Janus.Windows.UI.StatusBar.UIStatusBar();
            this.tabResult = new Janus.Windows.UI.Tab.UITabPage();
            this.grdResultDetail = new Janus.Windows.GridEX.GridEX();
            this.grdTestInfo = new Janus.Windows.GridEX.GridEX();
            this.grdPatients = new Janus.Windows.GridEX.GridEX();
            this.GroupBox7 = new System.Windows.Forms.GroupBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabTestInfo)).BeginInit();
            this.tabTestInfo.SuspendLayout();
            this.tabReg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTestTypeRegList)).BeginInit();
            this.tabResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTestInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPatients)).BeginInit();
            this.GroupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SplitContainer1.IsSplitterFixed = true;
            this.SplitContainer1.Location = new System.Drawing.Point(89, 21);
            this.SplitContainer1.Name = "SplitContainer1";
            this.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.Controls.Add(this.progressBar);
            this.SplitContainer1.Panel1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.SplitContainer1.Size = new System.Drawing.Size(1061, 501);
            this.SplitContainer1.SplitterDistance = 160;
            this.SplitContainer1.TabIndex = 37;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.GroupBox7);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabTestInfo);
            this.splitContainer2.Size = new System.Drawing.Size(1061, 337);
            this.splitContainer2.SplitterDistance = 446;
            this.splitContainer2.TabIndex = 38;
            // 
            // tabTestInfo
            // 
            this.tabTestInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTestInfo.Location = new System.Drawing.Point(0, 0);
            this.tabTestInfo.Name = "tabTestInfo";
            this.tabTestInfo.Size = new System.Drawing.Size(611, 337);
            this.tabTestInfo.TabIndex = 36;
            this.tabTestInfo.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.tabReg,
            this.tabResult});
            this.tabTestInfo.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.VS2005;
            // 
            // tabReg
            // 
            this.tabReg.Controls.Add(this.btnConfig);
            this.tabReg.Controls.Add(this.grdTestTypeRegList);
            this.tabReg.Controls.Add(this.uiStatusBar1);
            this.tabReg.Key = "tabReg";
            this.tabReg.Location = new System.Drawing.Point(1, 21);
            this.tabReg.Name = "tabReg";
            this.tabReg.Size = new System.Drawing.Size(609, 315);
            this.tabReg.TabStop = true;
            this.tabReg.Text = "Chỉ Định (F1)";
            // 
            // btnConfig
            // 
            this.btnConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnConfig.Image")));
            this.btnConfig.Location = new System.Drawing.Point(444, 145);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(41, 39);
            this.btnConfig.TabIndex = 7;
            this.btnConfig.UseVisualStyleBackColor = true;
            // 
            // grdTestTypeRegList
            // 
            this.grdTestTypeRegList.AutoEdit = true;
            this.grdTestTypeRegList.AutomaticSort = false;
            this.grdTestTypeRegList.ColumnAutoResize = true;
            grdTestTypeRegList_DesignTimeLayout.LayoutString = resources.GetString("grdTestTypeRegList_DesignTimeLayout.LayoutString");
            this.grdTestTypeRegList.DesignTimeLayout = grdTestTypeRegList_DesignTimeLayout;
            this.grdTestTypeRegList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTestTypeRegList.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.grdTestTypeRegList.GroupByBoxVisible = false;
            this.grdTestTypeRegList.GroupTotalRowFormatStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.grdTestTypeRegList.GroupTotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.grdTestTypeRegList.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdTestTypeRegList.Location = new System.Drawing.Point(0, 0);
            this.grdTestTypeRegList.Margin = new System.Windows.Forms.Padding(4);
            this.grdTestTypeRegList.Name = "grdTestTypeRegList";
            this.grdTestTypeRegList.Size = new System.Drawing.Size(609, 292);
            this.grdTestTypeRegList.TabIndex = 6;
            // 
            // uiStatusBar1
            // 
            this.uiStatusBar1.Location = new System.Drawing.Point(0, 292);
            this.uiStatusBar1.Name = "uiStatusBar1";
            uiStatusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel2.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel2.Key = "";
            uiStatusBarPanel2.ProgressBarValue = 0;
            uiStatusBarPanel2.Text = "Tick: Đăng ký chạy lại test đối với các loại XN hai chiều";
            uiStatusBarPanel2.Width = 280;
            this.uiStatusBar1.Panels.AddRange(new Janus.Windows.UI.StatusBar.UIStatusBarPanel[] {
            uiStatusBarPanel2});
            this.uiStatusBar1.Size = new System.Drawing.Size(609, 23);
            this.uiStatusBar1.TabIndex = 0;
            this.uiStatusBar1.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            // 
            // tabResult
            // 
            this.tabResult.Controls.Add(this.grdResultDetail);
            this.tabResult.Controls.Add(this.grdTestInfo);
            this.tabResult.Key = "tabResult";
            this.tabResult.Location = new System.Drawing.Point(1, 21);
            this.tabResult.Name = "tabResult";
            this.tabResult.Size = new System.Drawing.Size(609, 315);
            this.tabResult.TabStop = true;
            this.tabResult.Text = "Tra Cứu (F2)";
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
            this.grdResultDetail.Location = new System.Drawing.Point(0, 122);
            this.grdResultDetail.Name = "grdResultDetail";
            this.grdResultDetail.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Blue;
            this.grdResultDetail.Office2007CustomColor = System.Drawing.SystemColors.Highlight;
            this.grdResultDetail.RecordNavigator = true;
            this.grdResultDetail.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdResultDetail.SelectedFormatStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdResultDetail.SettingsKey = "grdResultDetail";
            this.grdResultDetail.Size = new System.Drawing.Size(609, 193);
            this.grdResultDetail.TabIndex = 3;
            this.grdResultDetail.TotalRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grdResultDetail.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            // 
            // grdTestInfo
            // 
            grdTestInfo_DesignTimeLayout.LayoutString = resources.GetString("grdTestInfo_DesignTimeLayout.LayoutString");
            this.grdTestInfo.DesignTimeLayout = grdTestInfo_DesignTimeLayout;
            this.grdTestInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdTestInfo.FocusCellFormatStyle.BackColor = System.Drawing.SystemColors.Control;
            this.grdTestInfo.FocusCellFormatStyle.BackColorGradient = System.Drawing.SystemColors.Control;
            this.grdTestInfo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdTestInfo.FrozenColumns = 2;
            this.grdTestInfo.GroupByBoxVisible = false;
            this.grdTestInfo.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdTestInfo.Location = new System.Drawing.Point(0, 0);
            this.grdTestInfo.Name = "grdTestInfo";
            this.grdTestInfo.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdTestInfo.Size = new System.Drawing.Size(609, 122);
            this.grdTestInfo.TabIndex = 2;
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
            this.grdPatients.Location = new System.Drawing.Point(3, 17);
            this.grdPatients.Name = "grdPatients";
            this.grdPatients.RecordNavigator = true;
            this.grdPatients.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdPatients.SelectedFormatStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdPatients.Size = new System.Drawing.Size(440, 317);
            this.grdPatients.TabIndex = 1;
            // 
            // GroupBox7
            // 
            this.GroupBox7.Controls.Add(this.grdPatients);
            this.GroupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox7.Location = new System.Drawing.Point(0, 0);
            this.GroupBox7.Name = "GroupBox7";
            this.GroupBox7.Size = new System.Drawing.Size(446, 337);
            this.GroupBox7.TabIndex = 37;
            this.GroupBox7.TabStop = false;
            this.GroupBox7.Text = "Danh sách bệnh nhân";
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(0, 0);
            this.progressBar.MarqueeAnimationSpeed = 30;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1061, 160);
            this.progressBar.TabIndex = 46;
            this.progressBar.Visible = false;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 601);
            this.Controls.Add(this.SplitContainer1);
            this.Name = "Form4";
            this.Text = "Form4";
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabTestInfo)).EndInit();
            this.tabTestInfo.ResumeLayout(false);
            this.tabReg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTestTypeRegList)).EndInit();
            this.tabResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdResultDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTestInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPatients)).EndInit();
            this.GroupBox7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.SplitContainer SplitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Janus.Windows.UI.Tab.UITab tabTestInfo;
        private Janus.Windows.UI.Tab.UITabPage tabReg;
        private System.Windows.Forms.Button btnConfig;
        internal Janus.Windows.GridEX.GridEX grdTestTypeRegList;
        private Janus.Windows.UI.StatusBar.UIStatusBar uiStatusBar1;
        private Janus.Windows.UI.Tab.UITabPage tabResult;
        internal Janus.Windows.GridEX.GridEX grdResultDetail;
        internal Janus.Windows.GridEX.GridEX grdTestInfo;
        internal System.Windows.Forms.GroupBox GroupBox7;
        internal Janus.Windows.GridEX.GridEX grdPatients;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}