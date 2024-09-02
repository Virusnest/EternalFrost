using System;
using EternalFrost.Item;
using EternalFrost.Registry;
using EternalFrost.Utils.TileMap.Tile;

namespace EternalFrost.Utils
{
  public static class Effects
  {

    public static TypeAsset<Effect> TILE = Register("tile", new TypeAsset<Effect>());

    public static TypeAsset<Effect> Register(string id, TypeAsset<Effect> effect)
    {
      return Registries.EFFECT_REG.Register(new ResourceLocation(id), effect);
    }
  }
  public class TypeAsset<T>
  {
    public T type;
    public TypeAsset()
    {

    }
  }
}

