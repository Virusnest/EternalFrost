using System.Collections.Generic;
using EternalFrost.Collections;
using EternalFrost.Utils.TileMap;
using MonoGame.Extended.Collections;

namespace EternalFrost.Utils.Entitys
{
  public class AnimateEntity : PhysicalEntity
  {
    public float Temperature;
    public float Health;
    public float Hunger;
    public float Air;
    public float Thirst;
    public Inventory Inventory = new Inventory(16);
    public AnimateEntity(Vector2 pos, World world) : base(pos, world)
    {

    }

  }
}

