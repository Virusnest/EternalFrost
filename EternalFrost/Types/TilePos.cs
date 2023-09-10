using EternalFrost.Utils.TileMap;

namespace EternalFrost.Types
{
	public struct TilePos : IEquatable<TilePos>
	{
		public TilePos(int x, int y, int z)
		{
			X = x;
			Y = y;
			Z = z;
		}
		public int X, Y, Z;
		public override string ToString() => $"({X}, {Y}, {Z})";
		public TilePos Zero()
		{
			return new TilePos(0, 0, 0);
		}

		public bool Equals(TilePos other)
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
		public TilePos ToChunkLocal()
		{
			TilePos tilePos = new TilePos(X % Chunk.WIDTH, Y % Chunk.HEIGHT, Z);
			
			if (tilePos.X < 0) {
				tilePos.X += Chunk.WIDTH;
			}
			if (tilePos.Y < 0) {
				tilePos.Y += Chunk.HEIGHT;
			}
			
			return tilePos;
		}
		public TilePos ToGlobalPos(ChunkPos pos)
		{
			return new TilePos(X+(pos.X*Chunk.WIDTH),Y+(pos.Y*Chunk.HEIGHT),Z);
		}
		public ChunkPos ToChunkPos() {
			return new ChunkPos((int)Math.Floor((float)X/Chunk.WIDTH), (int)Math.Floor((float)Y /Chunk.HEIGHT));
		}

	}
}

