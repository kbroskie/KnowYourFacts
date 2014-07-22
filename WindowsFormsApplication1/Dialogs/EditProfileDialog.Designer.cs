namespace KnowYourFacts.Dialogs
{
	partial class EditProfileDialog
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
			this.customFactsCheckBox = new System.Windows.Forms.CheckBox();
			this.saveChangesButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.divisionMaxFactNumberLabel = new System.Windows.Forms.Label();
			this.divisionMaxFactNumberMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.multiplicationMaxFactNumberLabel = new System.Windows.Forms.Label();
			this.multiplicationMaxFactNumberMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.subtractionMaxFactNumberLabel = new System.Windows.Forms.Label();
			this.subtractionMaxFactNumberMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.additionMaxFactNumberLabel = new System.Windows.Forms.Label();
			this.additonMaxFactNumberMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.cancelButton = new System.Windows.Forms.Button();
			this.usernameLabel = new System.Windows.Forms.Label();
			this.usernameMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// customFactsCheckBox
			// 
			this.customFactsCheckBox.AutoSize = true;
			this.customFactsCheckBox.Location = new System.Drawing.Point(12, 63);
			this.customFactsCheckBox.Name = "customFactsCheckBox";
			this.customFactsCheckBox.Size = new System.Drawing.Size(185, 17);
			this.customFactsCheckBox.TabIndex = 0;
			this.customFactsCheckBox.Text = "Use Custom Facts for Speed Test";
			this.customFactsCheckBox.UseVisualStyleBackColor = true;
			this.customFactsCheckBox.CheckedChanged += new System.EventHandler(this.customFactsCheckBox_CheckedChanged);
			// 
			// saveChangesButton
			// 
			this.saveChangesButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.saveChangesButton.Location = new System.Drawing.Point(12, 227);
			this.saveChangesButton.Name = "saveChangesButton";
			this.saveChangesButton.Size = new System.Drawing.Size(111, 24);
			this.saveChangesButton.TabIndex = 1;
			this.saveChangesButton.Text = "Save Changes";
			this.saveChangesButton.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(165, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Max. Days Between Speed Tests";
			// 
			// maskedTextBox1
			// 
			this.maskedTextBox1.Location = new System.Drawing.Point(212, 37);
			this.maskedTextBox1.Name = "maskedTextBox1";
			this.maskedTextBox1.Size = new System.Drawing.Size(55, 20);
			this.maskedTextBox1.TabIndex = 2;
			this.maskedTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputMaskedTextBox_KeyPress);
			this.maskedTextBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.maskedTextBoxKeyUpEvent);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.divisionMaxFactNumberLabel);
			this.groupBox1.Controls.Add(this.divisionMaxFactNumberMaskedTextBox);
			this.groupBox1.Controls.Add(this.multiplicationMaxFactNumberLabel);
			this.groupBox1.Controls.Add(this.multiplicationMaxFactNumberMaskedTextBox);
			this.groupBox1.Controls.Add(this.subtractionMaxFactNumberLabel);
			this.groupBox1.Controls.Add(this.subtractionMaxFactNumberMaskedTextBox);
			this.groupBox1.Controls.Add(this.additionMaxFactNumberLabel);
			this.groupBox1.Controls.Add(this.additonMaxFactNumberMaskedTextBox);
			this.groupBox1.Location = new System.Drawing.Point(18, 88);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(249, 125);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Maximum Fact Number";
			// 
			// divisionMaxFactNumberLabel
			// 
			this.divisionMaxFactNumberLabel.AutoSize = true;
			this.divisionMaxFactNumberLabel.CausesValidation = false;
			this.divisionMaxFactNumberLabel.Location = new System.Drawing.Point(38, 104);
			this.divisionMaxFactNumberLabel.Name = "divisionMaxFactNumberLabel";
			this.divisionMaxFactNumberLabel.Size = new System.Drawing.Size(44, 13);
			this.divisionMaxFactNumberLabel.TabIndex = 13;
			this.divisionMaxFactNumberLabel.Text = "Division";
			// 
			// divisionMaxFactNumberMaskedTextBox
			// 
			this.divisionMaxFactNumberMaskedTextBox.CausesValidation = false;
			this.divisionMaxFactNumberMaskedTextBox.Location = new System.Drawing.Point(154, 97);
			this.divisionMaxFactNumberMaskedTextBox.Mask = "##0";
			this.divisionMaxFactNumberMaskedTextBox.Name = "divisionMaxFactNumberMaskedTextBox";
			this.divisionMaxFactNumberMaskedTextBox.PromptChar = ' ';
			this.divisionMaxFactNumberMaskedTextBox.Size = new System.Drawing.Size(55, 20);
			this.divisionMaxFactNumberMaskedTextBox.TabIndex = 12;
			this.divisionMaxFactNumberMaskedTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputMaskedTextBox_KeyPress);
			this.divisionMaxFactNumberMaskedTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.maskedTextBoxKeyUpEvent);
			// 
			// multiplicationMaxFactNumberLabel
			// 
			this.multiplicationMaxFactNumberLabel.AutoSize = true;
			this.multiplicationMaxFactNumberLabel.CausesValidation = false;
			this.multiplicationMaxFactNumberLabel.Location = new System.Drawing.Point(38, 77);
			this.multiplicationMaxFactNumberLabel.Name = "multiplicationMaxFactNumberLabel";
			this.multiplicationMaxFactNumberLabel.Size = new System.Drawing.Size(68, 13);
			this.multiplicationMaxFactNumberLabel.TabIndex = 11;
			this.multiplicationMaxFactNumberLabel.Text = "Multiplication";
			// 
			// multiplicationMaxFactNumberMaskedTextBox
			// 
			this.multiplicationMaxFactNumberMaskedTextBox.CausesValidation = false;
			this.multiplicationMaxFactNumberMaskedTextBox.Location = new System.Drawing.Point(154, 70);
			this.multiplicationMaxFactNumberMaskedTextBox.Mask = "##0";
			this.multiplicationMaxFactNumberMaskedTextBox.Name = "multiplicationMaxFactNumberMaskedTextBox";
			this.multiplicationMaxFactNumberMaskedTextBox.PromptChar = ' ';
			this.multiplicationMaxFactNumberMaskedTextBox.Size = new System.Drawing.Size(55, 20);
			this.multiplicationMaxFactNumberMaskedTextBox.TabIndex = 10;
			this.multiplicationMaxFactNumberMaskedTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputMaskedTextBox_KeyPress);
			this.multiplicationMaxFactNumberMaskedTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.maskedTextBoxKeyUpEvent);
			// 
			// subtractionMaxFactNumberLabel
			// 
			this.subtractionMaxFactNumberLabel.AutoSize = true;
			this.subtractionMaxFactNumberLabel.CausesValidation = false;
			this.subtractionMaxFactNumberLabel.Location = new System.Drawing.Point(38, 50);
			this.subtractionMaxFactNumberLabel.Name = "subtractionMaxFactNumberLabel";
			this.subtractionMaxFactNumberLabel.Size = new System.Drawing.Size(61, 13);
			this.subtractionMaxFactNumberLabel.TabIndex = 9;
			this.subtractionMaxFactNumberLabel.Text = "Subtraction";
			// 
			// subtractionMaxFactNumberMaskedTextBox
			// 
			this.subtractionMaxFactNumberMaskedTextBox.CausesValidation = false;
			this.subtractionMaxFactNumberMaskedTextBox.Location = new System.Drawing.Point(154, 43);
			this.subtractionMaxFactNumberMaskedTextBox.Mask = "##0";
			this.subtractionMaxFactNumberMaskedTextBox.Name = "subtractionMaxFactNumberMaskedTextBox";
			this.subtractionMaxFactNumberMaskedTextBox.PromptChar = ' ';
			this.subtractionMaxFactNumberMaskedTextBox.Size = new System.Drawing.Size(55, 20);
			this.subtractionMaxFactNumberMaskedTextBox.TabIndex = 8;
			this.subtractionMaxFactNumberMaskedTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputMaskedTextBox_KeyPress);
			this.subtractionMaxFactNumberMaskedTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.maskedTextBoxKeyUpEvent);
			// 
			// additionMaxFactNumberLabel
			// 
			this.additionMaxFactNumberLabel.AutoSize = true;
			this.additionMaxFactNumberLabel.CausesValidation = false;
			this.additionMaxFactNumberLabel.Location = new System.Drawing.Point(38, 23);
			this.additionMaxFactNumberLabel.Name = "additionMaxFactNumberLabel";
			this.additionMaxFactNumberLabel.Size = new System.Drawing.Size(45, 13);
			this.additionMaxFactNumberLabel.TabIndex = 7;
			this.additionMaxFactNumberLabel.Text = "Addition";
			// 
			// additonMaxFactNumberMaskedTextBox
			// 
			this.additonMaxFactNumberMaskedTextBox.CausesValidation = false;
			this.additonMaxFactNumberMaskedTextBox.Location = new System.Drawing.Point(154, 16);
			this.additonMaxFactNumberMaskedTextBox.Mask = "##0";
			this.additonMaxFactNumberMaskedTextBox.Name = "additonMaxFactNumberMaskedTextBox";
			this.additonMaxFactNumberMaskedTextBox.PromptChar = ' ';
			this.additonMaxFactNumberMaskedTextBox.Size = new System.Drawing.Size(55, 20);
			this.additonMaxFactNumberMaskedTextBox.TabIndex = 6;
			this.additonMaxFactNumberMaskedTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputMaskedTextBox_KeyPress);
			this.additonMaxFactNumberMaskedTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.maskedTextBoxKeyUpEvent);
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(161, 227);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(111, 24);
			this.cancelButton.TabIndex = 7;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// usernameLabel
			// 
			this.usernameLabel.AutoSize = true;
			this.usernameLabel.Location = new System.Drawing.Point(9, 13);
			this.usernameLabel.Name = "usernameLabel";
			this.usernameLabel.Size = new System.Drawing.Size(55, 13);
			this.usernameLabel.TabIndex = 9;
			this.usernameLabel.Text = "Username";
			// 
			// usernameMaskedTextBox
			// 
			this.usernameMaskedTextBox.Location = new System.Drawing.Point(151, 10);
			this.usernameMaskedTextBox.Name = "usernameMaskedTextBox";
			this.usernameMaskedTextBox.Size = new System.Drawing.Size(116, 20);
			this.usernameMaskedTextBox.TabIndex = 8;
			this.usernameMaskedTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputMaskedTextBox_KeyPress);
			this.usernameMaskedTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.maskedTextBoxKeyUpEvent);
			// 
			// EditProfileDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.usernameLabel);
			this.Controls.Add(this.usernameMaskedTextBox);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.maskedTextBox1);
			this.Controls.Add(this.saveChangesButton);
			this.Controls.Add(this.customFactsCheckBox);
			this.Name = "EditProfileDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Profile";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox customFactsCheckBox;
		private System.Windows.Forms.Button saveChangesButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.MaskedTextBox maskedTextBox1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label additionMaxFactNumberLabel;
		private System.Windows.Forms.MaskedTextBox additonMaxFactNumberMaskedTextBox;
		private System.Windows.Forms.Label divisionMaxFactNumberLabel;
		private System.Windows.Forms.MaskedTextBox divisionMaxFactNumberMaskedTextBox;
		private System.Windows.Forms.Label multiplicationMaxFactNumberLabel;
		private System.Windows.Forms.MaskedTextBox multiplicationMaxFactNumberMaskedTextBox;
		private System.Windows.Forms.Label subtractionMaxFactNumberLabel;
		private System.Windows.Forms.MaskedTextBox subtractionMaxFactNumberMaskedTextBox;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Label usernameLabel;
		private System.Windows.Forms.MaskedTextBox usernameMaskedTextBox;
	}
}