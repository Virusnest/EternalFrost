using System;
using MonoGame.Extended.Collections;
using EternalFrost.InGameTypes;
using EternalFrost.Types;
using System.Drawing;

namespace EternalFrost.Utils.TileMap
{
	public class Chunk
	{
		public Point pos;
		public KeyedCollection<Guid, Entity.Entity> entities;
		public const int WIDTH=4;
		public const int HEIGHT=4;
		public const int DEPTH=3;
		public WorldTile[,,] tiles { get; set; }
		public bool isDirty = false;


		public Chunk(Point pos)
		{
			this.pos = pos;
			tiles = new WorldTile[WIDTH,HEIGHT,DEPTH];
			entities = new KeyedCollection<Guid, Entity.Entity>(e => e.guid);

		}
		public WorldTile GetTile(int x, int y,int z) {
			return tiles[x,y,z];
		}

		public void SetTile(int x, int y,int z, WorldTile tile)
		{
			if((x<=WIDTH-1) && (x >= 0) && (y<=HEIGHT-1) && (y>=0))
				tiles[x, y, z] = tile;
		}
		public void SetTile(Point pos, int z, WorldTile tile)
		{
			SetTile(pos.X, pos.Y, z, tile);
		}
		public void SetTile(BlockPos pos, WorldTile tile)
		{
			SetTile(pos.X, pos.Y, pos.Z, tile);
		}
		public void Fill()
		{
			for (int x = 0; x < WIDTH; x++) {
				for (int y = 0; y < HEIGHT; y++) {
					SetTile(x, y, 1,new WorldTile(Tiles.Tiles.ICE));
				}
			}
		}
		public static MonoGame.Extended.RectangleF GetBoundingBox()
		{
			return new MonoGame.Extended.RectangleF(0, 0, WIDTH* ChunkRenderer.TILESIZE, HEIGHT* ChunkRenderer.TILESIZE);
		}
	}
}

