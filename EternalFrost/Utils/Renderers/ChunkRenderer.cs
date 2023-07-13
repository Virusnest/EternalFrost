using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MonoGame.Extended;
using System.Reflection.Emit;

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
					Point pos = new Point(x*TILESIZE, y*TILESIZE) + new Point(chunk.pos.X*TILESIZE*Chunk.WIDTH,chunk.pos.Y*TILESIZE*Chunk.HEIGHT);
					if (chunk.GetTile(x, y,layer) != null) {
						batch.Draw(EternalFrost.tileAtlas.getTexture(), pos.ToVector2(), EternalFrost.tileAtlas.textures[chunk.GetTile(x,y,layer).registryItem.getLocation()],Color.White);
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

