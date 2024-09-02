using System;
namespace EternalFrost.Collision
{
  public class CollisionResult
  {
    public bool HasCollided;
    public float EntryTime;
    public Vector2 Normal, EntryDist;
    public CollisionResult(bool collision, Vector2 normal, Vector2 entryDist, float entryTime)
    {
      HasCollided = collision;
      Normal = normal;
      EntryTime = entryTime;
      EntryDist = entryDist;
    }
    public CollisionResult(bool collision)
    {
      HasCollided = collision;
    }
    public CollisionResult(bool collision, float entryTime)
    {
      HasCollided = collision;
      EntryTime = entryTime;
    }
  }
}

