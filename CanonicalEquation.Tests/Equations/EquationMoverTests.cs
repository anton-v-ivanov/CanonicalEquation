using System.Collections.Generic;
using System.Linq;
using CanonicalEquation.Equations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CanonicalEquation.Tests.Equations
{
	[TestClass]
	public class EquationMoverTests
	{
		private IEquationMover _sut;

		[TestInitialize]
		public void Prepare()
		{
			_sut = new EquationMover();
		}

		[TestMethod]
		public void MoveToLeftTest()
		{
			// x^2 + 3.5xy + y
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

			// y^2 - xy + y
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

			var input = new Equation(left, right);

			// x^2 + 3.5xy + y - y^2 + xy - y
			var expected = new List<Operand>
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
				new Operand(-1)
				{
					Variables = new List<Variable>
					{
						new Variable('y', 2)
					}
				},
				new Operand(1)
				{
					Variables = new List<Variable>
					{
						new Variable('x', 1),
						new Variable('y', 1)
					}
				},
				new Operand(-1)
				{
					Variables = new List<Variable>
					{
						new Variable('y', 1)
					}
				},
			};

			var actual = _sut.MoveToLeft(input);

			Assert.IsTrue(expected.SequenceEqual(actual));
		}
	}
}