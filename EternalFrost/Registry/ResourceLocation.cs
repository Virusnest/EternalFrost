namespace EternalFrost.Registry
{
	/// <summary>
	/// Class <c>ResourceLocation</c>: A Path to a Resource with a Namespace and a ID.
	/// </summary>
	public class ResourceLocation : IEquatable<ResourceLocation>
	{
		public string Namespace { get; }
		public string ID { get; }

		public ResourceLocation(string namespaceValue, string path)
		{
			Namespace = namespaceValue;
			ID = path;
		}
		public ResourceLocation(string path)
		{
			Namespace = "eternalfrost";
			ID = path;
		}

		public override string ToString()
		{
			return $"{Namespace}:{ID}";
		}

		bool IEquatable<ResourceLocation>.Equals(ResourceLocation other)
		{
			return (other.Namespace == Namespace) && (other.ID == ID);
		}
		public override int GetHashCode()
		{
			return ID.GetHashCode() ^ Namespace.GetHashCode();
		}
		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			if (!(obj is ResourceLocation)) return false;
			ResourceLocation other = (ResourceLocation)obj;
			return (other.Namespace == Namespace)&& (other.ID == ID);
		}
		public string getLocation()
		{
			return $"{Namespace}/{ID}";
		}

	}
}

