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
		static bool menubarToggle = true;
		static bool mainMenuControlToggle = true;
		static bool factsDisplayControlToggle = false;
		public static bool inputDisplayToggle = true;

		public static MathOperation operationType;

		static public int userResponse;
		public static String m_userInput;

		public long timeElapsed;
		public static System.Diagnostics.Stopwatch timer;

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
				Console.WriteLine ("logUserInput**************");

				// Check if this will trigger an early exit from facts processing.
				toggleFactsDisplayControl ();
				toggleInputDisplay ();
				toggleMainMenuControl ();
			}
			else
			{
				m_userInput = userInput;
			}
		}

		/*
		 * Event triggered when the functionality of the main menu control is changed.
		 * Toggles the functionality and visiblity of the main menu bar.
		 */
		private void toggleMainMenubar (object sender, EventArgs e)
		{
			Console.WriteLine ("toggleMainMenubar**************");

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
			Console.WriteLine ("toggleMainMenuControl**************");
			mainMenuControlToggle = !mainMenuControlToggle;

			m_mainMenuControl.Visible = mainMenuControlToggle;
			m_mainMenuControl.Enabled = mainMenuControlToggle;
		}

		/*
		 * Toggle the functionality and visibility of the facts display control.
		 */
		internal static void toggleFactsDisplayControl ()
		{
			Console.WriteLine ("toggleFactsDisplayControl**************");
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
			Console.WriteLine ("toggleInputDisplay**************");
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

			startTheFacts (sign, false);
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

			startTheFacts (sign, true);
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
		public void startTheFacts (MathOperationTypeEnum sign, Boolean test)
		{
			Console.WriteLine ("startTheFacts**************");

			operationType = new MathOperation (sign);
			speedTest = test;
			toggleMainMenuControl ();
			toggleFactsDisplayControl ();
			reference.startProcessingFacts (speedTest, operationType, m_factsDisplayControl);
		}

		/*
		 * Process a fact answer
		 */ 
		public void processInput ()
		{
			timer.Stop();											

			long secondsElapsed;
			String inputString = (m_factsDisplayControl.inputMaskedTextBox.Text);
		
			// Obtain the input answer.
			int answer = System.Convert.ToInt32 (inputString);
			Fact input = reference.getQuestionAndResponse (operationType);
			int calculatedAnswer = MathOperation.calculateAnswer (input.leftNum, input.rightNum, operationType);

			// Only store the response time for correct answers.
			if (answer == calculatedAnswer)
			{
				secondsElapsed = (long) (timer.ElapsedMilliseconds / 1000.0);
				Console.WriteLine ("Seconds elapsed: " + secondsElapsed);
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

			int lNum = 0, rNum = 0;

			// Get the next fact and update the labels.
			// Instead of returning a number, just use the front of queue below.
			if (reference.getNextFact (ref lNum, ref rNum, ref reference.queueOfFacts, 
						ref reference.numberOfFactsProcessed))
			{
				m_factsDisplayControl.inputMaskedTextBox.Text = "";
				m_factsDisplayControl.num1Label.Text = System.Convert.ToString (lNum);
				m_factsDisplayControl.num2Label.Text = System.Convert.ToString (rNum);

				timer.Restart ();
			}
			else
			{
				toggleInputDisplay ();

				if (!speedTest)
				{
					reference.writeResultsToFile (ref reference.correctResponseCount, ref reference.unknownFacts, 
							ref reference.knownFacts, operationType, reference.factResponseTime);

					if (reference.correctResponseCount > (int) (reference.numberOfFactsProcessed))
					{
						m_factsDisplayControl.messageLabel.Text = "All facts complete!\nYou got " + reference.correctResponseCount
								+ " out of the " + reference.numberOfFactsProcessed 
								+ " facts correct!" + reference.continuePrompt;
					}
					else if (reference.correctResponseCount == 0)
					{
						m_factsDisplayControl.messageLabel.Text = "All facts complete, very nice try!"
							+ "\nYou didn't get any facts correct this time." + reference.continuePrompt;
					}
					else
					{
						m_factsDisplayControl.messageLabel.Text = "All facts complete, great job!\n"
							+ "You got " + reference.correctResponseCount + " out of the "
							+ reference.numberOfFactsProcessed + " facts correct\n!" 
							+ reference.continuePrompt;
					}
				}
				else
				{
					reference.writeFactResponseTimeToFile (operationType);
					m_factsDisplayControl.messageLabel.Text = "Speed test complete!" 
							+ "\nNow try out the daily " + operationType.getOperationName () 
							+ " facts!\n" + reference.continuePrompt;
				}
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