namespace KnowYourFacts
{
	/*
	 * A class to hold the first name of a user.
	 */
	public class User
	{
		private string m_username;

		public User ()
		{
		}

		public User (string user)
		{
			m_username = user;
		}

		public void setUsername (string name)
		{
			m_username = name;
		}

		public string getUsername ()
		{
			return m_username;
		}
	}
}
