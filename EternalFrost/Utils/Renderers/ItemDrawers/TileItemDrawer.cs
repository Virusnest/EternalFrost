using System;
using EternalFrost.Registry;
using EternalFrost.Renderers;
using EternalFrost.Utils;
using EternalFrost.Utils.TileMap.Tile;

namespace EternalFrost.ItemDrawers
{
  public class TileItemDrawer : ItemRenderer
  {
    Tile Tile = Tiles.EMPTY;
    public TileItemDrawer(Tile tile)
    {
      Tile = tile;
    }

    public override void Render(SpriteBatch batch, Vector2 pos, float scale, float rotation, float depth)
    {
      TileSprite sprite = TileSprite.ConvertSpriteToTileSprite(EternalFrost.tileAtlas.GetSprite(Registries.TILE_REG.GetKey(Tile).getLocation().WithPrefixID("textures/").WithSuffix(".png")));
      var rec = sprite.Bounds;
      rec.Width = 8;
      rec.Height = 8;
      batch.Draw(sprite.Texture, pos + new Vector2(4, 4), rec, Color.White, rotation, new(4, 4), scale, SpriteEffects.None, depth);
    }
  }
}

