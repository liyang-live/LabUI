namespace Vietbait.Lablink.TestInformation.UI.Forms
{
    partial class Uc_QuickInputResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Uc_QuickInputResult));
            Janus.Windows.GridEX.GridEXLayout grdPatientInfo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCanLamSangID = new Janus.Windows.GridEX.EditControls.EditBox();
            this.cboTestType = new Janus.Windows.EditControls.UIComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBarcode = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSearch = new Janus.Windows.EditControls.UIButton();
            this.dtpDateFrom = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.uiStatusBar1 = new Janus.Windows.UI.StatusBar.UIStatusBar();
            this.grdPatientInfo = new Janus.Windows.GridEX.GridEX();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPatientInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.label3);
            this.uiGroupBox1.Controls.Add(this.label1);
            this.uiGroupBox1.Controls.Add(this.txtCanLamSangID);
            this.uiGroupBox1.Controls.Add(this.cboTestType);
            this.uiGroupBox1.Controls.Add(this.label2);
            this.uiGroupBox1.Controls.Add(this.txtBarcode);
            this.uiGroupBox1.Controls.Add(this.label11);
            this.uiGroupBox1.Controls.Add(this.btnSearch);
            this.uiGroupBox1.Controls.Add(this.dtpDateFrom);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(1056, 52);
            this.uiGroupBox1.TabIndex = 0;
            this.uiGroupBox1.Text = "Thông tin tìm kiếm";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.Location = new System.Drawing.Point(678, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 21);
            this.label3.TabIndex = 47;
            this.label3.Text = "Mã HIS (F2)";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 21);
            this.label1.TabIndex = 44;
            this.label1.Text = "Ngày";
            // 
            // txtCanLamSangID
            // 
            this.txtCanLamSangID.Location = new System.Drawing.Point(762, 21);
            this.txtCanLamSangID.Name = "txtCanLamSangID";
            this.txtCanLamSangID.Size = new System.Drawing.Size(100, 22);
            this.txtCanLamSangID.TabIndex = 3;
            this.txtCanLamSangID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCanLamSangID_KeyDown);
            // 
            // cboTestType
            // 
            this.cboTestType.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cboTestType.Location = new System.Drawing.Point(265, 21);
            this.cboTestType.Name = "cboTestType";
            this.cboTestType.Size = new System.Drawing.Size(209, 22);
            this.cboTestType.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.Location = new System.Drawing.Point(480, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 21);
            this.label2.TabIndex = 45;
            this.label2.Text = "Barcode (F1)";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(572, 21);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(100, 22);
            this.txtBarcode.TabIndex = 2;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.Location = new System.Drawing.Point(198, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 21);
            this.label11.TabIndex = 42;
            this.label11.Text = "Loại XN";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(920, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(130, 30);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Tìm kiếm (F3)";
            this.btnSearch.ToolTipText = "Tìm kiếm thông tin bệnh nhân hoặc nhấn phím tắt F3";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpDateFrom.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtpDateFrom.DropDownCalendar.Name = "";
            this.dtpDateFrom.Location = new System.Drawing.Point(60, 21);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.ShowUpDown = true;
            this.dtpDateFrom.Size = new System.Drawing.Size(132, 22);
            this.dtpDateFrom.TabIndex = 0;
            // 
            // uiStatusBar1
            // 
            this.uiStatusBar1.Location = new System.Drawing.Point(0, 426);
            this.uiStatusBar1.Name = "uiStatusBar1";
            this.uiStatusBar1.Size = new System.Drawing.Size(1056, 23);
            this.uiStatusBar1.TabIndex = 2;
            this.uiStatusBar1.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            // 
            // grdPatientInfo
            // 
            grdPatientInfo_DesignTimeLayout.LayoutString = resources.GetString("grdPatientInfo_DesignTimeLayout.LayoutString");
            this.grdPatientInfo.DesignTimeLayout = grdPatientInfo_DesignTimeLayout;
            this.grdPatientInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPatientInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdPatientInfo.GroupByBoxVisible = false;
            this.grdPatientInfo.Location = new System.Drawing.Point(0, 52);
            this.grdPatientInfo.Name = "grdPatientInfo";
            this.grdPatientInfo.Size = new System.Drawing.Size(1056, 374);
            this.grdPatientInfo.TabIndex = 1;
            this.grdPatientInfo.CellUpdated += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdPatientInfo_CellUpdated);
            this.grdPatientInfo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdPatientInfo_KeyPress);
            // 
            // Uc_QuickInputResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdPatientInfo);
            this.Controls.Add(this.uiStatusBar1);
            this.Controls.Add(this.uiGroupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Uc_QuickInputResult";
            this.Size = new System.Drawing.Size(1056, 449);
            this.Load += new System.EventHandler(this.frmQuickInputResult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPatientInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private Janus.Windows.UI.StatusBar.UIStatusBar uiStatusBar1;
        private Janus.Windows.GridEX.GridEX grdPatientInfo;
        internal Janus.Windows.CalendarCombo.CalendarCombo dtpDateFrom;
        internal Janus.Windows.EditControls.UIButton btnSearch;
        internal System.Windows.Forms.Label label1;
        private Janus.Windows.EditControls.UIComboBox cboTestType;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label label3;
        private Janus.Windows.GridEX.EditControls.EditBox txtCanLamSangID;
        internal System.Windows.Forms.Label label2;
        private Janus.Windows.GridEX.EditControls.EditBox txtBarcode;
    }
}