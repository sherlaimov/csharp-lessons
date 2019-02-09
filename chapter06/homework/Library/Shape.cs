using System;

namespace Library
{
  public class Shape
  {
    private int _height;
    public int Height { get { return _height; } set { _height = value; } }
    public int Width { get; set; }
    public int Area()
    {
      if (Height == 0 || Width == 0) throw new ArgumentException("Both Height and Width must be specified");
      return Height * Width;
    }
  }
}
