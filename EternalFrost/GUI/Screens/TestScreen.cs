using System;
using EternalFrost.GUI;
using EternalFrost.Managers;
using EternalFrost.Widgits;

namespace EternalFrost.Screens
{
	public class TestScreen : Screen
	{
		ButtonWidgit PlayButton;
		//ButtonWidgit SettingsButton;


		public TestScreen()
		{
			PlayButton = new ButtonWidgit(new Rectangle(0,0, 50, 20), "Play");
			PlayButton.OnClick += PlayButton_OnClick;
			//SettingsButton = new ButtonWidgit(new Rectangle(-10, 0, 50, 20), "WAH");
			//SettingsButton.OnClick += SettingsButton_OnClick;
		}

		private void SettingsButton_OnClick(object sender, EventArgs e)
		{
			Console.WriteLine("Settings!");
		}

		private void PlayButton_OnClick(object sender, EventArgs e)
		{
			Console.WriteLine("Play!");
			WorldManager.Init();
			EternalFrost.Paused = false;
			GUIManager.SetScreen(null);
		}
		public override void Update()
		{
			base.Update();
			PlayButton.Bounds.Location=new( (int)GUIManager.WindowWidth / 2 - 25, (int)GUIManager.WindowHeight / 2 -10 );
			//SettingsButton.Bounds.Location = new((int)GUIManager.WindowWidth / 2 - 25, 30+(int)(GUIManager.WindowHeight / 2 - 10));

		}

		public override void Init()
		{
			Console.WriteLine("init");
			Widgits.Add(PlayButton);
		}
		
	}
}

