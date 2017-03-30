using System.Collections.Generic;

namespace CanonicalEquation.IO
{
	public interface IInputReader
	{
		IEnumerable<string> Read();
	}
}