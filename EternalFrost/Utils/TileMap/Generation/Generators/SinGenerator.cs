using EternalFrost.InGameTypes;
using EternalFrost.Types;
using EternalFrost.Utils.TileMap.Tile;

namespace EternalFrost.Utils.TileMap.Generation.Generators
{
	public class SinGenerator : Generator
	{
		WorldTile tile;
		FastNoiseLite HeightNoise = new FastNoiseLite();
		FastNoiseLite ErosionNoise = new FastNoiseLite();
		FastNoiseLite ContentNoise = new FastNoiseLite();

		public SinGenerator(WorldTile tile)
		{
			
			this.tile = tile;
			HeightNoise.SetFractalType(FastNoiseLite.FractalType.FBm);
			HeightNoise.SetFractalOctaves(8);
			ErosionNoise.SetSeed(82476);
			HeightNoise.SetFrequency(0.05f);
		
		}
		public override WorldTile GetTile(TilePos pos)
		{
			if (pos.Z != 1) return new WorldTile(Tiles.EMPTY);
			if (HeightNoise.GetNoise(pos.X, pos.Y) > ErosionNoise.GetNoise(HeightNoise.GetNoise(pos.X, 0),0)) { return tile; }

			return new WorldTile(Tiles.EMPTY);
		}

		public float normaliseRange(float min, float max, float amount)
		{
			return (float)(amount - min) / (max - min);
		}
	}
}

