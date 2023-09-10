using EternalFrost.Registry;

namespace EternalFrost.Input
{
	public class Keybinds
	{
		public static Keybind JUMP = add(new ResourceLocation("jump"), new Keybind(Keys.Space));
		public static Keybind LEFT = add(new ResourceLocation("left"), new Keybind(Keys.Left));
		public static Keybind RIGHT = add(new ResourceLocation("right"), new Keybind(Keys.Right));
		public static Keybind UP = add(new ResourceLocation("up"), new Keybind(Keys.Up));
		public static Keybind DOWN = add(new ResourceLocation("down"), new Keybind(Keys.Down));
		public static Keybind A = add(new ResourceLocation("a"), new Keybind(Keys.A));
		public static Keybind D = add(new ResourceLocation("d"), new Keybind(Keys.D));
		public static Keybind W = add(new ResourceLocation("w"), new Keybind(Keys.W));
		public static Keybind S = add(new ResourceLocation("s"), new Keybind(Keys.S));
		private static Keybind add(ResourceLocation id, Keybind keybind)
		{
			return Registries.KEYBINDS.Register(id, keybind);
		}
	}
}
