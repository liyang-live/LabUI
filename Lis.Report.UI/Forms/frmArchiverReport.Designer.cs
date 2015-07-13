namespace VietBaIT.LABLink.Reports.Forms
{
    partial class frmArchiverReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArchiverReport));
            Janus.Windows.GridEX.GridEXLayout gridResult_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.sysColor = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtCreatePrint = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.cmdINPHIEU = new Janus.Windows.EditControls.UIButton();
            this.cmdExit = new Janus.Windows.EditControls.UIButton();
            this.dtpToDate = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label1 = new System.Windows.Forms.Label();
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.dtpFromDate = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdXemBaoCao = new Janus.Windows.EditControls.UIButton();
            this.chkPrintAll = new System.Windows.Forms.CheckBox();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gridResult = new Janus.Windows.GridEX.GridEX();
            this.cboObjectType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.sysColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridResult)).BeginInit();
            this.SuspendLayout();
            // 
            // sysColor
            // 
            this.sysColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sysColor.Controls.Add(this.pictureBox1);
            this.sysColor.Controls.Add(this.label3);
            this.sysColor.Controls.Add(this.lblMessage);
            this.sysColor.Dock = System.Windows.Forms.DockStyle.Top;
            this.sysColor.Location = new System.Drawing.Point(0, 0);
            this.sysColor.Name = "sysColor";
            this.sysColor.Size = new System.Drawing.Size(1004, 65);
            this.sysColor.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 61);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(113, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(250, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Bạn có thể dùng phím tắt để thao tác )";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMessage
            // 
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(0, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(1004, 44);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "BÁO CÁO LƯU";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 15);
            this.label7.TabIndex = 21;
            this.label7.Text = "&Ngày in:";
            // 
            // dtCreatePrint
            // 
            this.dtCreatePrint.CustomFormat = "dd/MM/yyyy";
            this.dtCreatePrint.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtCreatePrint.DropDownCalendar.Name = "";
            this.dtCreatePrint.Location = new System.Drawing.Point(89, 191);
            this.dtCreatePrint.Name = "dtCreatePrint";
            this.dtCreatePrint.ShowUpDown = true;
            this.dtCreatePrint.Size = new System.Drawing.Size(163, 21);
            this.dtCreatePrint.TabIndex = 20;
            // 
            // cmdINPHIEU
            // 
            this.cmdINPHIEU.Enabled = false;
            this.cmdINPHIEU.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdINPHIEU.Image = ((System.Drawing.Image)(resources.GetObject("cmdINPHIEU.Image")));
            this.cmdINPHIEU.Location = new System.Drawing.Point(89, 291);
            this.cmdINPHIEU.Name = "cmdINPHIEU";
            this.cmdINPHIEU.Size = new System.Drawing.Size(148, 30);
            this.cmdINPHIEU.TabIndex = 18;
            this.cmdINPHIEU.Text = "&In báo cáo(F4)";
            this.cmdINPHIEU.ToolTipText = "In báo (Bạn có thể nhấn F4 thực hiện in báo cáo)";
            this.cmdINPHIEU.Click += new System.EventHandler(this.cmdINPHIEU_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExit.Image = ((System.Drawing.Image)(resources.GetObject("cmdExit.Image")));
            this.cmdExit.Location = new System.Drawing.Point(89, 338);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(148, 30);
            this.cmdExit.TabIndex = 19;
            this.cmdExit.Text = "&Thoát(Esc)";
            this.cmdExit.ToolTipText = "Thoát khỏi Form hiện tại";
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtpToDate.DropDownCalendar.Name = "";
            this.dtpToDate.DropDownCalendar.Visible = false;
            this.dtpToDate.Location = new System.Drawing.Point(89, 123);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.ShowUpDown = true;
            this.dtpToDate.Size = new System.Drawing.Size(152, 21);
            this.dtpToDate.TabIndex = 9;
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpToDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "&Khoa";
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.cboObjectType);
            this.uiGroupBox1.Controls.Add(this.label5);
            this.uiGroupBox1.Controls.Add(this.dtpFromDate);
            this.uiGroupBox1.Controls.Add(this.label4);
            this.uiGroupBox1.Controls.Add(this.cmdXemBaoCao);
            this.uiGroupBox1.Controls.Add(this.label7);
            this.uiGroupBox1.Controls.Add(this.chkPrintAll);
            this.uiGroupBox1.Controls.Add(this.dtCreatePrint);
            this.uiGroupBox1.Controls.Add(this.cmdINPHIEU);
            this.uiGroupBox1.Controls.Add(this.cboDepartment);
            this.uiGroupBox1.Controls.Add(this.cmdExit);
            this.uiGroupBox1.Controls.Add(this.label2);
            this.uiGroupBox1.Controls.Add(this.label1);
            this.uiGroupBox1.Controls.Add(this.dtpToDate);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiGroupBox1.Image = ((System.Drawing.Image)(resources.GetObject("uiGroupBox1.Image")));
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 65);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(348, 391);
            this.uiGroupBox1.TabIndex = 17;
            this.uiGroupBox1.Text = "&Thông tin điều kiện tìm kiếm";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtpFromDate.DropDownCalendar.Name = "";
            this.dtpFromDate.DropDownCalendar.Visible = false;
            this.dtpFromDate.Location = new System.Drawing.Point(89, 91);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.ShowUpDown = true;
            this.dtpFromDate.Size = new System.Drawing.Size(152, 21);
            this.dtpFromDate.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 15);
            this.label4.TabIndex = 24;
            this.label4.Text = "&Đến Ngày";
            // 
            // cmdXemBaoCao
            // 
            this.cmdXemBaoCao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdXemBaoCao.Image = ((System.Drawing.Image)(resources.GetObject("cmdXemBaoCao.Image")));
            this.cmdXemBaoCao.Location = new System.Drawing.Point(89, 244);
            this.cmdXemBaoCao.Name = "cmdXemBaoCao";
            this.cmdXemBaoCao.Size = new System.Drawing.Size(148, 30);
            this.cmdXemBaoCao.TabIndex = 23;
            this.cmdXemBaoCao.Text = "&Xem báo cáo(F3)";
            this.cmdXemBaoCao.ToolTipText = "In báo (Bạn có thể nhấn F4 thực hiện in báo cáo)";
            this.cmdXemBaoCao.Click += new System.EventHandler(this.cmdXemBaoCao_Click);
            // 
            // chkPrintAll
            // 
            this.chkPrintAll.AutoSize = true;
            this.chkPrintAll.Location = new System.Drawing.Point(89, 158);
            this.chkPrintAll.Name = "chkPrintAll";
            this.chkPrintAll.Size = new System.Drawing.Size(258, 19);
            this.chkPrintAll.TabIndex = 22;
            this.chkPrintAll.Text = "In báo cáo lưu cả thông số chưa có kết quả";
            this.chkPrintAll.UseVisualStyleBackColor = true;
            // 
            // cboDepartment
            // 
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(89, 25);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(245, 23);
            this.cboDepartment.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "&Từ Ngày";
            // 
            // gridResult
            // 
            this.gridResult.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gridResult.AlternatingColors = true;
            this.gridResult.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet;
            this.gridResult.DefaultFilterRowComparison = Janus.Windows.GridEX.FilterConditionOperator.Contains;
            gridResult_DesignTimeLayout.LayoutString = resources.GetString("gridResult_DesignTimeLayout.LayoutString");
            this.gridResult.DesignTimeLayout = gridResult_DesignTimeLayout;
            this.gridResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridResult.DynamicFiltering = true;
            this.gridResult.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gridResult.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.gridResult.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.gridResult.FrozenColumns = 2;
            this.gridResult.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gridResult.GroupByBoxVisible = false;
            this.gridResult.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.gridResult.Location = new System.Drawing.Point(348, 65);
            this.gridResult.Name = "gridResult";
            this.gridResult.RecordNavigator = true;
            this.gridResult.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gridResult.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridResult.Size = new System.Drawing.Size(656, 391);
            this.gridResult.TabIndex = 18;
            // 
            // cboObjectType
            // 
            this.cboObjectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboObjectType.FormattingEnabled = true;
            this.cboObjectType.Location = new System.Drawing.Point(89, 58);
            this.cboObjectType.Name = "cboObjectType";
            this.cboObjectType.Size = new System.Drawing.Size(245, 23);
            this.cboObjectType.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 15);
            this.label5.TabIndex = 26;
            this.label5.Text = "&Đối tượng";
            // 
            // frmArchiverReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 456);
            this.Controls.Add(this.gridResult);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.sysColor);
            this.KeyPreview = true;
            this.Name = "frmArchiverReport";
            this.Text = "BÁO CÁO LƯU";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmArchiverReport_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmArchiverReport_KeyDown);
            this.sysColor.ResumeLayout(false);
            this.sysColor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel sysColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private Janus.Windows.CalendarCombo.CalendarCombo dtCreatePrint;
        private Janus.Windows.EditControls.UIButton cmdINPHIEU;
        private Janus.Windows.EditControls.UIButton cmdExit;
        private Janus.Windows.CalendarCombo.CalendarCombo dtpToDate;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.CheckBox chkPrintAll;
        private Janus.Windows.EditControls.UIButton cmdXemBaoCao;
        private Janus.Windows.GridEX.GridEX gridResult;
        private System.Windows.Forms.Label label4;
        private Janus.Windows.CalendarCombo.CalendarCombo dtpFromDate;
        private System.Windows.Forms.ComboBox cboObjectType;
        private System.Windows.Forms.Label label5;

    }
}