namespace CanonicalEquation.Parser
{
	public interface IParenthesisRemover
	{
		/// <summary>
		/// Remove parenthesis respecting modified sign before it
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		string Remove(string input);
	}
}