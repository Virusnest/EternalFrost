using EternalFrost.Types;
using EternalFrost.Utils.ClassExtentions;
using EternalFrost.Utils.TileMap;
using MonoGame.Extended;

namespace EternalFrost.Utils.Entitys
{
	public class PhysicalEntity : RenderingEntity
	{
		public const float GRAVITY = 0.5f;
		public RectangleF CollisionBox;
		public Vector2 Velocity;
		public bool isPhysical = true;
		private bool hasCollided = false;
		public bool isOnGround = false;
		public bool HasGravity = true;
		public float Mass=1;
		public float AirFriction = 0.9f;
		public Vector2 Acceleration;
		public float friction;
		public Vector2 oldPosition;
		public PhysicalEntity(Vector2 position) : base(position)
		{
			Velocity = Vector2.Zero;
			CollisionBox = new RectangleF(0, 0, 8, 8);
		}

		public RectangleF WorldCollider()
		{
			var tmp = CollisionBox;
			tmp.Offset(Position);
			return tmp;
		}
		public RectangleF WorldColliderPredict()
		{
			var tmp = CollisionBox;
			tmp.Offset(Position+Velocity);
			return tmp;
		}

		public void AddForce(Vector2 force)
		{
			//f=m*a
			Acceleration = force / Mass;
		}
		public bool isColliding(RectangleF rect)
		{ 
			return WorldCollider().Intersects(rect);
		}
		public bool willCollide(RectangleF rect)
		{
			return WorldColliderPredict().Intersects(rect);
		}
		public void UpdateMovement(World world)
		{
			oldPosition = Position;
			Velocity *= AirFriction;
			//Velocity += Acceleration;
			//Acceleration *= 0;
			Position.X += Velocity.X;
			if (isPhysical) { if (UpdateCollision(world)) { Position.X = oldPosition.X;
					Velocity.X = 0;
				} }
			Position.Y += Velocity.Y;
			if (isPhysical) {
				if (UpdateCollision(world)) {
					if (Velocity.Y >= 0) isOnGround = true;
					Position.Y = oldPosition.Y;
					Velocity.Y = 0;
				}
			}
			if (HasGravity) { Velocity.Y += GRAVITY; }
		}
		public bool UpdateCollision(World world)
		{
			bool hasCollided = false;
			for (int x= (int)MathF.Floor(Position.X/ChunkRenderer.TILESIZE)-1; x < Position.ToTilePos(1).X+(int)CollisionBox.Width / ChunkRenderer.TILESIZE+1; x++){
				for (int y = (int)MathF.Floor(Position.Y / ChunkRenderer.TILESIZE)-1; y < Position.ToTilePos(1).Y + (int)CollisionBox.Height / ChunkRenderer.TILESIZE+1; y++) {
					if (world.GetTile(x, y, 1) != null) {
						if (CollidesWith(new TilePos(x, y, 1), WorldCollider())) {
							//Position = oldPosition;
							//Velocity *=0;
							hasCollided=true;
						}
						RectangleF down = WorldCollider();
						down.Offset(0, 1);
						if (CollidesWith(new TilePos(x, y, 1), down)) {
							//isOnGround = true;
							//return true;
						} //else { isOnGround = false; }
					}
				}
			}
			return hasCollided;

		}
		public bool CollidesWith(TilePos pos,RectangleF collider)
		{
			var rec = new RectangleF(pos.ToWorldVec().X, pos.ToWorldVec().Y, 8,8);
			//rec.Intersects(WorldCollider());
			//bool xoverlaps = (pos.ToWorldVec().X < WorldCollider().Right) &&(pos.ToWorldVec().X+ChunkRenderer.TILESIZE> WorldCollider().Left);
			//bool yoverlaps = (pos.ToWorldVec().Y < WorldCollider().Bottom) && ((pos.ToWorldVec().Y+ ChunkRenderer.TILESIZE) < (WorldCollider().Top));

			return rec.Intersects(collider);
		}
		protected virtual void OnCollide()
		{

		}
	}
}

