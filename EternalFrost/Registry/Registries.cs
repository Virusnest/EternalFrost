using EternalFrost.Utils.TileMap;
using EternalFrost.Utils.Entitys;
using EternalFrost.Input;

namespace EternalFrost.Registry
{
	public class Registries
	{
		public static Registry<Tile> TILE_REG = new Registry<Tile>(new ResourceLocation("tiles"));
		public static Registry<Entity> ENTITY_REG = new Registry<Entity>(new ResourceLocation("entities"));
		public static Registry<Keybind> KEYBIND_REG = new Registry<Keybind>(new ResourceLocation("keybinds"));
	}
}

