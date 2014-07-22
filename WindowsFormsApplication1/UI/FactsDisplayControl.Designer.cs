namespace KnowYourFacts.UI
{
	partial class FactsDisplayControl
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
			this.num2Label = new System.Windows.Forms.Label();
			this.factSignLabel = new System.Windows.Forms.Label();
			this.num1Label = new System.Windows.Forms.Label();
			this.inputMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.lineLabel = new System.Windows.Forms.Label();
			this.messageLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// num2Label
			// 
			this.num2Label.CausesValidation = false;
			this.num2Label.Font = new System.Drawing.Font("Cambria", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.num2Label.Location = new System.Drawing.Point(117, 84);
			this.num2Label.Name = "num2Label";
			this.num2Label.Size = new System.Drawing.Size(75, 43);
			this.num2Label.TabIndex = 11;
			this.num2Label.Text = "0";
			this.num2Label.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// factSignLabel
			// 
			this.factSignLabel.CausesValidation = false;
			this.factSignLabel.Font = new System.Drawing.Font("Cambria", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.factSignLabel.Location = new System.Drawing.Point(82, 84);
			this.factSignLabel.Name = "factSignLabel";
			this.factSignLabel.Padding = new System.Windows.Forms.Padding(1);
			this.factSignLabel.Size = new System.Drawing.Size(46, 45);
			this.factSignLabel.TabIndex = 12;
			this.factSignLabel.Text = "+";
			this.factSignLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// num1Label
			// 
			this.num1Label.Font = new System.Drawing.Font("Cambria", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.num1Label.Location = new System.Drawing.Point(41, 24);
			this.num1Label.Name = "num1Label";
			this.num1Label.Size = new System.Drawing.Size(151, 43);
			this.num1Label.TabIndex = 10;
			this.num1Label.Text = "0";
			this.num1Label.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// inputMaskedTextBox
			// 
			this.inputMaskedTextBox.Font = new System.Drawing.Font("Cambria", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.inputMaskedTextBox.HidePromptOnLeave = true;
			this.inputMaskedTextBox.Location = new System.Drawing.Point(112, 148);
			this.inputMaskedTextBox.Mask = "000";
			this.inputMaskedTextBox.Name = "inputMaskedTextBox";
			this.inputMaskedTextBox.PromptChar = ' ';
			this.inputMaskedTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.inputMaskedTextBox.Size = new System.Drawing.Size(72, 51);
			this.inputMaskedTextBox.TabIndex = 9;
			this.inputMaskedTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputMaskedTextBox_KeyPress);
			this.inputMaskedTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.maskedTextBoxKeyUpEvent);
			// 
			// lineLabel
			// 
			this.lineLabel.AutoSize = true;
			this.lineLabel.CausesValidation = false;
			this.lineLabel.Font = new System.Drawing.Font("Cambria", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lineLabel.Location = new System.Drawing.Point(85, 93);
			this.lineLabel.Name = "lineLabel";
			this.lineLabel.Size = new System.Drawing.Size(117, 43);
			this.lineLabel.TabIndex = 13;
			this.lineLabel.Text = "_______";
			this.lineLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// messageLabel
			// 
			this.messageLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.messageLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.messageLabel.CausesValidation = false;
			this.messageLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.messageLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.messageLabel.Location = new System.Drawing.Point(4, 215);
			this.messageLabel.MinimumSize = new System.Drawing.Size(250, 30);
			this.messageLabel.Name = "messageLabel";
			this.messageLabel.Size = new System.Drawing.Size(282, 56);
			this.messageLabel.TabIndex = 14;
			this.messageLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.messageLabel.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.messageLabel_PreviewKeyDown);
			// 
			// FactsDisplayControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.num2Label);
			this.Controls.Add(this.factSignLabel);
			this.Controls.Add(this.num1Label);
			this.Controls.Add(this.inputMaskedTextBox);
			this.Controls.Add(this.lineLabel);
			this.Controls.Add(this.messageLabel);
			this.Name = "FactsDisplayControl";
			this.Size = new System.Drawing.Size(291, 280);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.Label num2Label;
		public System.Windows.Forms.Label factSignLabel;
		public System.Windows.Forms.Label num1Label;
		public System.Windows.Forms.MaskedTextBox inputMaskedTextBox;
		public System.Windows.Forms.Label lineLabel;
		public System.Windows.Forms.Label messageLabel;
	}
}
