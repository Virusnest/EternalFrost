using System;
using System.Collections.Generic;
using System.Drawing;
using EternalFrost.InGameTypes;
using EternalFrost.Types;
using MonoGame.Extended.Collections;

namespace EternalFrost.Utils.TileMap
{
	public class World
	{
		public KeyedCollection<Point, Chunk> chunks;
		public const int SIZE = int.MaxValue / 2;
		public World()
		{
			chunks = new KeyedCollection<Point, Chunk>(c => c.pos);
		}
		public void SetTile(BlockPos pos, WorldTile tile)
		{
			Point chunkPos = new Point(pos.X / Chunk.WIDTH, pos.Y / Chunk.HEIGHT);
			BlockPos blockPos = new BlockPos(pos.X%Chunk.WIDTH, pos.Y%Chunk.HEIGHT, pos.Z);
			if (chunks[chunkPos] != null) {
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

