namespace KnowYourFacts.Dialogs
{
	partial class ReviewResponseDataDialog
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
			this.responseDataTabControl = new System.Windows.Forms.TabControl();
			this.additionTabPage = new System.Windows.Forms.TabPage();
			this.subtractionTabPage = new System.Windows.Forms.TabPage();
			this.multiplicationTabPage = new System.Windows.Forms.TabPage();
			this.divisionTabPage = new System.Windows.Forms.TabPage();
			this.subtractionListView = new System.Windows.Forms.ListView();
			this.additionListView = new System.Windows.Forms.ListView();
			this.multiplicationListView = new System.Windows.Forms.ListView();
			this.divisionListView = new System.Windows.Forms.ListView();
			this.responseDataTabControl.SuspendLayout();
			this.additionTabPage.SuspendLayout();
			this.subtractionTabPage.SuspendLayout();
			this.multiplicationTabPage.SuspendLayout();
			this.divisionTabPage.SuspendLayout();
			this.SuspendLayout();
			// 
			// responseDataTabControl
			// 
			this.responseDataTabControl.Controls.Add(this.additionTabPage);
			this.responseDataTabControl.Controls.Add(this.subtractionTabPage);
			this.responseDataTabControl.Controls.Add(this.multiplicationTabPage);
			this.responseDataTabControl.Controls.Add(this.divisionTabPage);
			this.responseDataTabControl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.responseDataTabControl.Location = new System.Drawing.Point(0, 0);
			this.responseDataTabControl.Name = "responseDataTabControl";
			this.responseDataTabControl.SelectedIndex = 0;
			this.responseDataTabControl.Size = new System.Drawing.Size(286, 259);
			this.responseDataTabControl.TabIndex = 0;
			// 
			// additionTabPage
			// 
			this.additionTabPage.Controls.Add(this.additionListView);
			this.additionTabPage.Location = new System.Drawing.Point(4, 24);
			this.additionTabPage.Name = "additionTabPage";
			this.additionTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.additionTabPage.Size = new System.Drawing.Size(278, 231);
			this.additionTabPage.TabIndex = 0;
			this.additionTabPage.Text = "Addition";
			this.additionTabPage.UseVisualStyleBackColor = true;
			// 
			// subtractionTabPage
			// 
			this.subtractionTabPage.Controls.Add(this.subtractionListView);
			this.subtractionTabPage.Location = new System.Drawing.Point(4, 24);
			this.subtractionTabPage.Name = "subtractionTabPage";
			this.subtractionTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.subtractionTabPage.Size = new System.Drawing.Size(278, 231);
			this.subtractionTabPage.TabIndex = 1;
			this.subtractionTabPage.Text = "Subtraction";
			this.subtractionTabPage.UseVisualStyleBackColor = true;
			// 
			// multiplicationTabPage
			// 
			this.multiplicationTabPage.Controls.Add(this.multiplicationListView);
			this.multiplicationTabPage.Location = new System.Drawing.Point(4, 24);
			this.multiplicationTabPage.Name = "multiplicationTabPage";
			this.multiplicationTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.multiplicationTabPage.Size = new System.Drawing.Size(278, 231);
			this.multiplicationTabPage.TabIndex = 2;
			this.multiplicationTabPage.Text = "Multiplication";
			this.multiplicationTabPage.UseVisualStyleBackColor = true;
			// 
			// divisionTabPage
			// 
			this.divisionTabPage.Controls.Add(this.divisionListView);
			this.divisionTabPage.Location = new System.Drawing.Point(4, 27);
			this.divisionTabPage.Name = "divisionTabPage";
			this.divisionTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.divisionTabPage.Size = new System.Drawing.Size(278, 228);
			this.divisionTabPage.TabIndex = 3;
			this.divisionTabPage.Text = "Division";
			this.divisionTabPage.UseVisualStyleBackColor = true;
			// 
			// subtractionListView
			// 
			this.subtractionListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.subtractionListView.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.subtractionListView.GridLines = true;
			this.subtractionListView.Location = new System.Drawing.Point(3, 3);
			this.subtractionListView.Name = "subtractionListView";
			this.subtractionListView.Size = new System.Drawing.Size(272, 225);
			this.subtractionListView.TabIndex = 0;
			this.subtractionListView.UseCompatibleStateImageBehavior = false;
			// 
			// additionListView
			// 
			this.additionListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.additionListView.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.additionListView.Location = new System.Drawing.Point(3, 3);
			this.additionListView.Name = "additionListView";
			this.additionListView.Size = new System.Drawing.Size(272, 225);
			this.additionListView.TabIndex = 0;
			this.additionListView.UseCompatibleStateImageBehavior = false;
			this.additionListView.SelectedIndexChanged += new System.EventHandler(this.additionListView_SelectedIndexChanged);
			// 
			// multiplicationListView
			// 
			this.multiplicationListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.multiplicationListView.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.multiplicationListView.Location = new System.Drawing.Point(3, 3);
			this.multiplicationListView.Name = "multiplicationListView";
			this.multiplicationListView.Size = new System.Drawing.Size(272, 225);
			this.multiplicationListView.TabIndex = 0;
			this.multiplicationListView.UseCompatibleStateImageBehavior = false;
			// 
			// divisionListView
			// 
			this.divisionListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.divisionListView.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.divisionListView.Location = new System.Drawing.Point(3, 3);
			this.divisionListView.Name = "divisionListView";
			this.divisionListView.Size = new System.Drawing.Size(272, 222);
			this.divisionListView.TabIndex = 0;
			this.divisionListView.UseCompatibleStateImageBehavior = false;
			// 
			// ReviewResponseDataDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(285, 261);
			this.Controls.Add(this.responseDataTabControl);
			this.Name = "ReviewResponseDataDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Review Response Data";
			this.responseDataTabControl.ResumeLayout(false);
			this.additionTabPage.ResumeLayout(false);
			this.subtractionTabPage.ResumeLayout(false);
			this.multiplicationTabPage.ResumeLayout(false);
			this.divisionTabPage.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl responseDataTabControl;
		private System.Windows.Forms.TabPage additionTabPage;
		private System.Windows.Forms.TabPage subtractionTabPage;
		private System.Windows.Forms.TabPage multiplicationTabPage;
		private System.Windows.Forms.TabPage divisionTabPage;
		private System.Windows.Forms.ListView additionListView;
		private System.Windows.Forms.ListView multiplicationListView;
		private System.Windows.Forms.ListView divisionListView;
		private System.Windows.Forms.ListView subtractionListView;
	}
}