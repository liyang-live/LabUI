namespace Vietbait.Lablink.TestInformation.UI.Forms
{
    partial class frm_ChoosePrint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ChoosePrint));
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel1 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel2 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            this.UiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.grdTestType = new Janus.Windows.GridEX.GridEX();
            this.cmdExit = new Janus.Windows.EditControls.UIButton();
            this.cmdPrintPhieu = new Janus.Windows.EditControls.UIButton();
            this.radGopChung = new Janus.Windows.EditControls.UIRadioButton();
            this.radInTachRieng = new Janus.Windows.EditControls.UIRadioButton();
            this.statusBar = new Janus.Windows.UI.StatusBar.UIStatusBar();
            this.btnQuickPrint = new Janus.Windows.EditControls.UIButton();
            this.rdoNoheader = new Janus.Windows.EditControls.UIRadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.chkA4 = new System.Windows.Forms.CheckBox();
            this.chkA5 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDatePrint = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.ProgressBar = new Janus.Windows.EditControls.UIProgressBar();
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
            this.UiGroupBox1.Size = new System.Drawing.Size(474, 255);
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
            this.grdTestType.Size = new System.Drawing.Size(468, 234);
            this.grdTestType.TabIndex = 0;
            // 
            // cmdExit
            // 
            this.cmdExit.Image = ((System.Drawing.Image)(resources.GetObject("cmdExit.Image")));
            this.cmdExit.Location = new System.Drawing.Point(324, 343);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(120, 26);
            this.cmdExit.TabIndex = 4;
            this.cmdExit.Text = "&Thoát(Esc)";
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // cmdPrintPhieu
            // 
            this.cmdPrintPhieu.Image = ((System.Drawing.Image)(resources.GetObject("cmdPrintPhieu.Image")));
            this.cmdPrintPhieu.Location = new System.Drawing.Point(36, 343);
            this.cmdPrintPhieu.Name = "cmdPrintPhieu";
            this.cmdPrintPhieu.Size = new System.Drawing.Size(118, 26);
            this.cmdPrintPhieu.TabIndex = 3;
            this.cmdPrintPhieu.Text = "In phiếu (F4)";
            this.cmdPrintPhieu.Click += new System.EventHandler(this.cmdPrintPhieu_Click);
            // 
            // radGopChung
            // 
            this.radGopChung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGopChung.ForeColor = System.Drawing.Color.Red;
            this.radGopChung.Location = new System.Drawing.Point(7, 278);
            this.radGopChung.Name = "radGopChung";
            this.radGopChung.Size = new System.Drawing.Size(127, 23);
            this.radGopChung.TabIndex = 9;
            this.radGopChung.Text = "&In chung vào phiếu";
            this.radGopChung.Visible = false;
            // 
            // radInTachRieng
            // 
            this.radInTachRieng.Checked = true;
            this.radInTachRieng.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radInTachRieng.ForeColor = System.Drawing.Color.Red;
            this.radInTachRieng.Location = new System.Drawing.Point(138, 278);
            this.radInTachRieng.Name = "radInTachRieng";
            this.radInTachRieng.Size = new System.Drawing.Size(160, 23);
            this.radInTachRieng.TabIndex = 10;
            this.radInTachRieng.TabStop = true;
            this.radInTachRieng.Text = "&In loại xét nghiệm tách";
            this.radInTachRieng.Visible = false;
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 386);
            this.statusBar.Margin = new System.Windows.Forms.Padding(4);
            this.statusBar.Name = "statusBar";
            uiStatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel1.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel1.Key = "";
            uiStatusBarPanel1.ProgressBarValue = 0;
            uiStatusBarPanel1.Text = "Ctrl+A: Chọn Tất";
            uiStatusBarPanel1.Width = 93;
            uiStatusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel2.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel2.Key = "";
            uiStatusBarPanel2.ProgressBarValue = 0;
            uiStatusBarPanel2.Text = "Ctrl+U: Hủy Chọn";
            uiStatusBarPanel2.Width = 97;
            this.statusBar.Panels.AddRange(new Janus.Windows.UI.StatusBar.UIStatusBarPanel[] {
            uiStatusBarPanel1,
            uiStatusBarPanel2});
            this.statusBar.Size = new System.Drawing.Size(474, 30);
            this.statusBar.TabIndex = 11;
            this.statusBar.VisualStyle = Janus.Windows.UI.VisualStyle.OfficeXP;
            // 
            // btnQuickPrint
            // 
            this.btnQuickPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnQuickPrint.Image")));
            this.btnQuickPrint.Location = new System.Drawing.Point(170, 343);
            this.btnQuickPrint.Name = "btnQuickPrint";
            this.btnQuickPrint.Size = new System.Drawing.Size(128, 26);
            this.btnQuickPrint.TabIndex = 12;
            this.btnQuickPrint.Text = "In nhanh (F5)";
            this.btnQuickPrint.Click += new System.EventHandler(this.btnQuickPrint_Click);
            // 
            // rdoNoheader
            // 
            this.rdoNoheader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoNoheader.ForeColor = System.Drawing.Color.Red;
            this.rdoNoheader.Location = new System.Drawing.Point(287, 278);
            this.rdoNoheader.Name = "rdoNoheader";
            this.rdoNoheader.Size = new System.Drawing.Size(157, 23);
            this.rdoNoheader.TabIndex = 13;
            this.rdoNoheader.Text = "&In chung không header";
            this.rdoNoheader.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(28, 310);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 19);
            this.label1.TabIndex = 14;
            this.label1.Text = "Chọn khổ in:";
            // 
            // chkA4
            // 
            this.chkA4.AutoSize = true;
            this.chkA4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.chkA4.Location = new System.Drawing.Point(124, 311);
            this.chkA4.Name = "chkA4";
            this.chkA4.Size = new System.Drawing.Size(45, 20);
            this.chkA4.TabIndex = 15;
            this.chkA4.Text = "A4";
            this.chkA4.UseVisualStyleBackColor = true;
            this.chkA4.CheckedChanged += new System.EventHandler(this.chkA4_CheckedChanged);
            // 
            // chkA5
            // 
            this.chkA5.AutoSize = true;
            this.chkA5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.chkA5.ForeColor = System.Drawing.Color.Blue;
            this.chkA5.Location = new System.Drawing.Point(166, 311);
            this.chkA5.Name = "chkA5";
            this.chkA5.Size = new System.Drawing.Size(45, 20);
            this.chkA5.TabIndex = 16;
            this.chkA5.Text = "A5";
            this.chkA5.UseVisualStyleBackColor = true;
            this.chkA5.CheckedChanged += new System.EventHandler(this.chkA5_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(220, 311);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 19);
            this.label2.TabIndex = 17;
            this.label2.Text = "Chọn ngày in:";
            // 
            // dtpDatePrint
            // 
            this.dtpDatePrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtpDatePrint.CustomFormat = "dd/MM/yyyy";
            this.dtpDatePrint.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtpDatePrint.DropDownCalendar.FirstMonth = new System.DateTime(2013, 12, 1, 0, 0, 0, 0);
            this.dtpDatePrint.DropDownCalendar.Name = "";
            this.dtpDatePrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDatePrint.Location = new System.Drawing.Point(324, 310);
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
            this.ProgressBar.Size = new System.Drawing.Size(474, 17);
            this.ProgressBar.TabIndex = 8;
            this.ProgressBar.Visible = false;
            // 
            // frm_ChoosePrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 416);
            this.Controls.Add(this.dtpDatePrint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkA5);
            this.Controls.Add(this.chkA4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdoNoheader);
            this.Controls.Add(this.btnQuickPrint);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.UiGroupBox1);
            this.Controls.Add(this.radInTachRieng);
            this.Controls.Add(this.radGopChung);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.cmdPrintPhieu);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ChoosePrint";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn loại xét nghiệm cần in ";
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
        private Janus.Windows.EditControls.UIRadioButton radGopChung;
        private Janus.Windows.EditControls.UIRadioButton radInTachRieng;
        private Janus.Windows.UI.StatusBar.UIStatusBar statusBar;
        internal Janus.Windows.EditControls.UIButton btnQuickPrint;
        private Janus.Windows.EditControls.UIRadioButton rdoNoheader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkA4;
        private System.Windows.Forms.CheckBox chkA5;
        private System.Windows.Forms.Label label2;
        internal Janus.Windows.CalendarCombo.CalendarCombo dtpDatePrint;
        private Janus.Windows.EditControls.UIProgressBar ProgressBar;
    }
}