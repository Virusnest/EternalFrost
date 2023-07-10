using System;
using Microsoft.Xna.Framework.Input;
namespace EternalFrost.Input
{
	public class Keybind
	{
		public Keys Bind { get; set; }
		
		public Keybind(Keys defaultbind)
		{
			Bind = defaultbind;
		}
		public Keybind()
		{
			Bind = Keys.None;
		}
		public bool IsDown()
		{
			return Keyboard.GetState().IsKeyDown(Bind);
		}
		public bool IsUp()
		{
			return Keyboard.GetState().IsKeyUp(Bind);
		}
	}
}

