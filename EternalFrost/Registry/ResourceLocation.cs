namespace EternalFrost.Registry
{
  /// <summary>
  /// Class <c>ResourceLocation</c>: A Path to a Resource with a Namespace and a ID.
  /// </summary>
  public class ResourceLocation : IEquatable<ResourceLocation>
  {
    public const string DEFAULT_NAMESPACE = "eternalfrost";
    public string Namespace { get; }
    public string ID { get; }

    public ResourceLocation(string namespaceValue, string path)
    {
      Namespace = namespaceValue;
      ID = path;
    }
    public ResourceLocation(string path)
    {
      Namespace = DEFAULT_NAMESPACE;
      ID = path;
    }
    public static ResourceLocation FromString(string a)
    {
      var str = a.Split(':');
      return new ResourceLocation(str[0], str[1]);
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
      return (other.Namespace == Namespace) && (other.ID == ID);
    }
    public ResourceLocation WithSuffix(string suffix)
    {
      return new ResourceLocation(this.Namespace, this.ID + suffix);
    }

    public ResourceLocation WithPrefixID(string prefix)
    {
      return new ResourceLocation(this.Namespace, prefix + this.ID);
    }
    public string getLocation()
    {
      return $"{Namespace}/{ID}";
    }
  }
}

