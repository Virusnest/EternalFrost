
namespace EternalFrost.Utils.Entitys
{
	public class Entity
	{
		public Vector2 Position;
		public bool Active = true;
		public Guid Guid { get; private set; }

		public Entity(Vector2 position)
		{
			Position = position;
			Guid = Guid.NewGuid();
		}
		public Entity(Vector2 position, Guid guid)
		{
			Position = position;
			Guid = guid;
		}

		public virtual void Update(GameTime gameTime)
		{
			// Add update code here

		}
	}

}

