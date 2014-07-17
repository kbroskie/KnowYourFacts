namespace KnowYourFacts
{
	partial class MainMenuControl
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
			this.exitButton = new System.Windows.Forms.Button();
			this.startAllDailyFactsButton = new System.Windows.Forms.Button();
			this.userButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// exitButton
			// 
			this.exitButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.exitButton.Location = new System.Drawing.Point(50, 170);
			this.exitButton.Name = "exitButton";
			this.exitButton.Size = new System.Drawing.Size(188, 52);
			this.exitButton.TabIndex = 16;
			this.exitButton.Text = "Exit";
			this.exitButton.UseVisualStyleBackColor = true;
			this.exitButton.Click += new System.EventHandler(this.exitButtonClick);
			// 
			// startAllDailyFactsButton
			// 
			this.startAllDailyFactsButton.Location = new System.Drawing.Point(50, 101);
			this.startAllDailyFactsButton.Name = "startAllDailyFactsButton";
			this.startAllDailyFactsButton.Size = new System.Drawing.Size(188, 52);
			this.startAllDailyFactsButton.TabIndex = 15;
			this.startAllDailyFactsButton.Text = "Start All Daily Facts";
			this.startAllDailyFactsButton.UseVisualStyleBackColor = true;
			this.startAllDailyFactsButton.Click += new System.EventHandler(this.initiateFactsDisplay);
			// 
			// userButton
			// 
			this.userButton.Location = new System.Drawing.Point(50, 32);
			this.userButton.Name = "userButton";
			this.userButton.Size = new System.Drawing.Size(188, 52);
			this.userButton.TabIndex = 14;
			this.userButton.Text = "Create New User";
			this.userButton.UseVisualStyleBackColor = true;
			this.userButton.Click += new System.EventHandler(this.createNewUserButtonClick);
			// 
			// MainMenuControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.Controls.Add(this.userButton);
			this.Controls.Add(this.startAllDailyFactsButton);
			this.Controls.Add(this.exitButton);
			this.Name = "MainMenuControl";
			this.Size = new System.Drawing.Size(280, 245);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button exitButton;
		private System.Windows.Forms.Button startAllDailyFactsButton;
		private System.Windows.Forms.Button userButton;
	}
}
