using EternalFrost.InGameTypes;
using EternalFrost.ItemDrawers;
using EternalFrost.Registry;
using EternalFrost.Renderers;
using EternalFrost.Utils;
using EternalFrost.Utils.Renderers.EntityDrawers;
using EternalFrost.Utils.TileMap;

namespace EternalFrost.Item
{
  public class Item
  {
    public ItemRenderer ItemRenderer;

    public Item()
    {
      ItemRenderer = new BasicItemDrawer(this);
    }
    //L True _-_- R False
    public virtual void OnUse(WorldItem item, World world, bool LR)
    {

    }
    public virtual void Render(SpriteBatch batch, Vector2 pos, float scale, float rotation, float depth)
    {
      ItemRenderer.Render(batch, pos, scale, rotation, depth);
    }
  }
}

