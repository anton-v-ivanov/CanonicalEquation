using System;
using System.Collections.Generic;
using System.IO;

namespace CanonicalEquation.IO
{
	public class FileReader : IInputReader
	{
		private readonly string _fileName;

		public FileReader(string fileName)
		{
			_fileName = fileName;
		}

		public IEnumerable<string> Read()
		{
			if(!File.Exists(_fileName))
				throw new FileNotFoundException("Input file not found", _fileName);

			return File.ReadAllLines(_fileName);
		}
	}
}