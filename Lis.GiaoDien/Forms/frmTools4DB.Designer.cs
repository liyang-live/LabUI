namespace Vietbait.TestInformation.UI
{
    partial class frmTools4DB
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
            Janus.Windows.GridEX.GridEXLayout grdResultDetail_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTools4DB));
            Janus.Windows.GridEX.GridEXLayout grdTestInfo_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.btnExit = new Janus.Windows.EditControls.UIButton();
            this.btnSearch = new Janus.Windows.EditControls.UIButton();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBarcode = new Janus.Windows.GridEX.EditControls.EditBox();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.uiGroupBox3 = new Janus.Windows.EditControls.UIGroupBox();
            this.grdResultDetail = new Janus.Windows.GridEX.GridEX();
            this.uiGroupBox2 = new Janus.Windows.EditControls.UIGroupBox();
            this.grdTestInfo = new Janus.Windows.GridEX.GridEX();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox3)).BeginInit();
            this.uiGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).BeginInit();
            this.uiGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTestInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.btnExit);
            this.uiGroupBox1.Controls.Add(this.btnSearch);
            this.uiGroupBox1.Controls.Add(this.label3);
            this.uiGroupBox1.Controls.Add(this.dtpDateTo);
            this.uiGroupBox1.Controls.Add(this.label2);
            this.uiGroupBox1.Controls.Add(this.txtBarcode);
            this.uiGroupBox1.Controls.Add(this.dtpDateFrom);
            this.uiGroupBox1.Controls.Add(this.label1);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(764, 105);
            this.uiGroupBox1.TabIndex = 0;
            this.uiGroupBox1.Text = "Thông Tin Tìm Kiếm";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(152, 55);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(131, 36);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Thoát (Esc)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(15, 55);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(131, 36);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Tìm Kiếm (F3)";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(400, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Barcode";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Location = new System.Drawing.Point(280, 24);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(114, 25);
            this.dtpDateTo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Đến Ngày";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(463, 23);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(100, 25);
            this.txtBarcode.TabIndex = 2;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Location = new System.Drawing.Point(86, 24);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(114, 25);
            this.dtpDateFrom.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ Ngày";
            // 
            // uiGroupBox3
            // 
            this.uiGroupBox3.Controls.Add(this.grdResultDetail);
            this.uiGroupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.uiGroupBox3.Location = new System.Drawing.Point(448, 105);
            this.uiGroupBox3.Name = "uiGroupBox3";
            this.uiGroupBox3.Size = new System.Drawing.Size(316, 238);
            this.uiGroupBox3.TabIndex = 4;
            this.uiGroupBox3.Text = "Chi Tiết Kết Quả";
            // 
            // grdResultDetail
            // 
            this.grdResultDetail.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdResultDetail.ColumnAutoResize = true;
            grdResultDetail_DesignTimeLayout.LayoutString = resources.GetString("grdResultDetail_DesignTimeLayout.LayoutString");
            this.grdResultDetail.DesignTimeLayout = grdResultDetail_DesignTimeLayout;
            this.grdResultDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdResultDetail.GroupByBoxVisible = false;
            this.grdResultDetail.Location = new System.Drawing.Point(3, 21);
            this.grdResultDetail.Name = "grdResultDetail";
            this.grdResultDetail.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdResultDetail.Size = new System.Drawing.Size(310, 214);
            this.grdResultDetail.TabIndex = 1;
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.grdTestInfo);
            this.uiGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox2.Location = new System.Drawing.Point(0, 105);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Size = new System.Drawing.Size(448, 238);
            this.uiGroupBox2.TabIndex = 5;
            this.uiGroupBox2.Text = "Danh Sách Các XN";
            // 
            // grdTestInfo
            // 
            this.grdTestInfo.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            grdTestInfo_DesignTimeLayout.LayoutString = resources.GetString("grdTestInfo_DesignTimeLayout.LayoutString");
            this.grdTestInfo.DesignTimeLayout = grdTestInfo_DesignTimeLayout;
            this.grdTestInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTestInfo.GroupByBoxVisible = false;
            this.grdTestInfo.Location = new System.Drawing.Point(3, 21);
            this.grdTestInfo.Name = "grdTestInfo";
            this.grdTestInfo.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdTestInfo.Size = new System.Drawing.Size(442, 214);
            this.grdTestInfo.TabIndex = 1;
            this.grdTestInfo.SelectionChanged += new System.EventHandler(this.grdTestInfo_SelectionChanged);
            this.grdTestInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdTestInfo_KeyDown);
            // 
            // frmTools4DB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 343);
            this.Controls.Add(this.uiGroupBox2);
            this.Controls.Add(this.uiGroupBox3);
            this.Controls.Add(this.uiGroupBox1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTools4DB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CÔNG CỤ HỖ TRỢ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTools4DB_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTools4DB_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox3)).EndInit();
            this.uiGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdResultDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).EndInit();
            this.uiGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTestInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.GridEX.EditControls.EditBox txtBarcode;
        private Janus.Windows.EditControls.UIButton btnExit;
        private Janus.Windows.EditControls.UIButton btnSearch;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox3;
        private Janus.Windows.GridEX.GridEX grdResultDetail;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox2;
        private Janus.Windows.GridEX.GridEX grdTestInfo;
    }
}