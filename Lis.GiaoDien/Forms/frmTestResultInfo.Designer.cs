namespace Vietbait.Lablink.TestInformation.UI.Forms
{
    partial class frmTestResultInfo
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
            Janus.Windows.GridEX.GridEXLayout grdTestResult_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTestResultInfo));
            this.statusBar = new Janus.Windows.UI.StatusBar.UIStatusBar();
            this.uiGroupBox3 = new Janus.Windows.EditControls.UIGroupBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtSex = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.uiGroupBox2 = new Janus.Windows.EditControls.UIGroupBox();
            this.grdTestResult = new Janus.Windows.GridEX.GridEX();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox3)).BeginInit();
            this.uiGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).BeginInit();
            this.uiGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTestResult)).BeginInit();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 659);
            this.statusBar.Name = "statusBar";
            uiStatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel1.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel1.Key = "";
            uiStatusBarPanel1.ProgressBarValue = 0;
            uiStatusBarPanel1.Text = "Ctrl+C: Thu Gọn";
            uiStatusBarPanel1.Width = 117;
            uiStatusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel2.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel2.Key = "";
            uiStatusBarPanel2.ProgressBarValue = 0;
            uiStatusBarPanel2.Text = "Ctrl+E: Mở rộng";
            uiStatusBarPanel2.Width = 115;
            this.statusBar.Panels.AddRange(new Janus.Windows.UI.StatusBar.UIStatusBarPanel[] {
            uiStatusBarPanel1,
            uiStatusBarPanel2});
            this.statusBar.Size = new System.Drawing.Size(799, 23);
            this.statusBar.TabIndex = 1;
            this.statusBar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            // 
            // uiGroupBox3
            // 
            this.uiGroupBox3.Controls.Add(this.txtAge);
            this.uiGroupBox3.Controls.Add(this.Label4);
            this.uiGroupBox3.Controls.Add(this.txtPatientName);
            this.uiGroupBox3.Controls.Add(this.Label3);
            this.uiGroupBox3.Controls.Add(this.txtSex);
            this.uiGroupBox3.Controls.Add(this.Label2);
            this.uiGroupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiGroupBox3.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox3.Name = "uiGroupBox3";
            this.uiGroupBox3.Size = new System.Drawing.Size(799, 88);
            this.uiGroupBox3.TabIndex = 1;
            this.uiGroupBox3.Text = "Thông Tin Bệnh Nhân";
            // 
            // txtAge
            // 
            this.txtAge.Enabled = false;
            this.txtAge.Location = new System.Drawing.Point(333, 23);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(85, 22);
            this.txtAge.TabIndex = 8;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(294, 26);
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
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.grdTestResult);
            this.uiGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox2.Location = new System.Drawing.Point(0, 88);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Size = new System.Drawing.Size(799, 571);
            this.uiGroupBox2.TabIndex = 2;
            this.uiGroupBox2.Text = "Kết Quả";
            // 
            // grdTestResult
            // 
            this.grdTestResult.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><RecordNavigator>Số lư" +
                "ợng:| Of</RecordNavigator></LocalizableData>";
            grdTestResult_DesignTimeLayout.LayoutString = resources.GetString("grdTestResult_DesignTimeLayout.LayoutString");
            this.grdTestResult.DesignTimeLayout = grdTestResult_DesignTimeLayout;
            this.grdTestResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTestResult.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdTestResult.GroupByBoxVisible = false;
            this.grdTestResult.Location = new System.Drawing.Point(3, 18);
            this.grdTestResult.Name = "grdTestResult";
            this.grdTestResult.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Blue;
            this.grdTestResult.Office2007CustomColor = System.Drawing.SystemColors.Highlight;
            this.grdTestResult.RecordNavigator = true;
            this.grdTestResult.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowPosition;
            this.grdTestResult.Size = new System.Drawing.Size(793, 550);
            this.grdTestResult.TabIndex = 4;
            this.grdTestResult.TotalRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grdTestResult.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed;
            this.grdTestResult.CellUpdated += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdTestResult_CellUpdated);
            // 
            // frmTestResultInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 682);
            this.Controls.Add(this.uiGroupBox2);
            this.Controls.Add(this.uiGroupBox3);
            this.Controls.Add(this.statusBar);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTestResultInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "THÔNG TIN LOẠI XÉT NGHIỆM";
            this.Load += new System.EventHandler(this.frmTestResultInfo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTestResultInfo_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox3)).EndInit();
            this.uiGroupBox3.ResumeLayout(false);
            this.uiGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).EndInit();
            this.uiGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTestResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.StatusBar.UIStatusBar statusBar;
        internal Janus.Windows.EditControls.UIGroupBox uiGroupBox3;
        internal System.Windows.Forms.TextBox txtAge;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtPatientName;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtSex;
        internal System.Windows.Forms.Label Label2;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox2;
        private Janus.Windows.GridEX.GridEX grdTestResult;


    }
}