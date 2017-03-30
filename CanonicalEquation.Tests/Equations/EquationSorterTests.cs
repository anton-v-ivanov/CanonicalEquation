using System.Collections.Generic;
using System.Linq;
using CanonicalEquation.Equations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CanonicalEquation.Tests.Equations
{
	[TestClass]
	public class EquationSorterTests
	{
		private IEquationSorter _sut;

		[TestInitialize]
		public void Prepare()
		{
			_sut = new EquationSorter();
		}

		[TestMethod]
		public void SortTest()
		{
			// x^2 + 4.5xy - y^2
			var input = new List<Operand>
			{
				new Operand(1)
				{
					Variables = new List<Variable>
					{
						new Variable('x', 2)
					}
				},
				new Operand(4.5f)
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
						new Variable('y', 2)
					}
				}
			};

			// x^2 - y^2 + 4.5xy
			var expected = new List<Operand>
			{
				new Operand(1)
				{
					Variables = new List<Variable>
					{
						new Variable('x', 2)
					}
				},
				new Operand(-1)
				{
					Variables = new List<Variable>
					{
						new Variable('y', 2)
					}
				},
				new Operand(4.5f)
				{
					Variables = new List<Variable>
					{
						new Variable('x', 1),
						new Variable('y', 1)
					}
				}
			};

			var actual = _sut.Sort(input);
			Assert.IsTrue(expected.SequenceEqual(actual));
		}
	}
}