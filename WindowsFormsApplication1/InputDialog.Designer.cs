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
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(50, 57);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(160, 57);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// inputMaskedTextbox
			// 
			this.inputMaskedTextbox.Location = new System.Drawing.Point(52, 22);
			this.inputMaskedTextbox.Mask = "aaaaaaaaaaaaaaaaaaaaaaaaa";
			this.inputMaskedTextbox.Name = "inputMaskedTextbox";
			this.inputMaskedTextbox.Size = new System.Drawing.Size(185, 20);
			this.inputMaskedTextbox.TabIndex = 2;
			this.inputMaskedTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(31, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(222, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Enter any combination of letters and numbers.";
			// 
			// InputDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 92);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.inputMaskedTextbox);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "InputDialog";
			this.Text = "New Username";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.MaskedTextBox inputMaskedTextbox;
	}
}