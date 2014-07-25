namespace KnowYourFacts.Dialogs
{
	partial class SpeedFactEditDialog
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.cancelButton = new System.Windows.Forms.Button();
			this.saveChangesButton = new System.Windows.Forms.Button();
			this.speedFactsDataGridView = new System.Windows.Forms.DataGridView();
			this.topNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bottomNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.speedFactsDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(157, 225);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(111, 24);
			this.cancelButton.TabIndex = 9;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// saveChangesButton
			// 
			this.saveChangesButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.saveChangesButton.Location = new System.Drawing.Point(16, 225);
			this.saveChangesButton.Name = "saveChangesButton";
			this.saveChangesButton.Size = new System.Drawing.Size(111, 24);
			this.saveChangesButton.TabIndex = 8;
			this.saveChangesButton.Text = "Save Changes";
			this.saveChangesButton.UseVisualStyleBackColor = true;
			// 
			// speedFactsDataGridView
			// 
			this.speedFactsDataGridView.AllowUserToResizeColumns = false;
			this.speedFactsDataGridView.AllowUserToResizeRows = false;
			this.speedFactsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.speedFactsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.topNumber,
            this.bottomNumber});
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle1.Format = "N0";
			dataGridViewCellStyle1.NullValue = null;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.speedFactsDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
			this.speedFactsDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
			this.speedFactsDataGridView.Location = new System.Drawing.Point(36, 27);
			this.speedFactsDataGridView.Name = "speedFactsDataGridView";
			this.speedFactsDataGridView.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.speedFactsDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.speedFactsDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.speedFactsDataGridView.Size = new System.Drawing.Size(213, 174);
			this.speedFactsDataGridView.TabIndex = 0;
			// 
			// topNumber
			// 
			this.topNumber.HeaderText = "Top Number";
			this.topNumber.MaxInputLength = 3;
			this.topNumber.Name = "topNumber";
			this.topNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.topNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.topNumber.Width = 85;
			// 
			// bottomNumber
			// 
			this.bottomNumber.HeaderText = "Bottom Number";
			this.bottomNumber.MaxInputLength = 3;
			this.bottomNumber.Name = "bottomNumber";
			this.bottomNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.bottomNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.bottomNumber.Width = 85;
			// 
			// SpeedFactEditDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.speedFactsDataGridView);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.saveChangesButton);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SpeedFactEditDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Speed Fact Editor";
			((System.ComponentModel.ISupportInitialize)(this.speedFactsDataGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button saveChangesButton;
		private System.Windows.Forms.DataGridViewTextBoxColumn topNumber;
		private System.Windows.Forms.DataGridViewTextBoxColumn bottomNumber;
		public System.Windows.Forms.DataGridView speedFactsDataGridView;
	}
}