using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnowYourFacts
{
	public partial class InputDialog : Form
	{
		public InputDialog ()
		{
			InitializeComponent ();
		}

		private void factNumberHelpButton_Click (object sender, EventArgs e)
		{
			MessageBox.Show ("This is the highest fact number that will be used in generating your facts. For example, if the highest addition fact you want is 5 + 5, you would enter 5.\nFacts such as 5 + 6 or 6 + 1 would not be generated.", "Fact Number Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}	
	}
}
