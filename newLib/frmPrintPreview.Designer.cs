﻿namespace VNS.Libs
{
    partial class frmPrintPreview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintPreview));
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel1 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel2 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            this.crptViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.cmdTrinhKy = new Janus.Windows.EditControls.UIButton();
            this.cmdExcel = new Janus.Windows.EditControls.UIButton();
            this.uiStatusBar1 = new Janus.Windows.UI.StatusBar.UIStatusBar();
            this.cmdPrint = new Janus.Windows.EditControls.UIButton();
            this.txtCopyPage = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
            this.lblPageCopy = new System.Windows.Forms.Label();
            this.cboPrinter = new Janus.Windows.EditControls.UIComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip();
            this.cmdCalculator = new Janus.Windows.EditControls.UIButton();
            this.SuspendLayout();
            // 
            // crptViewer
            // 
            this.crptViewer.ActiveViewIndex = -1;
            this.crptViewer.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.crptViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crptViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crptViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crptViewer.EnableDrillDown = false;
            this.crptViewer.Location = new System.Drawing.Point(0, 0);
            this.crptViewer.Name = "crptViewer";
            this.crptViewer.SelectionFormula = "";
            this.crptViewer.ShowCloseButton = false;
            this.crptViewer.ShowCopyButton = false;
            this.crptViewer.ShowGroupTreeButton = false;
            this.crptViewer.ShowParameterPanelButton = false;
            this.crptViewer.ShowPrintButton = false;
            this.crptViewer.ShowRefreshButton = false;
            this.crptViewer.Size = new System.Drawing.Size(1018, 717);
            this.crptViewer.TabIndex = 0;
            this.crptViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crptViewer.ViewTimeSelectionFormula = "";
            // 
            // cmdTrinhKy
            // 
            this.cmdTrinhKy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTrinhKy.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdTrinhKy.Image = ((System.Drawing.Image)(resources.GetObject("cmdTrinhKy.Image")));
            this.cmdTrinhKy.ImageSize = new System.Drawing.Size(20, 20);
            this.cmdTrinhKy.Location = new System.Drawing.Point(333, 2);
            this.cmdTrinhKy.Name = "cmdTrinhKy";
            this.cmdTrinhKy.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom;
            this.cmdTrinhKy.Office2007CustomColor = System.Drawing.Color.White;
            this.cmdTrinhKy.Size = new System.Drawing.Size(36, 25);
            this.cmdTrinhKy.TabIndex = 11;
            this.toolTip1.SetToolTip(this.cmdTrinhKy, "Cập nhật trình ký");
            this.cmdTrinhKy.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.cmdTrinhKy.Click += new System.EventHandler(this.cmdTrinhKy_Click_2);
            // 
            // cmdExcel
            // 
            this.cmdExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExcel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExcel.Image = ((System.Drawing.Image)(resources.GetObject("cmdExcel.Image")));
            this.cmdExcel.ImageSize = new System.Drawing.Size(20, 20);
            this.cmdExcel.Location = new System.Drawing.Point(291, 2);
            this.cmdExcel.Name = "cmdExcel";
            this.cmdExcel.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom;
            this.cmdExcel.Office2007CustomColor = System.Drawing.Color.White;
            this.cmdExcel.Size = new System.Drawing.Size(36, 25);
            this.cmdExcel.TabIndex = 12;
            this.toolTip1.SetToolTip(this.cmdExcel, "Xuất báo cáo ra file Excel");
            this.cmdExcel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            // 
            // uiStatusBar1
            // 
            this.uiStatusBar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiStatusBar1.Location = new System.Drawing.Point(0, 717);
            this.uiStatusBar1.Name = "uiStatusBar1";
            uiStatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel1.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel1.Image = ((System.Drawing.Image)(resources.GetObject("uiStatusBarPanel1.Image")));
            uiStatusBarPanel1.Key = "";
            uiStatusBarPanel1.ProgressBarValue = 0;
            uiStatusBarPanel1.Text = "Nhấn Ctrl+P hoặc nhấn P để thực hiện in                                          " +
                "            ";
            uiStatusBarPanel1.Width = 505;
            uiStatusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            uiStatusBarPanel2.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel2.Key = "";
            uiStatusBarPanel2.ProgressBarValue = 0;
            uiStatusBarPanel2.Text = "                                                                            Nhấn " +
                "Ctrl+S hoặc nhấn phím S để xuất Excel";
            uiStatusBarPanel2.Width = 601;
            this.uiStatusBar1.Panels.AddRange(new Janus.Windows.UI.StatusBar.UIStatusBarPanel[] {
            uiStatusBarPanel1,
            uiStatusBarPanel2});
            this.uiStatusBar1.Size = new System.Drawing.Size(1018, 23);
            this.uiStatusBar1.TabIndex = 13;
            this.uiStatusBar1.VisualStyle = Janus.Windows.UI.VisualStyle.OfficeXP;
            // 
            // cmdPrint
            // 
            this.cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdPrint.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPrint.Image = ((System.Drawing.Image)(resources.GetObject("cmdPrint.Image")));
            this.cmdPrint.ImageSize = new System.Drawing.Size(20, 20);
            this.cmdPrint.Location = new System.Drawing.Point(796, 4);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom;
            this.cmdPrint.Office2007CustomColor = System.Drawing.Color.White;
            this.cmdPrint.Size = new System.Drawing.Size(90, 25);
            this.cmdPrint.TabIndex = 14;
            this.cmdPrint.Text = "&In";
            this.cmdPrint.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // txtCopyPage
            // 
            this.txtCopyPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCopyPage.BackColor = System.Drawing.Color.White;
            this.txtCopyPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCopyPage.Location = new System.Drawing.Point(516, 4);
            this.txtCopyPage.Name = "txtCopyPage";
            this.txtCopyPage.Numeric = true;
            this.txtCopyPage.Size = new System.Drawing.Size(40, 23);
            this.txtCopyPage.TabIndex = 0;
            this.txtCopyPage.Text = "1";
            this.txtCopyPage.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.txtCopyPage.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.txtCopyPage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCopyPage_KeyDown);
            this.txtCopyPage.Validating += new System.ComponentModel.CancelEventHandler(this.txtCopyPage_Validating);
            // 
            // lblPageCopy
            // 
            this.lblPageCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPageCopy.AutoSize = true;
            this.lblPageCopy.BackColor = System.Drawing.Color.Transparent;
            this.lblPageCopy.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageCopy.Location = new System.Drawing.Point(430, 9);
            this.lblPageCopy.Name = "lblPageCopy";
            this.lblPageCopy.Size = new System.Drawing.Size(71, 15);
            this.lblPageCopy.TabIndex = 15;
            this.lblPageCopy.Text = "Số lượng in";
            // 
            // cboPrinter
            // 
            this.cboPrinter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPrinter.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cboPrinter.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPrinter.Location = new System.Drawing.Point(562, 5);
            this.cboPrinter.Name = "cboPrinter";
            this.cboPrinter.Size = new System.Drawing.Size(228, 21);
            this.cboPrinter.TabIndex = 17;
            this.cboPrinter.Text = "Máy in";
            this.cboPrinter.SelectedIndexChanged += new System.EventHandler(this.cboPrinter_SelectedIndexChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipTitle = "Trợ giúp";
            // 
            // cmdCalculator
            // 
            this.cmdCalculator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCalculator.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCalculator.Image = ((System.Drawing.Image)(resources.GetObject("cmdCalculator.Image")));
            this.cmdCalculator.ImageSize = new System.Drawing.Size(24, 24);
            this.cmdCalculator.Location = new System.Drawing.Point(375, 2);
            this.cmdCalculator.Name = "cmdCalculator";
            this.cmdCalculator.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom;
            this.cmdCalculator.Office2007CustomColor = System.Drawing.Color.White;
            this.cmdCalculator.Size = new System.Drawing.Size(36, 25);
            this.cmdCalculator.TabIndex = 18;
            this.toolTip1.SetToolTip(this.cmdCalculator, "Máy tính ");
            this.cmdCalculator.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.cmdCalculator.Click += new System.EventHandler(this.cmdCalculator_Click);
            // 
            // frmPrintPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 740);
            this.Controls.Add(this.cmdCalculator);
            this.Controls.Add(this.cboPrinter);
            this.Controls.Add(this.lblPageCopy);
            this.Controls.Add(this.txtCopyPage);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.cmdExcel);
            this.Controls.Add(this.cmdTrinhKy);
            this.Controls.Add(this.crptViewer);
            this.Controls.Add(this.uiStatusBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmPrintPreview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrintPreview";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrintPreview_FormClosing);
            this.Load += new System.EventHandler(this.frmPrintPreview_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crptViewer;
        private Janus.Windows.EditControls.UIButton cmdTrinhKy;
        private Janus.Windows.EditControls.UIButton cmdExcel;
        private Janus.Windows.UI.StatusBar.UIStatusBar uiStatusBar1;
        private Janus.Windows.EditControls.UIButton cmdPrint;
        private Janus.Windows.GridEX.EditControls.MaskedEditBox txtCopyPage;
        private System.Windows.Forms.Label lblPageCopy;
        private Janus.Windows.EditControls.UIComboBox cboPrinter;
        private System.Windows.Forms.ToolTip toolTip1;
        private Janus.Windows.EditControls.UIButton cmdCalculator;

    }
}