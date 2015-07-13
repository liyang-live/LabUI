namespace VietBaIT.LABLink.List.UI
{
    partial class frm_BANGGIA
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
            Janus.Windows.GridEX.GridEXLayout grdListTestType_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_BANGGIA));
            Janus.Windows.GridEX.GridEXLayout grdDataControl_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.grdListTestType = new Janus.Windows.GridEX.GridEX();
            this.uiGroupBox2 = new Janus.Windows.EditControls.UIGroupBox();
            this.grdDataControl = new Janus.Windows.GridEX.GridEX();
            this.uiGroupBox3 = new Janus.Windows.EditControls.UIGroupBox();
            this.cmdSave = new Janus.Windows.EditControls.UIButton();
            this.nmrPrice = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdListTestType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).BeginInit();
            this.uiGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDataControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox3)).BeginInit();
            this.uiGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdListTestType
            // 
            this.grdListTestType.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdListTestType.ColumnAutoResize = true;
            grdListTestType_DesignTimeLayout.LayoutString = resources.GetString("grdListTestType_DesignTimeLayout.LayoutString");
            this.grdListTestType.DesignTimeLayout = grdListTestType_DesignTimeLayout;
            this.grdListTestType.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdListTestType.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.grdListTestType.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdListTestType.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdListTestType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.grdListTestType.GroupByBoxVisible = false;
            this.grdListTestType.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdListTestType.Location = new System.Drawing.Point(0, 0);
            this.grdListTestType.Name = "grdListTestType";
            this.grdListTestType.RecordNavigator = true;
            this.grdListTestType.Size = new System.Drawing.Size(343, 475);
            this.grdListTestType.TabIndex = 12;
            this.grdListTestType.SelectionChanged += new System.EventHandler(this.grdListTestType_SelectionChanged);
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.grdDataControl);
            this.uiGroupBox2.Controls.Add(this.uiGroupBox3);
            this.uiGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiGroupBox2.Image = ((System.Drawing.Image)(resources.GetObject("uiGroupBox2.Image")));
            this.uiGroupBox2.Location = new System.Drawing.Point(343, 0);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Size = new System.Drawing.Size(464, 475);
            this.uiGroupBox2.TabIndex = 13;
            this.uiGroupBox2.Text = "Thông tin chi tiết xét nghiệm";
            // 
            // grdDataControl
            // 
            this.grdDataControl.ColumnAutoResize = true;
            grdDataControl_DesignTimeLayout.LayoutString = resources.GetString("grdDataControl_DesignTimeLayout.LayoutString");
            this.grdDataControl.DesignTimeLayout = grdDataControl_DesignTimeLayout;
            this.grdDataControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDataControl.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
            this.grdDataControl.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdDataControl.FilterRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grdDataControl.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.grdDataControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdDataControl.GroupByBoxVisible = false;
            this.grdDataControl.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.grdDataControl.Location = new System.Drawing.Point(3, 18);
            this.grdDataControl.Name = "grdDataControl";
            this.grdDataControl.RecordNavigator = true;
            this.grdDataControl.Size = new System.Drawing.Size(458, 399);
            this.grdDataControl.TabIndex = 11;
            this.grdDataControl.CellEdited += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdDataControl_CellEdited);
            this.grdDataControl.CellUpdated += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdDataControl_CellUpdated);
            this.grdDataControl.SelectionChanged += new System.EventHandler(this.grdDataControl_SelectionChanged);
            // 
            // uiGroupBox3
            // 
            this.uiGroupBox3.Controls.Add(this.cmdSave);
            this.uiGroupBox3.Controls.Add(this.nmrPrice);
            this.uiGroupBox3.Controls.Add(this.label3);
            this.uiGroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiGroupBox3.Location = new System.Drawing.Point(3, 417);
            this.uiGroupBox3.Name = "uiGroupBox3";
            this.uiGroupBox3.Size = new System.Drawing.Size(458, 55);
            this.uiGroupBox3.TabIndex = 0;
            this.uiGroupBox3.Text = "Chức năng";
            this.uiGroupBox3.UseThemes = false;
            // 
            // cmdSave
            // 
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.Location = new System.Drawing.Point(296, 13);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(153, 33);
            this.cmdSave.TabIndex = 2;
            this.cmdSave.Text = "Lưu (Ctrl+S)";
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // nmrPrice
            // 
            this.nmrPrice.DecimalDigits = 0;
            this.nmrPrice.Location = new System.Drawing.Point(83, 20);
            this.nmrPrice.Name = "nmrPrice";
            this.nmrPrice.Size = new System.Drawing.Size(207, 22);
            this.nmrPrice.TabIndex = 1;
            this.nmrPrice.Text = "0";
            this.nmrPrice.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Giá";
            // 
            // frm_BANGGIA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 475);
            this.Controls.Add(this.uiGroupBox2);
            this.Controls.Add(this.grdListTestType);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.KeyPreview = true;
            this.Name = "frm_BANGGIA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BẢNG GIÁ";
            this.Load += new System.EventHandler(this.frm_BANGGIA_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_BANGGIA_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grdListTestType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).EndInit();
            this.uiGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDataControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox3)).EndInit();
            this.uiGroupBox3.ResumeLayout(false);
            this.uiGroupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.GridEX.GridEX grdListTestType;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox2;
        private Janus.Windows.GridEX.GridEX grdDataControl;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox3;
        private Janus.Windows.EditControls.UIButton cmdSave;
        private Janus.Windows.GridEX.EditControls.NumericEditBox nmrPrice;
        private System.Windows.Forms.Label label3;

    }
}