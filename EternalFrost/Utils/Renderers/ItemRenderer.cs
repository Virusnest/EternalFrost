using System;
using EternalFrost.Item;

namespace EternalFrost.Renderers
{
	public abstract class ItemRenderer
	{
		public ItemRenderer()
		{
		}
		public abstract void Render(SpriteBatch batch, Vector2 pos, float scale,float rotation, float depth);
	}
}

