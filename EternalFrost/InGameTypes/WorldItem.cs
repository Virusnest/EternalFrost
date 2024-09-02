using EternalFrost.Registry;

namespace EternalFrost.InGameTypes
{
  public class WorldItem
  {
    public Item.Item Item;
    public RegistryItem registryItem { get; private set; }
    public int Count;
    public WorldItem(Item.Item item, int count)
    {
      Count = count;
      Item = item;
      registryItem = Registries.ITEM_REG.GetKey(item);
    }
    public WorldItem(ResourceLocation location, int count)
    {
      registryItem = new RegistryItem(Registries.ITEM_REG.ID, location);
      Item = Registries.ITEM_REG.GetValue(location);
    }

    public void Render(SpriteBatch batch, Vector2 pos, float scale, float rotation, float depth)
    {
      Item.ItemRenderer.Render(batch, pos, scale, rotation, depth);
    }
    public override bool Equals(object obj)
    {
      return ReferenceEquals(((WorldItem)obj).Item, Item);
    }

    public WorldItem Clone()
    {
      var clone = new WorldItem(Item, Count);
      return clone;
    }
  }
}

