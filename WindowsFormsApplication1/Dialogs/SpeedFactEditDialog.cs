using System.Windows.Forms;

namespace KnowYourFacts.Dialogs
{
	public partial class SpeedFactEditDialog : Form
	{
		public SpeedFactEditDialog ()
		{
			InitializeComponent ();
		}

		private void speedFactsDataGridView_KeyPress (object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl (e.KeyChar)
					 && !char.IsDigit (e.KeyChar))
			{
				// Ignore non-numeric keypresses
				e.Handled = true;
			}
		}
	}
}
