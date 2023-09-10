 using System;
using EternalFrost.InGameTypes;
using EternalFrost.Types;

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
			return tile;
		}
	}
}

