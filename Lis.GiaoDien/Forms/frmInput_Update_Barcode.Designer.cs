namespace Vietbait.Lablink.TestInformation.UI.Forms
{
    partial class frmInput_Update_Barcode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInput_Update_Barcode));
            this.label1 = new System.Windows.Forms.Label();
            this.txtBarcode = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDate = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.txtTestType_Name = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAccept = new Janus.Windows.EditControls.UIButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ngày";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBarcode.Location = new System.Drawing.Point(75, 12);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(246, 25);
            this.txtBarcode.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Loại XN";
            // 
            // dtpDate
            // 
            // 
            // 
            // 
            this.dtpDate.DropDownCalendar.Name = "";
            this.dtpDate.Location = new System.Drawing.Point(75, 44);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(118, 25);
            this.dtpDate.TabIndex = 1;
            // 
            // txtTestType_Name
            // 
            this.txtTestType_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTestType_Name.Enabled = false;
            this.txtTestType_Name.Location = new System.Drawing.Point(75, 75);
            this.txtTestType_Name.Name = "txtTestType_Name";
            this.txtTestType_Name.Size = new System.Drawing.Size(246, 25);
            this.txtTestType_Name.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Barcode";
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(75, 106);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(246, 29);
            this.btnAccept.TabIndex = 8;
            this.btnAccept.Text = "Chấp nhận (Enter)";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // frmInput_Update_Barcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 145);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTestType_Name);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInput_Update_Barcode";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nhập Barcode";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInput_Update_Barcode_FormClosing);
            this.Load += new System.EventHandler(this.frmInput_Update_Barcode_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmInput_Update_Barcode_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.CalendarCombo.CalendarCombo dtpDate;
        private System.Windows.Forms.Label label3;
        private Janus.Windows.EditControls.UIButton btnAccept;
        public Janus.Windows.GridEX.EditControls.EditBox txtBarcode;
        public Janus.Windows.GridEX.EditControls.EditBox txtTestType_Name;

    }
}