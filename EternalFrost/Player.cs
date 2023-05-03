using System;
using EternalFrost.Utils.Entity;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace EternalFrost;

public class Player : Entity
{
	private float speed;

	public Player(Texture2D texture, Vector2 position, float speed) : base(texture, position)
	{
		this.speed = speed;
	}

	public void Move(Vector2 direction)
	{
		position += direction * speed;
	}
}

