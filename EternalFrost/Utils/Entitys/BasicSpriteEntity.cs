using System;
using EternalFrost.Utils.Renderers.EntityDrawers;
using Microsoft.Xna.Framework;

namespace EternalFrost.Utils.Entitys
{
	public class BasicSpriteEntity:PhysicalEntity
	{
		public BasicSpriteEntity(Vector2 pos) : base(pos)
		{
			Drawer = new StaticSpriteDrawer(EternalFrost.tileAtlas.atlas);
		}
		
		
	}
}

