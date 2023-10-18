using System;
namespace EternalFrost.Utils.TileMap.Tiles
{
	public class Tiles
	{
		public static Tile ICE = Register("ice", new GroundTile(new TileProperties() {
			Frition = 0.9f,
			Solid = true
		}));
		public static Tile SNOW = Register("snow", new SnowTile(new TileProperties()));
		public static Tile SNOWY_ICE = Register("snowy_ice", new SnowTile(new TileProperties()));

		private static Tile Register(string id, Tile tile)
		{
			return Registry.Registries.TILE_REG.Register(new Registry.ResourceLocation(id), tile);
		} 
	}
}

