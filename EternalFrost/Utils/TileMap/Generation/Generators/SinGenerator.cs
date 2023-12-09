using EternalFrost.InGameTypes;
using EternalFrost.Types;
using EternalFrost.Utils.TileMap.Tile;

namespace EternalFrost.Utils.TileMap.Generation.Generators
{
	public class SinGenerator : Generator
	{
		WorldTile tile;
		FastNoiseLite noise = new FastNoiseLite();
		static private Vector2[] vecs = { new Vector2(0,0), new Vector2(0.45f, 10), new Vector2(0.5f,90),new Vector2(1,1000) };
		public SinGenerator(WorldTile tile)
		{
			this.tile = tile;
			noise.SetNoiseType(FastNoiseLite.NoiseType.OpenSimplex2);
			noise.SetFractalType(FastNoiseLite.FractalType.FBm);
			noise.SetFractalOctaves(8);
			noise.SetFrequency(0.005f);
		}
		public override WorldTile GetTile(TilePos pos)
		{
			//noise.SetFrequency(pos.Y*-1/10);
			///if (noise.GetNoise(pos.X, pos.Y) > normaliseRange(0,-100,pos.Y)) { return tile; }
			///			noise.SetFractalOctaves(1);

			if (pos.Z != 1) return new WorldTile(Tiles.EMPTY);
			noise.SetFractalOctaves(8);
			var range = normaliseRange(0, lerp(normaliseRange(-1, 1, noise.GetNoise(pos.X, 1)), vecs), pos.Y);
			noise.SetFractalOctaves(32);
			//if ((noise.GetNoise(pos.X, 1)-1)*-1 * 25-15 < pos.Y && noise.GetNoise(pos.X, 1) * 200-15 > pos.Y) return new WorldTile(Tiles.STONE);
			if (noise.GetNoise(pos.X , pos.Y)<range) return new WorldTile(Tiles.STONE);
			//if (lerp(range, vecs) < pos.Y - 1) return tile;
			//if (lerp(range, vecs) < pos.Y) return new WorldTile(Tiles.SNOW);

			return new WorldTile(Tiles.EMPTY);
		}

		public float normaliseRange(float min, float max, float amount)
		{
			return (float)(amount - min) / (max - min);
		}
		public float lerp(float amount, Vector2[] vecs)
		{
			for (int i = 0; i < vecs.Length - 1; i++) {
				if (vecs[i].X <= amount && amount <= vecs[i + 1].X) {
					float t = (amount - vecs[i].X) / (vecs[i + 1].X - vecs[i].X);
					float interpolatedNoise = MathHelper.SmoothStep(vecs[i].Y, vecs[i + 1].Y, t);
					return interpolatedNoise;
				}
			}
			return 0f; // Default value if no valid interpolation range is found
		}
	}
}

