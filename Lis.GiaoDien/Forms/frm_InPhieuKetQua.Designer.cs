namespace Vietbait.Lablink.TestInformation.UI.Forms
{
    partial class frm_InPhieuKetQua
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
            Janus.Windows.GridEX.GridEXLayout grdTestType_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_InPhieuKetQua));
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel3 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel4 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            this.UiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.grdTestType = new Janus.Windows.GridEX.GridEX();
            this.cmdExit = new Janus.Windows.EditControls.UIButton();
            this.cmdPrintPhieu = new Janus.Windows.EditControls.UIButton();
            this.statusBar = new Janus.Windows.UI.StatusBar.UIStatusBar();
            this.btnQuickPrint = new Janus.Windows.EditControls.UIButton();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDatePrint = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.ProgressBar = new Janus.Windows.EditControls.UIProgressBar();
            this.txtTieuDeIn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoNoheader = new Janus.Windows.EditControls.UIRadioButton();
            this.radInTachRieng = new Janus.Windows.EditControls.UIRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBox1)).BeginInit();
            this.UiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTestType)).BeginInit();
            this.SuspendLayout();
            // 
            // UiGroupBox1
            // 
            this.UiGroupBox1.Controls.Add(this.grdTestType);
            this.UiGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.UiGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UiGroupBox1.Image = ((System.Drawing.Image)(resources.GetObject("UiGroupBox1.Image")));
            this.UiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.UiGroupBox1.Name = "UiGroupBox1";
            this.UiGroupBox1.Size = new System.Drawing.Size(526, 255);
            this.UiGroupBox1.TabIndex = 1;
            this.UiGroupBox1.Text = "&Thông tin xét nghiệm";
            // 
            // grdTestType
            // 
            this.grdTestType.ColumnAutoResize = true;
            grdTestType_DesignTimeLayout.LayoutString = resources.GetString("grdTestType_DesignTimeLayout.LayoutString");
            this.grdTestType.DesignTimeLayout = grdTestType_DesignTimeLayout;
            this.grdTestType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTestType.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.None;
            this.grdTestType.GroupByBoxVisible = false;
            this.grdTestType.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdTestType.Location = new System.Drawing.Point(3, 18);
            this.grdTestType.Name = "grdTestType";
            this.grdTestType.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdTestType.Size = new System.Drawing.Size(520, 234);
            this.grdTestType.TabIndex = 0;
            // 
            // cmdExit
            // 
            this.cmdExit.Image = ((System.Drawing.Image)(resources.GetObject("cmdExit.Image")));
            this.cmdExit.Location = new System.Drawing.Point(431, 301);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(88, 26);
            this.cmdExit.TabIndex = 4;
            this.cmdExit.Text = "Thoát(Esc)";
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // cmdPrintPhieu
            // 
            this.cmdPrintPhieu.Image = ((System.Drawing.Image)(resources.GetObject("cmdPrintPhieu.Image")));
            this.cmdPrintPhieu.Location = new System.Drawing.Point(237, 301);
            this.cmdPrintPhieu.Name = "cmdPrintPhieu";
            this.cmdPrintPhieu.Size = new System.Drawing.Size(86, 26);
            this.cmdPrintPhieu.TabIndex = 3;
            this.cmdPrintPhieu.Text = "In phiếu (F4)";
            this.cmdPrintPhieu.Click += new System.EventHandler(this.cmdPrintPhieu_Click);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 371);
            this.statusBar.Margin = new System.Windows.Forms.Padding(4);
            this.statusBar.Name = "statusBar";
            uiStatusBarPanel3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel3.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel3.Key = "";
            uiStatusBarPanel3.ProgressBarValue = 0;
            uiStatusBarPanel3.Text = "Ctrl+A: Chọn Tất";
            uiStatusBarPanel3.Width = 93;
            uiStatusBarPanel4.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel4.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel4.Key = "";
            uiStatusBarPanel4.ProgressBarValue = 0;
            uiStatusBarPanel4.Text = "Ctrl+U: Hủy Chọn";
            uiStatusBarPanel4.Width = 97;
            this.statusBar.Panels.AddRange(new Janus.Windows.UI.StatusBar.UIStatusBarPanel[] {
            uiStatusBarPanel3,
            uiStatusBarPanel4});
            this.statusBar.Size = new System.Drawing.Size(526, 30);
            this.statusBar.TabIndex = 11;
            this.statusBar.VisualStyle = Janus.Windows.UI.VisualStyle.OfficeXP;
            // 
            // btnQuickPrint
            // 
            this.btnQuickPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnQuickPrint.Image")));
            this.btnQuickPrint.Location = new System.Drawing.Point(329, 301);
            this.btnQuickPrint.Name = "btnQuickPrint";
            this.btnQuickPrint.Size = new System.Drawing.Size(96, 26);
            this.btnQuickPrint.TabIndex = 12;
            this.btnQuickPrint.Text = "In nhanh (F5)";
            this.btnQuickPrint.Click += new System.EventHandler(this.btnQuickPrint_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(6, 302);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 19);
            this.label2.TabIndex = 17;
            this.label2.Text = "Chọn ngày in:";
            // 
            // dtpDatePrint
            // 
            this.dtpDatePrint.BackColor = System.Drawing.Color.Silver;
            this.dtpDatePrint.CustomFormat = "dd/MM/yyyy";
            this.dtpDatePrint.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtpDatePrint.DropDownCalendar.FirstMonth = new System.DateTime(2013, 12, 1, 0, 0, 0, 0);
            this.dtpDatePrint.DropDownCalendar.Name = "";
            this.dtpDatePrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDatePrint.Location = new System.Drawing.Point(110, 301);
            this.dtpDatePrint.Name = "dtpDatePrint";
            this.dtpDatePrint.ShowUpDown = true;
            this.dtpDatePrint.Size = new System.Drawing.Size(120, 23);
            this.dtpDatePrint.TabIndex = 18;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.ProgressBar.Location = new System.Drawing.Point(0, 255);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.ShowPercentage = true;
            this.ProgressBar.Size = new System.Drawing.Size(526, 17);
            this.ProgressBar.TabIndex = 8;
            this.ProgressBar.Visible = false;
            // 
            // txtTieuDeIn
            // 
            this.txtTieuDeIn.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTieuDeIn.ForeColor = System.Drawing.Color.Red;
            this.txtTieuDeIn.Location = new System.Drawing.Point(84, 275);
            this.txtTieuDeIn.Name = "txtTieuDeIn";
            this.txtTieuDeIn.ReadOnly = true;
            this.txtTieuDeIn.Size = new System.Drawing.Size(435, 22);
            this.txtTieuDeIn.TabIndex = 19;
            this.txtTieuDeIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Tiêu đề in:";
            // 
            // rdoNoheader
            // 
            this.rdoNoheader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoNoheader.ForeColor = System.Drawing.Color.Red;
            this.rdoNoheader.Location = new System.Drawing.Point(357, 333);
            this.rdoNoheader.Name = "rdoNoheader";
            this.rdoNoheader.Size = new System.Drawing.Size(157, 23);
            this.rdoNoheader.TabIndex = 22;
            this.rdoNoheader.Text = "&In chung không header";
            this.rdoNoheader.Visible = false;
            // 
            // radInTachRieng
            // 
            this.radInTachRieng.Checked = true;
            this.radInTachRieng.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radInTachRieng.ForeColor = System.Drawing.Color.Red;
            this.radInTachRieng.Location = new System.Drawing.Point(208, 333);
            this.radInTachRieng.Name = "radInTachRieng";
            this.radInTachRieng.Size = new System.Drawing.Size(160, 23);
            this.radInTachRieng.TabIndex = 21;
            this.radInTachRieng.TabStop = true;
            this.radInTachRieng.Text = "&In loại xét nghiệm tách";
            this.radInTachRieng.Visible = false;
            // 
            // frm_InPhieuKetQua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 401);
            this.Controls.Add(this.rdoNoheader);
            this.Controls.Add(this.radInTachRieng);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTieuDeIn);
            this.Controls.Add(this.dtpDatePrint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnQuickPrint);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.UiGroupBox1);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.cmdPrintPhieu);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_InPhieuKetQua";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn loại xét nghiệm";
            this.Load += new System.EventHandler(this.frm_ChoosePrint_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_ChoosePrint_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.UiGroupBox1)).EndInit();
            this.UiGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTestType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Janus.Windows.EditControls.UIGroupBox UiGroupBox1;
        internal Janus.Windows.GridEX.GridEX grdTestType;
        internal Janus.Windows.EditControls.UIButton cmdExit;
        internal Janus.Windows.EditControls.UIButton cmdPrintPhieu;
        private Janus.Windows.UI.StatusBar.UIStatusBar statusBar;
        internal Janus.Windows.EditControls.UIButton btnQuickPrint;
        private System.Windows.Forms.Label label2;
        internal Janus.Windows.CalendarCombo.CalendarCombo dtpDatePrint;
        private Janus.Windows.EditControls.UIProgressBar ProgressBar;
        private System.Windows.Forms.TextBox txtTieuDeIn;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.EditControls.UIRadioButton rdoNoheader;
        private Janus.Windows.EditControls.UIRadioButton radInTachRieng;
    }
}