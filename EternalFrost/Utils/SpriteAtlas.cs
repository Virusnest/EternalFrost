using System.Collections.Generic;
using System.Linq;
using EternalFrost.Registry;
using MonoGame.Extended.Collections;
using RectpackSharp;

namespace EternalFrost.Utils
{
  public class TextureAtlas
  {
    public RenderTarget2D atlas { get; private set; }
    private GraphicsDevice device;
    private SpriteBatch batch;
    private int tw = 1024;
    private int th = 1024;
    public int textureCount { get; private set; }
    public KeyedCollection<ResourceLocation, Sprite> textures;
    public Sprite MissingTexture;

    public Sprite GetSprite(ResourceLocation location)
    {
      if (textures.ContainsKey(location))
      {
        if (EternalFrost.tileAtlas.textures[location] == null) return MissingTexture;
        return EternalFrost.tileAtlas.textures[location];
      }
      return MissingTexture;
    }
    private static Sprite CreateTextureMissing(GraphicsDevice device)
    {
      //initialize a texture
      Texture2D texture = new Texture2D(device, 8, 8);

      //the array holds the color for each pixel in the texture
      Color[] data = new Color[8 * 8];
      for (int i = 0; i < 8; i++)
      {
        for (int j = 0; j < 8; j++)
        {
          int colorIndex = (i / 4 + j / 4) % 2;
          data[i * 8 + j] = colorIndex == 1 ? Color.Black : Color.Magenta;
        }
      }
      //set the color
      texture.SetData(data);
      var sprite = new Sprite(new ResourceLocation("textures/missing.png"));
      sprite.Texture = texture;
      sprite.Bounds = new Rectangle(0, 0, 8, 8);
      return sprite;
    }
    public void PackTextures(Sprite[] textures)
    {
      PackingRectangle[] rectangles = new PackingRectangle[textures.Length];
      for (int i = 0; i < rectangles.Length; i++)
      {
        rectangles[i] = new PackingRectangle(new System.Drawing.Rectangle(0, 0, textures[i].Bounds.Width, textures[i].Bounds.Height), i);
      }
      var rect = new PackingRectangle(0, 0, (uint)tw, (uint)th);
      RectanglePacker.Pack(rectangles, out rect);
      device.SetRenderTarget(atlas);
      device.Clear(Color.Transparent);
      batch.Begin();
      // Loop over all the rectangles
      for (int i = 0; i < rectangles.Length; i++)
      {
        var rec = rectangles[i];
        var recc = new Rectangle((int)rec.X, (int)rec.Y, (int)rec.Width, (int)rec.Height);
        batch.Draw(textures[rectangles[i].Id].Texture, recc, Color.White);
        Sprite sp = textures[rectangles[i].Id];
        sp.Bounds = recc;
        sp.Texture = atlas;
        this.textures.Add(sp);
      }

      batch.End();
    }

    public TextureAtlas(GraphicsDevice device)
    {
      textures = new KeyedCollection<ResourceLocation, Sprite>(e => e.TextureLocation);
      this.device = device;
      batch = new SpriteBatch(device);
      atlas = new RenderTarget2D(device, th, tw);
      MissingTexture = CreateTextureMissing(device);
      textures.Add(MissingTexture);

    }
    public TextureAtlas(GraphicsDevice device, int size)
    {
      textures = new KeyedCollection<ResourceLocation, Sprite>(e => e.TextureLocation);
      this.device = device;
      batch = new SpriteBatch(device);
      atlas = new RenderTarget2D(device, size, size);
      MissingTexture = CreateTextureMissing(device);
      textures.Add(MissingTexture);
    }
  }
}

