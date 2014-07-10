using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

using Facts = System.Collections.Generic.List<KnowYourFacts.Fact>;

namespace KnowYourFacts
{
	public partial class MathFactsForm : Form, IView
	{
		static MainMenuControl m_mainMenuControl;
		public static FactsDisplayControl m_factsDisplayControl;
		static MathFacts reference;

		public static bool speedTest;
		static bool menubarToggle = true;

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
			reference.factResponseTime = new List<long> ();
			//	factSource.DataSource = FactsModel.Instance.Facts;
		}

		/*
		 * Updates the last value entered by the user, or toggles the display 
		 * if the spacebar was pressed to clear a status bar message.
		 */
		public static void logUserInput (String userInput)
		{
			if (userInput == "space")
			{
				toggleFactsDisplayControl (false);
				toggleMainMenuControl (true);
			}
			else
			{
				m_userInput = userInput;
			}
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
		internal static void toggleMainMenuControl (bool toggle)
		{
			m_mainMenuControl.Visible = toggle;
			m_mainMenuControl.Enabled = toggle;
		}

		/*
		 * Toggle the functionality and visibility of the facts display control.
		 */
		internal static void toggleFactsDisplayControl (bool toggle)
		{
			m_factsDisplayControl.Visible = toggle;
			m_factsDisplayControl.Enabled = toggle;
		}

		/*
		 * Toggle the visibility of the facts input display control,
		 * but leave the status area visible.
       */
		public static void toggleInputDisplay ()
		{
			m_factsDisplayControl.num1Label.Visible = false;
			m_factsDisplayControl.num2Label.Visible = false;
			m_factsDisplayControl.inputMaskedTextBox.Visible = false;
			m_factsDisplayControl.lineLabel.Visible = false;
			m_factsDisplayControl.factSignLabel.Visible = false;
			m_factsDisplayControl.messageLabel.Focus ();
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
			m_factsDisplayControl.messageLabel.Text = "";
			operationType = new MathOperation (sign);
			speedTest = test;
			toggleMainMenuControl (false);
			toggleFactsDisplayControl (true);
			reference.startProcessingFacts (speedTest, operationType, m_factsDisplayControl);
		}

		/*
		 * Process a fact answer
		 */ 
		public void processInput (FactsDisplayControl displayControl)
		{
			timer.Stop();											

			long secondsElapsed;
			String inputString = (displayControl.inputMaskedTextBox.Text);
		

			// Obtain the input answer.
			int answer = System.Convert.ToInt32 (inputString);
			Fact input = reference.getQuestionAndResponse (operationType);
			int calculatedAnswer = MathOperation.calculateAnswer (input.leftNum, input.rightNum, operationType);

			// Only store the response time for correct answers.
			if (answer == calculatedAnswer)
			{
				secondsElapsed = (long) (timer.ElapsedMilliseconds / 1000);
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

			// Clear the text box.
			m_factsDisplayControl.inputMaskedTextBox.Text = "";

			int lNum = 0, rNum = 0;

			// Get the next fact and update the labels.
			// Instead of returning a number, just use the front of queue below.
			if (reference.getNextFact (ref lNum, ref rNum, ref reference.queueOfFacts, 
						ref reference.numberOfFactsProcessed))
			{
				m_factsDisplayControl.inputMaskedTextBox.Text = "";
				m_factsDisplayControl.num1Label.Text = System.Convert.ToString (lNum);
				m_factsDisplayControl.num2Label.Text = System.Convert.ToString (rNum);

				timer.Reset();
				timer.Start();
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
						displayControl.messageLabel.Text = "All facts complete! You got " + reference.correctResponseCount
								+ " out of the " + reference.numberOfFactsProcessed 
								+ " facts correct!" + reference.continuePrompt;
					}
					else if (reference.correctResponseCount == 0)
					{
						displayControl.messageLabel.Text = "All facts complete, very nice try!" 
							+ "You didn't get any facts correct this time." + reference.continuePrompt;
					}
					else
					{
						displayControl.messageLabel.Text = "All facts complete, great job! "
							+ "You got " + reference.correctResponseCount + " out of the "
							+ reference.numberOfFactsProcessed + " facts correct!" 
							+ reference.continuePrompt;
					}
				}
				else
				{
					reference.writeFactResponseTimeToFile (operationType);
					displayControl.messageLabel.Text = "Speed test complete!" 
							+ "\n\nNow try out the daily " + operationType.getOperationName () 
							+ " facts!" + reference.continuePrompt;
				}	
			}
		}

		static void c_InputDetected (object sender, InputDetectedEventArgs e)
		{
			((MathFactsForm) m_factsDisplayControl.FindForm ()).processInput (m_factsDisplayControl);
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