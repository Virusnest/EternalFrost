using System;
using EternalFrost.InGameTypes;

namespace EternalFrost.Utils.TileMap.Generation.Generators
{
	public class SinGenerator : Generator
	{
		WorldTile tile;
		public SinGenerator(WorldTile tile)
		{
			this.tile = tile;
		}
		FastNoiseLite noise = new FastNoiseLite(); 
		public override void Generate(Chunk chunk)
		{
			for (int x = 0; x < Chunk.WIDTH; x++) {
				for (int y = Chunk.HEIGHT; y > noise.GetNoise(x*10,1)*10; y--) {
					Console.WriteLine(noise.GetNoise(x*10,1)*10);
					chunk.SetTile(x, y, 1, tile);
				}
			}
		}
	}
}

