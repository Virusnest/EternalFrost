using System;
using MonoGame.Extended;

namespace EternalFrost.Collision
{
	public static class Collisions
	{
		public static CollisionResult SweptAABB(RectangleF a, RectangleF b, Vector2 vel)
		{
			Vector2 EntryDist, ExitDist, EntryTime, ExitTime;
			if (vel.X > 0f) {
				EntryDist.X = b.X - (a.X + a.Width);
				ExitDist.X = (b.X + b.Width) - a.X;
			} else {
				EntryDist.X = (b.X + b.Width) - a.X;
				ExitDist.X = b.X - (a.X + a.Width);
			}
			if (vel.Y > 0f) {
				EntryDist.Y = b.Y - (a.Y + a.Height);
				ExitDist.Y = (b.Y + b.Height) - a.Y;
			} else {
				EntryDist.Y = (b.Y + b.Height) - a.Y;
				ExitDist.Y = b.Y - (a.Y + a.Height);
			}

			if (vel.X != 0) {
				EntryTime.X = (EntryDist.X / vel.X);
				ExitTime.X = (ExitDist.X / vel.X);
			} else {
				EntryTime.X = float.NegativeInfinity;
				ExitTime.X = float.PositiveInfinity;
			}
			if (vel.Y != 0) {
				EntryTime.Y = (EntryDist.Y / vel.Y);
				ExitTime.Y = (ExitDist.Y / vel.Y);
			} else {
				EntryTime.Y = float.NegativeInfinity;
				ExitTime.Y = float.PositiveInfinity;
			}
			float entryTime = Math.Max(EntryTime.X, EntryTime.Y);
			float exitTime = Math.Min(ExitTime.X, ExitTime.Y);
			if (EntryTime.X > 1.0f || EntryTime.Y > 1.0f) {
				return new CollisionResult(false, Vector2.Zero, Vector2.Zero, 0f);
			}
			if (EntryTime.X < 0.0f && EntryTime.Y < 0.0f) {
				return new CollisionResult(false, Vector2.Zero, Vector2.Zero, 0f);
			}
			if (entryTime > exitTime) {
				return new CollisionResult(false,Vector2.Zero,Vector2.Zero,0f);

			} else {
				Vector2 normal = new Vector2();
				if (EntryTime.X > EntryTime.Y) {
					if (vel.X < 0f) {
						normal.X = 1f;
					} else {
						normal.X = -1f;
					}
				} else {
					if (vel.Y < 0f) {
						normal.Y = 1f;
					} else {
						normal.Y = -1f;
					}
				}
				return new CollisionResult(true,normal,EntryDist,entryTime);
			}
		}
	}
}

