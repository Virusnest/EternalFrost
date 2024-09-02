using System.Collections.Generic;

namespace EternalFrost.Collections
{
  public class PaletteCollection<T>
  {
    public PaletteData<T> Data;
    int Size;
    T Default;
    public PaletteCollection(T def, int size)
    {
      Default = def;
      Data = new PaletteData<T>(size, def);
      Size = size;
    }
    public void Set(int index, T item)
    {
      int i = Data.IndexPalette(item);
      Data.Items[index] = (byte)i;
    }
    public T Swap(int index, T item)
    {
      int i = Data.IndexPalette(item);
      int j = Data.SwapItems(index, i);
      return Data.Palette[j];
    }
    public T Get(int index)
    {
      return Data.Palette[Data.Items[index]];
    }
    public void Resize()
    {
      var data = new PaletteData<T>(Size, Default);
      for (int i = 0; i < Data.Items.Length; i++)
      {
        data.Items[i] = data.IndexPalette(data.Palette[data.Items[i]]);
      }
    }
  }
  public class PaletteData<T>
  {
    public List<T> Palette = new List<T>();
    public int[] Items;
    public PaletteData(int size, T def)
    {
      IndexPalette(def);
      Items = new int[size];
    }
    public int IndexPalette(T type)
    {
      if (type == null) return 0;
      int i;
      for (i = 0; i < Palette.Count; i++)
      {
        if (!type.Equals(Palette[i])) continue;
        return i;
      }
      Palette.Add(type);
      return i;
    }
    public int SwapItems(int index, int key)
    {
      int i = Items[index];
      Items[index] = key;
      return i;
    }
  }

}

