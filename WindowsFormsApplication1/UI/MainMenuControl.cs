using System;
using System.Windows.Forms;

using KnowYourFacts.Math;

namespace KnowYourFacts.UI
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
			MathFactsForm.changeUser ();
		}

		private void exitButtonClick (object sender, EventArgs e)
		{
			Application.Exit ();
		}

		public void setUserButtonText (String username)
		{
			userButton.Text = username;
		}
	}
}
