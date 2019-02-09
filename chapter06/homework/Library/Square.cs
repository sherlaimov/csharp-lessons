using System;

namespace Library
{
  public class Square : Shape
  {

    public Square(int width)
    {
      Width = width;
    }
    public new int Area()
    {
      if (Width == 0) throw new ArgumentException("Width must be specified");
      return Width * Width;
    }
  }
}
