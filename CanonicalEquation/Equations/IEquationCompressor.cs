using System.Collections.Generic;

namespace CanonicalEquation.Equations
{
	public interface IEquationCompressor
	{
		/// <summary>
		/// Find similar operands and remove it counting coefficients
		/// </summary>
		/// <param name="operands"></param>
		/// <returns></returns>
		List<Operand> Compress(List<Operand> operands);
	}
}