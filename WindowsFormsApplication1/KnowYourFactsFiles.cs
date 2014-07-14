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

		private KnowYourFactsFiles ()
		{
			topLevelDirectory = System.IO.Path.Combine (userDirectory, "Know Your Facts");
			usersPath = System.IO.Path.Combine (topLevelDirectory, "Users");
			speedFactsPath = System.IO.Path.Combine (topLevelDirectory, "SpeedFacts");
			
			usersDataFilename = System.IO.Path.Combine (usersPath, usersData);
		}

		public bool mainDirectoryExists ()
		{
			return (System.IO.File.Exists (topLevelDirectory));
		}

		public bool userDirectoryExists (User user)
		{
			return (System.IO.File.Exists (System.IO.Path.Combine (usersPath, user.name)));
		}

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

		public void createNewUserDirectory (User newUser)
		{
			// Create the individual user directories.
			String userPath = System.IO.Path.Combine (usersPath, newUser.name);
			paths.Add (userPath);

			// Create the individual user subdirectories.
			String dailyFactsPath = System.IO.Path.Combine (userPath, "dailyFactsData");
			paths.Add (dailyFactsPath);

			String unknownFactsPath = System.IO.Path.Combine (userPath, "unknownFacts");
			paths.Add (unknownFactsPath);

			String knownFactsPath = System.IO.Path.Combine (userPath, "knownFacts");
			paths.Add (knownFactsPath);

			String speedTestPath = System.IO.Path.Combine (userPath, "speedTest");
			paths.Add (speedTestPath);

			String customSpeedTestPath = System.IO.Path.Combine (speedTestPath, "custom");

			// Create the individual user files.
			String dailyAdditionFactsData = System.IO.Path.Combine (dailyFactsPath, additionFilename);
			String dailySubtractionFactsData = System.IO.Path.Combine (dailyFactsPath, subtractionFilename);
			String dailyMultiplicationFactsData = System.IO.Path.Combine (dailyFactsPath, multiplicationFilename);
			String dailyDivisionFactsData = System.IO.Path.Combine (dailyFactsPath, divisionFilename);

			files.Add (dailyAdditionFactsData);
			files.Add (dailySubtractionFactsData);
			files.Add (dailyMultiplicationFactsData);
			files.Add (dailyDivisionFactsData);

			String userProfileFilename = "profile.txt";
			String userFilename = System.IO.Path.Combine (userPath, userProfileFilename);
			files.Add (userFilename);

			String speedAdditionFactsData = System.IO.Path.Combine (speedTestPath, additionFilename);
			String speedSubtractionFactsData = System.IO.Path.Combine (speedTestPath, subtractionFilename);
			String speedMultiplicationFactsData = System.IO.Path.Combine (speedTestPath, multiplicationFilename);
			String speedDivisionFactsData = System.IO.Path.Combine (speedTestPath, divisionFilename);

			files.Add (speedAdditionFactsData);
			files.Add (speedSubtractionFactsData);
			files.Add (speedMultiplicationFactsData);
			files.Add (speedDivisionFactsData);

			createFilesAndDirectories ();
			updateUsersData (newUser.name);
		}

		public void createFilesAndDirectories ()
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

		public static void updateUsersData (String username)
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
	}
}