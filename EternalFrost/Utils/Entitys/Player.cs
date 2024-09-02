
using EternalFrost.Input;
using EternalFrost.Utils.Renderers.EntityDrawers;
using EternalFrost.InGameTypes;
using EternalFrost.Item;
using EternalFrost.Entitys;
using EternalFrost.Registry;
using EternalFrost.Utils.TileMap;
using EternalFrost.Managers;

namespace EternalFrost.Utils.Entitys
{
  public class Player : AnimateEntity
  {
    public Player(Vector2 pos, World world) : base(pos, world)
    {
      Drawer = new StaticSpriteDrawer(EternalFrost.tileAtlas.GetSprite(new ResourceLocation("textures/entities/player.png")));
      Inventory.AddItem(new WorldItem(Items.SNOW_TILE, 120));
    }
    public override void Update(GameTime gameTime)
    {
      base.Update(gameTime);
      if (Keyboard.GetState().IsKeyDown(Keybinds.JUMP.Bind) && isOnGround)
      {
        Velocity += new Vector2(0, -10f);
        isOnGround = false;
      }
      if (Keyboard.GetState().IsKeyDown(Keybinds.W.Bind))
      {
        AddForce(new Vector2(0, -5f));
      }
      if (Keyboard.GetState().IsKeyDown(Keybinds.DROP.Bind))
      {
        var item = Inventory.Drop(0, 1);
        if (item != null)
        {
          WorldManager.world.SafeSpawnEntity(new ItemEntity(Position, World, item));
          if (item.Item != Items.EMPTY)
          {

          }
        }
        //Console.WriteLine(Inventory.Items[0].count);
      }
      if (Keyboard.GetState().IsKeyDown(Keybinds.A.Bind))
      {
        AddForce(new Vector2(-0.5f, 0));
      }
      if (Keyboard.GetState().IsKeyDown(Keybinds.S.Bind))
      {
        AddForce(new Vector2(0, 0.5f));
        Inventory.AddItem(new WorldItem(Items.SNOW_TILE, 120));
      }
      if (Keyboard.GetState().IsKeyDown(Keybinds.D.Bind))
      {
        AddForce(new Vector2(0.5f, 0 * Convert.ToByte(true)));
      }
      isOnGround = false;
      CalcBBB();
      EternalFrost.camera.Position = Position + (EternalFrost.camera.Position - EternalFrost.camera.Center);
    }
  }
}

