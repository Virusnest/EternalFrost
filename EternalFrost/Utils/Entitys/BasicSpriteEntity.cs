using EternalFrost.Input;
using EternalFrost.Utils.Renderers.EntityDrawers;

namespace EternalFrost.Utils.Entitys
{
	public class BasicSpriteEntity:PhysicalEntity
	{
		public BasicSpriteEntity(Vector2 pos) : base(pos)
		{
			Drawer = new StaticSpriteDrawer(EternalFrost.tileAtlas.textures[new Registry.ResourceLocation("textures/entities/basic_sprite_entity.png")]);
		}
		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
			//AddForce(new Vector2(-1, 1));
			if (HasGravity) { Velocity.Y += GRAVITY; }
			if (Keyboard.GetState().IsKeyDown(Keybinds.JUMP.Bind) && isOnGround) {
				AddForce(new Vector2(0, -10f));
				isOnGround = false;
			}
			if (Keyboard.GetState().IsKeyDown(Keybinds.W.Bind)) {
				AddForce(new Vector2(0, -1f));
				isOnGround = false;
			}
			if (Keyboard.GetState().IsKeyDown(Keybinds.A.Bind)) {
				AddForce(new Vector2(-1f, 0));
				isOnGround = false;
			}
			if (Keyboard.GetState().IsKeyDown(Keybinds.S.Bind)) {
				AddForce(new Vector2(0, 1f));
				isOnGround = false;
			}
			if (Keyboard.GetState().IsKeyDown(Keybinds.D.Bind)) {
				AddForce(new Vector2(1f, 0));
				isOnGround = false;
			}
			CalcBBB();
			EternalFrost.camera.Position = Position+(EternalFrost.camera.Position-EternalFrost.camera.Center);
		}
	}
}

