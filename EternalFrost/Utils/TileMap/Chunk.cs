using System;
using MonoGame.Extended.Collections;
using EternalFrost.InGameTypes;
using EternalFrost.Types;
using System.Drawing;
using EternalFrost.Utils.Entitys;
using System.Numerics;

namespace EternalFrost.Utils.TileMap
{
	public class Chunk
	{
		public ChunkPos pos;
		public KeyedCollection<Guid, Entitys.Entity> entities;
		public const int WIDTH=16;
		public const int HEIGHT=16;
		public const int DEPTH=3;
		public WorldTile[,,] tiles { get; set; }
		public bool isDirty = false;


		public Chunk(ChunkPos pos)
		{
			this.pos = pos;
			tiles = new WorldTile[WIDTH,HEIGHT,DEPTH];
			entities = new KeyedCollection<Guid, Entitys.Entity>(e => e.Guid);
		}
		public WorldTile GetTile(int x, int y,int z) {
			return tiles[x,y,z];
		}
		public WorldTile GetTile(BlockPos pos)
		{
			return tiles[pos.X, pos.Y, pos.Z];
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

