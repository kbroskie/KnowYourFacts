using System;
using System.Collections.Generic;
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
			return System.IO.File.Exists (USER_PROFILES);
		}

		public string getLastProfileLoaded ()
		{
			string[] names;

			try
			{

				using (System.IO.StreamReader din = System.IO.File.OpenText (USER_PROFILES))
				{
					names = System.IO.File.ReadAllLines (USER_PROFILES);
				}
			}
			catch (Exception)
			{
				// Display message that there was a problem reading the user data from the file.			
				return null;
			}

			List<User> profiles = new List<User> ();
			foreach (String name in names)
			{
				profiles.Add (new User (name));
			}

			return profiles.First ().name;
		}
	}
}