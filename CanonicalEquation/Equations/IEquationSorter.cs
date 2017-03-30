using System.Collections.Generic;

namespace CanonicalEquation.Equations
{
	public interface IEquationSorter
	{
		/// <summary>
		/// Sort operands from bigger power to lower
		/// </summary>
		/// <param name="operands"></param>
		/// <returns></returns>
		List<Operand> Sort(List<Operand> operands);
	}
}