using System.Collections.Generic;
using System.Linq;

namespace CanonicalEquation.Equations
{
	public class EquationMover : IEquationMover
	{
		public List<Operand> MoveToLeft(Equation equation)
		{
			var left = equation.LeftOperands.ToList();
			foreach (var operand in equation.RightOperands)
			{
				operand.Coefficient *= -1;
				left.Add(operand);
			}

			return left;
		}
	}
}