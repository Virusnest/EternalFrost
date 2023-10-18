using EternalFrost.Registry;
using EternalFrost.Utils;
using System.Collections.Generic;
using System.IO;

namespace EternalFrost.Managers
{
	public class AssetManager
	{
		public static string AssetDir = Path.Combine(Directory.GetCurrentDirectory(), "Assets");
		public static TextureAtlas SpriteAtlas=new TextureAtlas(EternalFrost._graphics.GraphicsDevice,1024*4);
		public static Dictionary<ResourceLocation, Sprite> Textures;
		private static HashSet<ResourceLocation> ToBeAtlased=new HashSet<ResourceLocation>();
		public AssetManager()
		{
			
		}

		//NOTE: make sure to use System.IO.Path for crossplatform files
		public static void LoadAssets()
		{
			loadTiles();
			loadEntities();
		}
		public static void AtlasTextures()
		{
			int counter = 0;
			Texture2D[] texture = new Texture2D[ToBeAtlased.Count];
			ResourceLocation[] id = new ResourceLocation[ToBeAtlased.Count];
			foreach (ResourceLocation location in ToBeAtlased) {
				var file = File.Open(Path.Combine(AssetDir, location.Namespace,location.ID), FileMode.Open);
				texture[counter] = Texture2D.FromStream(EternalFrost._graphics.GraphicsDevice, file);
				id[counter] = location;
				counter++;
				file.Close();
				file.Dispose();
			}
			EternalFrost.tileAtlas.PackTextures(texture, id);
		}
		public static string LocationToPath(ResourceLocation location)
		{
			return Path.Combine(location.Namespace,Path.Combine(location.ID.Split('/')));
		}
		private static void loadTiles()
		{
			foreach (RegistryItem entry in Registries.TILE_REG.Keys()) {
				Console.WriteLine(entry.getLocation().WithPrefixID("textures/").WithSuffix(".png"));
				ToBeAtlased.Add(entry.getLocation().WithPrefixID("textures/").WithSuffix(".png"));
			}
		}
		private static void loadEntities()
		{
			ToBeAtlased.Add(new ResourceLocation("textures/entities/basic_sprite_entity.png"));
		}
	}
}

