using EternalFrost.InGameTypes;
using EternalFrost.Types;
using EternalFrost.Utils.ClassExtentions;
using EternalFrost.Utils.Entitys;
using MonoGame.Extended.Collections;

namespace EternalFrost.Utils.TileMap
{
  public class World
  {
    public double Time;
    public static int DAY_LENGTH = 1440;
    public KeyedCollection<ChunkPos, Chunk> chunks;
    public const int SIZE = int.MaxValue / 2;
    public Bag<Entity> SpawnQueue = new Bag<Entity>(10);
    public World()
    {
      chunks = new KeyedCollection<ChunkPos, Chunk>(c => c.pos);
    }
    public void SetTile(TilePos pos, WorldTile tile)
    {
      ChunkPos chunkPos = new ChunkPos((int)MathF.Floor((float)pos.X / Chunk.WIDTH), (int)MathF.Floor((float)pos.Y / Chunk.HEIGHT));
      TilePos blockPos = pos.ToChunkLocal();
      //Console.WriteLine($"{chunkPos}, {blockPos}");
      if (chunks.ContainsKey(chunkPos))
      {
        chunks[chunkPos].SetTile(blockPos, tile);
      }
    }
    public void SetTile(System.Drawing.Point pos, int z, WorldTile tile)
    {
      SetTile(new TilePos(pos.X, pos.Y, z), tile);
    }
    public WorldTile GetTile(TilePos pos)
    {
      return GetTile(pos.X, pos.Y, pos.Z);
    }
    public WorldTile GetTile(int x, int y, int z)
    {
      var pos = new TilePos(x, y, z);
      if (!chunks.ContainsKey(pos.ToChunkPos())) { return null; }
      return chunks[pos.ToChunkPos()].GetTile(pos.ToChunkLocal());
    }
    public void SpawnEntity(Entity entity)
    {
      if (!chunks.ContainsKey(entity.Position.ToTilePos(1).ToChunkPos())) return;
      chunks[entity.Position.ToTilePos(1).ToChunkPos()].entities.Add(entity);
    }
    public void SafeSpawnEntity(Entity entity)
    {
      SpawnQueue.Add(entity);
    }

    public void SetTile(int x, int y, int z, WorldTile tile)
    {
      SetTile(new TilePos(x, y, z), tile);
    }
    public int GetDayMinute() { return (int)(Time % DAY_LENGTH); }
    public int GetDay() { return (int)(Time / DAY_LENGTH); }
  }
}

