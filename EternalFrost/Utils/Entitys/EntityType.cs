using System;
using EternalFrost.Utils.Entitys;
using EternalFrost.Utils.TileMap;
using PeterO.Cbor;

namespace EternalFrost.Entitys
{
	public class EntityType
	{
		Type Entity;
		public EntityType(Type entityType)
		{
			Entity = entityType;
		}
		public Entity Spawn(World world, CBORObject data)
		{
			return (Entity)Activator.CreateInstance(Entity, data, world);
			//(Entity)
		}
	}
}

