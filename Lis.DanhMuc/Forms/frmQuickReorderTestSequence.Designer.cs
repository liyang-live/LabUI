namespace VietBaIT.LABLink.List.UI
{
    partial class frmQuickReorderTestSequence
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuickReorderTestSequence));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TestData_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data_Sequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Measure_Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data_Point = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Normal_Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Normal_LevelW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data_View = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Data_Print = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TestData_ID,
            this.Data_Name,
            this.Data_Sequence,
            this.Measure_Unit,
            this.Data_Point,
            this.Normal_Level,
            this.Normal_LevelW,
            this.Data_View,
            this.Data_Print,
            this.Description});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1044, 437);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDown);
            this.dataGridView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseMove);
            this.dataGridView1.DragOver += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragOver);
            this.dataGridView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragDrop);
            // 
            // TestData_ID
            // 
            this.TestData_ID.DataPropertyName = "TestData_ID";
            this.TestData_ID.HeaderText = "MaXN";
            this.TestData_ID.Name = "TestData_ID";
            this.TestData_ID.ReadOnly = true;
            this.TestData_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TestData_ID.Visible = false;
            // 
            // Data_Name
            // 
            this.Data_Name.DataPropertyName = "Data_Name";
            this.Data_Name.HeaderText = "Tên XN";
            this.Data_Name.Name = "Data_Name";
            this.Data_Name.ReadOnly = true;
            this.Data_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Data_Sequence
            // 
            this.Data_Sequence.DataPropertyName = "Data_Sequence";
            this.Data_Sequence.HeaderText = "Số Thứ Tự";
            this.Data_Sequence.Name = "Data_Sequence";
            this.Data_Sequence.ReadOnly = true;
            this.Data_Sequence.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Data_Sequence.Visible = false;
            // 
            // Measure_Unit
            // 
            this.Measure_Unit.DataPropertyName = "Measure_Unit";
            this.Measure_Unit.HeaderText = "Đơn Vị";
            this.Measure_Unit.Name = "Measure_Unit";
            this.Measure_Unit.ReadOnly = true;
            this.Measure_Unit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Data_Point
            // 
            this.Data_Point.DataPropertyName = "Data_Point";
            this.Data_Point.HeaderText = "Phần Lẻ";
            this.Data_Point.Name = "Data_Point";
            this.Data_Point.ReadOnly = true;
            this.Data_Point.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Normal_Level
            // 
            this.Normal_Level.DataPropertyName = "Normal_Level";
            this.Normal_Level.HeaderText = "TB Nam";
            this.Normal_Level.Name = "Normal_Level";
            this.Normal_Level.ReadOnly = true;
            this.Normal_Level.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Normal_LevelW
            // 
            this.Normal_LevelW.DataPropertyName = "Normal_LevelW";
            this.Normal_LevelW.HeaderText = "TB Nữ";
            this.Normal_LevelW.Name = "Normal_LevelW";
            this.Normal_LevelW.ReadOnly = true;
            this.Normal_LevelW.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Data_View
            // 
            this.Data_View.DataPropertyName = "Data_View";
            this.Data_View.HeaderText = "Hiển thị kết quả";
            this.Data_View.Name = "Data_View";
            this.Data_View.ReadOnly = true;
            this.Data_View.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Data_Print
            // 
            this.Data_Print.DataPropertyName = "Data_Print";
            this.Data_Print.HeaderText = "Cho Phép In";
            this.Data_Print.Name = "Data_Print";
            this.Data_Print.ReadOnly = true;
            this.Data_Print.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Mô Tả";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 415);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1044, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(406, 17);
            this.toolStripStatusLabel1.Text = "Sắp xếp nhanh thứ tự các xét nghiệm                                   Nhấn ESC để" +
                " thoát";
            // 
            // frmQuickReorderTestSequence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 437);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmQuickReorderTestSequence";
            this.Text = "Sắp xếp nhanh";
            this.Load += new System.EventHandler(this.frmQuickReorderTestSequence_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmQuickReorderTestSequence_KeyUp);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmQuickReorderTestSequence_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestData_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data_Sequence;
        private System.Windows.Forms.DataGridViewTextBoxColumn Measure_Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data_Point;
        private System.Windows.Forms.DataGridViewTextBoxColumn Normal_Level;
        private System.Windows.Forms.DataGridViewTextBoxColumn Normal_LevelW;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Data_View;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Data_Print;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}