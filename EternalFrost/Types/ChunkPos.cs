using EternalFrost.Utils.TileMap;

namespace EternalFrost.Types
{
	public struct ChunkPos : IEquatable<ChunkPos>
	{
		public ChunkPos(int x, int y)
		{
			X = x;
			Y = y;
		}
		public static ChunkPos Zero = new ChunkPos(0, 0);
		public int X, Y;
		public override string ToString() => $"({X}, {Y}";
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
		public TilePos ToTilePos(int layer)
		{
			return new TilePos(X * Chunk.WIDTH, Y * Chunk.WIDTH, layer);
		}

		public static bool operator ==(ChunkPos chunk1, ChunkPos chunk2)
		{
			if (((object)chunk1) == null || ((object)chunk2) == null)
				return Equals(chunk1, chunk2);

			return chunk1.Equals(chunk2);
		}

		public static bool operator !=(ChunkPos chunk1, ChunkPos chunk2)
		{
			if (((object)chunk1) == null || ((object)chunk2) == null)
				return !Equals(chunk1, chunk2);

			return !chunk1.Equals(chunk2);
		}
		public static ChunkPos operator -(ChunkPos tile1, ChunkPos tile2)
		{
			return new ChunkPos(tile1.X - tile2.X, tile1.Y - tile2.Y);
		}

		public static ChunkPos operator +(ChunkPos tile1, ChunkPos tile2)
		{
			return new ChunkPos(tile1.X + tile2.X, tile1.Y + tile2.Y);
		}
		public override bool Equals(object obj)
		{
			return obj is ChunkPos && Equals((ChunkPos)obj);
		}
	}
}

