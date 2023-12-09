using System;
using EternalFrost.Utils.Entitys;

namespace EternalFrost.Entitys
{
	public class Entities
	{
		public static Type PLAYER = Register("player", typeof(Player));
		public static Type ITEM = Register("item", typeof(ItemEntity));


		private static Type Register(string id, Type entity)
		{	
			return Registry.Registries.ENTITY_REG.Register(new Registry.ResourceLocation(id), entity);
		}
	}
}

