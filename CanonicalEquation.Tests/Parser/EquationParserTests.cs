using System.Collections.Generic;
using System.Linq;
using CanonicalEquation.Equations;
using CanonicalEquation.Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CanonicalEquation.Tests.Parser
{
	[TestClass]
	public class EquationParserTests
	{
		private IEquationParser _sut;

		[TestInitialize]
		public void Prepare()
		{
			_sut = new EquationParser();
		}

		[TestMethod]
		public void TestParse()
		{
			const string input = "x^2 + 3.5xy + y = y^2 - xy + y";
			var left = new List<Operand>
			{
				new Operand(1)
				{
					Variables = new List<Variable>
					{
						new Variable('x', 2)
					}
				},
				new Operand(3.5f)
				{
					Variables = new List<Variable>
					{
						new Variable('x', 1),
						new Variable('y', 1)
					}
				},
				new Operand(1)
				{
					Variables = new List<Variable>
					{
						new Variable('y', 1)
					}
				},
			};
			var right = new List<Operand>()
			{
				new Operand(1)
				{
					Variables = new List<Variable>
					{
						new Variable('y', 2)
					}
				},
				new Operand(-1)
				{
					Variables = new List<Variable>
					{
						new Variable('x', 1),
						new Variable('y', 1)
					}
				},
				new Operand(1)
				{
					Variables = new List<Variable>
					{
						new Variable('y', 1)
					}
				},
			};

			var expected = new Equation(left, right);
			var actual = _sut.Parse(input);

			Assert.AreEqual(expected.LeftOperands.Count(), actual.LeftOperands.Count());
			Assert.AreEqual(expected.RightOperands.Count(), actual.RightOperands.Count());
			Assert.IsTrue(expected.LeftOperands.SequenceEqual(actual.LeftOperands));
			Assert.IsTrue(expected.RightOperands.SequenceEqual(actual.RightOperands));
		}
	}
}