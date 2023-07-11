using System;
using EternalFrost.Utils.TileMap;
using Microsoft.Xna.Framework;

namespace EternalFrost.Types
{
	public struct ChunkPos : IEquatable<ChunkPos>
	{
		public ChunkPos(int x, int y)
		{
			X = x;
			Y = y;
		}
		public int X, Y;
		public override string ToString() => $"({X}, {Y}";
		public ChunkPos Zero()
		{
			return new ChunkPos(0, 0);
		}

		public bool Equals(ChunkPos other)
		{
			return (X == other.X) && (Y == other.Y);
		}
		public override int GetHashCode()
		{
			return X.GetHashCode() ^ Y.GetHashCode();
		}
		public Vector2 AsWorldVec()
		{
			return new Vector2(X * ChunkRenderer.TILESIZE*Chunk.WIDTH, Y * ChunkRenderer.TILESIZE * Chunk.HEIGHT);
		}
		public BlockPos ToBlockPos(int layer)
		{
			return new BlockPos(X * Chunk.WIDTH, Y * Chunk.WIDTH, layer);
		}
	}
}

