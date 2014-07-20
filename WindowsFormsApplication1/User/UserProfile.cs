namespace KnowYourFacts
{
	/*
	 * Struct for storing & retrieving user profiles.
	 */
	public struct UserProfile
	{
		public User user;
		public int maxFactNumber;
		public bool hasCustomSpeedFacts;

		public UserProfile (User user, int maxFactNumber)
		{
			this.user = user;
			this.maxFactNumber = maxFactNumber;
			this.hasCustomSpeedFacts = false;
		}
	}
}