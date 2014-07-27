namespace KnowYourFacts.Dialogs
{
	partial class NewUserProfileDialog
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
			this.okButton = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.usernameMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.usernameLabel = new System.Windows.Forms.Label();
			this.maxFactNumberLabel = new System.Windows.Forms.Label();
			this.factNumberHelpButton = new System.Windows.Forms.Button();
			this.maxFactNumberMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.usernameHelpButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// okButton
			// 
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(62, 160);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 0;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
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
			// usernameMaskedTextBox
			// 
			this.usernameMaskedTextBox.HidePromptOnLeave = true;
			this.usernameMaskedTextBox.Location = new System.Drawing.Point(73, 45);
			this.usernameMaskedTextBox.Mask = "aaaaaaaaaaaaaaaaaaaaaaaaa";
			this.usernameMaskedTextBox.Name = "usernameMaskedTextBox";
			this.usernameMaskedTextBox.PromptChar = ' ';
			this.usernameMaskedTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.usernameMaskedTextBox.Size = new System.Drawing.Size(139, 20);
			this.usernameMaskedTextBox.TabIndex = 0;
			this.usernameMaskedTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.maskedTextBoxKeyUpEvent);
			// 
			// usernameLabel
			// 
			this.usernameLabel.AutoSize = true;
			this.usernameLabel.Location = new System.Drawing.Point(31, 16);
			this.usernameLabel.Name = "usernameLabel";
			this.usernameLabel.Size = new System.Drawing.Size(58, 13);
			this.usernameLabel.TabIndex = 3;
			this.usernameLabel.Text = "Username:";
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
			this.maxFactNumberMaskedTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.maxFactNumberMaskedTextBox.Size = new System.Drawing.Size(50, 20);
			this.maxFactNumberMaskedTextBox.TabIndex = 1;
			this.maxFactNumberMaskedTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.maskedTextBoxKeyUpEvent);
			// 
			// usernameHelpButton
			// 
			this.usernameHelpButton.Location = new System.Drawing.Point(179, 13);
			this.usernameHelpButton.Name = "usernameHelpButton";
			this.usernameHelpButton.Size = new System.Drawing.Size(38, 20);
			this.usernameHelpButton.TabIndex = 7;
			this.usernameHelpButton.TabStop = false;
			this.usernameHelpButton.Text = "Help";
			this.usernameHelpButton.UseVisualStyleBackColor = true;
			this.usernameHelpButton.Click += new System.EventHandler(this.usernameHelpButton_Click);
			// 
			// InputDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 197);
			this.Controls.Add(this.usernameHelpButton);
			this.Controls.Add(this.maxFactNumberMaskedTextBox);
			this.Controls.Add(this.factNumberHelpButton);
			this.Controls.Add(this.maxFactNumberLabel);
			this.Controls.Add(this.usernameLabel);
			this.Controls.Add(this.usernameMaskedTextBox);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.okButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "InputDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New User Profile";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label usernameLabel;
		public System.Windows.Forms.MaskedTextBox usernameMaskedTextBox;
		private System.Windows.Forms.Label maxFactNumberLabel;
		private System.Windows.Forms.Button factNumberHelpButton;
		private System.Windows.Forms.Button usernameHelpButton;
		public System.Windows.Forms.MaskedTextBox maxFactNumberMaskedTextBox;
	}
}