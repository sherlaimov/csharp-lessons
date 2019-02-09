using System;
using System.Collections.Generic;

// created using -> dotnet new classlib
// public -> модификатор доступа
namespace Packt.CS7
{
  public partial class Person : System.Object
  {
    public const string Species = "Homo Sapien";
    public readonly string HomePlanet = "Earth";
    public readonly DateTime Instantiated;
    public WondersOfTheAncientWorld FavouriteAncientWonder;
    public WondersOfTheAncientWorld BucketList;
    public string Name;
    public DateTime DateOfBirth;
    public List<Person> Children = new List<Person>();

    // старый синтаксис C# 4 и тип .NET 4.0 System.Tuple
    public Tuple<string, int> GetFruitCS4()
    {
      return Tuple.Create("Apples", 5);
    }
    // новый синтаксис C# 7 и новый тип System.ValueTuple
    public (string, int) GetFruitCS7()
    {
      return ("Apples", 5);
    }
    public string OptionalParameters(string command = "Run!",
double number = 0.0, bool active = true)
    {
      return $"command is {command}, number is {number}, active is {active}";
    }

    public void PassingParameters(int x, ref int y, out int z)
    {// параметры out не могут иметь значение по умолчанию и должны быть
     // инициализированы в методе
      z = 99;
      // инкрементирование каждого параметра
      x++;
      y++;
      z++;
    }
    public Person(System.String initialName)
    {
      // Name = "Unknown";
      Instantiated = DateTime.Now;
    }
  }
}
