using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EternalFrost.Utils.Entity
{
	public class Entity
	{
		protected Texture2D texture;
		protected Vector2 position;

		public Entity(Texture2D texture, Vector2 position)
		{
			this.texture = texture;
			this.position = position;
		}

		public void Update(GameTime gameTime)
		{
			// Add update code here
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, position, Color.White);
		}

		public Rectangle GetBounds()
		{
			return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
		}
	}

}

