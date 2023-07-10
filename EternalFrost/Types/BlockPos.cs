using System;
using System.Xml.Linq;

namespace EternalFrost.Types
{
	public struct BlockPos : IEquatable<BlockPos>
	{
		public BlockPos(int x, int y, int z)
		{
			X = x;
			Y = y;
			Z = z;
		}
		public int X, Y, Z;
		public override string ToString() => $"({X}, {Y}, {Z})";
		public BlockPos Zero()
		{
			return new BlockPos(0, 0, 0);
		}

		public bool Equals(BlockPos other)
		{
			return (X == other.X) && (Y == other.Y) && (Z == other.Z);
		}
		public override int GetHashCode()
		{
			return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
		}
	}
}

