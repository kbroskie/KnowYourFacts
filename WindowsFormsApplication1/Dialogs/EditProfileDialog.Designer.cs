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
			this.speedTestDaysMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.divisionMaxFactNumberLabel = new System.Windows.Forms.Label();
			this.divisionMaxFactNumberMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.multiplicationMaxFactNumberLabel = new System.Windows.Forms.Label();
			this.multiplicationMaxFactNumberMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.subtractionMaxFactNumberLabel = new System.Windows.Forms.Label();
			this.subtractionMaxFactNumberMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.additionMaxFactNumberLabel = new System.Windows.Forms.Label();
			this.additionMaxFactNumberMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.cancelButton = new System.Windows.Forms.Button();
			this.usernameLabel = new System.Windows.Forms.Label();
			this.usernameMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.editSpeedFactsButton = new System.Windows.Forms.Button();
			this.speedTestComboBox = new System.Windows.Forms.ComboBox();
			this.passwordTextBox = new System.Windows.Forms.TextBox();
			this.passwordConfirmTextBox = new System.Windows.Forms.TextBox();
			this.passwordLabel = new System.Windows.Forms.Label();
			this.passwordConfirmLabel = new System.Windows.Forms.Label();
			this.changePasswordLabel = new System.Windows.Forms.Label();
			this.changePasswordTextBox = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// customFactsCheckBox
			// 
			this.customFactsCheckBox.AutoSize = true;
			this.customFactsCheckBox.Location = new System.Drawing.Point(12, 63);
			this.customFactsCheckBox.Name = "customFactsCheckBox";
			this.customFactsCheckBox.Size = new System.Drawing.Size(146, 17);
			this.customFactsCheckBox.TabIndex = 2;
			this.customFactsCheckBox.Text = "Use Custom Speed Facts";
			this.customFactsCheckBox.UseVisualStyleBackColor = true;
			// 
			// saveChangesButton
			// 
			this.saveChangesButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.saveChangesButton.Location = new System.Drawing.Point(12, 352);
			this.saveChangesButton.Name = "saveChangesButton";
			this.saveChangesButton.Size = new System.Drawing.Size(111, 24);
			this.saveChangesButton.TabIndex = 12;
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
			// speedTestDaysMaskedTextBox
			// 
			this.speedTestDaysMaskedTextBox.Location = new System.Drawing.Point(212, 37);
			this.speedTestDaysMaskedTextBox.Name = "speedTestDaysMaskedTextBox";
			this.speedTestDaysMaskedTextBox.Size = new System.Drawing.Size(55, 20);
			this.speedTestDaysMaskedTextBox.TabIndex = 1;
			this.speedTestDaysMaskedTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputMaskedTextBox_KeyPress);
			this.speedTestDaysMaskedTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.maskedTextBoxKeyUpEvent);
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
			this.groupBox1.Controls.Add(this.additionMaxFactNumberMaskedTextBox);
			this.groupBox1.Location = new System.Drawing.Point(18, 116);
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
			this.divisionMaxFactNumberMaskedTextBox.TabIndex = 8;
			this.divisionMaxFactNumberMaskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
			this.multiplicationMaxFactNumberMaskedTextBox.TabIndex = 7;
			this.multiplicationMaxFactNumberMaskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
			this.subtractionMaxFactNumberMaskedTextBox.TabIndex = 6;
			this.subtractionMaxFactNumberMaskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
			// additionMaxFactNumberMaskedTextBox
			// 
			this.additionMaxFactNumberMaskedTextBox.CausesValidation = false;
			this.additionMaxFactNumberMaskedTextBox.Location = new System.Drawing.Point(154, 16);
			this.additionMaxFactNumberMaskedTextBox.Mask = "##0";
			this.additionMaxFactNumberMaskedTextBox.Name = "additionMaxFactNumberMaskedTextBox";
			this.additionMaxFactNumberMaskedTextBox.PromptChar = ' ';
			this.additionMaxFactNumberMaskedTextBox.Size = new System.Drawing.Size(55, 20);
			this.additionMaxFactNumberMaskedTextBox.TabIndex = 5;
			this.additionMaxFactNumberMaskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.additionMaxFactNumberMaskedTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputMaskedTextBox_KeyPress);
			this.additionMaxFactNumberMaskedTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.maskedTextBoxKeyUpEvent);
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(161, 352);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(111, 24);
			this.cancelButton.TabIndex = 13;
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
			this.usernameMaskedTextBox.TabIndex = 0;
			this.usernameMaskedTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputMaskedTextBox_KeyPress);
			this.usernameMaskedTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.maskedTextBoxKeyUpEvent);
			// 
			// editSpeedFactsButton
			// 
			this.editSpeedFactsButton.Location = new System.Drawing.Point(167, 87);
			this.editSpeedFactsButton.Name = "editSpeedFactsButton";
			this.editSpeedFactsButton.Size = new System.Drawing.Size(100, 23);
			this.editSpeedFactsButton.TabIndex = 4;
			this.editSpeedFactsButton.Text = "Edit Speed Facts";
			this.editSpeedFactsButton.UseVisualStyleBackColor = true;
			this.editSpeedFactsButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.editSpeedFactsButton_MouseClick);
			// 
			// speedTestComboBox
			// 
			this.speedTestComboBox.FormattingEnabled = true;
			this.speedTestComboBox.Items.AddRange(new object[] {
            "Addition",
            "Subtraction",
            "Multiplication",
            "Division"});
			this.speedTestComboBox.Location = new System.Drawing.Point(18, 87);
			this.speedTestComboBox.Name = "speedTestComboBox";
			this.speedTestComboBox.Size = new System.Drawing.Size(121, 21);
			this.speedTestComboBox.TabIndex = 3;
			// 
			// passwordTextBox
			// 
			this.passwordTextBox.Location = new System.Drawing.Point(147, 19);
			this.passwordTextBox.Name = "passwordTextBox";
			this.passwordTextBox.PasswordChar = '*';
			this.passwordTextBox.Size = new System.Drawing.Size(96, 20);
			this.passwordTextBox.TabIndex = 9;
			// 
			// passwordConfirmTextBox
			// 
			this.passwordConfirmTextBox.Location = new System.Drawing.Point(147, 79);
			this.passwordConfirmTextBox.Name = "passwordConfirmTextBox";
			this.passwordConfirmTextBox.PasswordChar = '*';
			this.passwordConfirmTextBox.Size = new System.Drawing.Size(96, 20);
			this.passwordConfirmTextBox.TabIndex = 11;
			// 
			// passwordLabel
			// 
			this.passwordLabel.AutoSize = true;
			this.passwordLabel.Location = new System.Drawing.Point(1, 22);
			this.passwordLabel.Name = "passwordLabel";
			this.passwordLabel.Size = new System.Drawing.Size(139, 13);
			this.passwordLabel.TabIndex = 12;
			this.passwordLabel.Text = "Parent Password (Required)";
			// 
			// passwordConfirmLabel
			// 
			this.passwordConfirmLabel.AutoSize = true;
			this.passwordConfirmLabel.Location = new System.Drawing.Point(3, 83);
			this.passwordConfirmLabel.Name = "passwordConfirmLabel";
			this.passwordConfirmLabel.Size = new System.Drawing.Size(91, 13);
			this.passwordConfirmLabel.TabIndex = 13;
			this.passwordConfirmLabel.Text = "Confirm Password";
			// 
			// changePasswordLabel
			// 
			this.changePasswordLabel.AutoSize = true;
			this.changePasswordLabel.Location = new System.Drawing.Point(3, 54);
			this.changePasswordLabel.Name = "changePasswordLabel";
			this.changePasswordLabel.Size = new System.Drawing.Size(93, 13);
			this.changePasswordLabel.TabIndex = 15;
			this.changePasswordLabel.Text = "Change Password";
			// 
			// changePasswordTextBox
			// 
			this.changePasswordTextBox.Location = new System.Drawing.Point(147, 50);
			this.changePasswordTextBox.Name = "changePasswordTextBox";
			this.changePasswordTextBox.PasswordChar = '*';
			this.changePasswordTextBox.Size = new System.Drawing.Size(96, 20);
			this.changePasswordTextBox.TabIndex = 10;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.passwordLabel);
			this.groupBox2.Controls.Add(this.changePasswordLabel);
			this.groupBox2.Controls.Add(this.passwordTextBox);
			this.groupBox2.Controls.Add(this.changePasswordTextBox);
			this.groupBox2.Controls.Add(this.passwordConfirmTextBox);
			this.groupBox2.Controls.Add(this.passwordConfirmLabel);
			this.groupBox2.Location = new System.Drawing.Point(18, 239);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(249, 106);
			this.groupBox2.TabIndex = 16;
			this.groupBox2.TabStop = false;
			// 
			// EditProfileDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 384);
			this.Controls.Add(this.speedTestComboBox);
			this.Controls.Add(this.editSpeedFactsButton);
			this.Controls.Add(this.usernameLabel);
			this.Controls.Add(this.usernameMaskedTextBox);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.speedTestDaysMaskedTextBox);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.saveChangesButton);
			this.Controls.Add(this.customFactsCheckBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "EditProfileDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Profile";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button saveChangesButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label additionMaxFactNumberLabel;
		private System.Windows.Forms.Label divisionMaxFactNumberLabel;
		private System.Windows.Forms.Label multiplicationMaxFactNumberLabel;
		private System.Windows.Forms.Label subtractionMaxFactNumberLabel;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Label usernameLabel;
		private System.Windows.Forms.Button editSpeedFactsButton;
		private System.Windows.Forms.ComboBox speedTestComboBox;
		private System.Windows.Forms.Label passwordConfirmLabel;
		private System.Windows.Forms.GroupBox groupBox2;
		public System.Windows.Forms.CheckBox customFactsCheckBox;
		public System.Windows.Forms.MaskedTextBox speedTestDaysMaskedTextBox;
		public System.Windows.Forms.MaskedTextBox additionMaxFactNumberMaskedTextBox;
		public System.Windows.Forms.MaskedTextBox divisionMaxFactNumberMaskedTextBox;
		public System.Windows.Forms.MaskedTextBox multiplicationMaxFactNumberMaskedTextBox;
		public System.Windows.Forms.MaskedTextBox subtractionMaxFactNumberMaskedTextBox;
		public System.Windows.Forms.MaskedTextBox usernameMaskedTextBox;
		public System.Windows.Forms.TextBox passwordTextBox;
		public System.Windows.Forms.TextBox passwordConfirmTextBox;
		public System.Windows.Forms.TextBox changePasswordTextBox;
		public System.Windows.Forms.Label changePasswordLabel;
		private System.Windows.Forms.Label passwordLabel;
	}
}