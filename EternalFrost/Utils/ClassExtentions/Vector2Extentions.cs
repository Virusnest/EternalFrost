using EternalFrost.Types;
using EternalFrost.Utils.TileMap;

namespace EternalFrost.Utils.ClassExtentions
{
	public static class Vector2Extentions
	{
		public static TilePos ToTilePos(this Vector2 vec,int z)
		{
			return new TilePos((int)Math.Floor(vec.X/ChunkRenderer.TILESIZE), (int)Math.Floor(vec.Y / ChunkRenderer.TILESIZE ), z);
		}
	}
}
