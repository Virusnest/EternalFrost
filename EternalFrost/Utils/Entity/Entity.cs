using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace EternalFrost.Utils.Entity
{
	public class Entity
	{
		protected Vector2 Position;
		public Guid Guid { get; private set; }
		public Rectangle CollisionBox;

		public Entity(Vector2 position,Guid guid=new Guid())
		{
			Position = position;
			Guid = guid;
		}

		public void Update(GameTime gameTime)
		{
			// Add update code here
		}

		public void Move(Vector2 dir)
		{
			Position = Position + dir;
		}
		public Rectangle GetRelativeCollisionBox()
		{
			var rect = CollisionBox;
			rect.Offset(Position);
			return rect;
		}
		public void Render(SpriteBatch batch)
		{
			batch.DrawRectangle(GetRelativeCollisionBox(), Color.Blue);
		}
	}

}

