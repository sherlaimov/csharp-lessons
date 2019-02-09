using System;
using static System.Console;
using Newtonsoft.Json;

// http://codingsonata.com/how-to-dump-object-for-debugging-purposes-in-csharp/
namespace Packt.CS7
{
  public static class ObjectHelper
  {
    // private static void Dump(object o)
    // {
    //   string json = JsonConvert.SerializeObject(o, Formatting.Indented);
    //   WriteLine(json);
    // }
    public static void Dump<T>(this T x)
    {
      string json = JsonConvert.SerializeObject(x, Formatting.Indented);
      Console.WriteLine(json);
    }
  }

}