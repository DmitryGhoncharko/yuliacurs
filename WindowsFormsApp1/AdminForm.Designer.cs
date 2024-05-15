using System.ComponentModel;

namespace WindowsFormsApp1
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtQuestionText;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Button btnAddQuestion;
        private System.Windows.Forms.Button btnUpdateQuestion;
        private System.Windows.Forms.Button btnDeleteQuestion;
        private System.Windows.Forms.DataGridView dataGridViewQuestions;

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
            this.txtQuestionText = new System.Windows.Forms.TextBox();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.btnAddQuestion = new System.Windows.Forms.Button();
            this.btnUpdateQuestion = new System.Windows.Forms.Button();
            this.btnDeleteQuestion = new System.Windows.Forms.Button();
            this.dataGridViewQuestions = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuestions)).BeginInit();
            this.SuspendLayout();
            // 
            // txtQuestionText
            // 
            this.txtQuestionText.Location = new System.Drawing.Point(12, 12);
            this.txtQuestionText.Name = "txtQuestionText";
            this.txtQuestionText.Size = new System.Drawing.Size(260, 20);
            this.txtQuestionText.TabIndex = 0;
            this.txtQuestionText.Text = "Question Text";
            // 
            // txtAnswer
            // 
            this.txtAnswer.Location = new System.Drawing.Point(12, 38);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(260, 20);
            this.txtAnswer.TabIndex = 1;
            this.txtAnswer.Text = "Answer";
            // 
            // btnAddQuestion
            // 
            this.btnAddQuestion.Location = new System.Drawing.Point(12, 64);
            this.btnAddQuestion.Name = "btnAddQuestion";
            this.btnAddQuestion.Size = new System.Drawing.Size(75, 23);
            this.btnAddQuestion.TabIndex = 2;
            this.btnAddQuestion.Text = "Add";
            this.btnAddQuestion.UseVisualStyleBackColor = true;
            this.btnAddQuestion.Click += new System.EventHandler(this.btnAddQuestion_Click);
            // 
            // btnUpdateQuestion
            // 
            this.btnUpdateQuestion.Location = new System.Drawing.Point(104, 64);
            this.btnUpdateQuestion.Name = "btnUpdateQuestion";
            this.btnUpdateQuestion.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateQuestion.TabIndex = 3;
            this.btnUpdateQuestion.Text = "Update";
            this.btnUpdateQuestion.UseVisualStyleBackColor = true;
            this.btnUpdateQuestion.Click += new System.EventHandler(this.btnUpdateQuestion_Click);
            // 
            // btnDeleteQuestion
            // 
            this.btnDeleteQuestion.Location = new System.Drawing.Point(197, 64);
            this.btnDeleteQuestion.Name = "btnDeleteQuestion";
            this.btnDeleteQuestion.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteQuestion.TabIndex = 4;
            this.btnDeleteQuestion.Text = "Delete";
            this.btnDeleteQuestion.UseVisualStyleBackColor = true;
            this.btnDeleteQuestion.Click += new System.EventHandler(this.btnDeleteQuestion_Click);
            // 
            // dataGridViewQuestions
            // 
            this.dataGridViewQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewQuestions.Location = new System.Drawing.Point(12, 93);
            this.dataGridViewQuestions.Name = "dataGridViewQuestions";
            this.dataGridViewQuestions.Size = new System.Drawing.Size(260, 156);
            this.dataGridViewQuestions.TabIndex = 5;
            this.dataGridViewQuestions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewQuestions_CellClick);
            // 
            // AdminForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.dataGridViewQuestions);
            this.Controls.Add(this.btnDeleteQuestion);
            this.Controls.Add(this.btnUpdateQuestion);
            this.Controls.Add(this.btnAddQuestion);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.txtQuestionText);
            this.Name = "AdminForm";
            this.Text = "Admin Panel";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuestions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}