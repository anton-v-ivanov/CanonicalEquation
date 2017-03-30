using CanonicalEquation.Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CanonicalEquation.Tests.Parser
{
	[TestClass]
	public class ParenthesisRemoverTests
	{
		private IParenthesisRemover _sut;

		[TestInitialize]
		public void Prepare()
		{
			_sut = new ParenthesisRemover();	
		}

		[TestMethod]
		public void TestPlusBeforePerenthesis()
		{
			const string input = "x^2 + (3.5xy + xy^2)";
			const string expected = "x^2+3.5xy+xy^2";

			var actual = _sut.Remove(input);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void TestMinusBeforePerenthesisWithPlusInside()
		{
			const string input = "x^2 - (3.5xy + xy^2)";
			const string expected = "x^2-3.5xy-xy^2";

			var actual = _sut.Remove(input);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void TestMinusBeforePerenthesisWithMinusInside()
		{
			const string input = "x^2 - (3.5xy - xy^2)";
			const string expected = "x^2-3.5xy+xy^2";

			var actual = _sut.Remove(input);
			Assert.AreEqual(expected, actual);
		}
	}
}
