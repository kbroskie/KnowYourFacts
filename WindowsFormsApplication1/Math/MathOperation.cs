using System;

namespace KnowYourFacts.Math
{
	public struct MathOperation
	{
		public MathOperationTypeEnum operationType;

		public MathOperation (MathOperationTypeEnum operationType)
		{
			this.operationType = operationType;
		}

		public override string ToString ()
		{
			String operationName = operationType.ToString ();
			return operationName.Substring (0, 1) + operationName.Substring (1).ToLower ();
		}

		public String getOperationSign ()
		{
			switch (operationType)
			{
				case MathOperationTypeEnum.ADDITION:
					return "+";
				case MathOperationTypeEnum.SUBTRACTION:
					return "-";
				case MathOperationTypeEnum.MULTIPLICATION:
					return "×";
				case MathOperationTypeEnum.DIVISION:
					return "÷";
				default:
					return "";
			}
		}

		static public int calculateAnswer (int leftNum, int rightNum, MathOperation operation)
		{
			if (operation.operationType == MathOperationTypeEnum.ADDITION)
				return leftNum + rightNum;
			else if (operation.operationType == MathOperationTypeEnum.SUBTRACTION)
				return leftNum - rightNum;
			else if (operation.operationType == MathOperationTypeEnum.MULTIPLICATION)
				return leftNum * rightNum;
			else
				return leftNum / rightNum;
		}
	}
}
