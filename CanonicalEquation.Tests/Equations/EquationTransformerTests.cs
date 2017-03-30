using System.Collections.Generic;
using CanonicalEquation.Equations;
using CanonicalEquation.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CanonicalEquation.Tests.Equations
{
	[TestClass()]
	public class EquationTransformerTests
	{
		private IEquationTransformer _sut;

		[TestInitialize]
		public void Prepare()
		{
			_sut = new EquationTransformer();
		}

		[TestMethod]
		public void TransformTest()
		{
			const string input = "x^2 + 3.5xy + y = y^2 - xy + y";
			IInputReader reader = new MockReader(input);
			const string expected = "x^2 - y^2 + 4.5xy = 0";
			var actual = _sut.Transform(reader);
			Assert.AreEqual(expected, actual);
		}

		private class MockReader : IInputReader
		{
			private readonly string _input;

			public MockReader(string input)
			{
				_input = input;
			}

			public IEnumerable<string> Read()
			{
				return new [] { _input };
			}
		}
	}
}