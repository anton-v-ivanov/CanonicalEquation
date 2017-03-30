using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using CanonicalEquation.IO;
using CanonicalEquation.Parser;

namespace CanonicalEquation.Equations
{
	public class EquationTransformer : IEquationTransformer
	{
		private readonly IEquationParser _parser;
		private readonly IEquationMover _mover;
		private readonly IEquationCompressor _compressor;
		private readonly IEquationSorter _sorter;

		public EquationTransformer()
		{
			_parser = new EquationParser();
			_mover = new EquationMover();
			_compressor = new EquationCompressor();
			_sorter = new EquationSorter();
		}

		public string Transform(IInputReader reader)
		{
			var equationStrings = reader.Read();
			var result = new StringBuilder();
			var count = 0;
			foreach (var equationString in equationStrings)
			{
				if (count > 0)
				{
					result.Append(Environment.NewLine);
				}

				// parse string to equation with parenthesis removed (opened according to rules)
				var equation = _parser.Parse(equationString);
				
				// move operand to left part
				var operands = _mover.MoveToLeft(equation);

				// find similar operands and count coefficients
				operands = _compressor.Compress(operands);
				
				// sort operands from bigger power to lower
				operands = _sorter.Sort(operands);

				// convert equation to string
				var resultString = $"{ConvertToString(operands)} = 0";
				result.Append(resultString);
				count++;
			}

			return result.ToString();
		}

		private static string ConvertToString(IList<Operand> operands)
		{
			var result = new StringBuilder();
			for (var i = 0; i < operands.Count; i++)
			{
				var operand = operands[i];
				if (i == 0)
				{
					if(operand.Coefficient < 0)
						result.Append("-");
				}
				else
					result.AppendFormat(" {0} {1}", 
						operand.Coefficient > 0 ? "+":"-", 
						Math.Abs(Math.Abs(operand.Coefficient) - 1) > 0.001f ? operand.Coefficient.ToString(CultureInfo.InvariantCulture) : string.Empty);

				if (operand.Variables == null)
					continue;

				foreach (var variable in operand.Variables)
				{
					if (variable.Power != 1)
						result.AppendFormat("{0}^{1}", variable.Name, variable.Power);
					else
						result.Append(variable.Name);
				}
			}
			return result.ToString();
		}
	}
}