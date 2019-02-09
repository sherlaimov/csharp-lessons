using System;
using static System.Console;
using Newtonsoft.Json;
using Library;

/* dotnet add package Newtonsoft.Json --version 12.0.1 */

namespace Program
{
  class Program
  {
    static void Main(string[] args)
    {
      Square s = new Square(5);
      WriteLine(s.Area());
      PrintObject(s);

      Rectangle r = new Rectangle(100, 40);
      WriteLine(r.Area());
      PrintObject(r);

      Circle c = new Circle(10);
      WriteLine(c.Area());
      PrintObject(c);

    }

    static void PrintObject(object o)
    {
      string json = JsonConvert.SerializeObject(o, Formatting.Indented);
      WriteLine(o.GetType());
      WriteLine(json);
    }
  }
}
