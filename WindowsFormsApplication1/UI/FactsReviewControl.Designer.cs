namespace KnowYourFacts.UI
{
	partial class FactsReviewControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ()
		{
			this.previousButton = new System.Windows.Forms.Button();
			this.nextButton = new System.Windows.Forms.Button();
			this.questionLabel = new System.Windows.Forms.Label();
			this.answeredLabel = new System.Windows.Forms.Label();
			this.correctAnswerLabel = new System.Windows.Forms.Label();
			this.questionContentLabel = new System.Windows.Forms.Label();
			this.answerContentLabel = new System.Windows.Forms.Label();
			this.correctAnswerContentLabel = new System.Windows.Forms.Label();
			this.mainMenuButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// previousButton
			// 
			this.previousButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.previousButton.Location = new System.Drawing.Point(65, 175);
			this.previousButton.Name = "previousButton";
			this.previousButton.Size = new System.Drawing.Size(68, 39);
			this.previousButton.TabIndex = 0;
			this.previousButton.Text = "Previous";
			this.previousButton.UseVisualStyleBackColor = true;
			this.previousButton.Click += new System.EventHandler(this.previousButton_Click);
			// 
			// nextButton
			// 
			this.nextButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.nextButton.Location = new System.Drawing.Point(157, 175);
			this.nextButton.Name = "nextButton";
			this.nextButton.Size = new System.Drawing.Size(68, 39);
			this.nextButton.TabIndex = 1;
			this.nextButton.Text = "Next";
			this.nextButton.UseVisualStyleBackColor = true;
			this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
			// 
			// questionLabel
			// 
			this.questionLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.questionLabel.Location = new System.Drawing.Point(33, 24);
			this.questionLabel.Name = "questionLabel";
			this.questionLabel.Size = new System.Drawing.Size(89, 22);
			this.questionLabel.TabIndex = 2;
			this.questionLabel.Text = "Question:";
			// 
			// answeredLabel
			// 
			this.answeredLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.answeredLabel.Location = new System.Drawing.Point(33, 69);
			this.answeredLabel.Name = "answeredLabel";
			this.answeredLabel.Size = new System.Drawing.Size(116, 22);
			this.answeredLabel.TabIndex = 3;
			this.answeredLabel.Text = "You Answered:";
			// 
			// correctAnswerLabel
			// 
			this.correctAnswerLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.correctAnswerLabel.Location = new System.Drawing.Point(33, 121);
			this.correctAnswerLabel.Name = "correctAnswerLabel";
			this.correctAnswerLabel.Size = new System.Drawing.Size(132, 19);
			this.correctAnswerLabel.TabIndex = 4;
			this.correctAnswerLabel.Text = "Correct Answer:";
			// 
			// questionContentLabel
			// 
			this.questionContentLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.questionContentLabel.Location = new System.Drawing.Point(169, 24);
			this.questionContentLabel.Name = "questionContentLabel";
			this.questionContentLabel.Size = new System.Drawing.Size(89, 22);
			this.questionContentLabel.TabIndex = 5;
			this.questionContentLabel.Text = "0 + 0";
			this.questionContentLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// answerContentLabel
			// 
			this.answerContentLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.answerContentLabel.Location = new System.Drawing.Point(169, 69);
			this.answerContentLabel.Name = "answerContentLabel";
			this.answerContentLabel.Size = new System.Drawing.Size(89, 22);
			this.answerContentLabel.TabIndex = 6;
			this.answerContentLabel.Text = "0";
			this.answerContentLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// correctAnswerContentLabel
			// 
			this.correctAnswerContentLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.correctAnswerContentLabel.Location = new System.Drawing.Point(169, 121);
			this.correctAnswerContentLabel.Name = "correctAnswerContentLabel";
			this.correctAnswerContentLabel.Size = new System.Drawing.Size(89, 22);
			this.correctAnswerContentLabel.TabIndex = 7;
			this.correctAnswerContentLabel.Text = "0";
			this.correctAnswerContentLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// mainMenuButton
			// 
			this.mainMenuButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mainMenuButton.Location = new System.Drawing.Point(72, 233);
			this.mainMenuButton.Name = "mainMenuButton";
			this.mainMenuButton.Size = new System.Drawing.Size(142, 35);
			this.mainMenuButton.TabIndex = 8;
			this.mainMenuButton.Text = "Return to Main Menu";
			this.mainMenuButton.UseVisualStyleBackColor = true;
			this.mainMenuButton.Click += new System.EventHandler(this.mainMenuButton_Click);
			// 
			// FactsReviewControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.Controls.Add(this.mainMenuButton);
			this.Controls.Add(this.correctAnswerContentLabel);
			this.Controls.Add(this.answerContentLabel);
			this.Controls.Add(this.questionContentLabel);
			this.Controls.Add(this.correctAnswerLabel);
			this.Controls.Add(this.answeredLabel);
			this.Controls.Add(this.questionLabel);
			this.Controls.Add(this.nextButton);
			this.Controls.Add(this.previousButton);
			this.Name = "FactsReviewControl";
			this.Size = new System.Drawing.Size(291, 280);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button previousButton;
		private System.Windows.Forms.Button nextButton;
		private System.Windows.Forms.Label questionLabel;
		private System.Windows.Forms.Label answeredLabel;
		private System.Windows.Forms.Label correctAnswerLabel;
		private System.Windows.Forms.Label questionContentLabel;
		private System.Windows.Forms.Label answerContentLabel;
		private System.Windows.Forms.Label correctAnswerContentLabel;
		private System.Windows.Forms.Button mainMenuButton;
	}
}
