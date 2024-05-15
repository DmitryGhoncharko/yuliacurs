namespace WindowsFormsApp1
{
    partial class ClientForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnStartTest;
        private System.Windows.Forms.Button btnViewResults;
        private System.Windows.Forms.Label lblProgress;

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
            this.lblQuestion = new System.Windows.Forms.Label();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnStartTest = new System.Windows.Forms.Button();
            this.btnViewResults = new System.Windows.Forms.Button();
            this.lblProgress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Location = new System.Drawing.Point(12, 50);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(52, 13);
            this.lblQuestion.TabIndex = 0;
            this.lblQuestion.Text = "Question:";
            // 
            // txtAnswer
            // 
            this.txtAnswer.Location = new System.Drawing.Point(15, 70);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(100, 20);
            this.txtAnswer.TabIndex = 1;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(130, 68);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnStartTest
            // 
            this.btnStartTest.Location = new System.Drawing.Point(15, 10);
            this.btnStartTest.Name = "btnStartTest";
            this.btnStartTest.Size = new System.Drawing.Size(75, 23);
            this.btnStartTest.TabIndex = 3;
            this.btnStartTest.Text = "Start Test";
            this.btnStartTest.UseVisualStyleBackColor = true;
            this.btnStartTest.Click += new System.EventHandler(this.btnStartTest_Click);
            // 
            // btnViewResults
            // 
            this.btnViewResults.Location = new System.Drawing.Point(110, 10);
            this.btnViewResults.Name = "btnViewResults";
            this.btnViewResults.Size = new System.Drawing.Size(95, 23);
            this.btnViewResults.TabIndex = 4;
            this.btnViewResults.Text = "View Results";
            this.btnViewResults.UseVisualStyleBackColor = true;
            this.btnViewResults.Click += new System.EventHandler(this.btnViewResults_Click);
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(12, 100);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(48, 13);
            this.lblProgress.TabIndex = 5;
            this.lblProgress.Text = "Progress:";
            // 
            // ClientForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 131);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.btnViewResults);
            this.Controls.Add(this.btnStartTest);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.lblQuestion);
            this.Name = "ClientForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
