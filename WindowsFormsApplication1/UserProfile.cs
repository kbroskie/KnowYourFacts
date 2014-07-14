﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KnowYourFacts
{
	/*
	 * Struct for storing & retrieving user profiles.
	 */
	public struct UserProfile
	{
		const string USER_PROFILES = "UserProfiles.txt";

		public User user;
		
		public UserProfile (User user)
		{
			this.user = user;
		}
			
		public bool checkForProfiles ()
		{
			try
			{
				File.OpenText (USER_PROFILES);
				return true;
			}
			catch (FileNotFoundException)
			{
				return false;
			}
		}

		public string getLastProfileLoaded ()
		{
			List<User> profiles = new List<User>();

			try
			{
				string name = "";

				StreamReader din = File.OpenText (USER_PROFILES);

				// Read the items in the file.
				while ((name = din.ReadLine ()) != null)
				{
					profiles.Add (new User (name));
				}
				din.Close ();

				return profiles.First ().name;
			}
			catch (Exception)
			{
				// Display message that there was a problem reading the user data from the file.			
				return null;
			}
		}
	}
}