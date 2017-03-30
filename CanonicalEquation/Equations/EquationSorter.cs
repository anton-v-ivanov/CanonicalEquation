using System.Collections.Generic;
using System.Linq;

namespace CanonicalEquation.Equations
{
	public class EquationSorter : IEquationSorter
	{
		public List<Operand> Sort(List<Operand> operands)
		{
			return operands.OrderByDescending(o => o.Variables.Any() ? o.Variables.Max(v => v.Power) : 0).ToList();
		}
	}
}