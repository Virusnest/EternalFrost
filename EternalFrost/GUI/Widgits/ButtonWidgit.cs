using System;
using EternalFrost.GUI;
using EternalFrost.Managers;
using MonoGame.Extended;

namespace EternalFrost.Widgits
{
  public class ButtonWidgit : Widgit
  {
    bool Hovering = false;
    private bool hasPressed = false;
    private string Text;
    private bool startedClickingOut = false;
    public ButtonWidgit(Rectangle rectangle, string text) : base(rectangle)
    {
      Text = text;
    }
    public event EventHandler OnClick;
    public override void Update()
    {
      Hovering = false;
      var pos = GUIManager.GetMousePos();

      if (Bounds.Contains(pos))
      {
        Hovering = true;
      }
      if (Mouse.GetState().LeftButton == ButtonState.Pressed)
      {
        if (Hovering && (!startedClickingOut))
        {
          hasPressed = true;
        }
        else { startedClickingOut = true; }
      }
      if (Mouse.GetState().LeftButton == ButtonState.Released)
      {
        if (hasPressed && Hovering)
        {
          OnClick.Invoke(this, new());
        }
        startedClickingOut = false;
        hasPressed = false;
      }

    }
    public override void Render(SpriteBatch batch)
    {
      var toggle = !Hovering | hasPressed;
      batch.Draw(EternalFrost.tileAtlas.MissingTexture.Texture, Bounds, toggle ? Color.White : Color.Gray);
      batch.DrawString(EternalFrost.font, Text, (Bounds.Location.ToVector2() + Bounds.Size.ToVector2() / 2) - EternalFrost.font.MeasureString(Text) / 2, toggle ? Color.White : Color.Gray);
    }
  }
}

