using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KnowYourFacts;

namespace KnowYourFacts
{
	public partial class MainMenuControl : UserControl
	{
		static MainMenuControl instanceMainMenuControl;

		public static MainMenuControl Instance
		{
			get
			{
				if (instanceMainMenuControl == null)
				{
					instanceMainMenuControl = new MainMenuControl ();
				}
				return instanceMainMenuControl;
			}
		}

		private MainMenuControl ()
		{
			InitializeComponent ();
		}

		// Display the form to process input of facts.
		private void initiateFactsDisplay (object sender, EventArgs e)
		{
			// Triggers the toggleMenuBar event.
			MathFactsForm.toggleMainMenuControl (false);

			// Triggers the startDailyFacts event.
			MathFactsForm.toggleFactsDisplayControl (true);
		}

		private void createNewUserButtonClick (object sender, EventArgs e)
		{
			UserProfile users = new UserProfile ();
			if (users.checkForProfiles ())
			{
				// Load this as the default username. Load others later on.
				users.setUsername (users.getLastProfileLoaded ());
			}

			string name = users.getUsername ();
			MessageBox.Show (name);
		}

		private void exitButtonClick (object sender, EventArgs e)
		{
			Application.Exit ();
		}
	}
}
