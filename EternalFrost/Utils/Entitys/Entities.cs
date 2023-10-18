using System;
using EternalFrost.Utils.Entitys;

namespace EternalFrost.Entitys
{
	public class Entities
	{
		public static Entity BASIC_SPRITE_ENTITY = Register("basic_sprite_entity", new BasicSpriteEntity(Vector2.One));

		private static Entity Register(string id, Entity entity)
		{
			return Registry.Registries.ENTITY_REG.Register(new Registry.ResourceLocation(id), entity);
		}
	}
}

