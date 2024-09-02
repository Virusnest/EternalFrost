namespace EternalFrost.Utils.TileMap.Tile
{
  public class Tile
  {
    public TileProperties Properties;
    public Tile(TileProperties properties)
    {
      Properties = properties;
    }
    public void Update() { }
    public void Broken() { }
    public void Placed() { }
  }

  public class TileProperties
  {
    public bool Solid, Visible = true;
    public float Frition = 0.9f;
  }
}

