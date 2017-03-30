using System.Collections.Generic;
using CanonicalEquation.Equations;
using CanonicalEquation.Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CanonicalEquation.Tests.Parser
{
	[TestClass]
	public class OperandFabricTests
	{
		private IOperandFabric _sut;

		[TestInitialize]
		public void Prepare()
		{
			_sut = new OperandFabric();
		}

		[TestMethod]
		public void ParsePositiveIntegerNumber()
		{
			const string input = "254";
			var expected = new Operand(254);

			var actual = _sut.FromString(input);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ParseNegativeIntegerNumber()
		{
			const string input = "-254";
			var expected = new Operand(-254);

			var actual = _sut.FromString(input);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ParsePositiveFloatNumber()
		{
			const string input = "25.4";
			var expected = new Operand(25.4f);

			var actual = _sut.FromString(input);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ParseNegativeFloatNumber()
		{
			const string input = "-25.4";
			var expected = new Operand(-25.4f);

			var actual = _sut.FromString(input);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ParseSigleVariable()
		{
			const string input = "x";
			var expected = new Operand(1)
			{
				Variables = new List<Variable>
				{
					new Variable('x', 1)
				}
			};

			var actual = _sut.FromString(input);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ParseDoubleVariable()
		{
			const string input = "xy";
			var expected = new Operand(1)
			{
				Variables = new List<Variable>
				{
					new Variable('x', 1),
					new Variable('y', 1)
				}
			};

			var actual = _sut.FromString(input);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ParseSigleVariableWithPositiveIntegerCoefficient()
		{
			const string input = "254x";
			var expected = new Operand(254)
			{
				Variables = new List<Variable>
				{
					new Variable('x', 1)
				}
			};

			var actual = _sut.FromString(input);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ParseSigleVariableWithNegativeIntegerCoefficient()
		{
			const string input = "-254x";
			var expected = new Operand(-254)
			{
				Variables = new List<Variable>
				{
					new Variable('x', 1)
				}
			};

			var actual = _sut.FromString(input);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ParseSigleVariableWithPositiveFloatCoefficient()
		{
			const string input = "25.4x";
			var expected = new Operand(25.4f)
			{
				Variables = new List<Variable>
				{
					new Variable('x', 1)
				}
			};

			var actual = _sut.FromString(input);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ParseSigleVariableWithNegativeFloatCoefficient()
		{
			const string input = "-25.4x";
			var expected = new Operand(-25.4f)
			{
				Variables = new List<Variable>
				{
					new Variable('x', 1)
				}
			};

			var actual = _sut.FromString(input);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ParseSigleVariableWithPower()
		{
			const string input = "x^2";
			var expected = new Operand(1)
			{
				Variables = new List<Variable>
				{
					new Variable('x', 2)
				}
			};

			var actual = _sut.FromString(input);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ParseDoubleVariableWithPower()
		{
			const string input = "x^4y^2";
			var expected = new Operand(1)
			{
				Variables = new List<Variable>
				{
					new Variable('x', 4),
					new Variable('y', 2)
				}
			};

			var actual = _sut.FromString(input);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ParseDoubleVariableWithPowerAndPositiveIntegerCoefficient()
		{
			const string input = "254x^4y^2";
			var expected = new Operand(254)
			{
				Variables = new List<Variable>
				{
					new Variable('x', 4),
					new Variable('y', 2)
				}
			};

			var actual = _sut.FromString(input);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ParseDoubleVariableWithPowerAndNegativeIntegerCoefficient()
		{
			const string input = "-254x^4y^2";
			var expected = new Operand(-254)
			{
				Variables = new List<Variable>
				{
					new Variable('x', 4),
					new Variable('y', 2)
				}
			};

			var actual = _sut.FromString(input);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ParseDoubleVariableWithPowerAndPositiveFloatCoefficient()
		{
			const string input = "25.4x^4y^2";
			var expected = new Operand(25.4f)
			{
				Variables = new List<Variable>
				{
					new Variable('x', 4),
					new Variable('y', 2)
				}
			};

			var actual = _sut.FromString(input);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ParseDoubleVariableWithPowerAndNegativeFloatCoefficient()
		{
			const string input = "-25.4x^4y^2";
			var expected = new Operand(-25.4f)
			{
				Variables = new List<Variable>
				{
					new Variable('x', 4),
					new Variable('y', 2)
				}
			};

			var actual = _sut.FromString(input);
			Assert.AreEqual(expected, actual);
		}
	}
}
