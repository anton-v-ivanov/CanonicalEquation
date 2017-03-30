using System.IO;

namespace CanonicalEquation.IO
{
	public class FileWriter : IOutputWriter
	{
		private readonly string _fileName;

		public FileWriter(string fileName)
		{
			_fileName = fileName;
			if(File.Exists(_fileName))
				File.Delete(_fileName);
		}

		public void Write(string equation)
		{
			File.AppendAllLines(_fileName, new[] {equation});
		}
	}
}