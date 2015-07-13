namespace Vietbait.Lablink.TestInformation.UI.Forms
{
    partial class frmSearchPatient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchPatient));
            Janus.Windows.GridEX.GridEXLayout grdPatients_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.btnExit = new Janus.Windows.EditControls.UIButton();
            this.cmdSearch = new Janus.Windows.EditControls.UIButton();
            this.Label7 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.dtpDate = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label2 = new System.Windows.Forms.Label();
            this.grdPatients = new Janus.Windows.GridEX.GridEX();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPatients)).BeginInit();
            this.SuspendLayout();
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.btnExit);
            this.uiGroupBox1.Controls.Add(this.cmdSearch);
            this.uiGroupBox1.Controls.Add(this.Label7);
            this.uiGroupBox1.Controls.Add(this.txtBarcode);
            this.uiGroupBox1.Controls.Add(this.dtpDate);
            this.uiGroupBox1.Controls.Add(this.label2);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(984, 49);
            this.uiGroupBox1.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(844, 16);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(128, 25);
            this.btnExit.TabIndex = 42;
            this.btnExit.Text = "Thoát (Esc)";
            this.btnExit.ToolTipText = "Tìm kiếm thông tin bệnh nhân hoặc nhấn phím tắt F3";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cmdSearch
            // 
            this.cmdSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdSearch.Image")));
            this.cmdSearch.Location = new System.Drawing.Point(710, 16);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(128, 25);
            this.cmdSearch.TabIndex = 41;
            this.cmdSearch.Text = "Tìm kiếm (F3)";
            this.cmdSearch.ToolTipText = "Tìm kiếm thông tin bệnh nhân hoặc nhấn phím tắt F3";
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // Label7
            // 
            this.Label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Label7.Location = new System.Drawing.Point(211, 19);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(63, 19);
            this.Label7.TabIndex = 40;
            this.Label7.Text = "Barcode";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(277, 16);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(153, 25);
            this.txtBarcode.TabIndex = 39;
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDate.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtpDate.DropDownCalendar.Name = "";
            this.dtpDate.Location = new System.Drawing.Point(68, 16);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.ShowUpDown = true;
            this.dtpDate.Size = new System.Drawing.Size(132, 25);
            this.dtpDate.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 38;
            this.label2.Text = "Ngày";
            // 
            // grdPatients
            // 
            this.grdPatients.AllowDrop = true;
            this.grdPatients.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdPatients.BuiltInTextsData = "<LocalizableData ID=\"LocalizableStrings\" Collection=\"true\"><RecordNavigator>Số lư" +
                "ợng: | Of</RecordNavigator><FilterRowInfoText>Lọc thông tin bệnh nhân</FilterRow" +
                "InfoText></LocalizableData>";
            grdPatients_DesignTimeLayout.LayoutString = resources.GetString("grdPatients_DesignTimeLayout.LayoutString");
            this.grdPatients.DesignTimeLayout = grdPatients_DesignTimeLayout;
            this.grdPatients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPatients.DynamicFiltering = true;
            this.grdPatients.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdPatients.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.grdPatients.FilterRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grdPatients.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdPatients.FocusCellFormatStyle.BackColor = System.Drawing.SystemColors.Highlight;
            this.grdPatients.FocusCellFormatStyle.BackColorGradient = System.Drawing.SystemColors.Highlight;
            this.grdPatients.FocusCellFormatStyle.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdPatients.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdPatients.GroupByBoxVisible = false;
            this.grdPatients.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdPatients.Location = new System.Drawing.Point(0, 49);
            this.grdPatients.Name = "grdPatients";
            this.grdPatients.RecordNavigator = true;
            this.grdPatients.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowPosition;
            this.grdPatients.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdPatients.SelectedFormatStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdPatients.Size = new System.Drawing.Size(984, 404);
            this.grdPatients.TabIndex = 1;
            this.grdPatients.DoubleClick += new System.EventHandler(this.grdPatients_DoubleClick);
            // 
            // frmSearchPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 453);
            this.Controls.Add(this.grdPatients);
            this.Controls.Add(this.uiGroupBox1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSearchPatient";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TÌM KIẾM BỆNH NHÂN";
            this.Load += new System.EventHandler(this.frmSearchPatient_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSearchPatient_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPatients)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        internal Janus.Windows.GridEX.GridEX grdPatients;
        internal Janus.Windows.CalendarCombo.CalendarCombo dtpDate;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.TextBox txtBarcode;
        internal Janus.Windows.EditControls.UIButton cmdSearch;
        internal Janus.Windows.EditControls.UIButton btnExit;
    }
}