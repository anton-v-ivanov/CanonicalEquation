using System;
using System.Globalization;
using System.IO;
using CanonicalEquation.Equations;

namespace CanonicalEquation.Parser
{
	public class OperandFabric : IOperandFabric
	{
		public Operand FromString(string strOperand)
		{
			var operand = new Operand(1);

			using (var reader = new StringReader(strOperand))
			{
				char ch;
				while (reader.TryGetNextChar(out ch))
				{
					// reading sign
					if (ch == Symbols.Minus)
					{
						operand.Coefficient = -1;
						if (!reader.TryGetNextChar(out ch))
							break;
					}

					// reading coefficient
					var coeff = string.Empty;
					while (char.IsDigit(ch) || ch == Symbols.Dot)
					{
						coeff += ch;
						if (!reader.TryGetNextChar(out ch))
							break;
					}

					if (!string.IsNullOrEmpty(coeff))
						operand.Coefficient *= float.Parse(coeff, CultureInfo.InvariantCulture);

					// reading variables
					while(char.IsLetter(ch))
					{
						var varName = ch;
						var power = 1;

						if (reader.TryGetNextChar(out ch))
						{
							// variable has a power specified
							if (ch == Symbols.Power)
							{
								if (!reader.TryGetNextChar(out ch))
									throw new ArgumentException("Power sign is not followed by power digit");

								// reading power
								var powerStr = string.Empty;
								while (char.IsDigit(ch))
								{
									powerStr += ch;
									if (!reader.TryGetNextChar(out ch))
										break;
								}

								if (!string.IsNullOrEmpty(powerStr))
									power = int.Parse(powerStr);

								operand.Variables.Add(new Variable(varName, power));
							}
							else // variable has no power sign
							{
								operand.Variables.Add(new Variable(varName, power));
							}
						}
						else // end of variable
						{
							operand.Variables.Add(new Variable(varName, power));
							break;
						}
					}
				}
			}

			return operand;
		}
	}
}