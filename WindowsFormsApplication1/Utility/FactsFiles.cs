﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;

using KnowYourFacts.Users;
using KnowYourFacts.Math;

namespace KnowYourFacts.Utility
{	
	public class FactsFiles
	{
		#region Variables
		List<String> paths = new List<String> ();
		List<String> files = new List<String> ();

		static String userDirectory = Environment.GetFolderPath (Environment.SpecialFolder.UserProfile);
		static String topLevelDirectory;

		static String usersPath;
		static String usersDataFilename;
		static String userFilename;
		static String userPath;

		static String speedFactsPath;
		static String dailyFactsPath;
		static String unknownFactsPath;
		static String knownFactsPath;
		static String speedTestPath;
		static String customSpeedTestPath;

		static String dailyAdditionFactsData;
		static String dailySubtractionFactsData;
		static String dailyMultiplicationFactsData;
		static String dailyDivisionFactsData;

		static String speedAdditionFactsDataFilename;
		static String speedSubtractionFactsDataFilename;
		static String speedMultiplicationFactsDataFilename;
		static String speedDivisionFactsDataFilename;

		#endregion

		#region Constants

		public const String ADDITION = "addition.txt";
		public const String SUBTRACTION = "subtraction.txt";
		public const String MULTIPLICATION = "multiplication.txt";
		public const String DIVISION = "division.txt";
		public const String FACT_RESPONSE_TIME = "factResponseTime.txt";
		public const String USER__PROFILE = "profile.txt";
		public const String USER_DATA = "usersData.txt";

		public const int MAX_DAYS_BETWEEN_SPEED_TEST = 30;

		#endregion

		#region Singleton

		static FactsFiles instanceKnowYourFactsFiles;

		public static FactsFiles Instance
		{
			get
			{
				if (instanceKnowYourFactsFiles == null)
				{
					instanceKnowYourFactsFiles = new FactsFiles ();
				}
				return instanceKnowYourFactsFiles;
			}
		}

		private FactsFiles ()
		{
			topLevelDirectory = System.IO.Path.Combine (userDirectory, "Know Your Facts");
			usersPath = System.IO.Path.Combine (topLevelDirectory, "Users");
			speedFactsPath = System.IO.Path.Combine (topLevelDirectory, "SpeedFacts");
			usersDataFilename = System.IO.Path.Combine (usersPath, USER_DATA);
		}

		#endregion

		#region Methods for creation of directories and files
		/*
		 * Creates the default directories for the application.
		 */ 
		public void createDefaultProgramDirectory ()
		{
			paths.Add (topLevelDirectory);
			paths.Add (usersPath);
			paths.Add (speedFactsPath);

			// Create the default speed test files.
			String additionSpeedTestFilename = System.IO.Path.Combine (speedFactsPath, ADDITION);
			String subtractionSpeedTestFilename = System.IO.Path.Combine (speedFactsPath, SUBTRACTION);
			String multiplicationSpeedTestFilename = System.IO.Path.Combine (speedFactsPath, MULTIPLICATION);
			String divisionSpeedTestFilename = System.IO.Path.Combine (speedFactsPath, DIVISION);

			files.Add (additionSpeedTestFilename);
			files.Add (subtractionSpeedTestFilename);
			files.Add (multiplicationSpeedTestFilename);
			files.Add (divisionSpeedTestFilename);

			// To hold general users data
			files.Add (usersDataFilename);

			createFilesAndDirectories ();
		}

		/*
		 * Creates files and directories for a new user.
		 */ 
		public void createNewUserDirectory (UserProfile newUserProfile)
		{
			// Create the individual user directories.
			userPath = System.IO.Path.Combine (usersPath, newUserProfile.user.name);
			paths.Add (userPath);

			// Create the individual user subdirectories.
			dailyFactsPath = System.IO.Path.Combine (userPath, "dailyFactsData");
			paths.Add (dailyFactsPath);

			unknownFactsPath = System.IO.Path.Combine (userPath, "unknownFacts");
			paths.Add (unknownFactsPath);

			knownFactsPath = System.IO.Path.Combine (userPath, "knownFacts");
			paths.Add (knownFactsPath);

			speedTestPath = System.IO.Path.Combine (userPath, "speedTest");
			paths.Add (speedTestPath);

			customSpeedTestPath = System.IO.Path.Combine (speedTestPath, "custom");

			// Create the individual user files.
			dailyAdditionFactsData = System.IO.Path.Combine (dailyFactsPath, ADDITION);
			dailySubtractionFactsData = System.IO.Path.Combine (dailyFactsPath, SUBTRACTION);
			dailyMultiplicationFactsData = System.IO.Path.Combine (dailyFactsPath, MULTIPLICATION);
			dailyDivisionFactsData = System.IO.Path.Combine (dailyFactsPath, DIVISION);

			files.Add (dailyAdditionFactsData);
			files.Add (dailySubtractionFactsData);
			files.Add (dailyMultiplicationFactsData);
			files.Add (dailyDivisionFactsData);

			userFilename = System.IO.Path.Combine (userPath, USER__PROFILE);
			files.Add (userFilename);

			speedAdditionFactsDataFilename = System.IO.Path.Combine (speedTestPath, ADDITION);
			speedSubtractionFactsDataFilename = System.IO.Path.Combine (speedTestPath, SUBTRACTION);
			speedMultiplicationFactsDataFilename = System.IO.Path.Combine (speedTestPath, MULTIPLICATION);
			speedDivisionFactsDataFilename = System.IO.Path.Combine (speedTestPath, DIVISION);

			files.Add (speedAdditionFactsDataFilename);
			files.Add (speedSubtractionFactsDataFilename);
			files.Add (speedMultiplicationFactsDataFilename);
			files.Add (speedDivisionFactsDataFilename);

			createFilesAndDirectories ();
			updateUsersData (newUserProfile.user.name);
		}

		private void createFilesAndDirectories ()
		{
			foreach (String path in paths)
			{
				if (!System.IO.File.Exists (path))
				{
					System.IO.Directory.CreateDirectory (path);
				}
			}

			foreach (String file in files)
			{
				if (!System.IO.File.Exists (file))
				{
					System.IO.File.Create (file).Close ();
					
				}
			}
		}

		#endregion

		/*
		 * Checks whether the main directory exists.
		 */
		public bool mainDirectoryExists ()
		{
			return (System.IO.File.Exists (topLevelDirectory));
		}

		/*
		 * Checks whether the given user exists.
		 */
		public bool userDirectoryExists (User user)
		{
			return (System.IO.Directory.Exists (System.IO.Path.Combine (usersPath, user.name)));
		}

		/*
		 * Updates all the read/write paths for the current user, and updates the UsersData file.
		 */ 
		public void updateCurrentUser (String currentUser)
		{
			updateUsersData (currentUser);

			if (currentUser != "Guest")
			{
				userPath = System.IO.Path.Combine (usersPath, currentUser);

				dailyFactsPath = System.IO.Path.Combine (userPath, "dailyFactsData");
				unknownFactsPath = System.IO.Path.Combine (userPath, "unknownFacts");
				knownFactsPath = System.IO.Path.Combine (userPath, "knownFacts");
				speedTestPath = System.IO.Path.Combine (userPath, "speedTest");
				customSpeedTestPath = System.IO.Path.Combine (speedTestPath, "custom");

				dailyAdditionFactsData = System.IO.Path.Combine (dailyFactsPath, ADDITION);
				dailySubtractionFactsData = System.IO.Path.Combine (dailyFactsPath, SUBTRACTION);
				dailyMultiplicationFactsData = System.IO.Path.Combine (dailyFactsPath, MULTIPLICATION);
				dailyDivisionFactsData = System.IO.Path.Combine (dailyFactsPath, DIVISION);

				userFilename = System.IO.Path.Combine (userPath, USER__PROFILE);

				speedAdditionFactsDataFilename = System.IO.Path.Combine (speedTestPath, ADDITION);
				speedSubtractionFactsDataFilename = System.IO.Path.Combine (speedTestPath, SUBTRACTION);
				speedMultiplicationFactsDataFilename = System.IO.Path.Combine (speedTestPath, MULTIPLICATION);
				speedDivisionFactsDataFilename = System.IO.Path.Combine (speedTestPath, DIVISION);
			}
		}

		#region Filename accessors
		public static String getDailyFactsDataFilename (MathOperationTypeEnum operation)
		{
			switch (operation)
			{
				case MathOperationTypeEnum.ADDITION:
					return dailyAdditionFactsData;
				case MathOperationTypeEnum.SUBTRACTION:
					return dailySubtractionFactsData;
				case MathOperationTypeEnum.MULTIPLICATION:
					return dailyMultiplicationFactsData;
				default:
					return dailyDivisionFactsData;
			}
		}

		private static String getFactsFilename (MathOperationTypeEnum operation)
		{
			switch (operation)
			{
				case MathOperationTypeEnum.ADDITION:
					return ADDITION;
				case MathOperationTypeEnum.SUBTRACTION:
					return SUBTRACTION;
				case MathOperationTypeEnum.MULTIPLICATION:
					return MULTIPLICATION;
				default:
					return DIVISION;
			}
		}

		public static String getFactResponseTimeFilename  ()
		{
			return System.IO.Path.Combine (userPath, FACT_RESPONSE_TIME);
		}

		/*
		 * Determine which filename should be used.
		 */
		public static string getDailyFactsFilename (MathOperationTypeEnum operationType, bool knownFile)
		{
			switch (operationType)
			{
				case MathOperationTypeEnum.ADDITION:
					if (knownFile)
					{
						return System.IO.Path.Combine (knownFactsPath, ADDITION);
					}
					else
					{
						return System.IO.Path.Combine (unknownFactsPath, ADDITION);
					}
				case MathOperationTypeEnum.SUBTRACTION:
					if (knownFile)
					{
						return System.IO.Path.Combine (knownFactsPath, SUBTRACTION);
					}
					else
					{
						return System.IO.Path.Combine (unknownFactsPath, SUBTRACTION);
					}
				case MathOperationTypeEnum.MULTIPLICATION:
					if (knownFile)
					{
						return System.IO.Path.Combine (knownFactsPath, MULTIPLICATION);
					}
					else
					{
						return System.IO.Path.Combine (unknownFactsPath, MULTIPLICATION);
					}
				default:
					if (knownFile)
					{
						return System.IO.Path.Combine (knownFactsPath, DIVISION);
					}
					else
					{
						return System.IO.Path.Combine (unknownFactsPath, DIVISION);
					}
			}
		}
	#endregion

		#region File write operations

 		public void updateUserProfile (UserProfile profile)
		{
			try
			{
				using (System.IO.StreamWriter file = new System.IO.StreamWriter (userFilename))
				{
					file.WriteLine (profile.user.name);
					for (int index = 0; index < profile.maxFactNumbers.Count (); ++index)
					{
						file.WriteLine (profile.maxFactNumbers[index]);
					}
					file.WriteLine (profile.hasCustomSpeedFacts.ToString());
					file.WriteLine (profile.maxDaysBetweenSpeedTests);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine (e);
			}
		}
		
		/*
		 * Updates the current user in the file system.
		 */
		private static void updateUsersData (String username)
		{
			try
			{
				using (System.IO.StreamWriter file = new System.IO.StreamWriter (usersDataFilename))
				{
					file.WriteLine (username);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine (e);
			}
		}

		/*
		 * Saves the current date for the given math fact operation.
		 */
		public static void writeDailyFactsDateDataToFile (String date, MathOperationTypeEnum operation)
		{
			try
			{
				using (System.IO.StreamWriter fileWriter = System.IO.File.AppendText (getDailyFactsDataFilename (operation)))
				{
					fileWriter.WriteLine (date);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine (e);
			}	
		}

		public void saveCustomSpeedFacts (MathOperation operation, List<Fact> speedFacts)
		{
			String speedFactsFilename = System.IO.Path.Combine (speedTestPath, operation.ToString () + ".txt");

			using (System.IO.StreamWriter file = new System.IO.StreamWriter (speedFactsFilename))
			{
				foreach (Fact speedFact in speedFacts)
				{
					file.WriteLine (speedFact.leftNum);
					file.WriteLine (speedFact.rightNum);
				}
			}
		}

		public void updateUserDirectoryName (String newUsername)
		{
			String newUserPath = System.IO.Path.Combine (usersPath, newUsername);
			System.IO.Directory.Move (userPath, newUserPath);
		}

		public void	saveResponseData (int[] incorrectResponses, Fact[] unknownFacts, String username, MathOperationTypeEnum operation)
		{
			Data.UserDataSetTableAdapters.ResponseDataTableAdapter responseDataTableAdapter = new Data.UserDataSetTableAdapters.ResponseDataTableAdapter ();
			DateTime date = DateTime.Today.Date;
			System.Text.StringBuilder responseStringBuilder = new System.Text.StringBuilder ();

			// Create a formatted response string.
			for (int index = 0; index < unknownFacts.Count (); ++index)
			{
				responseStringBuilder.Append ("\n");
				responseStringBuilder.Append (unknownFacts[index].ToString ());
				responseStringBuilder.Append (" = ");
				responseStringBuilder.Append(incorrectResponses[index].ToString ());
			}

			try
			{
				responseDataTableAdapter.Insert (username, date, (int) operation, responseStringBuilder.ToString ());
			}
			catch (Exception e)
			{
				// TODO Handle exceptions
				Console.WriteLine (e.StackTrace);
			}
		}

		#endregion

		#region File read operations

		/*
		 * Returns the last user logged in.
		 */
		public String loadCurrentUsername ()
		{
			try
			{
				using (System.IO.StreamReader din = System.IO.File.OpenText (usersDataFilename))
				{
					return din.ReadLine ();
				}
			}
			catch (Exception)
			{
				return  "";
			}
		}
		
		/*
		 * Returns a list of all the current users.
		 */
		public static List<String> loadUsers ()
		{
			try
			{
				List<String> users = new List<String> ();
				String[] userDirectories = System.IO.Directory.GetDirectories (usersPath);

				foreach (string userDirectory in userDirectories)
				{
					users.Add (new System.IO.DirectoryInfo (userDirectory).Name);
				}

				return users;
			}
			catch (Exception)
			{
				return null;
			}
		}

		/*
		 * Retrieves the last date a daily fact was run for the given operation.
		 */
		public String readDailyFactsDateDataFromFile (MathOperationTypeEnum operation)
		{
			try
			{
				String dateLog = getDailyFactsDataFilename (operation);
				
				// Check if more than 1 month has elapsed since the last speed test.
				using (System.IO.StreamReader file = new System.IO.StreamReader (dateLog))
				{
					DateTime dateOfFirstSpeedTest = Convert.ToDateTime (file.ReadLine ());
					if (DateTime.Today.AddMonths (1) <= dateOfFirstSpeedTest)
					{
						// Overwrite the current file to avoid saving more than 30 days of data at a time.
						System.IO.File.Create (dateLog);
						return "MAX_TIME_ELAPSED";
					}

					return System.IO.File.ReadLines (dateLog).Last ();
				}
			}
			catch (Exception)
			{
				return "";
			}
		}

		public UserProfile loadUserProfile ()
		{
			try
			{
				using (System.IO.StreamReader file = new System.IO.StreamReader (userFilename))
				{
					String username = file.ReadLine ();
					int[] maxFactNumbers = new int[4]; 
					for (int index = 0; index < maxFactNumbers.Count (); ++index)
					{
						maxFactNumbers[index] = Convert.ToInt32 (file.ReadLine ());
					}

					Boolean hasCustomSpeedFacts = Convert.ToBoolean (file.ReadLine ());
					int maxDaysBetweenSpeedTests = Convert.ToInt32 (file.ReadLine ());
					return new UserProfile (new User (username), maxFactNumbers, hasCustomSpeedFacts, maxDaysBetweenSpeedTests);
				}
			}
			catch (Exception)
			{
				return new UserProfile();
			}
		}

		public static List<Fact> loadDefaultSpeedFacts (MathOperation operation)
		{
			List<Fact> speedFactsList = new List<Fact> ();
			String speedFactsString = "";
			
			switch (operation.operationType)
			{
				case MathOperationTypeEnum.ADDITION:
					speedFactsString = Properties.Resources.AdditionSpeedFacts;
					break;
				case MathOperationTypeEnum.SUBTRACTION:
					speedFactsString = Properties.Resources.SubtractionSpeedFacts;
					break;
				case MathOperationTypeEnum.MULTIPLICATION:
					speedFactsString = Properties.Resources.MultiplicationSpeedFacts;
					break;
				case MathOperationTypeEnum.DIVISION:
					speedFactsString = Properties.Resources.DivisionSpeedFacts;
					break;
			}

			int[] speedFactDataArray = speedFactsString.Split (' ', '\n').Select (n => Convert.ToInt32 (n)).ToArray ();

			Fact speedFact = new Fact ();
			speedFact.operation = operation;

			for (int index = 0; index < speedFactDataArray.Count (); ++index)
			{
				speedFact.leftNum = speedFactDataArray[index++];
				speedFact.rightNum = speedFactDataArray[index];
				speedFactsList.Add (speedFact);
			}
			
			return speedFactsList;
		}

		public static List<Fact> loadCustomSpeedFacts (MathOperation operation)
		{
			List<Fact> speedFactsList = new List<Fact> ();
			Fact speedFact = new Fact ();
			speedFact.operation = operation;

			String speedFactsFilename = System.IO.Path.Combine (speedTestPath, operation.ToString () + ".txt");

			using (System.IO.StreamReader file = new System.IO.StreamReader (speedFactsFilename))
			{
				String speedFactNumber;
				while ((speedFactNumber = file.ReadLine ()) != null)
				{
					speedFact.leftNum = System.Convert.ToInt32 (speedFactNumber);

					if ((speedFactNumber = file.ReadLine ()) != null)
					{
						speedFact.rightNum = System.Convert.ToInt32 (speedFactNumber);
						speedFactsList.Add (speedFact);
					}
				}
			}

			return speedFactsList;
		}

		#endregion
	}
}