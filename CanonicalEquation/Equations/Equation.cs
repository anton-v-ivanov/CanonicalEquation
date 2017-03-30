using System.Collections.Generic;

namespace CanonicalEquation.Equations
{
	public class Equation
	{
		public readonly IEnumerable<Operand> LeftOperands;
		public readonly IEnumerable<Operand> RightOperands;

		public Equation(IEnumerable<Operand> left, IEnumerable<Operand> right)
		{
			LeftOperands = left;
			RightOperands = right;
		}
	}
}