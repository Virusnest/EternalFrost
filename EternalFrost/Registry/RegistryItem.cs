using System;
using System.Xml.Linq;

namespace EternalFrost.Registry
{
	public class RegistryItem : IEquatable<RegistryItem>
	{
		public ResourceLocation Location { get; }
		public ResourceLocation Value { get; }

		public RegistryItem(ResourceLocation location, ResourceLocation value) {
			Value = value;
			Location = location;
		}

		bool IEquatable<RegistryItem>.Equals(RegistryItem? other)
		{
			return (Value.Equals(other.Value));
		}
		public override int GetHashCode()
		{
			return Location.GetHashCode() ^ Value.GetHashCode();
		}
		public override bool Equals(object? obj)
		{
			if (obj is RegistryItem) return false;
			RegistryItem other = (RegistryItem)obj;
			return (Value.Equals(other.Value));
		}
		public override string ToString()
		{
			return $"{Location.ToString()}/{Value.ID}";
		}
		public string getLocation()
		{
			return $"{Location.getLocation()}/{Value.ID}";
		}
	}
}

