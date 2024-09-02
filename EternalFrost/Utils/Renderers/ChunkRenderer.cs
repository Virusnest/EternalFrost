using MonoGame.Extended;
using EternalFrost.Types;
using EternalFrost.Utils.TileMap.Tile;

namespace EternalFrost.Utils.TileMap
{
  public class ChunkRenderer
  {
    public static int TILESIZE = 8;
    public void DrawLayer(SpriteBatch batch, Matrix viewMatrix, Chunk chunk, int layer)
    {
      batch.Begin(transformMatrix: viewMatrix, samplerState: SamplerState.PointClamp);
      for (int x = 0; x < Chunk.WIDTH; x++)
      {
        for (int y = 0; y < Chunk.HEIGHT; y++)
        {
          var pos = new TilePos(x, y, layer).ToGlobalPos(chunk.pos);
          if (chunk.GetTile(x, y, layer).tile != Tiles.EMPTY)
          {
            TileSprite sprite = TileSprite.ConvertSpriteToTileSprite(EternalFrost.tileAtlas.GetSprite(chunk.GetTile(x, y, layer).registryItem.getLocation().WithPrefixID("textures/").WithSuffix(".png")));
            var rec = sprite.Bounds;
            rec.Width = sprite.TileSpriteBounds.Width;
            rec.Height = sprite.TileSpriteBounds.Height;
            //Console.WriteLine((byte)pos.GetHashedPos() % sprite.Variations);
            rec.X += (sprite.TileSpriteBounds.Width * ((byte)pos.GetHashedPos() % sprite.Variations));
            batch.Draw(sprite.Texture, pos.ToWorldVec() + new Vector2(4, 4),
              rec,
              Color.White,
              sprite.Rotates ? MathHelper.ToRadians((pos.GetHashedPos() % 4) * 90) : 0,
              new Vector2(4, 4), Vector2.One, SpriteEffects.None, layer);

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

