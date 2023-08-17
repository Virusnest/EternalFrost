using System;
using System.Reflection.Metadata.Ecma335;
using EternalFrost.InGameTypes;
using EternalFrost.Utils.Entitys;
using Microsoft.Xna.Framework;

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
			chunk.entities.Add(new BasicSpriteEntity(Vector2.Zero));
			for (int x = 0; x < Chunk.WIDTH; x++) {
				for (int y = 0; y < Chunk.HEIGHT; y++) {
					
					if (y + (chunk.pos.Y * Chunk.HEIGHT) > (noise.GetNoise((x + (chunk.pos.X * Chunk.WIDTH)) * 5, 1) * 5)) {
						chunk.SetTile(x, y, 1, tile); 
					}
					/*
					if (noise.GetNoise((x + (chunk.pos.X * Chunk.WIDTH))*4, (y + (chunk.pos.Y * Chunk.HEIGHT))*4) > 0.1) {
						chunk.SetTile(x, y, 1, tile);
					}
					*/
				}
			}
		}
	}
}

