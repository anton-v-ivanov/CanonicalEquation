using System;
using CanonicalEquation.Equations;
using CanonicalEquation.IO;

namespace CanonicalEquation
{
	class Program
	{
		static void Main(string[] args)
		{
			IEquationTransformer transformer = new EquationTransformer();
			IInputReader reader;
			IOutputWriter writer;

			// if no args specified, it's an interactive mode
			if (args.Length == 0)
			{
				writer = new ConsoleWriter();
				while (true)
				{
					reader = new ConsoleReader();
					try
					{
						var result = transformer.Transform(reader);
						writer.Write(result);
					}
					catch (Exception exception)
					{
						Console.WriteLine(exception);
						Console.Read();
					}
				}
			}

			// if there's argument, it's a file mode
			var fileName = args[0];
			reader = new FileReader(fileName);
			writer = new FileWriter($"{fileName}.out");
			
			try
			{
				var result = transformer.Transform(reader);
				writer.Write(result);
			}
			catch (Exception exception)
			{
				writer.Write(exception.ToString());
			}
		}
	}
}
