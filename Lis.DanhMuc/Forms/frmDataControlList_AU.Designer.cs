namespace VietBaIT.LABLink.List.UI
{
    partial class frmDataControlList_AU
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDataControlList_AU));
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.txtID = new Janus.Windows.GridEX.EditControls.EditBox();
            this.ID = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboDevice = new Janus.Windows.EditControls.UIComboBox();
            this.txtDesc = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAlias = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new Janus.Windows.EditControls.UIButton();
            this.btnSave = new Janus.Windows.EditControls.UIButton();
            this.btnReset = new Janus.Windows.EditControls.UIButton();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox2
            // 
            this.GroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox2.Controls.Add(this.txtID);
            this.GroupBox2.Controls.Add(this.ID);
            this.GroupBox2.Controls.Add(this.label9);
            this.GroupBox2.Controls.Add(this.cboDevice);
            this.GroupBox2.Controls.Add(this.txtDesc);
            this.GroupBox2.Controls.Add(this.label8);
            this.GroupBox2.Controls.Add(this.txtAlias);
            this.GroupBox2.Controls.Add(this.label1);
            this.GroupBox2.Location = new System.Drawing.Point(14, 14);
            this.GroupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.GroupBox2.Size = new System.Drawing.Size(350, 135);
            this.GroupBox2.TabIndex = 0;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Thông Tin";
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(92, 49);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(239, 22);
            this.txtID.TabIndex = 24;
            // 
            // ID
            // 
            this.ID.AutoSize = true;
            this.ID.Location = new System.Drawing.Point(18, 52);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(21, 16);
            this.ID.TabIndex = 23;
            this.ID.Text = "ID";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 16);
            this.label9.TabIndex = 22;
            this.label9.Text = "Thiết Bị";
            // 
            // cboDevice
            // 
            this.cboDevice.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cboDevice.Location = new System.Drawing.Point(92, 21);
            this.cboDevice.Name = "cboDevice";
            this.cboDevice.Size = new System.Drawing.Size(239, 22);
            this.cboDevice.TabIndex = 1;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(92, 105);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(239, 22);
            this.txtDesc.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 16);
            this.label8.TabIndex = 18;
            this.label8.Text = "Mô Tả";
            // 
            // txtAlias
            // 
            this.txtAlias.Location = new System.Drawing.Point(92, 77);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(239, 22);
            this.txtAlias.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Alias";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(232, 183);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(113, 23);
            this.btnExit.TabIndex = 23;
            this.btnExit.Text = "Thoát (Esc)";
            this.btnExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(106, 183);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 23);
            this.btnSave.TabIndex = 24;
            this.btnSave.Tag = "";
            this.btnSave.Text = "Lưu (Ctrl+S)";
            this.btnSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(106, 154);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(238, 23);
            this.btnReset.TabIndex = 25;
            this.btnReset.Tag = "";
            this.btnReset.Text = "Làm Mới (Ctrl+R)";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // frmDataControlList_AU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 214);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.GroupBox2);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDataControlList_AU";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "THÔNG TIN MÃ ĐIỀU KHIỂN THIẾT BỊ";
            this.Load += new System.EventHandler(this.frmTestDataList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTestDataList_KeyDown);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox2;
        private Janus.Windows.GridEX.EditControls.EditBox txtAlias;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.GridEX.EditControls.EditBox txtDesc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private Janus.Windows.EditControls.UIComboBox cboDevice;
        private Janus.Windows.EditControls.UIButton btnExit;
        private Janus.Windows.EditControls.UIButton btnSave;
        private Janus.Windows.EditControls.UIButton btnReset;
        private Janus.Windows.GridEX.EditControls.EditBox txtID;
        private System.Windows.Forms.Label ID;
    }
}

