using System;
using EternalFrost.Utils.Entitys;
using Microsoft.Xna.Framework.Graphics;

namespace EternalFrost.Utils.Renderers.EntityDrawers
{
  public abstract class EntityDrawer
  {
    public EntityDrawer()
    {
    }

    public abstract void Draw(SpriteBatch batch, RenderingEntity entity);
  }
}

