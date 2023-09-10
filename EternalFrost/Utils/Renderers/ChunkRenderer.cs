using MonoGame.Extended;
using EternalFrost.Types;

namespace EternalFrost.Utils.TileMap
{
	public class ChunkRenderer
	{
		public static int TILESIZE = 8;
		public void DrawLayer(SpriteBatch batch,Matrix viewMatrix, Chunk chunk,int layer)
		{
			batch.Begin(transformMatrix: viewMatrix,samplerState: SamplerState.PointClamp) ;
			for (int x = 0; x < Chunk.WIDTH; x++) {
				for (int y = 0; y < Chunk.HEIGHT; y++) {
					var pos = new TilePos(x, y, layer).ToGlobalPos(chunk.pos);
					if (chunk.GetTile(x, y,layer) != null) {
						batch.Draw(EternalFrost.tileAtlas.getTexture(), pos.ToWorldVec()+new Vector2(4,4), EternalFrost.tileAtlas.textures[chunk.GetTile(x,y,layer).registryItem.getLocation()],Color.White,MathHelper.ToRadians(pos.ToWorldVec().GetHashCode()%90*45),new Vector2(4,4),Vector2.One,SpriteEffects.None,1);
					}
				}  
			}
#if DEBUG
			var rect =Chunk.GetBoundingBox();
			rect.Offset(chunk.pos.X*TILESIZE*Chunk.WIDTH, chunk.pos.Y* TILESIZE * Chunk.HEIGHT);
			batch.DrawRectangle(rect,Color.Red);
			batch.DrawString(EternalFrost.font,chunk.pos.X+" "+chunk.pos.Y,rect.TopLeft,Color.Black);
#endif
			batch.End();
		}
	}
}

