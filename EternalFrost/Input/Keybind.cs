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
  }
}

