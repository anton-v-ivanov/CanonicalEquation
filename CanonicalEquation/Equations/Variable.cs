namespace CanonicalEquation.Equations
{
	public class Variable
	{
		public char Name { get; }
		public int Power { get; }

		public Variable(char name, int power)
		{
			Name = name;
			Power = power;
		}

		public override bool Equals(object obj)
		{
			var variable = obj as Variable;
			return variable != null && Equals(variable);
		}

		protected bool Equals(Variable other)
		{
			return Name == other.Name && Power == other.Power;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (Name.GetHashCode() * 397) ^ Power;
			}
		}
	}
}