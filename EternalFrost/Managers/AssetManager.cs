using EternalFrost.Registry;
using EternalFrost.Utils;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace EternalFrost.Managers
{
	public class AssetManager
	{
		public static string AssetDir = Path.Combine(Directory.GetCurrentDirectory(), "Assets");
		public static TextureAtlas SpriteAtlas=new TextureAtlas(EternalFrost._graphics.GraphicsDevice,1024*4);
		public static Dictionary<ResourceLocation, Sprite> Textures;
		private static HashSet<Sprite> ToBeAtlased=new HashSet<Sprite>();
		public AssetManager()
		{
			
		}
		//NOTE: make sure to use System.IO.Path for crossplatform files
		public static void LoadAssets()
		{
			loadItems();
			loadTiles();
			loadEntities();
		}
		public static void AtlasTextures()
		{
			int counter = 0;
			List<Sprite> id = new List<Sprite>();
			foreach (Sprite location in ToBeAtlased) {
				try {
					var textur = File.Open(Path.Combine(AssetDir, location.TextureLocation.getLocation()), FileMode.Open);
					location.Texture = Texture2D.FromStream(EternalFrost._graphics.GraphicsDevice, textur);
					location.Bounds = location.Texture.Bounds;
					id.Add(location);
					counter++;
					textur.Close();
					textur.Dispose();
				} catch {
					Console.WriteLine(location.TextureLocation + " Missing"); 
				}
			}
			EternalFrost.tileAtlas.PackTextures(id.ToArray());
		}
		public static string LocationToPath(ResourceLocation location)
		{
			return Path.Combine(location.Namespace,Path.Combine(location.ID.Split('/')));
		}
		private static void loadTiles()
		{
			foreach (RegistryItem entry in Registries.TILE_REG.Keys()) {
				//Console.WriteLine(entry.Value);
				if (entry.Value.Equals(new ResourceLocation("empty"))) continue;
				try {
					var model = File.Open(Path.Combine(AssetDir, entry.getLocation().WithPrefixID("models/").WithSuffix(".json").getLocation()), FileMode.Open);
					var json = JsonDocument.Parse(model).RootElement;
					TileSprite sprite = new TileSprite(ResourceLocation.FromString(json.GetProperty("Texture").ToString()));
					var bounds = json.GetProperty("Size");
					sprite.TileSpriteBounds = new Rectangle(0,0,bounds.GetProperty("w").GetInt32(), bounds.GetProperty("h").GetInt32());
					sprite.Variations = json.GetProperty("Variations").GetByte();
					sprite.Connects = json.GetProperty("Connects").GetBoolean();
					sprite.Rotates = json.GetProperty("Rotates").GetBoolean();
					ToBeAtlased.Add(sprite);
					//Console.WriteLine(str);
					
				} catch {
					Console.WriteLine(entry.getLocation().WithPrefixID("models/").WithSuffix(".json").getLocation()+ " Missing");
				}
			}
		}
		private static void loadItems()
		{
			foreach (RegistryItem entry in Registries.ITEM_REG.Keys()) {
				Console.WriteLine(entry.Value);
				if (entry.Value.Equals(new ResourceLocation("empty"))) continue;
				try {
					var model = File.Open(Path.Combine(AssetDir, entry.getLocation().WithPrefixID("models/").WithSuffix(".json").getLocation()), FileMode.Open);
					var json = JsonDocument.Parse(model).RootElement;
					Sprite sprite = new Sprite(ResourceLocation.FromString(json.GetProperty("Texture").ToString()));
					ToBeAtlased.Add(sprite);
				} catch {
					Console.WriteLine(entry.getLocation().WithPrefixID("models/").WithSuffix(".json").getLocation() + " Missing");
				}
			}
		}
		private static void loadEntities()
		{
			ToBeAtlased.Add(new Sprite(new ResourceLocation("textures/entities/player.png")));
		}
	}
}

