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
	public partial class EditProfileDialog : Form
	{
		public EditProfileDialog ()
		{
			InitializeComponent ();
			// TODO Load current profile
		}

		private void maskedTextBoxKeyUpEvent (object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				saveChangesButton.PerformClick ();
			}
		}

		private void inputMaskedTextBox_KeyPress (object sender, KeyPressEventArgs e)
		{
			// Suppress the sound generated when the user presses enter.
			if (e.KeyChar == (char) Keys.Enter)
			{
				e.Handled = true;
			}
		}

		private void customFactsCheckBox_CheckedChanged (object sender, EventArgs e)
		{
			// TODO toggle speedfacts usage. If toggled off, prompt for editing. Then update user profile bool.
		}
	}
}
