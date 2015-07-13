namespace Vietbait.Lablink.TestInformation.UI.Forms
{
    partial class frmQuickTabConfig
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuickTabConfig));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ControlName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ControlTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ControlTabStop = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ControlTabIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ControlName,
            this.ControlTag,
            this.ControlTabStop,
            this.ControlTabIndex});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(520, 561);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.VirtualMode = true;
            this.dataGridView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragDrop);
            this.dataGridView1.DragOver += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragOver);
            this.dataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDown);
            this.dataGridView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseMove);
            // 
            // ControlName
            // 
            this.ControlName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ControlName.DataPropertyName = "ControlName";
            this.ControlName.HeaderText = "Control Name";
            this.ControlName.Name = "ControlName";
            this.ControlName.ReadOnly = true;
            this.ControlName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ControlName.Width = 69;
            // 
            // ControlTag
            // 
            this.ControlTag.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ControlTag.DataPropertyName = "ControlTag";
            this.ControlTag.HeaderText = "Control Tag";
            this.ControlTag.Name = "ControlTag";
            this.ControlTag.ReadOnly = true;
            this.ControlTag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ControlTag.Width = 61;
            // 
            // ControlTabStop
            // 
            this.ControlTabStop.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ControlTabStop.DataPropertyName = "ControlTabStop";
            this.ControlTabStop.FalseValue = "false";
            this.ControlTabStop.FillWeight = 200F;
            this.ControlTabStop.HeaderText = "Control Tab Stop";
            this.ControlTabStop.Name = "ControlTabStop";
            this.ControlTabStop.TrueValue = "true";
            // 
            // ControlTabIndex
            // 
            this.ControlTabIndex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ControlTabIndex.DataPropertyName = "ControlTabIndex";
            this.ControlTabIndex.HeaderText = "Control TabIndex";
            this.ControlTabIndex.Name = "ControlTabIndex";
            this.ControlTabIndex.ReadOnly = true;
            this.ControlTabIndex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(520, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(385, 17);
            this.toolStripStatusLabel1.Text = "Sắp xếp nhanh thứ tự các control                                   Nhấn ESC để th" +
    "oát";
            // 
            // frmQuickTabConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 561);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmQuickTabConfig";
            this.Text = "Sắp xếp nhanh";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmQuickReorderTestSequence_FormClosing);
            this.Load += new System.EventHandler(this.frmQuickTabConfig_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmQuickReorderTestSequence_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ControlName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ControlTag;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ControlTabStop;
        private System.Windows.Forms.DataGridViewTextBoxColumn ControlTabIndex;
    }
}