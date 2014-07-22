using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnowYourFacts.Dialogs
{
	public partial class InputDialog : Form
	{
		public InputDialog ()
		{
			InitializeComponent ();
			usernameMaskedTextBox.Focus ();
			usernameMaskedTextBox.Select (10, 0);
		}

		private void factNumberHelpButton_Click (object sender, EventArgs e)
		{
			MessageBox.Show ("This is the highest fact number that will be used in generating your facts. For example, if the highest addition fact you want is 5 + 5, you would enter 5.\nFacts such as 5 + 6 or 6 + 1 would not be generated.", "Fact Number Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void usernameHelpButton_Click (object sender, EventArgs e)
		{
			MessageBox.Show ("Your username can be any combination of letters and numbers.", "Username Help", 
								  MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void maskedTextBoxKeyUpEvent (object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				okButton.PerformClick ();
			}
		}
	}
}
