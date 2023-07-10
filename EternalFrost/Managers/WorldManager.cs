using System;
using EternalFrost.InGameTypes;
using EternalFrost.Utils.TileMap;
using EternalFrost.Utils.TileMap.Generation;
using EternalFrost.Utils.TileMap.Generation.Generators;
using EternalFrost.Utils.TileMap.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace EternalFrost.Managers
{
	public class WorldManager
	{
		public World world;
		ChunkGenerator generator;
		public WorldRenderer renderer;
		
		public WorldManager()
		{
			world = new World();
			generator = new ChunkGenerator(new SinGenerator(new WorldTile(Tiles.SNOW)));
			renderer = new WorldRenderer();
		}

		public void Update(OrthographicCamera camera)
		{
			var BL = Vector2.Round(((Vector2)camera.BoundingRectangle.BottomLeft)/ChunkRenderer.TILESIZE / Chunk.WIDTH);
			var TR = Vector2.Round(((Vector2)camera.BoundingRectangle.TopRight)/ ChunkRenderer.TILESIZE / Chunk.WIDTH);

			for (int x = (int)BL.X-1; x < (int)TR.X+1; x++) {
				for (int y = (int)TR.Y-1; y < (int)BL.Y+1; y++) {
					var pos = new System.Drawing.Point(x, y);
					if (!world.chunks.ContainsKey(pos)) {
						world.chunks.Add(new Chunk(pos));
					}
				}
			}
			var bounds = (Rectangle)camera.BoundingRectangle;
			bounds.Inflate(ChunkRenderer.TILESIZE * Chunk.WIDTH*2, ChunkRenderer.TILESIZE * Chunk.HEIGHT*2);
			foreach (Chunk chunk in world.chunks) {
				if (!chunk.isDirty) {
					generator.GenerateChunk(chunk);
				}
				var boundpos = new Vector2(chunk.pos.X * ChunkRenderer.TILESIZE * Chunk.WIDTH, chunk.pos.Y * ChunkRenderer.TILESIZE * Chunk.HEIGHT);
				if (!bounds.Contains(new Rectangle(boundpos.ToPoint(),new Point((int)Chunk.GetBoundingBox().Width, (int)Chunk.GetBoundingBox().Height)))) {
					world.chunks.Remove(chunk);
				}
			}
		}
		public void Render(SpriteBatch spriteBatch, Matrix viewMatrix)
		{
			renderer.Render(spriteBatch, viewMatrix, world);
		}
	}
}

