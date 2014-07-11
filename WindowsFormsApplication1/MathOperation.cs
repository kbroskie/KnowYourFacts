using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowYourFacts
{
	public class MathOperation
	{
		private MathOperationTypeEnum m_operationType;

		public MathOperation (MathOperationTypeEnum operationType)
		{
			m_operationType = operationType;
		}

		public string getOperationName ()
		{
			String operationName = m_operationType.ToString ();
			return operationName.Substring(0, 1) + operationName.Substring(1).ToLower ();
		}

		public MathOperationTypeEnum getOperationType ()
		{
			return m_operationType;
		}

		public void setOperationType (MathOperationTypeEnum oper)
		{
			m_operationType = oper;
		}

		public string getOperationSign ()
		{
			switch (m_operationType)
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
			if (operation.getOperationType () == MathOperationTypeEnum.ADDITION)
				return leftNum + rightNum;
			else if (operation.getOperationType () == MathOperationTypeEnum.SUBTRACTION)
				return leftNum - rightNum;
			else if (operation.getOperationType () == MathOperationTypeEnum.MULTIPLICATION)
				return leftNum * rightNum;
			else
				return leftNum / rightNum;
		}
	}
}
