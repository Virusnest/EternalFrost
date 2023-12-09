using System;
using EternalFrost.InGameTypes;
using EternalFrost.Item;
using EternalFrost.Utils.Entitys;
using EternalFrost.Utils.TileMap;
using MonoGame.Extended;

namespace EternalFrost.Entitys
{
	public class ItemEntity : PhysicalEntity
	{
		WorldItem Item = new WorldItem(Items.EMPTY,0);

		public ItemEntity(Vector2 pos, World world, WorldItem item) : base(pos, world)
		{
			Item = item;
			CollisionBox = new RectangleF(1,1,6,6);
		}
		public override void Render(SpriteBatch batch)
		{
			var offset= new Vector2(0, ((float)Math.Sin((EternalFrost.elapsedtime.TotalMilliseconds+Guid.GetHashCode()) / 200)) * 1.5f - 5f);
			Item.Render(batch,Vector2.Floor(Position+offset),1, (float)Math.Sin((EternalFrost.elapsedtime.TotalMilliseconds + Guid.GetHashCode()) / 200),1);
		}
	}
}

