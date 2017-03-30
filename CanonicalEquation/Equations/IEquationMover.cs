using System.Collections.Generic;

namespace CanonicalEquation.Equations
{
	public interface IEquationMover
	{
		/// <summary>
		/// Move operand of equation to left part respecting math rules
		/// </summary>
		/// <param name="equation"></param>
		/// <returns></returns>
		List<Operand> MoveToLeft(Equation equation);
	}
}