using EternalFrost.Input;
using EternalFrost.Utils.Renderers.EntityDrawers;

namespace EternalFrost.Utils.Entitys
{
	public class BasicSpriteEntity:PhysicalEntity
	{
		public BasicSpriteEntity(Vector2 pos) : base(pos)
		{
			Drawer = new StaticSpriteDrawer(EternalFrost.tileAtlas.atlas);
		}

		public override void Update(GameTime gameTime)
		{
			if (Keyboard.GetState().IsKeyDown(Keybinds.JUMP.Bind)&&isOnGround) {
				Velocity+= new Vector2(0, -10f);
				isOnGround = false;
			}
			if (Keyboard.GetState().IsKeyDown(Keybinds.W.Bind)) {
				Velocity += new Vector2(0, -0.5f);
				isOnGround = false;
			}
			if (Keyboard.GetState().IsKeyDown(Keybinds.A.Bind)) {
				Velocity += new Vector2(-0.5f, 0);
				isOnGround = false;
			}
			if (Keyboard.GetState().IsKeyDown(Keybinds.S.Bind)) {
				Velocity += new Vector2(0, 0.5f);
				isOnGround = false;
			}
			if (Keyboard.GetState().IsKeyDown(Keybinds.D.Bind)) {
				Velocity += new Vector2(0.5f, 0);
				isOnGround = false;
			}
			base.Update(gameTime);
		}
	}
}

