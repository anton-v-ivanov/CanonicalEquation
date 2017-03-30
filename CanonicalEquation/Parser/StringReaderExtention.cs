using System.IO;

namespace CanonicalEquation.Parser
{
	public static class StringReaderExtention
	{
		public static bool TryGetNextChar(this StringReader reader, out char ch)
		{
			var curr = reader.Read();
			if (curr != -1)
			{
				ch = (char) curr;
				return true;
			}

			ch = default(char);
			return false;
		}
	}
}