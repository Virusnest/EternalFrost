namespace EternalFrost.Utils.TileMap.Generation
{
	public class ChunkGenerator
	{
		public Generator generator { get; private set; }
		public ChunkGenerator(Generator generator)
		{
			this.generator = generator;
		}
		public void GenerateChunk(Chunk chunk)
		{
			for(int i=0; i < chunk.tiles.Length; i++) {
				chunk.tiles[i]=generator.GetTile(chunk.to3D(i).ToGlobalPos(chunk.pos));
			}
			chunk.isDirty = true;
		}
	}
}

