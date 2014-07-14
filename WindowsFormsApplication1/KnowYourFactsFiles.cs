using System;
using System.IO;
using System.Collections.Generic;

namespace KnowYourFacts
{
	public class KnowYourFactsFiles
	{
		List<String> paths = new List<String> ();
		List<String> files = new List<String> ();

		static String userDirectory = Environment.GetFolderPath (Environment.SpecialFolder.UserProfile);
		static String topLevelDirectory;

		static String usersPath;
		String usersData = "usersData.txt";
		static String usersDataFilename;

		static String speedFactsPath;

		String additionFilename = "addition.txt";
		String subtractionFilename = "subtraction.txt";
		String multiplicationFilename = "multiplication.txt";
		String divisionFilename = "division.txt";
		
		String userProfileFilename = "profile.txt";
		static String userFilename;

		static String userPath;
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
		
		static KnowYourFactsFiles instanceKnowYourFactsFiles;

		public static KnowYourFactsFiles Instance
		{
			get
			{
				if (instanceKnowYourFactsFiles == null)
				{
					instanceKnowYourFactsFiles = new KnowYourFactsFiles ();
				}
				return instanceKnowYourFactsFiles;
			}
		}

		// Singleton constructor
		private KnowYourFactsFiles ()
		{
			topLevelDirectory = System.IO.Path.Combine (userDirectory, "Know Your Facts");
			usersPath = System.IO.Path.Combine (topLevelDirectory, "Users");
			speedFactsPath = System.IO.Path.Combine (topLevelDirectory, "SpeedFacts");
			usersDataFilename = System.IO.Path.Combine (usersPath, usersData);
		}

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
			return (System.IO.File.Exists (System.IO.Path.Combine (usersPath, user.name)));
		}

		/*
		 * Creates the default directories for the application.
		 */ 
		public void createDefaultProgramDirectory ()
		{
			paths.Add (topLevelDirectory);
			paths.Add (usersPath);
			paths.Add (speedFactsPath);

			// Create the default speed test files.
			String additionSpeedTestFilename = System.IO.Path.Combine (speedFactsPath, additionFilename);
			String subtractionSpeedTestFilename = System.IO.Path.Combine (speedFactsPath, subtractionFilename);
			String multiplicationSpeedTestFilename = System.IO.Path.Combine (speedFactsPath, multiplicationFilename);
			String divisionSpeedTestFilename = System.IO.Path.Combine (speedFactsPath, divisionFilename);

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
		public void createNewUserDirectory (User newUser)
		{
			// Create the individual user directories.
			userPath = System.IO.Path.Combine (usersPath, newUser.name);
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
			dailyAdditionFactsData = System.IO.Path.Combine (dailyFactsPath, additionFilename);
			dailySubtractionFactsData = System.IO.Path.Combine (dailyFactsPath, subtractionFilename);
			dailyMultiplicationFactsData = System.IO.Path.Combine (dailyFactsPath, multiplicationFilename);
			dailyDivisionFactsData = System.IO.Path.Combine (dailyFactsPath, divisionFilename);

			files.Add (dailyAdditionFactsData);
			files.Add (dailySubtractionFactsData);
			files.Add (dailyMultiplicationFactsData);
			files.Add (dailyDivisionFactsData);

			userFilename = System.IO.Path.Combine (userPath, userProfileFilename);
			files.Add (userFilename);

			speedAdditionFactsDataFilename = System.IO.Path.Combine (speedTestPath, additionFilename);
			speedSubtractionFactsDataFilename = System.IO.Path.Combine (speedTestPath, subtractionFilename);
			speedMultiplicationFactsDataFilename = System.IO.Path.Combine (speedTestPath, multiplicationFilename);
			speedDivisionFactsDataFilename = System.IO.Path.Combine (speedTestPath, divisionFilename);

			files.Add (speedAdditionFactsDataFilename);
			files.Add (speedSubtractionFactsDataFilename);
			files.Add (speedMultiplicationFactsDataFilename);
			files.Add (speedDivisionFactsDataFilename);

			createFilesAndDirectories ();
			updateUsersData (newUser.name);
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
					System.IO.File.Create (file);
				}
			}
		}

		/*
		 * Returns the last user logged in.
		 */ 
		public String loadCurrentUsername ()
		{
			StreamReader din = File.OpenText (usersDataFilename);
			String username;

			try
			{
				username = din.ReadLine ();
			}
			catch (Exception)
			{
				username = "";
			}
			finally
			{
				din.Close ();
			}
			return username;
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

				dailyAdditionFactsData = System.IO.Path.Combine (dailyFactsPath, additionFilename);
				dailySubtractionFactsData = System.IO.Path.Combine (dailyFactsPath, subtractionFilename);
				dailyMultiplicationFactsData = System.IO.Path.Combine (dailyFactsPath, multiplicationFilename);
				dailyDivisionFactsData = System.IO.Path.Combine (dailyFactsPath, divisionFilename);

				userFilename = System.IO.Path.Combine (userPath, userProfileFilename);

				speedAdditionFactsDataFilename = System.IO.Path.Combine (speedTestPath, additionFilename);
				speedSubtractionFactsDataFilename = System.IO.Path.Combine (speedTestPath, subtractionFilename);
				speedMultiplicationFactsDataFilename = System.IO.Path.Combine (speedTestPath, multiplicationFilename);
				speedDivisionFactsDataFilename = System.IO.Path.Combine (speedTestPath, divisionFilename);
			}
		}

		/*
		 * Updates the current user in the file system.
		 */ 
		private static void updateUsersData (String username)
		{
			try
			{
				StreamWriter sw = new StreamWriter (usersDataFilename);
				sw.Write (username);
				sw.Close ();
			}	
			catch (Exception e)	
			{
				Console.WriteLine(e);
			}
		}

		/*
		 * Returns a list of all the current users.
		 */  
		public static List<String> loadUsers ()
		{
			List <String> users = new List<String> ();
			String[] userDirectories = Directory.GetDirectories (usersPath);
			
			foreach (string userDirectory in userDirectories)
			{
				users.Add (new DirectoryInfo(userDirectory).Name);
			}

			return users;
		}

		/*
		 * Saves the current date for the given math fact operation.
		 */ 
		public static void writeDailyFactsDateDataToFile (String date, MathOperationTypeEnum operation)
		{
			String fileToSaveDataTo = getDailyFactsDataFilename (operation);
			Console.WriteLine (fileToSaveDataTo);

			StreamWriter fileWriter = new StreamWriter (fileToSaveDataTo, true);
			fileWriter.Write (date);
			fileWriter.Close ();	
		}

		/*
		 * Retrieves the last date a daily fact was run for the given operation.
		 */ 
		public String readDailyFactsDateDataFromFile (MathOperationTypeEnum operation)
		{
			String fileToReadDataFrom = getDailyFactsDataFilename (operation);

			StreamReader fileReader = new StreamReader (fileToReadDataFrom);
			String lastDateUsed = fileReader.ReadLine ();
			fileReader.Close ();

			return lastDateUsed;
		}
 
		private static String getDailyFactsDataFilename (MathOperationTypeEnum operation)
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
	}
}