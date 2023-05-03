using System;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EternalFrost.InGameTypes;
namespace EternalFrost.Utils.TileMap
{
	public class TileMap
	{
		public int width { get; private set; }
		public int height { get; private set; }
		public WorldTile[,] tilemap { get; set; }
		public Vector2 pos { get; set; }

		public TileMap(int width, int height)
		{
			pos = Vector2.Zero;
			this.width = width;
			this.height = height;
			tilemap = new WorldTile[width, height];
		}
		public WorldTile GetTile(int x, int y) {
			return tilemap[x,y];
		}
		public void FillTiles(WorldTile tile) {
			for (int x = 0; x < width; x++) {
				for (int y = 0; y < height; y++) {
					SetTile(x, y, tile);
				}
			}
		}
		public void SetTile(int x, int y, WorldTile tile)
		{
			if((x<=width-1) && (x >= 0) && (y<=height-1) && (y>=0))
				tilemap[x, y] = tile;
		}
	}
}

