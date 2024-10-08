﻿using EternalFrost.Utils.TileMap;
using MonoGame.Extended;

namespace EternalFrost.Types
{
  public struct TilePos : IEquatable<TilePos>
  {
    public TilePos(int x, int y, int z)
    {
      X = x;
      Y = y;
      Z = z;
    }
    public int X, Y, Z;
    public override string ToString() => $"({X}, {Y}, {Z})";
    public TilePos Zero()
    {
      return new TilePos(0, 0, 0);
    }

    public bool Equals(TilePos other)
    {
      return (X == other.X) && (Y == other.Y) && (Z == other.Z);
    }
    public override int GetHashCode()
    {
      return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
    }
    public int GetHashedPos()
    {
      long l = (X * 39037871) ^ Z * 13486921L ^ Y;
      l = l * l * 1208897L + l * 16L;
      return (int)l >> 16;
    }
    public Vector2 ToWorldVec()
    {
      return new Vector2((int)((long)X * ChunkRenderer.TILESIZE), (int)((long)Y * ChunkRenderer.TILESIZE));
    }
    public TilePos ToChunkLocal()
    {
      TilePos tilePos = new TilePos(X % Chunk.WIDTH, Y % Chunk.HEIGHT, Z);

      if (tilePos.X < 0)
      {
        tilePos.X += Chunk.WIDTH;
      }
      if (tilePos.Y < 0)
      {
        tilePos.Y += Chunk.HEIGHT;
      }

      return tilePos;
    }

    public static bool operator ==(TilePos tile1, TilePos tile2)
    {
      if (((object)tile1) == null || ((object)tile2) == null)
        return Equals(tile1, tile2);

      return tile1.Equals(tile2);
    }

    public static bool operator !=(TilePos tile1, TilePos tile2)
    {
      if (((object)tile1) == null || ((object)tile2) == null)
        return !Equals(tile1, tile2);

      return !tile1.Equals(tile2);
    }
    public static TilePos operator -(TilePos tile1, TilePos tile2)
    {
      return new TilePos(tile1.X - tile2.X, tile1.Y - tile2.Y, tile1.Z);
    }

    public static TilePos operator +(TilePos tile1, TilePos tile2)
    {
      return new TilePos(tile1.X + tile2.X, tile1.Y + tile2.Y, tile1.Z);
    }

    public TilePos ToGlobalPos(ChunkPos pos)
    {
      return new TilePos(X + (pos.X * Chunk.WIDTH), Y + (pos.Y * Chunk.HEIGHT), Z);
    }
    public ChunkPos ToChunkPos()
    {
      return new ChunkPos((int)Math.Floor((double)X / (double)Chunk.WIDTH), (int)Math.Floor((double)Y / (double)Chunk.HEIGHT));
    }

  }
}

