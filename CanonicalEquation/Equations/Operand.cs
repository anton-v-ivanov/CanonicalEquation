using System.Collections.Generic;
using System.Linq;

namespace CanonicalEquation.Equations
{
	public class Operand
	{
		public float Coefficient { get; set; }
		public IList<Variable> Variables { get; set; }

		public Operand(float coefficient)
		{
			Coefficient = coefficient;
			Variables = new List<Variable>();
		}

		public override bool Equals(object obj)
		{
			var operand = obj as Operand;
			return operand != null && Equals(operand);
		}

		protected bool Equals(Operand other)
		{
			return Coefficient.Equals(other.Coefficient) && Variables.SequenceEqual(other.Variables);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (Coefficient.GetHashCode() * 397) ^ (Variables?.GetHashCode() ?? 0);
			}
		}
	}
}