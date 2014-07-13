using System;
using System.Windows.Forms;

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
			MathFactsForm.toggleMainMenuControl ();

			MathFactsForm.toggleFactsDisplayControl ();
			MathFactsForm.startTheFacts (MathOperationTypeEnum.ADDITION, false, true);
		}

		private void createNewUserButtonClick (object sender, EventArgs e)
		{
			UserProfile userProfile = new UserProfile ();
			if (userProfile.checkForProfiles ())
			{
				// Load this as the default username. Load others later on.
				userProfile.user.name = userProfile.getLastProfileLoaded ();
			}

			string name = userProfile.user.name;
			MessageBox.Show (name);
		}

		private void exitButtonClick (object sender, EventArgs e)
		{
			Application.Exit ();
		}
	}
}
