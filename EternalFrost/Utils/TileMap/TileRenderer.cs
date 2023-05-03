using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace EternalFrost.Utils.TileMap
{
	public class TileRenderer
	{
		private TileMap tileMap;
		private int tileSize;
		private bool[] adjacent;
		public TileRenderer(TileMap tileMap, int tileSize)
		{
			this.tileMap = tileMap;
			this.tileSize = tileSize;
			adjacent = new bool[3];
		}
		public void Draw(SpriteBatch batch, Tile tile, Vector2 tilePos)
		{
			getAdjacent(tile,tilePos);
		}
		private void getAdjacent(Tile tile, Vector2 tilePos)
		{
			adjacent[0] = tileMap.GetTile((int)tilePos.X - 1, (int)tilePos.Y) != null;
			adjacent[1] = tileMap.GetTile((int)tilePos.X + 1, (int)tilePos.Y) != null;
			adjacent[2] = tileMap.GetTile((int)tilePos.X, (int)tilePos.Y - 1) != null;
			adjacent[3] = tileMap.GetTile((int)tilePos.X, (int)tilePos.Y + 1) != null;
		}
	}
}

