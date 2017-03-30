using System;
using System.Collections.Generic;
using System.Linq;

namespace CanonicalEquation.Equations
{
	public class EquationCompressor : IEquationCompressor
	{
		public List<Operand> Compress(List<Operand> operands)
		{
			for (var i = 0; i < operands.Count; i++)
			{
				var firstOperand = operands[i];
				for (var j = i+1; j < operands.Count; j++)
				{
					var secondOperand = operands[j];
					if (!IsSimilar(firstOperand, secondOperand))
						continue;

					firstOperand.Coefficient += secondOperand.Coefficient;
					operands.RemoveAt(j);
				}
			}

			// remove operands with zero coefficients
			operands.RemoveAll(o => Math.Abs(o.Coefficient) < 0.001f);

			return operands;
		}

		private static bool IsSimilar(Operand firstOperand, Operand secondOperand)
		{
			var sortedFirstVars = SortVariables(firstOperand.Variables);
			var sortedSecondVars = SortVariables(secondOperand.Variables);
			return sortedFirstVars.SequenceEqual(sortedSecondVars);
		}

		private static IEnumerable<Variable> SortVariables(IEnumerable<Variable> variables)
		{
			return variables.OrderBy(v => v.Name).ThenByDescending(v => v.Power);
		}
	}
}