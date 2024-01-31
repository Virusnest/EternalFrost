using System;
using System.Collections.Generic;
using EternalFrost.InGameTypes;
using EternalFrost.Types;
using EternalFrost.Utils.TileMap;
using PeterO.Cbor;

namespace EternalFrost.TileMap
{
	public class ChunkParser
	{
		
		public ChunkParser()
		{

		}
		public Chunk DeserializeChunk(CBORObject data)
		{

			return new Chunk(ChunkPos.Zero);
		}
		public CBORObject SerializeChunk(Chunk chunk)
		{
			var data = CBORObject.NewMap();
			var pos = chunk.pos;
			data.Add("pos",CBORObject.NewArray().Add(pos.X).Add(pos.Y));
			var palette = CBORObject.NewArray();
			foreach (WorldTile tile in chunk.tiles.Data.Palette) { palette.Add(tile.ToCBORObject()); }
			data.Add("palette",palette);
			data.Add("tiles", chunk.tiles.Data.Items);
			return data;
		}
	}
}

