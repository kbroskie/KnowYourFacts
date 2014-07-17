namespace KnowYourFacts
{
	// Holds two integers and a MathOperation associated with a math fact.
	public struct Fact
	{
		public int leftNum;
		public int rightNum;
		public MathOperation operation;

		public Fact(int leftNum, int rightNum, MathOperation operation)
		{
			this.leftNum = leftNum;
			this.rightNum = rightNum;
			this.operation = operation;
		}
	}
}