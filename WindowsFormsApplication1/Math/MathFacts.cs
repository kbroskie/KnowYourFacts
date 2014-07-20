using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using FactsList = System.Collections.Generic.List<KnowYourFacts.Fact>;
using FactsQueue = System.Collections.Generic.Queue<KnowYourFacts.Fact>;

namespace KnowYourFacts
{
	public class MathFacts
	{
		#region Variables and Constants

		// Max number of facts to go up to
		public int maxFactNumber = 5;

		public List<long> factResponseTime;
		public int maxResponseTime;
		public double time;

		public int correctResponseCount;
		public int numberOfFactsProcessed;

		public ArrayList factsOrder;
		public FactsQueue queueOfFacts;
		public Stack<Fact> knownFacts;
		public Stack<Fact> unknownFacts;

		#endregion

		public MathFacts ()
		{
			correctResponseCount = 0;
			numberOfFactsProcessed = 0;
			factResponseTime = new List<long> ();

			factsOrder = new ArrayList();
			queueOfFacts = new FactsQueue ();
			knownFacts = new Stack<Fact> ();
			unknownFacts = new Stack<Fact> ();
		}

		public Fact getQuestionAndResponse (MathOperation operation)
		{
			return new Fact (queueOfFacts.First ().leftNum, queueOfFacts.First ().rightNum, operation);
		}

		/*
		 * Fill the List with newly generated facts if no known facts exist; 
		 * otherwise, fill with unknown facts.
		 */
		void generateFactsList (ref FactsQueue facts, MathOperation oper, UserProfile userProfile)
		{
			FactsList mathFactsList = new FactsList ();

			// Determine whether to read previously generated facts or generate new facts.
			if ((System.IO.File.Exists (FactsFiles.getDailyFactsFilename (oper.operationType, false))))
			{
				readUnknownFactsFromFile (ref mathFactsList, oper);
			}
			else
			{
				generateAndStoreNewFacts (ref mathFactsList, oper, userProfile);
			}

			// Determine the number of facts and obtain a set of random numbers for displaying of the facts
			if (mathFactsList != null)
			{
				randomizeFacts (ref facts, ref mathFactsList);
			}
		}

		/* 
		 * Read unmastered facts from the file.
		 */
		static void readUnknownFactsFromFile (ref FactsList mathFactsList, MathOperation operation)
		{
			try
			{
				String[] numbers = System.IO.File.ReadAllLines (FactsFiles.getDailyFactsFilename (operation.operationType,
					false));
			
				Fact newFact = new Fact ();
				newFact.operation = operation;

				for (int index = 0; index < numbers.Count (); ++index)
				{
					newFact.leftNum = System.Convert.ToInt32 (numbers[index++]);

					if (numbers.Count () != 0)
					{
						newFact.rightNum = System.Convert.ToInt32 (numbers[index]);
						mathFactsList.Add (newFact);
					}
				}
			}
			catch (Exception e)
			{
				if (e.InnerException is System.IO.FileNotFoundException)
				{
					MessageBox.Show ("The file with your unmastered facts could not be found.");
					return;
				}
				else
				{
					MessageBox.Show ("There was a problem reading the file with your unmastered facts.");
					Application.Exit ();
				}
			}
		}

		/*
		 * Fills facts queue with simple facts for testing input speed.
		 */
		public static void getFactsForSpeedTest (ref FactsQueue facts, MathOperation operationType)
		{
			FactsList mathFactsList;				// Later consider asking for certain range of numbers from user to be used.

			MathOperationTypeEnum operation = operationType.operationType;
			if (operation == MathOperationTypeEnum.ADDITION)
			{
				mathFactsList = new FactsList (new Fact[] {new Fact(1, 1, operationType), new Fact(2, 2, operationType), 
														 new Fact(0, 1, operationType), new Fact(0, 2, operationType)});
			}
			else if (operation == MathOperationTypeEnum.SUBTRACTION)
			{
				mathFactsList = new FactsList (new Fact[] {new Fact(1, 1, operationType), new Fact(2, 1, operationType), 
									 new Fact(1, 0, operationType), new Fact(3, 2, operationType)});
			}
			else if (operation == MathOperationTypeEnum.MULTIPLICATION)
			{
				mathFactsList = new FactsList (new Fact[] {new Fact(1, 1, operationType), new Fact(2, 2, operationType), 
									 new Fact(0, 1, operationType), new Fact(2, 1, operationType)});
			}
			else
			{
				mathFactsList = new FactsList (new Fact[] {new Fact(1, 1,  operationType), new Fact(2, 2, operationType), 
									 new Fact(0, 1, operationType), new Fact(4, 2, operationType)});
			}
			randomizeFacts (ref facts, ref mathFactsList);
		}

		/*
		 * Generate and stores the facts.
		 */
		static void generateAndStoreNewFacts (ref FactsList factsList, MathOperation operation, UserProfile userProfile)
		{
			Fact newFact;
			newFact.operation = operation;
			MathOperationTypeEnum operationType = operation.operationType;

			// Generate facts starting from 0 to the max number.
			for (int i = 0; i <= userProfile.maxFactNumber; ++i)
			{
				for (int j = 0; j <= userProfile.maxFactNumber; ++j)
				{
					if (operationType == MathOperationTypeEnum.ADDITION ||
						 operationType == MathOperationTypeEnum.MULTIPLICATION)
					{
						newFact.leftNum = i;
						newFact.rightNum = j;
						factsList.Add (newFact);
					}

					// Don't allow division by 0 or results with remainders for division facts.
					else if (i >= j && (operationType == MathOperationTypeEnum.SUBTRACTION ||
							(operationType == MathOperationTypeEnum.DIVISION && j != 0 && (i % j == 0))))
					{
						newFact.leftNum = i;
						newFact.rightNum = j;
						factsList.Add (newFact);
					}
				}
			}
		}

		/*
		 * Fills the List with random numbers equivalent to the number of facts to 
		 * display them in a random order.
		 */
		static void randomizeFacts (ref FactsQueue facts, ref FactsList factsList)
		{
			Random random = new Random ();
			int randomNumber;
			List<int> factsOrder = new List<int> ();

			while (factsOrder.Count () < factsList.Count ())
			{
				// Check that the number is unique.
				do
				{
					randomNumber = random.Next (factsList.Count ());
				} while (factsOrder.Contains (randomNumber));

				factsOrder.Add (randomNumber);
			}

			// Assign the numbers to a queue to display them in a random order.
			facts = new FactsQueue (factsOrder.Count ());
			foreach (int index in factsOrder)
			{
				facts.Enqueue (factsList[factsOrder[index]]);
			}
		}

		/*
		 * Functions to process the facts. Removes the last answered fact and retrieves the next fact.
		 */
		public bool getNextFact (ref Fact nextFact)
		{
			queueOfFacts.Dequeue ();
			++numberOfFactsProcessed;

			// Return the next fact to display, if any remain.
			if (queueOfFacts.Count () > 0)
			{
				nextFact = queueOfFacts.Peek ();
				return true;
			}

			return false;
		}

		/*
		 * Retrieve the current saved response time.
		 */
		public static bool getSavedResponseTime (MathOperationTypeEnum operationType,
															  List<long> factResponseTime, ref int maxResponseTime)
		{
			List<int> responseTime = new List<int> ();
			String[] savedTimes;
			try
			{
				savedTimes = System.IO.File.ReadAllLines (FactsFiles.getFactResponseTimeFilename ());
			}
			catch (System.IO.FileNotFoundException)
			{
				return false;
			}

			foreach (String time in savedTimes)
			{
				responseTime.Add (System.Convert.ToInt32 (time));
			}

			maxResponseTime = responseTime[(int) operationType];

			// No fact response times have been recorded if no maxResponseTime exists
			return !maxResponseTime.Equals(0);
		}

		/*
		 * Handles starting the daily facts and speed test.
		 */
		public void startProcessingFacts (bool speedTest, MathOperation operation, FactsDisplayControl displayControl, 
													 bool processingAllDailyFacts, UserProfile userProfile)
		{
			MathOperationTypeEnum opType = MathFactsForm.operationType.operationType;
			// Suppress messages if all daily facts are being processed.
			if (!MathFactsForm.speedTest && !getSavedResponseTime (opType, factResponseTime, ref maxResponseTime))
			{
				if (!processingAllDailyFacts)
				{
					// No saved response data was found for this fact type.
					MathFactsForm.toggleInputDisplay ();

					String operatorName = MathFactsForm.operationType.ToString ();
					MathFactsForm.m_factsDisplayControl.messageLabel.Text = "No data could be found for " + operatorName + " facts.\n"
								+ "Please take the " + operatorName + " speed test first.\n" + MathFactsForm.COMPLETION_CONTINUE_PROMPT;
					return;
				}
			}

			correctResponseCount = 0;
			numberOfFactsProcessed = 0;

			if (!speedTest)
			{
				generateFactsList (ref queueOfFacts, operation, userProfile);
			}
			else
			{
				getFactsForSpeedTest (ref queueOfFacts, operation);
			}

			if (queueOfFacts.Count () == 0)
			{
				if (!processingAllDailyFacts)
				{
					MathFactsForm.toggleInputDisplay ();
					displayControl.messageLabel.Text = "You have mastered all the facts, there are none to practice!\n"
							+ MathFactsForm.COMPLETION_CONTINUE_PROMPT;
				}
			}
			else
			{
				// Display the first fact.
				displayControl.factSignLabel.Text = operation.getOperationSign ();
				displayControl.num1Label.Text = System.Convert.ToString (queueOfFacts.First ().leftNum);
				displayControl.num2Label.Text = System.Convert.ToString (queueOfFacts.First ().rightNum);

				displayControl.inputMaskedTextBox.Focus ();
				MathFactsForm.timer = System.Diagnostics.Stopwatch.StartNew ();
			}
		}

		/*
		 * The writeToFile function opens the file, erases the current 
		 * in the file, and then prints the new results.
		 */
		public void writeResultsToFile (ref int correctResponseCount, ref Stack<Fact> unknown, ref Stack<Fact> known,
										MathOperation operatorType, List<long> factResponseTime)
		{
			using (System.IO.StreamWriter swU = new System.IO.StreamWriter (FactsFiles.getDailyFactsFilename
					(operatorType.operationType, false))) 
			{
				using (System.IO.StreamWriter swK = new System.IO.StreamWriter (FactsFiles.getDailyFactsFilename
						(operatorType.operationType, true), true))
				{
					// For use with factResponseTime.
					int index = 0;

					// Store each number from the List in the appropriate file.
					while (knownFacts.Count () != 0)
					{
						// Determine whether a correct answer was entered, and whether the answer was entered after a period of elapsed time. 
						if (factResponseTime[index] < maxResponseTime)
						{
							// A correct answer was given. Store in the known facts file.
							swK.WriteLine (knownFacts.Peek ().leftNum);
							swK.WriteLine (knownFacts.Peek ().rightNum);
						}

						// Correct answer was given, but in more than allotted time for a known fact.
						else
						{
							swU.WriteLine (knownFacts.Peek ().leftNum);
							swU.WriteLine (knownFacts.Peek ().rightNum);
						}

						knownFacts.Pop ();
						++correctResponseCount;
						++index;
					}

					// Store incorrect responses in the unknown facts file.
					while (unknownFacts.Count () != 0)
					{
						swU.WriteLine (unknownFacts.Peek ().leftNum);
						swU.WriteLine (unknownFacts.Peek ().rightNum);
						unknownFacts.Pop ();
					}
				}
			}

			// Save the current date in MM/DD/YYYY format to file.
			FactsFiles.writeDailyFactsDateDataToFile (DateTime.Today.ToString ("d"), operatorType.operationType);
		}

		/*
		 * For determining how long it takes for known versus unknown fact responses to to be entered.
		 */
		public void writeFactResponseTimeToFile (MathOperation operation)
		{
			List<int> responseTime = new List<int> ();
			String responseTimeFilename = FactsFiles.getFactResponseTimeFilename ();

			// Read in the current input and write out the new data.
			if (System.IO.File.Exists (responseTimeFilename))
			{
				String[] savedTimes = System.IO.File.ReadAllLines (responseTimeFilename);

				foreach (String time in savedTimes)
				{
					responseTime.Add (Convert.ToInt32 (time));
				}

				// Determine if the saved file has a complete data set.
				if (responseTime.Count != 4)
				{
					MessageBox.Show ("The file with your fact response time was damaged.\nYour results for this test have been saved,\nbut any other test data could not be recovered.");
					responseTime = new List<int> (new int[] { 0, 0, 0, 0 });
				}
			}
			else
			{
				// The file was not created yet - create default data.
				responseTime = new List<int> (new int[] { 0, 0, 0, 0 });
			}

			double sum = 0;
			foreach (double time in factResponseTime)
			{
				sum += time;
			}

			// Store the average response time.
			responseTime[(int) operation.operationType] = (int) (System.Math.Ceiling (sum / factResponseTime.Count ()));

			using (System.IO.StreamWriter sw = new System.IO.StreamWriter (responseTimeFilename))
			{
				foreach (int time in responseTime)
				{
					sw.WriteLine (time);
				}
			}
		}
	}
}