 using System;
using EternalFrost.InGameTypes;
using EternalFrost.Types;
using EternalFrost.Utils.TileMap.Tile;

namespace EternalFrost.Utils.TileMap.Generation.Generators
{
	public class FillGenerator : Generator
	{
	
		private WorldTile tile;
		public FillGenerator(WorldTile tile)
		{
			this.tile = tile;
		}

		public override WorldTile GetTile(TilePos pos)
		{
			if(pos.Y>1&&pos.Z==1)
				return tile;
			return new(Tiles.EMPTY);
		}
	}
}

