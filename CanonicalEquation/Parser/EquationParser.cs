using System;
using System.Collections.Generic;
using System.Linq;
using CanonicalEquation.Equations;

namespace CanonicalEquation.Parser
{
	public class EquationParser : IEquationParser
	{
		private readonly IParenthesisRemover _parenthesisRemover;
		private readonly IOperandFabric _operandFabric;

		public EquationParser()
		{
			_parenthesisRemover = new ParenthesisRemover();
			_operandFabric = new OperandFabric();
		}

		public Equation Parse(string equation)
		{
			if (string.IsNullOrWhiteSpace(equation))
				throw new ArgumentNullException(equation, "Equation can't be empty");

			if (!equation.Contains("="))
				throw new FormatException("Equation must contain '=' symbol");

			var temp = equation.Split(new[] { Symbols.Equality }, StringSplitOptions.RemoveEmptyEntries);

			// open parenthesises
			var left = _parenthesisRemover.Remove(temp[0]);
			var right = _parenthesisRemover.Remove(temp[1]);

			var leftOperands = ParseToOperands(left);
			var rightOperands = ParseToOperands(right);

			return new Equation(leftOperands, rightOperands);
		}

		private IEnumerable<Operand> ParseToOperands(string input)
		{
			var operators = new[] { Symbols.Plus, Symbols.Minus };
			var strOperands = new List<string>();

			var current = string.Empty;
			foreach (var ch in input)
			{
				if (operators.Contains(ch))
				{
					if(!string.IsNullOrEmpty(current))
						strOperands.Add(current);
					current = string.Empty;
				}
				current += ch;
			}
			strOperands.Add(current);

			return strOperands.Select(s => _operandFabric.FromString(s)).ToList();
		}
	}
}