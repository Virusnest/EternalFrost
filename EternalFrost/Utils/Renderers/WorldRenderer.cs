using EternalFrost.Utils.Entitys;

namespace EternalFrost.Utils.TileMap
{
	public class WorldRenderer
	{
    ChunkRenderer chunkRenderer;

		public WorldRenderer()
		{
			chunkRenderer = new ChunkRenderer();
    }
    public void Render(SpriteBatch spriteBatch, Matrix viewMatrix, World world)
	  {
			foreach(var chunk in world.chunks) {
				chunkRenderer.DrawLayer(spriteBatch, viewMatrix, chunk, 0);
				chunkRenderer.DrawLayer(spriteBatch, viewMatrix, chunk, 1);
			}
			//TODO: Implement Entity Rendering
			spriteBatch.Begin(transformMatrix: viewMatrix, samplerState: SamplerState.PointClamp);
			foreach (var chunk in world.chunks) {
				foreach(var entity in chunk.entities) {
					if (entity is RenderingEntity) {
						var tmp = entity as RenderingEntity;
						if (tmp.Visible) {
							tmp.Render(spriteBatch);
						}
					}
				}
			}
			spriteBatch.End();
			foreach (var chunk in world.chunks) {
				chunkRenderer.DrawLayer(spriteBatch, viewMatrix, chunk, 2);
			}
		}
	}
}

