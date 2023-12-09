using EternalFrost.ItemDrawers;
using EternalFrost.Utils.TileMap.Tile;

namespace EternalFrost.Item
{
	public class TileItem : Item
	{
		Tile Tile = Tiles.EMPTY;
		public TileItem(Tile tile)
		{
			Tile = tile;
			ItemRenderer = new TileItemDrawer(Tile);
		}
	}
}

