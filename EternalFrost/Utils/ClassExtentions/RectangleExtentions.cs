using EternalFrost.Types;
using EternalFrost.Utils.TileMap;

namespace EternalFrost.ClassExtentions
{
	public static class RectangleExtentions
	{
		public static Rectangle ReturnOffset(this Rectangle rec,int x,int y)
		{
			rec.Location += new Point(x, y);
			return rec;
		}
	}
}

