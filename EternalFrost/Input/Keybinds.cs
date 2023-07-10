using System;
using EternalFrost.Registry;

namespace EternalFrost.Input
{
	public class Keybinds
	{
		Keybind move = add(new ResourceLocation(""), new Keybind());

		private static Keybind add(ResourceLocation id, Keybind keybind)
		{
			return Registries.KEYBINDS.Register(id, keybind);
		}
	}
}
