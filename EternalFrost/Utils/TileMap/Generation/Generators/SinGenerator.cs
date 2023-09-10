using EternalFrost.InGameTypes;
using EternalFrost.Types;

namespace EternalFrost.Utils.TileMap.Generation.Generators
{
	public class SinGenerator : Generator
	{
		
		WorldTile tile;
		FastNoiseLite noise = new FastNoiseLite();


		static private Vector2[] vecs = { new Vector2(0,0), new Vector2(0.45f, 10), new Vector2(0.5f,90),new Vector2(1,100) };
		public SinGenerator(WorldTile tile)
		{
			this.tile = tile;
			noise.SetNoiseType(FastNoiseLite.NoiseType.OpenSimplex2);
			noise.SetFractalType(FastNoiseLite.FractalType.FBm);
			noise.SetFractalOctaves(16);
			noise.SetFrequency(0.001f);
		}
		public override WorldTile GetTile(TilePos pos)
		{
			//noise.SetFrequency(pos.Y*-1/10);
			///if (noise.GetNoise(pos.X, pos.Y) > normaliseRange(0,-100,pos.Y)) { return tile; }
			///			noise.SetFractalOctaves(1);

			if (pos.Z != 1) return null;
			noise.SetFractalOctaves(8);
			var range = normaliseRange(-1, 1, noise.GetNoise(pos.X, 1));
			noise.SetFractalOctaves(32);
			if ((noise.GetNoise(pos.X, 1)-1)*-1 * 25-15 < pos.Y && noise.GetNoise(pos.X, 1) * 200-15 > pos.Y) return tile;
			if (lerp(range, vecs) < pos.Y) return tile;
			return null;
		}

		public float normaliseRange(int min, int max, float amount)
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

