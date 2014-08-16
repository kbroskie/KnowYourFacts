namespace KnowYourFacts.UI
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
			this.welcomeLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// exitButton
			// 
			this.exitButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.exitButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.exitButton.Location = new System.Drawing.Point(78, 182);
			this.exitButton.Name = "exitButton";
			this.exitButton.Size = new System.Drawing.Size(124, 36);
			this.exitButton.TabIndex = 16;
			this.exitButton.Text = "Exit";
			this.exitButton.UseVisualStyleBackColor = true;
			this.exitButton.Click += new System.EventHandler(this.exitButtonClick);
			// 
			// startAllDailyFactsButton
			// 
			this.startAllDailyFactsButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.startAllDailyFactsButton.Location = new System.Drawing.Point(78, 119);
			this.startAllDailyFactsButton.Name = "startAllDailyFactsButton";
			this.startAllDailyFactsButton.Size = new System.Drawing.Size(124, 36);
			this.startAllDailyFactsButton.TabIndex = 15;
			this.startAllDailyFactsButton.Text = "Start All Daily Facts";
			this.startAllDailyFactsButton.UseVisualStyleBackColor = true;
			this.startAllDailyFactsButton.Click += new System.EventHandler(this.initiateFactsDisplay);
			// 
			// userButton
			// 
			this.userButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.userButton.Location = new System.Drawing.Point(78, 56);
			this.userButton.Name = "userButton";
			this.userButton.Size = new System.Drawing.Size(124, 36);
			this.userButton.TabIndex = 14;
			this.userButton.Text = "Change User";
			this.userButton.UseVisualStyleBackColor = true;
			this.userButton.Click += new System.EventHandler(this.createNewUserButtonClick);
			// 
			// welcomeLabel
			// 
			this.welcomeLabel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.welcomeLabel.Location = new System.Drawing.Point(10, 22);
			this.welcomeLabel.Name = "welcomeLabel";
			this.welcomeLabel.Size = new System.Drawing.Size(261, 23);
			this.welcomeLabel.TabIndex = 17;
			this.welcomeLabel.Text = "Welcome to KnowYourFacts!";
			this.welcomeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// MainMenuControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.Controls.Add(this.welcomeLabel);
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
		private System.Windows.Forms.Label welcomeLabel;
	}
}
