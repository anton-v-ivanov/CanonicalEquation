using System;

namespace CanonicalEquation.IO
{
	public class ConsoleWriter : IOutputWriter
	{
		public void Write(string equation)
		{
			Console.WriteLine(equation);
		}
	}
}