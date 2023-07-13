using System;
using System.Xml.Linq;
using EternalFrost.Utils.TileMap;
using Microsoft.Xna.Framework;

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
		public Vector2 ToWorldVec() {
			return new Vector2(X*ChunkRenderer.TILESIZE, Y * ChunkRenderer.TILESIZE);
		}
		public BlockPos ToChunkLocal()
		{
			BlockPos blockPos = new BlockPos(X % Chunk.WIDTH, Y % Chunk.HEIGHT, Z);
			
			if (blockPos.X < 0) {
				blockPos.X += Chunk.WIDTH;
			}
			if (blockPos.Y < 0) {
				blockPos.Y += Chunk.HEIGHT;
			}
			
			return blockPos;
		}
		public ChunkPos ToChunkPos() {
			return new ChunkPos();
		}

	}
}

