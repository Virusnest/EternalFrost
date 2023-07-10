using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace EternalFrost.Utils
{
	public class TileAtlas
	{
		public RenderTarget2D atlas { get; private set; }
		private GraphicsDevice device;
		private SpriteBatch batch;
		private int tw;
		private int th;
		public int textureCount { get; private set; }
		public Dictionary<string, Rectangle> textures;

		public TileAtlas(GraphicsDevice device, int tw, int th, int tiles)
		{
			textures = new Dictionary<string, Rectangle>();
			this.th = th;
			this.tw = tw;
			batch = new SpriteBatch(device);
			atlas = new RenderTarget2D(device, tiles*tw,th);
		}
		public void AddTexture(Texture2D texture,string id)
		{
			batch.GraphicsDevice.SetRenderTarget(atlas);
			batch.Begin();
			batch.Draw(texture,new Vector2(tw*textureCount),Color.White);
			batch.End();
			textures.Add(id, new Rectangle(tw * textureCount, 0, th, tw));
			textureCount++;
		}
		public void AddTextures(Texture2D[] texture, string[] id)
		{
			batch.GraphicsDevice.SetRenderTarget(atlas);
			batch.Begin();
			for (int i = 0; i < id.Length; i++) {
				batch.Draw(texture[i], new Vector2(tw * textureCount,0), Color.White);
				textures.Add(id[i], new Rectangle(tw * textureCount, 0, th, tw));
				textureCount++;
			}
			batch.End();
		}
		public Texture2D getTexture()
		{
			return (Texture2D)atlas;
		}
	}
}

