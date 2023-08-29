using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace EternalFrost.Utils.TileMap
{
	public class Tile
	{

		public TileProperties Properties;
		public Tile(TileProperties properties)
		{
			Properties = properties;
		}
		public void Update() { }
		public void Broken() { }
		public void Placed() { }
		
	}

	public class TileProperties
	{
		public bool Solid,Visible = true;
		public float Frition=1;
	}
}

