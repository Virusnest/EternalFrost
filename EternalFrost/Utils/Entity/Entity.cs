using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EternalFrost.Utils.Entity
{
	public class Entity
	{
		protected Vector2 position;
		public Guid guid { get; private set; }

		public Entity(Vector2 position,Guid guid=new Guid())
		{
			this.position = position;
			this.guid = guid;
		}

		public void Update(GameTime gameTime)
		{
			// Add update code here
		}
	}

}

