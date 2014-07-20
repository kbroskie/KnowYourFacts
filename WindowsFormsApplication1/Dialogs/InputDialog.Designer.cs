namespace KnowYourFacts
{
	partial class InputDialog
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.inputMaskedTextbox = new System.Windows.Forms.MaskedTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.maxFactNumberLabel = new System.Windows.Forms.Label();
			this.factNumberHelpButton = new System.Windows.Forms.Button();
			this.maxFactNumberMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(62, 160);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(147, 160);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// inputMaskedTextbox
			// 
			this.inputMaskedTextbox.HidePromptOnLeave = true;
			this.inputMaskedTextbox.Location = new System.Drawing.Point(52, 49);
			this.inputMaskedTextbox.Mask = "aaaaaaaaaaaaaaaaaaaaaaaaa";
			this.inputMaskedTextbox.Name = "inputMaskedTextbox";
			this.inputMaskedTextbox.PromptChar = ' ';
			this.inputMaskedTextbox.Size = new System.Drawing.Size(185, 20);
			this.inputMaskedTextbox.TabIndex = 2;
			this.inputMaskedTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(31, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(222, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Enter any combination of letters and numbers.";
			// 
			// maxFactNumberLabel
			// 
			this.maxFactNumberLabel.Location = new System.Drawing.Point(31, 87);
			this.maxFactNumberLabel.Name = "maxFactNumberLabel";
			this.maxFactNumberLabel.Size = new System.Drawing.Size(160, 24);
			this.maxFactNumberLabel.TabIndex = 4;
			this.maxFactNumberLabel.Text = "Highest fact number to go up to: ";
			// 
			// factNumberHelpButton
			// 
			this.factNumberHelpButton.Location = new System.Drawing.Point(179, 113);
			this.factNumberHelpButton.Name = "factNumberHelpButton";
			this.factNumberHelpButton.Size = new System.Drawing.Size(38, 20);
			this.factNumberHelpButton.TabIndex = 5;
			this.factNumberHelpButton.TabStop = false;
			this.factNumberHelpButton.Text = "Help";
			this.factNumberHelpButton.UseVisualStyleBackColor = true;
			this.factNumberHelpButton.Click += new System.EventHandler(this.factNumberHelpButton_Click);
			// 
			// maxFactNumberMaskedTextBox
			// 
			this.maxFactNumberMaskedTextBox.AllowDrop = true;
			this.maxFactNumberMaskedTextBox.AllowPromptAsInput = false;
			this.maxFactNumberMaskedTextBox.HidePromptOnLeave = true;
			this.maxFactNumberMaskedTextBox.Location = new System.Drawing.Point(73, 113);
			this.maxFactNumberMaskedTextBox.Mask = "##0";
			this.maxFactNumberMaskedTextBox.Name = "maxFactNumberMaskedTextBox";
			this.maxFactNumberMaskedTextBox.PromptChar = ' ';
			this.maxFactNumberMaskedTextBox.Size = new System.Drawing.Size(50, 20);
			this.maxFactNumberMaskedTextBox.TabIndex = 6;
			this.maxFactNumberMaskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// InputDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 197);
			this.Controls.Add(this.maxFactNumberMaskedTextBox);
			this.Controls.Add(this.factNumberHelpButton);
			this.Controls.Add(this.maxFactNumberLabel);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.inputMaskedTextbox);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "InputDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New User Profile";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.MaskedTextBox inputMaskedTextbox;
		private System.Windows.Forms.Label maxFactNumberLabel;
		private System.Windows.Forms.Button factNumberHelpButton;
		private System.Windows.Forms.MaskedTextBox maxFactNumberMaskedTextBox;
	}
}