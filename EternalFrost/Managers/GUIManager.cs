using System;
using EternalFrost.GUI;


namespace EternalFrost.Managers
{
	public static class GUIManager
	{
		public static Screen ActiveScreen;
		public static int Scale= 3;
		public static int _finalScale;
		public static Matrix GUIMatrix;
		private static int _virtualScale;

		public static int calculateScale(int scale)
		{
			int i;
			for (i = 1;i!=scale && EternalFrost._spriteBatch.GraphicsDevice.Viewport.Width / (i + 1) > 400 && EternalFrost._spriteBatch.GraphicsDevice.Viewport.Width / (i + 1) > 300;i++) { }
			return i;
		}

		public static float WindowWidth => EternalFrost._spriteBatch.GraphicsDevice.Viewport.Width / _virtualScale;
		public static float WindowHeight => EternalFrost._spriteBatch.GraphicsDevice.Viewport.Height / _virtualScale;

		public static Vector2 GetMousePos()
		{
			return Vector2.Transform(Mouse.GetState().Position.ToVector2(),Matrix.Invert(GUIMatrix));
		}

		public static void Update(GameTime time)
		{
			_virtualScale= calculateScale(Scale);
			GUIMatrix = Matrix.CreateScale(Vector3.One*_virtualScale);
			if (ActiveScreen == null) { return; }
			ActiveScreen.Update();
		}
		public static void Render(SpriteBatch spriteBatch)
		{
			if (ActiveScreen == null) { return; }
			ActiveScreen.Render(spriteBatch);
		}
		public static void SetScreen(Screen screen)
		{
			ActiveScreen = screen;
			if (ActiveScreen == null) { return; }
			screen.Init();
		}
	}

}

