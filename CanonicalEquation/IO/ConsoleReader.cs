using System;
using System.Collections.Generic;

namespace CanonicalEquation.IO
{
	public class ConsoleReader : IInputReader
	{
		public IEnumerable<string> Read()
		{
			Console.WriteLine("Enter equation and press Enter. Press Ctrl+C to exit");
			var input = Console.ReadLine();

			return new[] { input };
		}
	}
}