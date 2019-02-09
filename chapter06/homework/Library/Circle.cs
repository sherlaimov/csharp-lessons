using System;

namespace Library
{
  public class Circle : Shape
  {
    public int Radius { get; set; }
    public new double Area()
    {
      double area = Math.PI * Math.Pow(Radius, 2);
      double rounded = Math.Round(area, 2, MidpointRounding.AwayFromZero);
      return rounded;

    }
    public Circle(int radius)
    {
      if (radius == 0) throw new ArgumentException("Radius cannot be zero");
      Radius = radius;
    }
  }
}
