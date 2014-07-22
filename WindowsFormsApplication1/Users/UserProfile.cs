namespace KnowYourFacts.Users
{		
	/*
	 * Struct for storing & retrieving user profiles.
	 */
	public struct UserProfile
	{
		public User user;
		public int maxFactNumber;
		public bool hasCustomSpeedFacts;

		private const int DEFAULT_MAX_FACT_NUMBER = 10;

		public UserProfile (User user)
		{
			this.user = user;
			this.maxFactNumber = DEFAULT_MAX_FACT_NUMBER;
			this.hasCustomSpeedFacts = false;
		}
		
		public UserProfile (User user, int maxFactNumber)
		{
			this.user = user;
			this.maxFactNumber = maxFactNumber;
			this.hasCustomSpeedFacts = false;
		}

		public UserProfile (User user, int maxFactNumber, bool  hasCustomSpeedFacts)
		{
			this.user = user;
			this.maxFactNumber = maxFactNumber;
			this.hasCustomSpeedFacts = hasCustomSpeedFacts;
		}
	}
}