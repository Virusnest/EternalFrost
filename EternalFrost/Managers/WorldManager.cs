using System.Linq;
using EternalFrost.Entitys;
using EternalFrost.InGameTypes;
using EternalFrost.Item;
using EternalFrost.Types;
using EternalFrost.Utils.ClassExtentions;
using EternalFrost.Utils.Entitys;
using EternalFrost.Utils.TileMap;
using EternalFrost.Utils.TileMap.Generation;
using EternalFrost.Utils.TileMap.Generation.Generators;
using EternalFrost.Utils.TileMap.Tile;
using MonoGame.Extended;

namespace EternalFrost.Managers
{
	public class WorldManager
	{
		public World world;
		ChunkGenerator generator;
		public WorldRenderer renderer;
		public Player player;
		
		public WorldManager()
		{
			world = new World();
			generator = new ChunkGenerator(new SinGenerator(new WorldTile(Tiles.ICE)));
			renderer = new WorldRenderer();
		}
		public void Generate(Chunk o)
		{
			if (!o.isDirty) {
				generator.GenerateChunk(o);
			}
		}
		public void Init()
		{
			var pos = new TilePos(1000,0,1);
			player = new Player( pos.ToWorldVec(),world);
			Console.WriteLine(pos.ToChunkPos().AsWorldVec());
			Console.WriteLine(pos.ToWorldVec());
			var chunk = new Chunk( pos.ToChunkPos());
			chunk.entities.Add(player);
			world.chunks.Add(chunk);
		}
		public void Update(OrthographicCamera camera,GameTime time)
		{
			var BL = Vector2.Round(((Vector2)camera.BoundingRectangle.BottomLeft)/ChunkRenderer.TILESIZE / Chunk.WIDTH);
			var TR = Vector2.Round(((Vector2)camera.BoundingRectangle.TopRight)/ ChunkRenderer.TILESIZE / Chunk.WIDTH);
			for (int x = (int)BL.X-1; x < (int)TR.X+1; x++) {
				for (int y = (int)TR.Y-1; y < (int)BL.Y+1; y++) {
					var pos = new ChunkPos(x, y);
					if (!world.chunks.ContainsKey(pos)) {
						world.chunks.Add(new Chunk(pos));
					}
				}
			}
			var bounds = (Rectangle)camera.BoundingRectangle;
			bounds.Inflate(ChunkRenderer.TILESIZE * Chunk.WIDTH*2, ChunkRenderer.TILESIZE * Chunk.HEIGHT*2);
			foreach (Chunk chunk in world.chunks) {
				Generate(chunk);
				foreach (Entity e in chunk.entities) {
					if (e.Position.ToTilePos(1).ToChunkPos() != chunk.pos) {
						//Console.WriteLine(chunk.pos.ToString()+" "+entity.Position.ToString());
						if (world.chunks.ContainsKey(e.Position.ToTilePos(1).ToChunkPos())) {
							world.chunks[e.Position.ToTilePos(1).ToChunkPos()].entities.Add(e);
							chunk.entities.Remove(e);
						}
					}
					if (e is PhysicalEntity) {
						((PhysicalEntity)e).UpdateMovement();
					}
					e.Update(time);
					if (e is PhysicalEntity) {
						((PhysicalEntity)e).CalcBBB();
					}
					if (e.ToDespawn) chunk.entities.Remove(e);
				}
				var boundpos = new Vector2(chunk.pos.X * ChunkRenderer.TILESIZE * Chunk.WIDTH, chunk.pos.Y * ChunkRenderer.TILESIZE * Chunk.HEIGHT);
				if (!bounds.Contains(new Rectangle(boundpos.ToPoint(),new Point((int)Chunk.GetBoundingBox().Width, (int)Chunk.GetBoundingBox().Height)))) {
					world.chunks.Remove(chunk);
				}
			}
			foreach (Entity e in world.SpawnQueue) {
				world.SpawnEntity(e);
			}
			world.SpawnQueue.Clear();
		}
		public void Render(SpriteBatch spriteBatch, Matrix viewMatrix)
		{
			renderer.Render(spriteBatch, viewMatrix, world);
		}
		
	}
}

