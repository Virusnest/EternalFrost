using System;
using EternalFrost.Utils.ClassExtentions;
using EternalFrost.Utils.Renderers.EntityDrawers;
using EternalFrost.Utils.TileMap;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace EternalFrost.Utils.Entitys
{
	public class PhysicalEntity : RenderingEntity
	{
		public const float GRAVITY = 2f;
		public RectangleF CollisionBox;
		public Vector2 Velocity;
		public bool Physical = true;
		private bool hasCollided = false;
		public bool isOnGround = false;
		public bool HasGravity = true;
		public float Mass;
		public float AirFriction = 0.9f;
		public float friction;
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
			Velocity *= AirFriction;
			Position += Velocity;
			if (HasGravity) { Velocity.Y += GRAVITY*Mass; }

		}
		public void UpdateCollision(World world)
		{
			for (int x= (int)Position.X-(int)CollisionBox.Width/ChunkRenderer.TILESIZE; x > Position.ToBlockPos(1).X+ (int)CollisionBox.Width / ChunkRenderer.TILESIZE; x++){
				for (int y = (int)Position.Y - (int)CollisionBox.Height / ChunkRenderer.TILESIZE; y > Position.ToBlockPos(1).Y+ (int)CollisionBox.Height / ChunkRenderer.TILESIZE; x++) {
					if(world.GetTile(x, y, 1) == null) {
						
					}
				}
			}

		}
		protected virtual void OnCollide()
		{

		}
	}
}

