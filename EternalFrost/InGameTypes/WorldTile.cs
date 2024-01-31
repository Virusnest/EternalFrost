using EternalFrost.Registry;
using EternalFrost.States;
using EternalFrost.Utils.TileMap.Tile;
using Newtonsoft.Json.Linq;
using PeterO.Cbor;

namespace EternalFrost.InGameTypes
{
	public class WorldTile : IEquatable<WorldTile>
	{
		public Tile tile { get; }
		public ByteData StateBitmask;
		public RegistryItem registryItem { get; }
		public TileProperties Properties { get; }

		public WorldTile(Tile tile)
		{
			this.tile = tile;
			Properties = tile.Properties;
			registryItem = Registries.TILE_REG.GetKey(tile);
		}
		public WorldTile(ResourceLocation location)
		{
			registryItem = new RegistryItem(Registries.TILE_REG.ID,location);
			tile = Registries.TILE_REG.GetValue(location);
		}
		public override bool Equals(object obj)
		{
			return Equals((WorldTile)obj);
		}
		public bool Equals(WorldTile other)
		{
			return ReferenceEquals(other.tile,tile);
		}
		public CBORObject ToCBORObject()
		{
			return CBORObject.NewMap().Add("ID",registryItem.Value.ToString()).Add("data",StateBitmask.Data);
		}
	}
	public struct ByteData {
		public byte Data { get; private set; }
		public ByteData(byte data)
		{
			Data = data;
		}
		public byte GetNibble()
		{
			return (byte)(Data >> 4);
		}
		public byte GetBoolNibble()
		{
			return (byte)(Data & 0xF);
		}
		public void SetNibble(byte nib)
		{
			Data=(byte)(Data &~(0xF << 4) | (nib << 4));
		}
		public bool GetBool(byte index)
		{
			 return ((Data >> index) & 1) == 1;
		}
		public void SetBool(byte index, bool value)
		{
			 Data=(byte)(((value?1:0) << index ) | Data);
		}
	}
}