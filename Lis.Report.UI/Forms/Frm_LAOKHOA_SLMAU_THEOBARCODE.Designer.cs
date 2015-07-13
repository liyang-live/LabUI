namespace VietBaIT.LABLink.Reports.Forms
{
    partial class Frm_LAOKHOA_SLMAU_THEOBARCODE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_LAOKHOA_SLMAU_THEOBARCODE));
            this.btnCancel = new Janus.Windows.EditControls.UIButton();
            this.btnPrint = new Janus.Windows.EditControls.UIButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtToBarcode = new Janus.Windows.GridEX.EditControls.EditBox();
            this.txtFromBarcode = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sysColor = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dtpDatePrintFrom = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.chkSoLuong = new System.Windows.Forms.CheckBox();
            this.chkDanhSach = new System.Windows.Forms.CheckBox();
            this.sysColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageSize = new System.Drawing.Size(24, 24);
            this.btnCancel.Location = new System.Drawing.Point(199, 260);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(162, 37);
            this.btnCancel.TabIndex = 101;
            this.btnCancel.Text = "Thoát (Esc)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageSize = new System.Drawing.Size(24, 24);
            this.btnPrint.Location = new System.Drawing.Point(25, 260);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(159, 37);
            this.btnPrint.TabIndex = 100;
            this.btnPrint.Text = "In Báo cáo (F4)";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(89, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(290, 68);
            this.label7.TabIndex = 1;
            this.label7.Text = "BÁO CÁO SỐ LƯỢNG MẪU THEO BARCODE";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 17);
            this.label4.TabIndex = 99;
            this.label4.Text = "&Barcode từ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(84, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 17);
            this.label3.TabIndex = 98;
            this.label3.Text = "đến:";
            // 
            // txtToBarcode
            // 
            this.txtToBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtToBarcode.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToBarcode.Location = new System.Drawing.Point(123, 187);
            this.txtToBarcode.MaxLength = 4;
            this.txtToBarcode.Name = "txtToBarcode";
            this.txtToBarcode.Size = new System.Drawing.Size(170, 21);
            this.txtToBarcode.TabIndex = 97;
            this.txtToBarcode.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            // 
            // txtFromBarcode
            // 
            this.txtFromBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtFromBarcode.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromBarcode.Location = new System.Drawing.Point(123, 157);
            this.txtFromBarcode.MaxLength = 4;
            this.txtFromBarcode.Name = "txtFromBarcode";
            this.txtFromBarcode.Size = new System.Drawing.Size(170, 21);
            this.txtFromBarcode.TabIndex = 96;
            this.txtFromBarcode.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(60, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 95;
            this.label2.Text = "&Ngày in:";
            // 
            // sysColor
            // 
            this.sysColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sysColor.Controls.Add(this.label6);
            this.sysColor.Controls.Add(this.label7);
            this.sysColor.Controls.Add(this.pictureBox1);
            this.sysColor.Dock = System.Windows.Forms.DockStyle.Top;
            this.sysColor.Location = new System.Drawing.Point(0, 0);
            this.sysColor.Margin = new System.Windows.Forms.Padding(5);
            this.sysColor.Name = "sysColor";
            this.sysColor.Size = new System.Drawing.Size(373, 100);
            this.sysColor.TabIndex = 93;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(113, 68);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(213, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Bạn có thể dùng phím tắt để thao tác )";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(5, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(79, 83);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // dtpDatePrintFrom
            // 
            this.dtpDatePrintFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpDatePrintFrom.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.dtpDatePrintFrom.DropDownCalendar.Name = "";
            this.dtpDatePrintFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDatePrintFrom.Location = new System.Drawing.Point(125, 124);
            this.dtpDatePrintFrom.Margin = new System.Windows.Forms.Padding(5);
            this.dtpDatePrintFrom.Name = "dtpDatePrintFrom";
            this.dtpDatePrintFrom.ShowUpDown = true;
            this.dtpDatePrintFrom.Size = new System.Drawing.Size(168, 23);
            this.dtpDatePrintFrom.TabIndex = 91;
            // 
            // chkSoLuong
            // 
            this.chkSoLuong.AutoSize = true;
            this.chkSoLuong.ForeColor = System.Drawing.Color.Blue;
            this.chkSoLuong.Location = new System.Drawing.Point(123, 214);
            this.chkSoLuong.Name = "chkSoLuong";
            this.chkSoLuong.Size = new System.Drawing.Size(139, 19);
            this.chkSoLuong.TabIndex = 102;
            this.chkSoLuong.Text = "Số lượng xét nghiệm";
            this.chkSoLuong.UseVisualStyleBackColor = true;
            this.chkSoLuong.CheckedChanged += new System.EventHandler(this.chkSoLuong_CheckedChanged);
            // 
            // chkDanhSach
            // 
            this.chkDanhSach.AutoSize = true;
            this.chkDanhSach.ForeColor = System.Drawing.Color.Blue;
            this.chkDanhSach.Location = new System.Drawing.Point(123, 235);
            this.chkDanhSach.Name = "chkDanhSach";
            this.chkDanhSach.Size = new System.Drawing.Size(150, 19);
            this.chkDanhSach.TabIndex = 103;
            this.chkDanhSach.Text = "Danh sách bệnh nhân ";
            this.chkDanhSach.UseVisualStyleBackColor = true;
            this.chkDanhSach.CheckedChanged += new System.EventHandler(this.chkDanhSach_CheckedChanged);
            // 
            // Frm_LAOKHOA_SLMAU_THEOBARCODE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 309);
            this.Controls.Add(this.chkDanhSach);
            this.Controls.Add(this.chkSoLuong);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtToBarcode);
            this.Controls.Add(this.txtFromBarcode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sysColor);
            this.Controls.Add(this.dtpDatePrintFrom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_LAOKHOA_SLMAU_THEOBARCODE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THỐNG KÊ SỐ LƯỢNG MẪU THEO BARCODE";
            this.Load += new System.EventHandler(this.Frm_LAOKHOA_SLMAU_THEOBARCODE_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_LAOKHOA_SLMAU_THEOBARCODE_KeyDown);
            this.sysColor.ResumeLayout(false);
            this.sysColor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Janus.Windows.EditControls.UIButton btnCancel;
        private Janus.Windows.EditControls.UIButton btnPrint;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.GridEX.EditControls.EditBox txtToBarcode;
        private Janus.Windows.GridEX.EditControls.EditBox txtFromBarcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel sysColor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Janus.Windows.CalendarCombo.CalendarCombo dtpDatePrintFrom;
        private System.Windows.Forms.CheckBox chkSoLuong;
        private System.Windows.Forms.CheckBox chkDanhSach;
    }
}