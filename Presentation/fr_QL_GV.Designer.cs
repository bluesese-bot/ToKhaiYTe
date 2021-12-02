
namespace ToKhaiYTe.Presentation
{
    partial class fr_QL_GV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fr_QL_GV));
            this.msds = new ADGV.AdvancedDataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.msds)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // msds
            // 
            this.msds.AutoGenerateContextFilters = true;
            this.msds.BackgroundColor = System.Drawing.Color.White;
            this.msds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.msds.DateWithTime = false;
            this.msds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msds.Location = new System.Drawing.Point(0, 0);
            this.msds.Name = "msds";
            this.msds.ReadOnly = true;
            this.msds.RowHeadersWidth = 51;
            this.msds.RowTemplate.Height = 24;
            this.msds.Size = new System.Drawing.Size(1231, 681);
            this.msds.TabIndex = 1;
            this.msds.TimeFilter = false;
            this.msds.SortStringChanged += new System.EventHandler(this.msds_SortStringChanged);
            this.msds.FilterStringChanged += new System.EventHandler(this.msds_FilterStringChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.msds);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1231, 747);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 681);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1231, 66);
            this.panel3.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.DarkTurquoise;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumAquamarine;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(926, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(233, 55);
            this.button2.TabIndex = 2;
            this.button2.Text = "In báo cáo";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // fr_QL_GV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1231, 747);
            this.Controls.Add(this.panel2);
            this.Name = "fr_QL_GV";
            this.Text = "Quản Lý GV";
            this.Load += new System.EventHandler(this.fr_QL_GV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.msds)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ADGV.AdvancedDataGridView msds;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button2;
    }
}