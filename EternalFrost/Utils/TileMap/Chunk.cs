using System;
using MonoGame.Extended.Collections;
using EternalFrost.InGameTypes;
using EternalFrost.Types;
using EternalFrost.Utils.Entitys;
using EternalFrost.Collections;
using EternalFrost.Utils.TileMap.Tile;

namespace EternalFrost.Utils.TileMap
{
	public class Chunk
	{
		public ChunkPos pos;
		public KeyedCollection<Guid, Entity> entities;
		public const int WIDTH=16;
		public const int HEIGHT=16;
		public const int DEPTH=3;
		public const int SIZE = WIDTH * HEIGHT*DEPTH;
		public PaletteCollection<WorldTile> tiles { get; set; }
		public bool isDirty = false;

		public Chunk(ChunkPos pos)
		{
			this.pos = pos;
			tiles = new PaletteCollection<WorldTile>(new WorldTile(Tiles.EMPTY),WIDTH*HEIGHT*DEPTH);
			entities = new KeyedCollection<Guid, Entity>(e => e.Guid);
		}
		public WorldTile GetTile(int x, int y,int z) {
			return tiles.Get(to1D(x,y,z));
		}
		public WorldTile GetTile(TilePos pos)
		{
			return tiles.Get(to1D(pos.X, pos.Y, pos.Z));
		}
		public TilePos to3D(int idx)
		{
			int z = idx / (WIDTH * HEIGHT);
			idx -= (z * WIDTH * HEIGHT);
			int y = idx / WIDTH;
			int x = idx % WIDTH;
			return new TilePos(x, y, z);
		}

		public int to1D(int x, int y, int z)
		{
			return (z * WIDTH * HEIGHT) + (y * WIDTH) + x;
		}
		public void SetTile(int x, int y,int z, WorldTile tile)
		{
			if((x<=WIDTH-1) && (x >= 0) && (y<=HEIGHT-1) && (y>=0))
				tiles.Set(to1D(x, y, z),tile);
		}
		public void SetTile(System.Drawing.Point pos, int z, WorldTile tile)
		{
			SetTile(pos.X, pos.Y, z, tile);
		}
		public void SetTile(TilePos pos, WorldTile tile)
		{
			SetTile(pos.X, pos.Y, pos.Z, tile);
		}
		public void Fill()
		{
			for (int x = 0; x < WIDTH; x++) {
				for (int y = 0; y < HEIGHT; y++) {
					SetTile(x, y, 1,new WorldTile(Tile.Tiles.ICE));
				}
			}
		}
		public static MonoGame.Extended.RectangleF GetBoundingBox()
		{
			return new MonoGame.Extended.RectangleF(0, 0, WIDTH* ChunkRenderer.TILESIZE, HEIGHT* ChunkRenderer.TILESIZE);
		}
	}
}

