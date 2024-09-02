using System;
using EternalFrost.Item;
using EternalFrost.Registry;
using EternalFrost.Renderers;
using EternalFrost.Utils;

namespace EternalFrost.ItemDrawers
{
  public class BasicItemDrawer : ItemRenderer
  {
    Item.Item Item = Items.EMPTY;

    public BasicItemDrawer(Item.Item item)
    {
      Item = item;
    }
    public override void Render(SpriteBatch batch, Vector2 pos, float scale, float rotation, float depth)
    {
      Sprite sprite = EternalFrost.tileAtlas.GetSprite(Registries.ITEM_REG.GetKey(Item).getLocation().WithPrefixID("textures/").WithSuffix(".png"));
      batch.Draw(sprite.Texture, pos + new Vector2(4, 4), sprite.Bounds, Color.White, rotation, new(4, 4), scale, SpriteEffects.None, depth);
    }
  }
}

