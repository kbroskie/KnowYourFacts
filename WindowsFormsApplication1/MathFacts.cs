using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FactsList = System.Collections.Generic.List<KnowYourFacts.Fact>;
using FactsQueue = System.Collections.Generic.Queue<KnowYourFacts.Fact>;

namespace KnowYourFacts
{
	public class MathFacts
	{
		//----------------------------------------------------------------------------------------
		// Constants
		const int MAX_NUM = 5;         	// Max number of facts to go up to.
		const string UNKNOWN_ADDITION_FACTS_FILE = "unknownAdditionFacts.txt";
		const string KNOWN_ADDITION_FACTS_FILE = "knownAdditionFacts.txt";
		const string UNKNOWN_SUBTRACTION_FACTS_FILE = "unknownSubtractionFacts.txt";
		const string KNOWN_SUBTRACTION_FACTS_FILE = "knownSubtractionFacts.txt";
		const string UNKNOWN_MULTIPLICATION_FACTS_FILE = "unknownMultiplicationFacts.txt";
		const string KNOWN_MULTIPLICATION_FACTS_FILE = "knownMultiplcationFacts.txt";
		const string UNKNOWN_DIVISION_FACTS_FILE = "unknownDivisionFacts.txt";
		const string KNOWN_DIVISION_FACTS_FILE = "knownDivisionFacts.txt";
		const string FACT_RESPONSE_TIME_FILE = "factResponseTime.txt";

		/************************************************************/
		// Class instance variables
		public List<long> factResponseTime;
		public int maxResponseTime;
		public double time;

		public int correctResponseCount;
		public int numberOfFactsProcessed;

		public string continuePrompt = "\nPress the spacebar to continue.";

		public ArrayList factsOrder;
		public FactsQueue queueOfFacts;
		public Stack<Fact> knownFacts;
		public Stack<Fact> unknownFacts;

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
			Console.WriteLine ("getQuestionAndResponse**************");

			return new Fact (queueOfFacts.First ().leftNum, queueOfFacts.First ().rightNum, operation);
		}

		/*
			Determine which filename should be used.
		*/
		static string getFileName (MathOperationTypeEnum op, bool knownFile)
		{
			Console.WriteLine ("getFileName**************");

			if (op == MathOperationTypeEnum.ADDITION)
			{
				if (knownFile)
				{
					return KNOWN_ADDITION_FACTS_FILE;
				}
				else
				{
					return UNKNOWN_ADDITION_FACTS_FILE;
				}
			}
			else if (op == MathOperationTypeEnum.SUBTRACTION)
			{
				if (knownFile)
				{
					return KNOWN_SUBTRACTION_FACTS_FILE;
				}
				else
				{
					return UNKNOWN_SUBTRACTION_FACTS_FILE;
				}
			}
			else if (op == MathOperationTypeEnum.MULTIPLICATION)
			{
				if (knownFile)
				{
					return KNOWN_MULTIPLICATION_FACTS_FILE;
				}
				else
				{
					return UNKNOWN_MULTIPLICATION_FACTS_FILE;
				}
			}
			else
			{
				if (knownFile)
				{
					return KNOWN_DIVISION_FACTS_FILE;
				}
				else
				{
					return UNKNOWN_DIVISION_FACTS_FILE;
				}
			}
		}

		/*
			Fill the List with newly generated facts if no known facts exist; 
			otherwise, fill with unknown facts.
		*/
		void generateFactsList (ref FactsQueue facts, MathOperation oper)
		{
			Console.WriteLine ("generateFactsList**************");

			FactsList mathFactsList = new FactsList ();

			// Determine whether to read previously generated facts or generate new facts.
			if ((File.Exists (getFileName (oper.getOperationType (), false))))
			{
				readUnknownFactsFromFile (ref mathFactsList, oper);
			}
			else
			{
				generateAndStoreNewFacts (ref mathFactsList, oper);
			}

			// Determine the number of facts and obtain a set of random numbers for displaying of the facts
			if (mathFactsList != null)
			{
				randomizeFacts (ref facts, ref mathFactsList);
			}
		}

		/* 
			Read unmastered facts from the file.
		*/
		static void readUnknownFactsFromFile (ref FactsList mathFactsList, MathOperation operation)
		{
			Console.WriteLine ("readUnknownFactsFromFile**************");

			StreamReader din = File.OpenText (getFileName (operation.getOperationType (), false));

			Fact factFromFile;
			try
			{
				String numInFile = din.ReadLine ();

				// Read the items in the file.
				while (numInFile != null)
				{
					factFromFile = new Fact ();
					factFromFile.leftNum = System.Convert.ToInt32 (numInFile);
					numInFile = din.ReadLine ();
					factFromFile.rightNum = System.Convert.ToInt32 (numInFile);
					factFromFile.operation = operation;
					mathFactsList.Add (factFromFile);
					numInFile = din.ReadLine ();
				}
			}
			catch (Exception e)
			{
				if (e.InnerException is System.IO.FileNotFoundException)
				{
					MessageBox.Show ("The file with your unmastered facts could not be found.");
				}
				else
				{
					MessageBox.Show ("There was a problem reading the file with your unmastered facts.");
					Application.Exit ();
				}
			}
			finally
			{
				din.Close ();
			}
		}

		/*
			Fills facts queue with simple facts for testing input speed.
		*/
		public static void getFactsForSpeedTest (ref FactsQueue facts, MathOperation operationType)
		{
			FactsList mathFactsList;				// Later consider asking for certain range of numbers from user to be used.

			MathOperationTypeEnum operation = operationType.getOperationType ();
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
		  Generate and stores the facts.
		*/
		static void generateAndStoreNewFacts (ref FactsList factsList, MathOperation operation)
		{
			Console.WriteLine ("generateAndStoreNewFacts**************");

			Fact newFact;
			newFact.operation = operation;
			MathOperationTypeEnum operationType = operation.getOperationType ();

			// Generate facts starting from 0 to the max number.
			for (int i = 0; i <= MAX_NUM; ++i)
			{
				for (int j = 0; j <= MAX_NUM; ++j)
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
			Fills the List with random numbers equivalent to the number of facts to 
			display them in a random order.
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
			Functions to process the facts. Removes the last answered fact and retrieves the next fact.
		*/
		public bool getNextFact (ref int num1, ref int num2, ref FactsQueue facts, ref int numberOfFactsProcessed)
		{
			Console.WriteLine ("getNextFact**************");
			facts.Dequeue ();
			Console.WriteLine ("facts count: " + facts.Count ());

			++numberOfFactsProcessed;

			// Determine whether more facts are left to be displayed.
			if (queueOfFacts.Count () > 0)
			{
				// Obtain the numbers for the next fact to display.
				num1 = facts.Peek ().leftNum;
				num2 = facts.Peek ().rightNum;
				return true;
			}

			return false;
		}

		/*
			Retrieve the current saved response time.
		*/
		public static bool getSavedResponseTime (MathOperationTypeEnum operationType,
															  List<long> factResponseTime, int maxResponseTime)
		{
			List<int> responseTime = new List<int> ();
			Console.WriteLine ("getSavedResponseTime**************");
			
			try 
			{
				StreamReader din = File.OpenText (FACT_RESPONSE_TIME_FILE);
				String savedTime = "";
				while ((savedTime = din.ReadLine ()) != null)
				{
					responseTime.Add (System.Convert.ToInt32 (savedTime));
				}
				din.Close ();
			}
			catch (FileNotFoundException)
			{
				return false;
			}
			
			maxResponseTime = responseTime[(int) operationType];
			if (maxResponseTime == 0)
			{
				// No fact response times have been recorded.
				return false;
			}

			return true;
		}

		/*
			For determining how long it takes for known versus unknown fact responses to to be entered.
		*/
		public void writeFactResponseTimeToFile (MathOperation operation)
		{
			Console.WriteLine ("writeFactResponseTime**************");

			List<int> responseTime = new List<int> ();
	
			// Read in the current input and write out the new data.
			if (File.Exists (FACT_RESPONSE_TIME_FILE))
			{
				StreamReader din = File.OpenText (FACT_RESPONSE_TIME_FILE);
				String savedTime = din.ReadLine ();

				while (savedTime != null)
				{
					Console.WriteLine (savedTime);
					responseTime.Add (Convert.ToInt32 (savedTime));
					savedTime = din.ReadLine ();
				}

				din.Close ();

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
				responseTime = new List<int> (new int[] {0, 0, 0, 0});
			}

			double sum = 0;
			foreach (double time in factResponseTime)
			{
				sum += time;
				Console.WriteLine ("Time: " + time);
			}

			// Store the average response time.
			responseTime[(int) operation.getOperationType()] = (int) (System.Math.Ceiling (sum / factResponseTime.Count ()));

			StreamWriter sw = new StreamWriter (FACT_RESPONSE_TIME_FILE);
			foreach (int time in responseTime)
			{
				sw.WriteLine (time);
			}

			sw.Close ();
		}

		/*
		 * The writeToFile function opens the file, erases the current 
		 * in the file, and then prints the new results.
		 */
		public void writeResultsToFile (ref int correctResponseCount, ref Stack<Fact> unknown, ref Stack<Fact> known,
										MathOperation operatorType, List<long> factResponseTime)
		{
			Console.WriteLine ("writeResultsToFile**************");

			StreamWriter swU = new StreamWriter (getFileName (operatorType.getOperationType (), false));
			StreamWriter swK = new StreamWriter (getFileName (operatorType.getOperationType (), true), true);

			// For use with factResponseTime.
			int index = 0;

			// Clear the current contents of the unknown facts file.
			swU.Write ("");

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

			// Close the files.
			swU.Close ();
			swK.Close ();
		}

		/*
		 * Handles starting the daily facts and speed test.
		 */
		public void startProcessingFacts (bool speedTest, MathOperation operation,
													FactsDisplayControl displayControl)
		{
			Console.WriteLine ("startProcessingFacts**************");

			MathOperationTypeEnum opType = MathFactsForm.operationType.getOperationType ();
			if (!MathFactsForm.speedTest && !getSavedResponseTime (opType, factResponseTime, maxResponseTime))
			{
				// No saved response data was found for this fact type.
				MathFactsForm.toggleInputDisplay ();

				String operatorName = MathFactsForm.operationType.getOperationName ();
				MathFactsForm.m_factsDisplayControl.messageLabel.Text = "No data could be found for " + operatorName + " facts.\n" +
											"Please take the " + operatorName + " speed test first.\n" + continuePrompt;
				return;
			}

			correctResponseCount = 0;
			numberOfFactsProcessed = 0;

			if (!speedTest)
			{
				generateFactsList (ref queueOfFacts, operation);
			}
			else
			{
				getFactsForSpeedTest (ref queueOfFacts, operation);
			}

			if (queueOfFacts.Count () == 0)
			{
				MathFactsForm.toggleInputDisplay ();
				displayControl.messageLabel.Text = "You have mastered all the facts, there are none to practice!\n"
											+ continuePrompt;
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
	}
}