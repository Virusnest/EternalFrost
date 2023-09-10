using EternalFrost.Utils.Renderers.EntityDrawers;

namespace EternalFrost.Utils.Entitys
{
	public class RenderingEntity : Entity
	{
		protected EntityDrawer Drawer;
		public bool Visible = true;
		public RenderingEntity(Vector2 position): base(position)
		{
		}
		public void Render(SpriteBatch batch)
		{
			Drawer.Draw(batch, this);
		}
	}
}

