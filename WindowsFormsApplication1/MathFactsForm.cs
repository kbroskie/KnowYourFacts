using System;
using System.Windows.Forms;

namespace KnowYourFacts
{
	public partial class MathFactsForm : Form, IView
	{
		static MainMenuControl m_mainMenuControl;
		public static FactsDisplayControl m_factsDisplayControl;
		static MathFacts reference;

		public static bool speedTest;
		static bool processingAllDailyFacts = false;

		static bool menubarToggle = true;
		static bool mainMenuControlToggle = true;
		static bool factsDisplayControlToggle = false;
		public static bool inputDisplayToggle = true;

		public static MathOperation operationType;

		static public int userResponse;
		public static String m_userInput;

		public long timeElapsed;
		public static System.Diagnostics.Stopwatch timer;

		private String continueDailyFactsPrompt = "\nPress the spacebar to continue your facts.";

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
		static private void continueProcessingDailyFacts ()
		{
			MathOperationTypeEnum lastOperation = operationType.getOperationType ();

			if (processingAllDailyFacts && lastOperation != MathOperationTypeEnum.DIVISION)
			{
				operationType.setOperationType ((MathOperationTypeEnum) ((int) lastOperation + 1));
				startTheFacts (operationType.getOperationType (), speedTest = false, processingAllDailyFacts);
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
		static public void startTheFacts (MathOperationTypeEnum sign, Boolean isSpeedTest, Boolean processAllDailyFacts)
		{
			operationType = new MathOperation (sign);
			speedTest = isSpeedTest;
			processingAllDailyFacts = processAllDailyFacts;

			if (!processingAllDailyFacts)
			{
				toggleMainMenuControl ();
				toggleFactsDisplayControl ();
			}

			// Change the bool value so the last set of messages for all daily facts are not suppressed.
			if (operationType.getOperationType () == MathOperationTypeEnum.DIVISION)
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
			Console.WriteLine ("processInput**************");
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
				reference.writeResultsToFile (ref reference.correctResponseCount, ref reference.unknownFacts,
						ref reference.knownFacts, operationType, reference.factResponseTime);

				if (reference.correctResponseCount == 0)
				{
					if (processingAllDailyFacts && operationType.getOperationType () != MathOperationTypeEnum.DIVISION)
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
					if (processingAllDailyFacts && operationType.getOperationType () != MathOperationTypeEnum.DIVISION)
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
					if (processingAllDailyFacts && operationType.getOperationType () != MathOperationTypeEnum.DIVISION)
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
						+ "\nNow try out the daily " + operationType.getOperationName ()
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