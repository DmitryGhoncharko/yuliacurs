namespace WindowsFormsApp1
{
    partial class ResultsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewResults;
        private System.Windows.Forms.Label lblUserName; // Add a label for the user name

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridViewResults = new System.Windows.Forms.DataGridView();
            this.lblUserName = new System.Windows.Forms.Label(); // Initialize the label
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewResults
            // 
            this.dataGridViewResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResults.Location = new System.Drawing.Point(12, 41);
            this.dataGridViewResults.Name = "dataGridViewResults";
            this.dataGridViewResults.Size = new System.Drawing.Size(260, 237);
            this.dataGridViewResults.TabIndex = 0;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(12, 9);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(57, 13);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "UserName"; // Set default text for the label
            // 
            // ResultsForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 291);
            this.Controls.Add(this.lblUserName); // Add the label to the form
            this.Controls.Add(this.dataGridViewResults);
            this.Name = "ResultsForm";
            this.Text = "Results";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
