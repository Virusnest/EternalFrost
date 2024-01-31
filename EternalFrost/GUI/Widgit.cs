using System;
namespace EternalFrost.GUI
{
	public class Widgit
	{
		public Rectangle Bounds;
		public bool Active;
		public bool Visible;
		public Widgit(Rectangle bounds)
		{
			Bounds = bounds;
		}
		public virtual void Render(SpriteBatch batch)
		{
			batch.Draw(EternalFrost.tileAtlas.MissingTexture.Texture,Bounds,Color.White);
		}
		public virtual void Update()
		{
		}
	}
}

