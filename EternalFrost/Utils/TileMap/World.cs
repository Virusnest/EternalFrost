using System;
using System.Drawing;
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
		public void SetTile(BlockPos pos, WorldTile tile)
		{
			ChunkPos chunkPos = new ChunkPos((int)MathF.Floor((float)pos.X / Chunk.WIDTH), (int)MathF.Floor((float)pos.Y / Chunk.HEIGHT));
			BlockPos blockPos = pos.ToChunkLocal();
			Console.WriteLine($"{chunkPos}, {blockPos}");
			if (chunks.ContainsKey(chunkPos)) {
				chunks[chunkPos].SetTile(blockPos, tile);
			}
		}
		public void SetTile(Point pos, int z, WorldTile tile)
		{
			SetTile(new BlockPos(pos.X, pos.Y, z), tile);
		}
		public void SetTile(int x, int y, int z, WorldTile tile)
		{
			SetTile(new BlockPos(x, y, z), tile);
		}
	}
}

