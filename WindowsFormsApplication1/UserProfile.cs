using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KnowYourFacts
{
	/*
	 * Class for retrieving of stored user profiles.
	 */
	class UserProfile : User
	{
		const string USER_PROFILES = "UserProfiles.txt";

		public UserProfile () :
			base ()
		{
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
			List<User> profiles = null;

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

				return profiles.First ().getUsername ();
			}
			catch (Exception)
			{
				// Display message that there was a problem reading the user data from the file.			
				return null;
			}
		}
	}
}