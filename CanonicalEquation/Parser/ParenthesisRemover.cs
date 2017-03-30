using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CanonicalEquation.Parser
{
	public class ParenthesisRemover : IParenthesisRemover
	{
		private readonly char[] _operators;

		public ParenthesisRemover()
		{
			_operators = new[] { Symbols.Plus, Symbols.Minus };
		}

		public string Remove(string input)
		{
			var outList = new List<char>();

			foreach (var ch in input)
			{
				if (ch == Symbols.CloseParenthesis)
				{
					// found ')' symbol
					// going back to list to find corresponding '(' symbol
					for (var i = outList.Count - 1; i >= 0; i--)
					{
						if (outList[i] != Symbols.OpenParenthesis)
							continue;
						if (i <= 0)
							break;

						// get modification sign previous to '('
						if (!IsOperator(outList[i - 1]))
							continue;

						var modificationOperator = outList[i - 1];

						// if modification operator is plus, we don't need to do anything
						if (modificationOperator != Symbols.Minus)
							continue;

						// if modification operator is minus, we need to switch operators in parenthesis
						for (var j = i; j < outList.Count; j++)
						{
							if (!IsOperator(outList[j]))
								continue;

							outList[j] = outList[j] == Symbols.Plus ? Symbols.Minus : Symbols.Plus;
						}
					}
				}
				else if(!char.IsWhiteSpace(ch))
				{
					outList.Add(ch);
				}
			}

			// remove parenthesis
			outList.RemoveAll(s => s == Symbols.OpenParenthesis || s == Symbols.CloseParenthesis);

			// we might get ambiguous equation after switching signs and removing parenthesis (e.g. x^2-(-3.5xy+y) --> x^2-+3.5xy-y
			// so we need to remove first sign (which was a modification sign
			for (var i = 0; i < outList.Count; i++)
			{
				if (i >= outList.Count - 1)
					break;

				if (IsOperator(outList[i]) && IsOperator(outList[i + 1]) && outList[i] != outList[i + 1])
				{
					outList.RemoveAt(i);
				}
			}

			var result = new StringBuilder();
			foreach (var token in outList)
			{
				result.Append(token);
			}

			return result.ToString();
		}

		private bool IsOperator(char ch)
		{
			return _operators.Contains(ch);
		}
	}
}