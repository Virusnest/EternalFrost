using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Threading;
using EternalFrost.InGameTypes;
using EternalFrost.Types;
using EternalFrost.Utils.ClassExtentions;
using EternalFrost.Utils.Entitys;
using EternalFrost.Utils.TileMap;
using EternalFrost.Utils.TileMap.Generation;
using EternalFrost.Utils.TileMap.Generation.Generators;
using EternalFrost.Utils.TileMap.Tiles;
using MonoGame.Extended;

namespace EternalFrost.Managers
{
	public class WorldManager
	{
		public World world;
		ChunkGenerator generator;
		public WorldRenderer renderer;
		
		public WorldManager()
		{
			world = new World();
			generator = new ChunkGenerator(new SinGenerator(new WorldTile(Tiles.ICE)));
			renderer = new WorldRenderer();
		}
		public void Generate(Chunk o)
		{
			if (!o.isDirty) {
				//Console.WriteLine(o.pos);
					generator.GenerateChunk(o);
			}
		}
		public void Init()
		{
			var chunk = new Chunk(ChunkPos.Zero);
			chunk.entities.Add(new BasicSpriteEntity(Vector2.One));
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
				//ThreadPool.QueueUserWorkItem(Generate, chunk,true);
				Generate(chunk);
				foreach (Entity entity in chunk.entities) {
					entity.Update(time);
					if (entity.Position.ToTilePos(1).ToChunkPos() != chunk.pos) {
						//Console.WriteLine(chunk.pos.ToString()+" "+entity.Position.ToString());
						if (world.chunks.ContainsKey(entity.Position.ToTilePos(1).ToChunkPos())) {
							world.chunks[entity.Position.ToTilePos(1).ToChunkPos()].entities.Add(entity);
							chunk.entities.Remove(entity);
						}
					}
					if(entity is PhysicalEntity) {
						((PhysicalEntity)entity).UpdateMovement(world);
					}
				}
				var boundpos = new Vector2(chunk.pos.X * ChunkRenderer.TILESIZE * Chunk.WIDTH, chunk.pos.Y * ChunkRenderer.TILESIZE * Chunk.HEIGHT);
				if (!bounds.Contains(new Rectangle(boundpos.ToPoint(),new Point((int)Chunk.GetBoundingBox().Width, (int)Chunk.GetBoundingBox().Height)))) {
					world.chunks.Remove(chunk);
				}
			}
		}
		public void Render(SpriteBatch spriteBatch, Matrix viewMatrix)
		{
			renderer.Render(spriteBatch, viewMatrix, world);
		}
		
	}
}

