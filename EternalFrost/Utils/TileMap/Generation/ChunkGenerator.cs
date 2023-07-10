using System;
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
			generator.Generate(chunk);
			chunk.isDirty = true;
		}
	}
}

