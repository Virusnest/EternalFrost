using System;
namespace EternalFrost.Utils.TileMap.Tiles
{
	public class Tiles
	{
		public static Tile ICE = Register("ice", new GroundTile());
		public static Tile SNOW = Register("snow", new SnowTile());
		public static Tile SNOWY_ICE = Register("snowy_ice", new SnowTile());

		private static Tile Register(string id, Tile tile)
		{
			return Registry.Registries.TILE_REG.Register(new Registry.ResourceLocation(id), tile);
		}
	}
}

