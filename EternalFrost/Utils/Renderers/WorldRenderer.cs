using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EternalFrost.InGameTypes;
using MonoGame.Extended;

namespace EternalFrost.Utils.TileMap
{
	public class WorldRenderer
	{
        ChunkRenderer chunkRenderer;

		public WorldRenderer()
		{
            chunkRenderer = new ChunkRenderer();
        }
        public void Render(SpriteBatch spriteBatch, Matrix viewMatrix, World world)
        {
            foreach(var chunk in world.chunks) {
                chunkRenderer.DrawLayer(spriteBatch, viewMatrix, chunk, 0);
				chunkRenderer.DrawLayer(spriteBatch, viewMatrix, chunk, 1);
			}
			//TODO: Implement Entity Rendering
			foreach (var chunk in world.chunks) {
				chunkRenderer.DrawLayer(spriteBatch, viewMatrix, chunk, 2);
			}
		}
    }
}

