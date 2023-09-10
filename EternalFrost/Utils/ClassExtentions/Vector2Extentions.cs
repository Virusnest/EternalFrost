using EternalFrost.Types;
using EternalFrost.Utils.TileMap;

namespace EternalFrost.Utils.ClassExtentions
{
	public static class Vector2Extentions
	{
		public static TilePos ToTilePos(this Vector2 vec,int z)
		{
			return new TilePos((int)MathF.Floor(vec.X/ChunkRenderer.TILESIZE), (int)MathF.Floor(vec.Y / ChunkRenderer.TILESIZE ), z);
		}
	}
}
