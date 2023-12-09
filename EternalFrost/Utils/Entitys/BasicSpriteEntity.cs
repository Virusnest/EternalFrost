using System.Reflection;
using EternalFrost.Input;
using EternalFrost.Utils.Renderers.EntityDrawers;
using EternalFrost.Utils.TileMap;

namespace EternalFrost.Utils.Entitys
{
	public class BasicSpriteEntity:PhysicalEntity
	{
		public BasicSpriteEntity(Vector2 pos, World world) : base(pos, world)
		{
		}

	}
}

