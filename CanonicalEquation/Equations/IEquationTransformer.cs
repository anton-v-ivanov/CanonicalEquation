using CanonicalEquation.IO;

namespace CanonicalEquation.Equations
{
	public interface IEquationTransformer
	{
		/// <summary>
		/// Transforms equation to canonical form
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		string Transform(IInputReader reader);
	}
}