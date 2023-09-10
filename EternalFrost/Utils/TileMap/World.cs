using EternalFrost.InGameTypes;
using EternalFrost.Types;
using MonoGame.Extended.Collections;

namespace EternalFrost.Utils.TileMap
{
	public class World
	{
		public KeyedCollection<ChunkPos, Chunk> chunks;
		public const int SIZE = int.MaxValue / 2;
		public World()
		{
			chunks = new KeyedCollection<ChunkPos, Chunk>(c => c.pos);
		}
		public void SetTile(TilePos pos, WorldTile tile)
		{
			ChunkPos chunkPos = new ChunkPos((int)MathF.Floor((float)pos.X / Chunk.WIDTH), (int)MathF.Floor((float)pos.Y / Chunk.HEIGHT));
			TilePos blockPos = pos.ToChunkLocal();
			//Console.WriteLine($"{chunkPos}, {blockPos}");
			if (chunks.ContainsKey(chunkPos)) {
				chunks[chunkPos].SetTile(blockPos, tile);
			}
		}
		public void SetTile(System.Drawing.Point pos, int z, WorldTile tile)
		{
			SetTile(new TilePos(pos.X, pos.Y, z), tile);
		}
		public WorldTile GetTile(TilePos pos)
		{
			return chunks[pos.ToChunkPos()].GetTile(pos.ToChunkLocal());
		}
		public WorldTile GetTile(int x,int y,int z)
		{
			var pos = new TilePos(x,y,z);
			if (!chunks.ContainsKey(pos.ToChunkPos())) { return null; }
			return chunks[pos.ToChunkPos()].GetTile(pos.ToChunkLocal());
		}
		public void SetTile(int x, int y, int z, WorldTile tile)
		{
			SetTile(new TilePos(x, y, z), tile);
		}
	}
}

