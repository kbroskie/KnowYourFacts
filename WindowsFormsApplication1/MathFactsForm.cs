using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace KnowYourFacts
{
	public partial class MathFactsForm : Form, IView
	{
		static MainMenuControl m_mainMenuControl;
		public static FactsDisplayControl m_factsDisplayControl;
		static MathFacts reference;

		public static bool speedTest;
		static bool processingAllDailyFacts = false;
		static bool saveProgress = true;

		static bool menubarToggle = true;
		static bool mainMenuControlToggle = true;
		static bool factsDisplayControlToggle = false;
		public static bool inputDisplayToggle = true;
		public static KnowYourFactsFiles files = KnowYourFactsFiles.Instance;

		public static MathOperation operationType;

		static public int userResponse;
		public static String m_userInput;

		public long timeElapsed;
		public static System.Diagnostics.Stopwatch timer;

		private String continueDailyFactsPrompt = "\nPress the spacebar to continue your facts.";

		private static User user;

		/*
		 * Constructor to create a form object with a menu control and display control.
		 */
		public MathFactsForm ()
		{
			InitializeComponent ();
			initializeAndAddMainMenuControl ();
			initializeAndAddFactsDisplayControl ();

			reference = new MathFacts ();
			//	factSource.DataSource = FactsModel.Instance.Facts;

			if (!files.mainDirectoryExists())
			{
				files.createDefaultProgramDirectory ();
			}

			// Need to change where this is called. If no user data is present, the input dialog appears
			// before the form shows.
			loadLastUserOrPromptForNewUser ();
			m_mainMenuControl.setUserButtonText ("Welcome " + user.name + "!" + "\nNot " + user.name + "?\nClick here to change users");
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

		private void loadLastUserOrPromptForNewUser () 
		{
			user.name = files.loadCurrentUsername ();
			
			// No user data exists
			if (user.name == null)
			{
				user.name = promptForNewUsername ();

				// Need to ensure name conforms to windows naming conventions. 
				while (files.userDirectoryExists (user))
				{
					MessageBox.Show ("Sorry, that username is already taken.\nPlease try again with a different username.");
					user.name = promptForNewUsername ();
				}

				files.createNewUserDirectory (user);
			}
			else
			{
				files.updateCurrentUser (user.name);
			}
		}

		/*
		 * Prompt for and obtain a new username, or use "Guest" for default.
		 */
		private String promptForNewUsername ()
		{
			String username = "";

			InputDialog inputDialog = new InputDialog ();
			if (inputDialog.ShowDialog () == DialogResult.OK)
			{
				username = inputDialog.inputMaskedTextbox.Text;

				if (username == "")
				{
					var confirmResult = MessageBox.Show ("You didn't enter a username to create. Continue without creating a username?\nYour progress will not be saved.",
							"Confirm Cancel", MessageBoxButtons.YesNo);
					if (confirmResult == DialogResult.Yes)
					{
						username = "Guest";
					}
				}
			}
			else
			{
				var confirmResult = MessageBox.Show ("Are you sure you don't want to create a username?\nYour progress will not be saved.",
				"Confirm Cancel", MessageBoxButtons.YesNo);
				if (confirmResult == DialogResult.Yes)
				{
					username = "Guest";
				}
			}

			if (inputDialog != null)
			{
				inputDialog.Dispose ();
			}
			return username;
		}

		public static void changeUser ()
		{
			ChangeUserDialog changeUserDialog = new ChangeUserDialog ();
			changeUserDialog.setUserChoices (KnowYourFactsFiles.loadUsers ());

			if (changeUserDialog.ShowDialog () == DialogResult.OK)
			{
				user.name = changeUserDialog.getSelectedUser ();
				files.updateCurrentUser (user.name);
				m_mainMenuControl.setUserButtonText ("Welcome " + user.name + "!" + "\nNot " + user.name + "?\nClick here to change users");
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
		public static void logUserInput (String userInput)
		{
			if (userInput == "space" && reference.queueOfFacts.Count == 0)
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
			else
			{
				m_userInput = userInput;
			}
		}

		/*
		 * Used to cycle through all the facts when the user selects the option to start all daily facts.
		 */ 
		private static void continueProcessingDailyFacts ()
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

		}

		/*
		 * Starts the chosen daily facts or speed test
		 */
		public static void startTheFacts (MathOperationTypeEnum sign, Boolean isSpeedTest, Boolean processAllDailyFacts)
		{
			operationType = new MathOperation (sign);

			// Determine if the user has already used the daily facts today.
			if (files.readDailyFactsDateDataFromFile(operationType.operationType) == DateTime.Today.ToString ("d"))
			{
				saveProgress = false;

				var continueWithoutSavingResponse = MessageBox.Show ("Oops! It looks like you have already practiced your " + operationType.getOperationName() + " facts today.\nYou can practice them again, but your progress will not be saved.\n\n Continue anyway?",
				"Progress Will Not Be Saved", MessageBoxButtons.YesNo);
				if (continueWithoutSavingResponse == DialogResult.No)
				{
					return;
				}
			}
			else
			{
				saveProgress = false;
			}
			
			speedTest = isSpeedTest;
			processingAllDailyFacts = processAllDailyFacts;

			if (!processingAllDailyFacts)
			{
				toggleMainMenuControl ();
				toggleFactsDisplayControl ();
			}

			// Change the bool value so the last set of messages for all daily facts are not suppressed.
			if (operationType.operationType == MathOperationTypeEnum.DIVISION)
			{
				processingAllDailyFacts = !processingAllDailyFacts;
			}

			reference.startProcessingFacts (speedTest, operationType, m_factsDisplayControl, processingAllDailyFacts);
		}

		/*
		 * Process a fact answer
		 */ 
		public void processInput ()
		{
			timer.Stop();											

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
					reference.writeResultsToFile (ref reference.correctResponseCount, ref reference.unknownFacts,
							ref reference.knownFacts, operationType, reference.factResponseTime);
				}

				if (reference.correctResponseCount == 0)
				{
					if (processingAllDailyFacts && operationType.operationType != MathOperationTypeEnum.DIVISION)
					{
						m_factsDisplayControl.messageLabel.Text = "All facts complete, very nice try!"
								+ "\nYou didn't get any facts correct this time.\n" + continueDailyFactsPrompt;
					}
					else
					{
						m_factsDisplayControl.messageLabel.Text = "All facts complete, very nice try!"
								+ "\nYou didn't get any facts correct this time.\n" + reference.completionContinuePrompt;
					}
				}
				
				else if (reference.correctResponseCount < (int) (reference.numberOfFactsProcessed / 2))
				{
					if (processingAllDailyFacts && operationType.operationType != MathOperationTypeEnum.DIVISION)
					{
						m_factsDisplayControl.messageLabel.Text = "All facts complete!\nYou got " + reference.correctResponseCount
								+ " out of " + reference.numberOfFactsProcessed
								+ " facts correct!" + continueDailyFactsPrompt;
					}
					else
					{
						m_factsDisplayControl.messageLabel.Text = "All facts complete!\nYou got " + reference.correctResponseCount
								+ " out of " + reference.numberOfFactsProcessed
								+ " facts correct!" + reference.completionContinuePrompt;
					}
				}
				
				else
				{
					if (processingAllDailyFacts && operationType.operationType != MathOperationTypeEnum.DIVISION)
					{
						m_factsDisplayControl.messageLabel.Text = "All facts complete, great job!\n"
							+ "You got " + reference.correctResponseCount + " out of "
							+ reference.numberOfFactsProcessed + " facts correct!\n"
							+ continueDailyFactsPrompt;
					}
					else
					{
						m_factsDisplayControl.messageLabel.Text = "All facts complete, great job!\n"
							+ "You got " + reference.correctResponseCount + " out of "
							+ reference.numberOfFactsProcessed + " facts correct!\n"
							+ reference.completionContinuePrompt;
					}
				}
			}
			else
			{
				reference.writeFactResponseTimeToFile (operationType);
				m_factsDisplayControl.messageLabel.Text = "Speed test complete!"
						+ "\nNow try out the daily " + operationType.operationType
						+ " facts!\n" + reference.completionContinuePrompt;
			}
		}

		static void c_InputDetected (object sender, InputDetectedEventArgs e)
		{
			((MathFactsForm) m_factsDisplayControl.FindForm ()).processInput ();
		}

		/*
		 * Update the factsdisplayControl with the new fact.
		 */
		public void FactsModelChange (object sender, FactsModelChangeEventArgs e)
		{
			if (!e.fact.Equals (null))
			{
				FactsModel.Instance.AddFact (e.fact.leftNum, e.fact.rightNum, e.fact.operation);
				m_factsDisplayControl.num1Label.Text = System.Convert.ToString (e.fact.leftNum);
				m_factsDisplayControl.num2Label.Text = System.Convert.ToString (e.fact.rightNum);
				m_factsDisplayControl.factSignLabel.Text = System.Convert.ToString 
																			(e.fact.operation.getOperationSign ());
				m_factsDisplayControl.inputMaskedTextBox.Text = "";
			}
		}
	}
}