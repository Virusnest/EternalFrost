using System;
using EternalFrost.InGameTypes;

namespace EternalFrost.Utils.TileMap.Generation.Generators
{
	public class FillGenerator : Generator
	{
		private WorldTile tile;
		public FillGenerator(WorldTile tile)
		{
			this.tile = tile;
		}

		public override void Generate(Chunk chunk)
		{
			Console.WriteLine("Generating "+chunk.pos);
			for (int x = 0; x < Chunk.WIDTH; x++) {
				for (int y = 0; y < Chunk.HEIGHT; y++) {
					chunk.SetTile(x, y, 1, tile);
				}
			}
		}
	}
}

