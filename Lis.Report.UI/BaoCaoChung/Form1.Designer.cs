namespace Lis.Report.UI.BaoCaoChung
{
    partial class Form1
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
            Janus.Windows.GridEX.GridEXLayout gridResult_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gridResult = new Janus.Windows.GridEX.GridEX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridResult)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gridResult);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(998, 286);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // gridResult
            // 
            this.gridResult.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gridResult.DefaultFilterRowComparison = Janus.Windows.GridEX.FilterConditionOperator.Contains;
            gridResult_DesignTimeLayout.LayoutString = resources.GetString("gridResult_DesignTimeLayout.LayoutString");
            this.gridResult.DesignTimeLayout = gridResult_DesignTimeLayout;
            this.gridResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridResult.DynamicFiltering = true;
            this.gridResult.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.gridResult.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.gridResult.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges;
            this.gridResult.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridResult.FrozenColumns = 2;
            this.gridResult.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gridResult.GroupByBoxVisible = false;
            this.gridResult.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.gridResult.Location = new System.Drawing.Point(3, 16);
            this.gridResult.Name = "gridResult";
            this.gridResult.RecordNavigator = true;
            this.gridResult.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.gridResult.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridResult.Size = new System.Drawing.Size(992, 267);
            this.gridResult.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Location = new System.Drawing.Point(23, 241);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1004, 305);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 558);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridResult)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private Janus.Windows.GridEX.GridEX gridResult;
        private System.Windows.Forms.GroupBox groupBox1;


    }
}