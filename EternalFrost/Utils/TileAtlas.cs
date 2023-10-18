using System;
using System.Collections.Generic;
using EternalFrost.Registry;
using Microsoft.Xna.Framework.Graphics;
using RectpackSharp;

namespace EternalFrost.Utils
{
	public class TextureAtlas
	{
		public RenderTarget2D atlas { get; private set; }
		private GraphicsDevice device;
		private SpriteBatch batch;
		private int tw=1024;
		private int th=1024;
		public int textureCount { get; private set; }
		public Dictionary<ResourceLocation, Sprite> textures;

		public void PackTextures(Texture2D[] textures, ResourceLocation[] id)
		{
			PackingRectangle[] rectangles = new PackingRectangle[textures.Length];
			for(int i=0; i<rectangles.Length;i++) {
				rectangles[i]=new PackingRectangle(new System.Drawing.Rectangle(0, 0, textures[i].Width, textures[i].Height),i);
			}
			var rect = new PackingRectangle(0, 0, (uint)tw, (uint)th);
			RectanglePacker.Pack(rectangles,out rect);
			device.SetRenderTarget(atlas);
			batch.Begin();
			// Loop over all the rectangles
			for (int i = 0; i < rectangles.Length; i++) {
				Console.WriteLine($"{i} {rectangles[i].Id} "+ id[rectangles[i].Id]);
				var rec = rectangles[i];
				var recc= new Rectangle((int)rec.X,(int)rec.Y,(int)rec.Width,(int)rec.Height);
				batch.Draw(textures[rectangles[i].Id], recc, Color.White);
				this.textures.Add(id[rectangles[i].Id],new Sprite(recc));
			}
			batch.End();
		}

		public TextureAtlas(GraphicsDevice device)
		{
			textures = new Dictionary<ResourceLocation, Sprite>();
			this.device = device;
			batch = new SpriteBatch(device);
			atlas = new RenderTarget2D(device, th, tw);
		}
		public TextureAtlas(GraphicsDevice device,int size)
		{
			textures = new Dictionary<ResourceLocation, Sprite>();
			this.device = device;
			batch = new SpriteBatch(device);
			atlas = new RenderTarget2D(device, size, size);
		}
	}
}

