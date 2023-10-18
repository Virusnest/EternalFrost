using System.Collections.Generic;
using System.Linq;
using EternalFrost.Collision;
using EternalFrost.Input;
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
		public Vector2 Velocity = Vector2.Zero;
		public bool isPhysical = true;
		private bool hasCollided = false;
		public bool isOnGround = false;
		private bool groundnextframe = false;
		public bool HasGravity = true;
		public RectangleF BBB;
		public float Mass=1;
		public Vector2 Force;
		public float AirFriction = 0.01f;
		public Vector2 Acceleration;
		public float friction;
		private bool Colliding=false;
		RectangleF slideBox = new RectangleF(0,0,6,16);
		public PhysicalEntity(Vector2 position) : base(position)
		{
			Velocity = Vector2.Zero;
			CollisionBox = new RectangleF(1, 0, 6, 16);
			BBB = new RectangleF();
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
			//F=ma
			Velocity +=force / Mass;
		}
		public bool isColliding(RectangleF rect)
		{ 
			return WorldCollider().Intersects(rect);
		}
		public bool willCollide(RectangleF rect)
		{
			return WorldColliderPredict().Intersects(rect);
		}
		public TilePos getTilePos()
		{
			return (Position + new Vector2(CollisionBox.Width / 2, CollisionBox.Bottom)).ToTilePos(1);
		}

		public void ApplyAirResistance()
		{
			// Calculate air resistance force (opposite direction of velocity)
			Vector2 airResistance = -Velocity * Velocity.Length() * AirFriction;

			// Apply the air resistance force
			AddForce(airResistance);
		}
		public void UpdateMovement(World world)
		{

			if (isPhysical) {
				UpdateCollision(world);
			}
			Position += Velocity;
			if (world.GetTile(getTilePos() + new TilePos(0, 1, 0)) != null)
				Velocity.X *= world.GetTile(getTilePos() + new TilePos(0, 1, 0)).Properties.Frition;
			//else
			ApplyAirResistance();
			//Velocity *= AirFriction;
		}

		public void CalcBBB()
		{
			var worldColl = WorldCollider();
			if (Velocity.X > 0) {
				BBB.X=worldColl.X;
			} else { BBB.X = WorldColliderPredict().X; }
			if (Velocity.Y > 0) {
				BBB.Y = worldColl.Y;
			} else { BBB.Y = WorldColliderPredict().Y; }
			BBB.Width = worldColl.Width + Math.Abs(Velocity.X);
			BBB.Height = worldColl.Height + Math.Abs(Velocity.Y);
		}
		public void UpdateCollision(World world)
		{
			for (int i = 0; i < 2	; i++) {
				List<CollisionResult> collisions = new List<CollisionResult>();
				for (int x = (int)MathF.Floor(BBB.Left / ChunkRenderer.TILESIZE); x < (int)MathF.Ceiling(BBB.Right / ChunkRenderer.TILESIZE); x++) {
					for (int y = (int)MathF.Floor(BBB.Top / ChunkRenderer.TILESIZE); y < (int)MathF.Ceiling(BBB.Bottom / ChunkRenderer.TILESIZE); y++) {
						var pos = new TilePos(x, y, 1);
						if (world.GetTile(pos) == null) continue;
						var plat = new RectangleF(pos.ToWorldVec().X, pos.ToWorldVec().Y, 8, 8);
						var col = Collisions.SweptAABB(WorldCollider(), plat, Velocity);
						if (col.Normal == Vector2.Zero) continue;
						collisions.Add(col);
					}
				}
				if (collisions.Count == 0) break;
				CollisionResult minValue = collisions.Aggregate((min, current) => current.EntryTime < min.EntryTime ? current : min);
				float collisiontime = minValue.EntryTime;
				var normal = minValue.Normal;
				collisiontime -= 0.001f;
				//Console.WriteLine(normal);
				if (normal.Y != 0) {
					Console.WriteLine(Velocity.Y);
					if (Velocity.Y >= 0) isOnGround = true;

				}
				Velocity += normal * new Vector2(MathF.Abs(Velocity.X), MathF.Abs(Velocity.Y)) * (1 - collisiontime);
				Velocity.ToAngle();

				if (normal.X != 0) {

				}

			}
			//

		}
		public override void Render(SpriteBatch batch)
		{
			base.Render(batch);
			for (int x = (int)MathF.Floor(BBB.Left / ChunkRenderer.TILESIZE); x < (int)MathF.Ceiling(BBB.Right / ChunkRenderer.TILESIZE); x++) {
				for (int y = (int)MathF.Floor(BBB.Top / ChunkRenderer.TILESIZE); y < (int)MathF.Ceiling(BBB.Bottom / ChunkRenderer.TILESIZE); y++) {
					var pos = new TilePos(x, y, 1);
					var plat = new RectangleF(pos.ToWorldVec().X, pos.ToWorldVec().Y, 8, 8);
					//batch.DrawRectangle(plat, Color.Black);
				}
			}
			
			batch.DrawRectangle(WorldCollider(), Color.White);
			batch.DrawRectangle(WorldColliderPredict(), Color.White);
			batch.DrawLine(Vector2.Zero, 100, EternalFrost.camera.ScreenToWorld(Mouse.GetState().Position.ToVector2()).ToAngle(), Color.Red);
		}
		protected virtual void OnCollide()
		{

		}
	}
}

