using System;
using EternalFrost.Registry;

namespace EternalFrost.Utils
{
  public class TileSprite : Sprite
  {
    public byte Variations = 1;
    public bool Connects = false;
    public bool Rotates = false;
    public Rectangle TileSpriteBounds = new Rectangle(0, 0, 8, 8);//bounds of the tile texture excluding animation frames and variation
    public TileSprite(ResourceLocation location) : base(location)
    {

    }
    public TileSprite(ResourceLocation location, Texture2D texture) : base(location, texture)
    {

    }
    public static TileSprite ConvertSpriteToTileSprite(Sprite sprite)
    {
      if (sprite is TileSprite) return (TileSprite)sprite;
      var spr = new TileSprite(sprite.TextureLocation, sprite.Texture);
      spr.TileSpriteBounds = sprite.Bounds;
      return spr;
    }
  }
}

