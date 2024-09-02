using EternalFrost.Utils.TileMap.Tile;

namespace EternalFrost.Item
{
  public static class Items
  {
    public static Item EMPTY = Register("empty", new Item());
    public static Item SNOWBALL = Register("snowball", new Item());
    public static Item SNOW_TILE = Register("snow_tile", new TileItem(Tiles.SNOW));

    private static Item Register(string id, Item item)
    {
      return Registry.Registries.ITEM_REG.Register(new Registry.ResourceLocation(id), item);
    }

  }
}

