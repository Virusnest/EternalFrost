using System;
using EternalFrost.InGameTypes;

namespace EternalFrost.Utils.TileMap.Generation.Generators
{
	public class SinGenerator : Generator
	{
		WorldTile tile;
		FastNoiseLite noise = new FastNoiseLite();
		public SinGenerator(WorldTile tile)
		{
			this.tile = tile;
		}
		public override void Generate(Chunk chunk)
		{
			for (int x = 0; x < Chunk.WIDTH; x++) {
				for (int y = 0; y < Chunk.HEIGHT; y++) {
					if (y + (chunk.pos.Y * Chunk.HEIGHT) > (noise.GetNoise((x + (chunk.pos.X * Chunk.WIDTH)) * 5, 1) * 5)) {
						chunk.SetTile(x, y, 1, tile);
					}
				}
			}
		}
	}
}

