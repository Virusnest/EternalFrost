using System;
using EternalFrost.Utils.Entitys;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EternalFrost.Utils.Renderers.EntityDrawers
{
	public class StaticSpriteDrawer : EntityDrawer
	{
		public Sprite Sprite;
		public StaticSpriteDrawer(Sprite sprite)
		{
			Sprite = sprite;
		}
		public override void Draw(SpriteBatch batch,RenderingEntity entity)
		{
			batch.Draw(Sprite.Texture,entity.Position,Sprite.Bounds,Color.White);
		}
	}
}

