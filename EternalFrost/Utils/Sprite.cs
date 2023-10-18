
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using EternalFrost.Registry;

namespace EternalFrost.Utils
{
	public class Sprite
	{
		public ResourceLocation AtlasTexture;
		public int Framerate;
		public Rectangle Bounds;
		public bool Animated = false;
		public Texture2D Texture;
		public KeyedCollection<ResourceLocation,Animation> Animations;
		public ResourceLocation CurrentAnimation;
		public Sprite(Rectangle bounds)
		{
			Bounds = bounds;
		}
		
	}
	public class Animation
	{
		public ResourceLocation ID;
		public int frame;
		public int Frames;
		public bool animDir;
		public Animation()
		{

		}
		
	}
}

