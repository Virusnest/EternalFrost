using System;
using EternalFrost.Utils.Entitys;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EternalFrost.Utils.Renderers.EntityDrawers
{
	public class StaticSpriteDrawer : EntityDrawer
	{
		public Texture2D Sprite;
		public StaticSpriteDrawer(Texture2D sprite)
		{
			Sprite = sprite;
		}
		public override void Draw(SpriteBatch batch,RenderingEntity entity)
		{
			batch.Draw(Sprite,entity.Position,Color.White);
		}
	}
}

