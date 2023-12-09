using EternalFrost.Registry;

namespace EternalFrost.Utils
{
	public class Sprite
	{
		public ResourceLocation TextureLocation;
		public Rectangle Bounds;
		public Texture2D Texture;
		public Sprite(ResourceLocation location)
		{
			TextureLocation = location;
		}
		public Sprite(ResourceLocation location,Texture2D texture)
		{
			TextureLocation = location;
			Texture = texture;
		}
	}

}

