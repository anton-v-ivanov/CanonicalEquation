using CanonicalEquation.Equations;

namespace CanonicalEquation.Parser
{
	public interface IOperandFabric
	{
		/// <summary>
		/// Convert string to operand
		/// </summary>
		/// <param name="strOperand"></param>
		/// <returns></returns>
		Operand FromString(string strOperand);
	}
}