namespace KnowYourFacts
{
	partial class MathFactsForm
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
			this.components = new System.ComponentModel.Container();
			this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
			this.dailyFactsMenuItem = new System.Windows.Forms.MenuItem();
			this.additionFactsMenuItem = new System.Windows.Forms.MenuItem();
			this.subtractionMenuItem = new System.Windows.Forms.MenuItem();
			this.multiplicationMenuItem = new System.Windows.Forms.MenuItem();
			this.divisionFactsMenuItem = new System.Windows.Forms.MenuItem();
			this.speedTestMenuItem = new System.Windows.Forms.MenuItem();
			this.additionTestMenuItem = new System.Windows.Forms.MenuItem();
			this.subtractionTestMenuItem = new System.Windows.Forms.MenuItem();
			this.multiplicationTestMenuItem = new System.Windows.Forms.MenuItem();
			this.divisionTestMenuItem = new System.Windows.Forms.MenuItem();
			this.optionsMenuItem = new System.Windows.Forms.MenuItem();
			this.helpMenuItem = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.dailyFactsMenuItem,
            this.speedTestMenuItem,
            this.optionsMenuItem,
            this.helpMenuItem});
			// 
			// dailyFactsMenuItem
			// 
			this.dailyFactsMenuItem.Index = 0;
			this.dailyFactsMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.additionFactsMenuItem,
            this.subtractionMenuItem,
            this.multiplicationMenuItem,
            this.divisionFactsMenuItem});
			this.dailyFactsMenuItem.Text = "Daily Facts";
			// 
			// additionFactsMenuItem
			// 
			this.additionFactsMenuItem.Index = 0;
			this.additionFactsMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
			this.additionFactsMenuItem.Text = "Start Addition Facts";
			this.additionFactsMenuItem.Click += new System.EventHandler(this.dailyFactsClick);
			// 
			// subtractionMenuItem
			// 
			this.subtractionMenuItem.Index = 1;
			this.subtractionMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.subtractionMenuItem.Text = "Start Subtraction Facts";
			this.subtractionMenuItem.Click += new System.EventHandler(this.dailyFactsClick);
			// 
			// multiplicationMenuItem
			// 
			this.multiplicationMenuItem.Index = 2;
			this.multiplicationMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlM;
			this.multiplicationMenuItem.Text = "Start Multiplication Facts";
			this.multiplicationMenuItem.Click += new System.EventHandler(this.dailyFactsClick);
			// 
			// divisionFactsMenuItem
			// 
			this.divisionFactsMenuItem.Index = 3;
			this.divisionFactsMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
			this.divisionFactsMenuItem.Text = "Start Division Facts";
			this.divisionFactsMenuItem.Click += new System.EventHandler(this.dailyFactsClick);
			// 
			// speedTestMenuItem
			// 
			this.speedTestMenuItem.Index = 1;
			this.speedTestMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.additionTestMenuItem,
            this.subtractionTestMenuItem,
            this.multiplicationTestMenuItem,
            this.divisionTestMenuItem});
			this.speedTestMenuItem.Text = "Speed Test";
			// 
			// additionTestMenuItem
			// 
			this.additionTestMenuItem.Index = 0;
			this.additionTestMenuItem.Text = "Addition Speed Test";
			this.additionTestMenuItem.Click += new System.EventHandler(this.speedTestClick);
			// 
			// subtractionTestMenuItem
			// 
			this.subtractionTestMenuItem.Index = 1;
			this.subtractionTestMenuItem.Text = "Subtraction Speed Test";
			this.subtractionTestMenuItem.Click += new System.EventHandler(this.speedTestClick);
			// 
			// multiplicationTestMenuItem
			// 
			this.multiplicationTestMenuItem.Index = 2;
			this.multiplicationTestMenuItem.Text = "Multiplication Speed Test";
			this.multiplicationTestMenuItem.Click += new System.EventHandler(this.speedTestClick);
			// 
			// divisionTestMenuItem
			// 
			this.divisionTestMenuItem.Index = 3;
			this.divisionTestMenuItem.Text = "Division Speed Test";
			this.divisionTestMenuItem.Click += new System.EventHandler(this.speedTestClick);
			// 
			// optionsMenuItem
			// 
			this.optionsMenuItem.Index = 2;
			this.optionsMenuItem.Text = "Options";
			// 
			// helpMenuItem
			// 
			this.helpMenuItem.Index = 3;
			this.helpMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlH;
			this.helpMenuItem.Text = "Help";
			// 
			// MathFactsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.ClientSize = new System.Drawing.Size(290, 237);
			this.Menu = this.mainMenu;
			this.Name = "MathFactsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Know Your Facts";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.MenuItem dailyFactsMenuItem;
		private System.Windows.Forms.MenuItem additionFactsMenuItem;
		private System.Windows.Forms.MenuItem subtractionMenuItem;
		private System.Windows.Forms.MenuItem multiplicationMenuItem;
		private System.Windows.Forms.MenuItem divisionFactsMenuItem;
		private System.Windows.Forms.MenuItem speedTestMenuItem;
		private System.Windows.Forms.MenuItem additionTestMenuItem;
		private System.Windows.Forms.MenuItem subtractionTestMenuItem;
		private System.Windows.Forms.MenuItem multiplicationTestMenuItem;
		private System.Windows.Forms.MenuItem divisionTestMenuItem;
		private System.Windows.Forms.MenuItem optionsMenuItem;
		private System.Windows.Forms.MenuItem helpMenuItem;
	}
}

