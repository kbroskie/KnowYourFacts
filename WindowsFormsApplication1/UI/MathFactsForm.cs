using KnowYourFacts.Dialogs;
using KnowYourFacts.Math;
using KnowYourFacts.Users;
using KnowYourFacts.Utility;

using System;
using System.Windows.Forms;
using System.Security.Cryptography;

using System.Text;
using System.Globalization;

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KnowYourFacts.UI
{
	public partial class MathFactsForm : Form
	{
		private static MainMenuControl m_mainMenuControl;
		public static FactsDisplayControl m_factsDisplayControl;
		private FactsReviewControl factsReviewControl;
		private static MathFacts reference;

		public static bool speedTest;
		private static bool processingAllDailyFacts = false;
		private static bool saveProgress = true;

		private static bool menubarToggle = true;
		private static bool mainMenuControlToggle = true;
		private static bool factsDisplayControlToggle = false;
		public static bool inputDisplayToggle = true;
		public static FactsFiles files = FactsFiles.Instance;

		public static MathOperation operationType;

		public static int userResponse;
		public static String m_userInput;
		private Stack <int> incorrectResponses;

		public long timeElapsed;
		public static System.Diagnostics.Stopwatch timer;

		public const string COMPLETION_CONTINUE_PROMPT = "\nPress the spacebar to continue.";
		private const String CONTINUE_DAILY_FACTS_PROMPT = "\nPress the spacebar to continue your facts.";

		public static UserProfile userProfile;

		readonly static UserProfile GUEST_PROFILE = new UserProfile (new User ("Guest"));

		/*
		 * Constructor to create a form object with a menu control and display control.
		 */
		public MathFactsForm ()
		{
			InitializeComponent ();
			initializeAndAddMainMenuControl ();
			initializeAndAddFactsDisplayControl ();

			reference = new MathFacts ();

			if (!files.mainDirectoryExists())
			{
				files.createDefaultProgramDirectory ();
			}

			loadLastUser ();
			m_mainMenuControl.setUserButtonText ("Welcome " + userProfile.user.name + "!" + "\nNot " + userProfile.user.name + "?\nClick here to change users");
			factsReviewControl = new FactsReviewControl ();
		}

		private void initializeAndAddMainMenuControl ()
		{
			m_mainMenuControl = MainMenuControl.Instance;
			m_mainMenuControl.EnabledChanged += new System.EventHandler (this.toggleMainMenubar);

			this.Controls.Add (m_mainMenuControl);
		}

		private void initializeAndAddFactsDisplayControl ()
		{
			m_factsDisplayControl = FactsDisplayControl.Instance;
			m_factsDisplayControl.Enabled = false;
			m_factsDisplayControl.Visible = false;
			m_factsDisplayControl.InputDetected += c_InputDetected;

			this.Controls.Add (m_factsDisplayControl);
		}

		private void loadLastUser () 
		{
			userProfile.user.name = files.loadCurrentUsername ();

			// No user data exists. Load a sample guest profile.
			if (String.IsNullOrEmpty (userProfile.user.name))
			{
				userProfile = GUEST_PROFILE;
				editProfileMenuItem.Enabled = false;
			}
			else
			{
				files.updateCurrentUser (userProfile.user.name);
				userProfile = files.loadUserProfile ();
			}
		}

		/*
		 * Prompt for and obtain a new user profile.
		 */
		private void createNewUserProfile ()
		// TODO Test that the dialog does not close before all valid data is entered.
		{
			EditProfileDialog newProfileDialog = new EditProfileDialog ();
			newProfileDialog.prepareFieldsForNewProfileEntry ();
			newProfileDialog.ShowDialog ();
		}

		public void changeUser ()
		{
			ChangeUserDialog changeUserDialog = new ChangeUserDialog ();
			changeUserDialog.setUserChoices (FactsFiles.loadUsers ());

			if (changeUserDialog.ShowDialog () == DialogResult.OK)
			{
				String selectedUser = changeUserDialog.getSelectedUser ();
				if (selectedUser == "<New User>")
				{
					createNewUserProfile ();
				}
				else 
				{
					files.updateCurrentUser (selectedUser);
					userProfile = files.loadUserProfile (); 
				}

				m_mainMenuControl.setUserButtonText ("Welcome " + userProfile.user.name + "!" + "\nNot " + userProfile.user.name + "?\nClick Here to Change Users.");
			}

			if (!userProfile.Equals(GUEST_PROFILE))
			{
				editProfileMenuItem.Enabled = true;
			}

			if (changeUserDialog != null)
			{
				changeUserDialog.Dispose ();
			}
		}

		/*
		 * Updates the last value entered by the user, or toggles the display 
		 * if the spacebar was pressed to clear a status bar message.
		 */
		public void logUserInput (String userInput)
		{
			if ((userInput == "space" || userInput == "n") && reference.queueOfFacts.Count == 0)
			{
				if (processingAllDailyFacts)
				{
					toggleInputDisplay ();
					continueProcessingDailyFacts ();
				}
				else
				{
					toggleFactsDisplayControl ();
					toggleInputDisplay ();
					toggleMainMenuControl ();
				}
			}
			else if (userInput == "y" && reference.unknownFacts.Count > 0)
			{
				toggleFactsDisplayControl ();
				this.Controls.Add (factsReviewControl);
				factsReviewControl.incorrectQuestions.AddRange (reference.unknownFacts);
				factsReviewControl.incorrectResponses.AddRange (incorrectResponses);
				factsReviewControl.displayFirstFact ();
				factsReviewControl.Focus ();
			}
			else if (userInput == "return to main menu")
			{
				toggleInputDisplay ();
				toggleMainMenuControl ();
				this.Controls.Remove (factsReviewControl);

				//factsReviewControl.incorrectQuestions.Clear ();
				//factsReviewControl.incorrectQuestions.Clear ();
			}
			else
			{
				m_userInput = userInput;
			}
		}

		/*
		 * Used to cycle through all the facts when the user selects the option to start all daily facts.
		 */ 
		private void continueProcessingDailyFacts ()
		{
			MathOperationTypeEnum lastOperation = operationType.operationType;

			if (processingAllDailyFacts && lastOperation != MathOperationTypeEnum.DIVISION)
			{
				operationType.operationType = (MathOperationTypeEnum) ((int) lastOperation + 1);
				startTheFacts (operationType.operationType, speedTest = false, processingAllDailyFacts);
			}
		}

		/*
		 * Event triggered when the functionality of the main menu control is changed.
		 * Toggles the functionality and visiblity of the main menu bar.
		 */
		private void toggleMainMenubar (object sender, EventArgs e)
		{
			menubarToggle = !menubarToggle;

			dailyFactsMenuItem.Visible = menubarToggle;
			dailyFactsMenuItem.Enabled = menubarToggle;

			speedTestMenuItem.Visible = menubarToggle;
			speedTestMenuItem.Enabled = menubarToggle;

			helpMenuItem.Visible = menubarToggle;
			helpMenuItem.Enabled = menubarToggle;

			optionsMenuItem.Visible = menubarToggle;
			optionsMenuItem.Enabled = menubarToggle;
		}

		/*
		 * Toggle the functionality and visibility of the main menu control.
		 */
		internal static void toggleMainMenuControl ()
		{
			mainMenuControlToggle = !mainMenuControlToggle;

			m_mainMenuControl.Visible = mainMenuControlToggle;
			m_mainMenuControl.Enabled = mainMenuControlToggle;
		}

		/*
		 * Toggle the functionality and visibility of the facts display control.
		 */
		internal static void toggleFactsDisplayControl ()
		{
			factsDisplayControlToggle = !factsDisplayControlToggle;

			m_factsDisplayControl.Visible = factsDisplayControlToggle;
			m_factsDisplayControl.Enabled = factsDisplayControlToggle;

			m_factsDisplayControl.messageLabel.Text = "";
			m_factsDisplayControl.factsProgressBar.Value = 0;
		}

		/*
		 * Toggle the functionality and visibility of the facts input display
		 * control, but leave the message area visible.
       */
		public static void toggleInputDisplay ()
		{
			inputDisplayToggle = !inputDisplayToggle;

			m_factsDisplayControl.num1Label.Visible = inputDisplayToggle;
			m_factsDisplayControl.num2Label.Visible = inputDisplayToggle;
			m_factsDisplayControl.inputMaskedTextBox.Visible = inputDisplayToggle;
			m_factsDisplayControl.lineLabel.Visible = inputDisplayToggle;
			m_factsDisplayControl.factSignLabel.Visible = inputDisplayToggle;

			m_factsDisplayControl.num1Label.Enabled= inputDisplayToggle;
			m_factsDisplayControl.num2Label.Enabled = inputDisplayToggle;
			m_factsDisplayControl.inputMaskedTextBox.Enabled = inputDisplayToggle;
			m_factsDisplayControl.lineLabel.Enabled = inputDisplayToggle;
			m_factsDisplayControl.factSignLabel.Enabled = inputDisplayToggle;

			m_factsDisplayControl.num1Label.Text = "";
			m_factsDisplayControl.num2Label.Text = "";
			m_factsDisplayControl.inputMaskedTextBox.Text = "";
			m_factsDisplayControl.factSignLabel.Text = "";

			if (!inputDisplayToggle)
			{
				m_factsDisplayControl.messageLabel.Focus ();
			}
		}

		/*
		 * Handle events for starting daily facts.
		 */
		private void dailyFactsClick (object sender, EventArgs e)
		{
			MathOperationTypeEnum sign;
			if (ReferenceEquals (sender, (additionFactsMenuItem)))
			{
				sign = MathOperationTypeEnum.ADDITION;
			}
			else if (ReferenceEquals (sender, subtractionMenuItem))
			{
				sign = MathOperationTypeEnum.SUBTRACTION;
			}
			else if (ReferenceEquals (sender, multiplicationMenuItem))
			{
				sign = MathOperationTypeEnum.MULTIPLICATION;
			}
			else
			{
				sign = MathOperationTypeEnum.DIVISION;
			}

			startTheFacts (sign, false, false);
		}

		/*
		 * Handles events to start speed tests.
		 */
		private void speedTestClick (object sender, EventArgs e)
		{
			MathOperationTypeEnum sign;
			if (sender.Equals (additionTestMenuItem))
			{
				sign = MathOperationTypeEnum.ADDITION;
			}
			else if (sender.Equals (subtractionTestMenuItem))
			{
				sign = MathOperationTypeEnum.SUBTRACTION;
			}
			else if (sender.Equals (multiplicationTestMenuItem))
			{
				sign = MathOperationTypeEnum.MULTIPLICATION;
			}
			else
			{
				sign = MathOperationTypeEnum.DIVISION;
			}

			startTheFacts (sign, true, false);
		}

		/*
		 * 
		 */ 
		private void helpMenuItemClick (object sender, EventArgs e)
		{

		}

		/*
		 * 
		 */
		private void optionsMenuItemClick (object sender, EventArgs e)
		{
			if (sender.Equals (editProfileMenuItem))
			{
				EditProfileDialog editProfileDialog = new EditProfileDialog ();
				editProfileDialog.ShowDialog ();
			}
			else
			{
				ReviewResponseDataDialog reviewResponseDataDialog = new ReviewResponseDataDialog ();
				reviewResponseDataDialog.loadResponseData (userProfile.user.name);
				reviewResponseDataDialog.ShowDialog ();
			}
		}

		/*
		 * Starts the chosen daily facts or speed test
		 */
		public void startTheFacts (MathOperationTypeEnum sign, Boolean isSpeedTest, Boolean processAllDailyFacts)
		{
			operationType = new MathOperation (sign);

			if (userProfile.Equals (GUEST_PROFILE))
			{
				var confirmResult = MessageBox.Show ("Would you like to create a profile before continuing?\nA profile is required for your progress to be saved.", "Confirm Cancel", MessageBoxButtons.YesNo);
				if (confirmResult == DialogResult.Yes)
				{
					createNewUserProfile ();
				}
			}

			// Determine if the user has already used the daily facts today.
			String dateData = files.readDailyFactsDateDataFromFile(operationType.operationType);
			if (dateData == "MAX_TIME_ELAPSED")
			{
				MessageBox.Show ("A month or more has passed since your last speed test.\nPlease retake the " + operationType.ToString () + 
									 "Facts speed test.", "New Speed Test Needed");
				
				return;
			}
			else if (dateData == DateTime.Today.ToString ("d"))
			{
				saveProgress = false;
				var continueWithoutSavingResponse = MessageBox.Show ("Oops! It looks like you have already practiced your " + operationType.ToString () + 
					" facts today.\nYou can practice them again, but your progress will not be saved.\n\n Continue anyway?",
					"Progress Will Not Be Saved", MessageBoxButtons.YesNo);

				if (continueWithoutSavingResponse == DialogResult.No)
				{
					return;
				}
			}
			else
			{
				saveProgress = true;
			}
			
			speedTest = isSpeedTest;
			processingAllDailyFacts = processAllDailyFacts;

			if (!processingAllDailyFacts)
			{
				toggleMainMenuControl ();
				toggleFactsDisplayControl ();
			}

			// Change the bool value so the last set of messages for all daily facts are not suppressed.
			else if (operationType.operationType == MathOperationTypeEnum.DIVISION)
			{
				processingAllDailyFacts = !processingAllDailyFacts;
			}

			// Initialize and reset data structures for holding facts data
			incorrectResponses = new Stack <int> ();
			reference.unknownFacts.Clear ();
			reference.knownFacts.Clear ();
			reference.correctResponseCount = 0;
			reference.factResponseTime.Clear ();
			reference.factsOrder.Clear ();
			incorrectResponses.Clear ();
			factsReviewControl.incorrectQuestions.Clear ();
			 
			reference.startProcessingFacts (speedTest, operationType, m_factsDisplayControl, processingAllDailyFacts, userProfile);
		}

		/*
		 * Process a fact answer
		 */ 
		public void processInput ()
		{
			timer.Stop();
			m_factsDisplayControl.factsProgressBar.Increment (1);

			long secondsElapsed;
		
			// Obtain the input answer.
			String inputString = (m_factsDisplayControl.inputMaskedTextBox.Text);
			int answer = System.Convert.ToInt32 (inputString);
			Fact input = reference.getQuestionAndResponse (operationType);
			int calculatedAnswer = MathOperation.calculateAnswer (input.leftNum, input.rightNum, operationType);

			// Only store the response time for correct answers.
			if (answer == calculatedAnswer)
			{
				secondsElapsed = (long) (timer.ElapsedMilliseconds / 1000.0);
				reference.factResponseTime.Add(secondsElapsed);
			}

			// Only keep answers for daily facts.
			if (!speedTest)
			{
				if (answer == calculatedAnswer)
				{
					reference.knownFacts.Push (new Fact (input.leftNum, input.rightNum, operationType));
				}
				else
				{
					reference.unknownFacts.Push (new Fact (input.leftNum, input.rightNum, operationType));
					incorrectResponses.Push (answer);
				}
			}

			Fact nextFact = new Fact();

			// Get the next fact and update the labels.
			if (reference.getNextFact (ref nextFact))
			{
				m_factsDisplayControl.inputMaskedTextBox.Text = "";
				m_factsDisplayControl.num1Label.Text = System.Convert.ToString (nextFact.leftNum);
				m_factsDisplayControl.num2Label.Text = System.Convert.ToString (nextFact.rightNum);

				timer.Restart ();
			}
			else
			{
				toggleInputDisplay ();
				displayCompletionMessage ();
			}
		}

		/*
		 * Displays a completion message for finishing a set of facts, based on the number of 
		 * facts correct.
		 */ 
		void displayCompletionMessage ()
		{
			if (!speedTest)
			{
				if (saveProgress)
				{
					reference.writeResultsToFile (reference.correctResponseCount, reference.unknownFacts,
						reference.knownFacts, operationType, reference.factResponseTime);
					Console.WriteLine (reference.unknownFacts.ToArray ());
					files.saveResponseData (incorrectResponses.ToArray (), reference.unknownFacts.ToArray (),userProfile.user.name, operationType.operationType);
				}
				//TODO remove after testing
				Console.WriteLine (reference.unknownFacts.ToArray ());
				files.saveResponseData (incorrectResponses.ToArray (), reference.unknownFacts.ToArray (), userProfile.user.name, operationType.operationType);
				if (reference.correctResponseCount == 0)
				{
					if (processingAllDailyFacts && operationType.operationType != MathOperationTypeEnum.DIVISION)
					{
						m_factsDisplayControl.messageLabel.Text = "All facts complete, very nice try!"
								+ "\nYou didn't get any facts correct this time.\n" + CONTINUE_DAILY_FACTS_PROMPT;
					}
					else
					{
						m_factsDisplayControl.messageLabel.Text = "All facts complete, very nice try!"
								+ "\nYou didn't get any facts correct this time.\n" + COMPLETION_CONTINUE_PROMPT;
					}
				}
				
				else if (reference.correctResponseCount < (int) (reference.numberOfFactsProcessed / 2))
				{
					if (processingAllDailyFacts && operationType.operationType != MathOperationTypeEnum.DIVISION)
					{
						m_factsDisplayControl.messageLabel.Text = "All facts complete!\nYou got " + reference.correctResponseCount
								+ " out of " + reference.numberOfFactsProcessed
								+ " facts correct!" + CONTINUE_DAILY_FACTS_PROMPT;
					}
					else
					{
						m_factsDisplayControl.messageLabel.Text = "All facts complete!\nYou got " + reference.correctResponseCount
								+ " out of " + reference.numberOfFactsProcessed
								+ " facts correct!" + COMPLETION_CONTINUE_PROMPT;
					}
				}
				
				else
				{
					if (processingAllDailyFacts && operationType.operationType != MathOperationTypeEnum.DIVISION)
					{
						m_factsDisplayControl.messageLabel.Text = "All facts complete, great job!\n"
							+ "You got " + reference.correctResponseCount + " out of "
							+ reference.numberOfFactsProcessed + " facts correct!\n"
							+ CONTINUE_DAILY_FACTS_PROMPT;
					}
					else
					{
						m_factsDisplayControl.messageLabel.Text = "All facts complete, great job!\n"
							+ "You got " + reference.correctResponseCount + " out of "
							+ reference.numberOfFactsProcessed + " facts correct!\n"
							+ COMPLETION_CONTINUE_PROMPT;
					}
				}
			}
			else
			{
				reference.writeFactResponseTimeToFile (operationType);
				m_factsDisplayControl.messageLabel.Text = "Speed test complete!"
						+ "\nNow try out the daily " + operationType.ToString ()
						+ " facts!\n" + COMPLETION_CONTINUE_PROMPT;
			}
		}

		static void c_InputDetected (object sender, InputDetectedEventArgs e)
		{
			((MathFactsForm) m_factsDisplayControl.FindForm ()).processInput ();
		}
	}
}