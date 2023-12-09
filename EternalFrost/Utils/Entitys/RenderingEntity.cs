using EternalFrost.Utils.Renderers.EntityDrawers;
using EternalFrost.Utils.TileMap;

namespace EternalFrost.Utils.Entitys
{
	public class RenderingEntity : Entity
	{
		protected EntityDrawer Drawer;
		public bool Visible = true;
		public RenderingEntity(Vector2 position, World world): base(position, world)
		{
		}
		public virtual void Render(SpriteBatch batch)
		{
			Drawer.Draw(batch, this);
		}
	}
}

