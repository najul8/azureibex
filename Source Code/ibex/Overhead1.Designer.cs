namespace ibex
{
    partial class Overhead1
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
            this.gvResults = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // gvResults
            // 
            this.gvResults.AllowUserToAddRows = false;
            this.gvResults.AllowUserToDeleteRows = false;
            this.gvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvResults.Location = new System.Drawing.Point(13, 13);
            this.gvResults.Name = "gvResults";
            this.gvResults.ReadOnly = true;
            this.gvResults.Size = new System.Drawing.Size(727, 307);
            this.gvResults.TabIndex = 0;
            // 
            // Overhead1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 352);
            this.Controls.Add(this.gvResults);
            this.Name = "Overhead1";
            this.Text = "Overhead";
            this.Load += new System.EventHandler(this.Overhead1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvResults;
    }
}