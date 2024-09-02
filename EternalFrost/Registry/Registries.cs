
using EternalFrost.Entitys;
using EternalFrost.Input;
using EternalFrost.Utils;
using EternalFrost.Utils.Entitys;
using EternalFrost.Utils.TileMap.Tile;

namespace EternalFrost.Registry
{
  public static class Registries
  {
    public static Registry<Tile> TILE_REG = new Registry<Tile>(new ResourceLocation("tiles"));
    public static Registry<Item.Item> ITEM_REG = new(new ResourceLocation("items"));

    public static Registry<Type> ENTITY_REG = new Registry<Type>(new ResourceLocation("entities"));
    public static Registry<Keybind> KEYBIND_REG = new Registry<Keybind>(new ResourceLocation("keybinds"));
    public static Registry<TypeAsset<Effect>> EFFECT_REG = new Registry<TypeAsset<Effect>>(new ResourceLocation("effects"));


  }
}

