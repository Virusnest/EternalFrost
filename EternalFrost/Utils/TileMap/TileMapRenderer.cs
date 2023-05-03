using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EternalFrost.InGameTypes;

namespace EternalFrost.Utils.TileMap
{
	public class TileMapRenderer
	{
        RenderTarget2D tilemapTexture;
        TileMap tilemap;
        int tileSize;
        GraphicsDevice graphics;
        
        public TileMapRenderer(TileMap tilemap, int tileSize, GraphicsDevice graphicsDevice)
		{
            graphics = graphicsDevice;
            this.tilemap = tilemap;
            this.tileSize = tileSize;
            tilemapTexture = new RenderTarget2D(graphicsDevice, tileSize * tilemap.width, tilemap.height * tileSize);
        }
        public void Render(SpriteBatch spriteBatch)
        {
			for (int x = 0; x < tilemap.width; x++) {
				for (int y = 0; y < tilemap.height; y++) {
                    //Console.WriteLine($"{x} {y}");
					WorldTile tile = tilemap.GetTile(x, y);
					Vector2 pos = new Vector2(x * tileSize, y * tileSize)+tilemap.pos;
                    if (tile != null) ;
					    //spriteBatch.Draw(tile.texture, pos, Color.White);
				}
			}
        }
    }
}

