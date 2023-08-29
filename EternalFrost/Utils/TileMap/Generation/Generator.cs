using System;
using EternalFrost.InGameTypes;
using EternalFrost.Types;

namespace EternalFrost.Utils.TileMap.Generation
{
	public abstract class Generator
	{
		public abstract WorldTile GetTile(TilePos pos);
	}
}

