using System;
using EternalFrost.Types;
using EternalFrost.Utils.TileMap;
using Microsoft.Xna.Framework;

namespace EternalFrost.Utils.ClassExtentions
{
	public static class Vector2Extentions
	{
		public static TilePos ToTilePos(this Vector2 vec,int z)
		{
			return new TilePos((int)MathF.Floor(vec.X/Chunk.WIDTH/ChunkRenderer.TILESIZE), (int)MathF.Floor(vec.Y / Chunk.HEIGHT / ChunkRenderer.TILESIZE), z);
		}
	}
}
