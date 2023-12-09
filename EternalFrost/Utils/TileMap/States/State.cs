using System;
namespace EternalFrost.States
{
	public struct State : IEquatable<State>
	{
		public byte ByteData;
		public bool BoolData;
		public State(byte by, bool bo)
		{
			BoolData = bo;
			ByteData = by;
		}
		public override bool Equals(object obj)
		{
			var state = (State)obj;
			return ByteData == state.ByteData && BoolData == state.BoolData;
		}
		public bool Equals(State other)
		{
			return Equals(other);
		}
	}
}

