
using EternalFrost.Utils.TileMap;
using PeterO.Cbor;

namespace EternalFrost.Utils.Entitys
{
	public class Entity
	{
		public Vector2 Position;
		public bool ToDespawn = false;
		public bool Active = true;
		public Guid Guid { get; private set; }
		protected World World;
		public CBORObject Data=DEFAULT_DATA;
		public static CBORObject DEFAULT_DATA = CBORObject.NewMap()
			.Add("Pos",Vector2.Zero)
			.Add("GUID",Guid.NewGuid());
		public Entity(Vector2 position,World world)
		{
			World = world;
			Position = position;
			Guid = Guid.NewGuid();
		}
		public Entity(CBORObject data, World world)
		{
			Data = data;
			World = world;
		}
		public Entity(Vector2 position, World world, Guid guid)
		{
			World = world;
			Position = position;
			Guid = guid;
		}

		public virtual void Update(GameTime gameTime)
		{
			// Add update code here
			
		}
	}

}

