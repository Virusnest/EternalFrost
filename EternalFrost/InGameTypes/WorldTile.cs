using EternalFrost.Utils.TileMap;
using EternalFrost.Registry;
namespace EternalFrost.InGameTypes
{
	public class WorldTile
	{
		public Tile tile { get; }
		public RegistryItem registryItem { get; }
		public TileProperties Properties { get; }
		
		public WorldTile(Tile tile)
		{
			this.tile = tile;
			Properties = tile.Properties;
			registryItem = Registries.TILE_REG.GetKey(tile);
		}
		public WorldTile(ResourceLocation location)
		{
			registryItem = new RegistryItem(Registries.TILE_REG.ID,location);
			tile = Registries.TILE_REG.GetValue(location);
		}
	}
}