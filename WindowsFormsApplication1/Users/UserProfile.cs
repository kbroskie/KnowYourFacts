using System.Linq;

namespace KnowYourFacts.Users
{		
	/*
	 * Struct for storing & retrieving user profiles.
	 */
	public struct UserProfile
	{
		public User user;
		public int[] maxFactNumbers;
		public bool hasCustomSpeedFacts;
		public int maxDaysBetweenSpeedTests;

		private const int DEFAULT_MAX_FACT_NUMBER = 10;
		private const int DEFAULT_MAX_DAYS_BETWEEN_SPEED_TESTS = 30;

		public UserProfile (User user)
		{
			this.user = user;

			maxFactNumbers = new int[4]; 
			for (int index = 0; index < maxFactNumbers.Count (); ++index)
			{
				maxFactNumbers[index] = DEFAULT_MAX_FACT_NUMBER;
			}
			this.hasCustomSpeedFacts = false;
			this.maxDaysBetweenSpeedTests = DEFAULT_MAX_DAYS_BETWEEN_SPEED_TESTS;
		}
		
		public UserProfile (User user, int[] maxFactNumbers)
		{
			this.user = user;
	
			this.maxFactNumbers = new int[4]; 
			for (int index = 0; index < maxFactNumbers.Count (); ++index)
			{
				this.maxFactNumbers[index] = maxFactNumbers[index];
			}
			this.hasCustomSpeedFacts = false;
			this.maxDaysBetweenSpeedTests = DEFAULT_MAX_DAYS_BETWEEN_SPEED_TESTS;
		}

		public UserProfile (User user, int[] maxFactNumbers, bool hasCustomSpeedFacts, int maxDaysBetweenSpeedTests)
		{
			this.user = user;
	
			this.maxFactNumbers = new int[4]; 
			for (int index = 0; index < maxFactNumbers.Count (); ++index)
			{
				this.maxFactNumbers[index] = maxFactNumbers[index];
			}
			this.hasCustomSpeedFacts = hasCustomSpeedFacts;
			this.maxDaysBetweenSpeedTests = maxDaysBetweenSpeedTests;
		}
	}
}