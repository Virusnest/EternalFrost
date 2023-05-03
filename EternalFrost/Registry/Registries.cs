using System;
using EternalFrost.Utils.TileMap;
using EternalFrost.Utils.Entity;

namespace EternalFrost.Registry
{
	public class Registries
	{
		public static Registry<Tile> TILE_REG = new Registry<Tile>(new ResourceLocation("tiles"));
		public static Registry<Entity> ENTITY_REG = new Registry<Entity>(new ResourceLocation("entitys"));
	}
}

