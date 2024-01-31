using System;
using System.Collections.Generic;
using System.Linq;
using EternalFrost.Managers;
using EternalFrost.Registry;
using EternalFrost.Utils;
using Microsoft.Xna.Framework.Graphics;

namespace EternalFrost.GUI
{
	public class Screen
	{
		protected List<Widgit> Widgits = new List<Widgit>();
		protected bool Background=true;
		protected int TilingSize=1;
		protected ResourceLocation BackgroundLocation = new ResourceLocation("textures/tiles/colon3.png");
		public Screen()
		{
		}
		public virtual void Init()
		{

		}
		public virtual void Update()
		{
			foreach (Widgit widgit in Widgits) {
				widgit.Update();
			}
		}
		public virtual void Render(SpriteBatch batch)
		{
			if (Background) {
				var sprite = EternalFrost.tileAtlas.GetSprite(BackgroundLocation);
				batch.Draw(sprite.Texture,new Rectangle(0,0,(int)GUIManager.WindowWidth,(int)GUIManager.WindowHeight), new Rectangle(0, 0, sprite.Bounds.Width, sprite.Bounds.Height), Color.White);
			}
			foreach (Widgit widgit in Widgits) {
				widgit.Render(batch);
			}
		}
	}
}

