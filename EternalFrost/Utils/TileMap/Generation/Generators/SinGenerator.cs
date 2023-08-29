
using EternalFrost.InGameTypes;
using EternalFrost.Types;
using Microsoft.Xna.Framework;

namespace EternalFrost.Utils.TileMap.Generation.Generators
{
	public class SinGenerator : Generator
	{
		WorldTile tile;
		FastNoiseLite noise = new FastNoiseLite();

		static private Vector2[] vecs = { new Vector2(0,0), new Vector2(0.5f,-5), new Vector2(0.7f,-40), new Vector2(1,-50) };
		public SinGenerator(WorldTile tile)
		{
			this.tile = tile;
			noise.SetNoiseType(FastNoiseLite.NoiseType.OpenSimplex2);
			noise.SetFractalType(FastNoiseLite.FractalType.FBm);
			noise.SetFractalOctaves(4);
			noise.SetFrequency(0.005f);
		}
		public override WorldTile GetTile(TilePos pos)
		{
			if (pos.Z != 1) return null;
			float val = (noise.GetNoise(pos.X/2.1f, 1) + 1) / 2;
			if (lerp(val,vecs)<pos.Y) { return tile; }
			return null;
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

