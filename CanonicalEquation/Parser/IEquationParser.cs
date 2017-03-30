using CanonicalEquation.Equations;

namespace CanonicalEquation.Parser
{
	public interface IEquationParser
	{
		/// <summary>
		/// Parse string to equation with parenthesis removed (opened according to rules)
		/// </summary>
		/// <param name="equation"></param>
		/// <returns></returns>
		Equation Parse(string equation);
	}
}