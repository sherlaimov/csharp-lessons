using System;
using System.Collections.Generic;
using static System.Console;

namespace Packt.CS7
{
  public partial class Person
  {
    // свойство, определенное с синтаксисом из C# 1 - 5
    public string Origin
    {
      get
      {
        return $"{Name} was born on {HomePlanet}";
      }
    }
    // два свойства, определенные с помощью синтаксиса лямбда-выражения
    // из C# 6 и выше
    public string Greeting => $"{Name} says 'Hello!'";
    public int Age => (int)(System.DateTime.Today.Subtract(DateOfBirth).TotalDays /
    365.25);
    // COMPUTED PROPERTIES
    public string FavoriteIceCream { get; set; } // автосинтаксис
    private string favoritePrimaryColor;
    public string FavoritePrimaryColor
    {
      get
      {
        return favoritePrimaryColor;
      }
      set
      {
        switch (value.ToLower())
        {
          case "red":
          case "green":
          case "blue":
            favoritePrimaryColor = value;
            break;
          default:
            throw new System.ArgumentException($"{value} is not a primary color.Choose from: red, green, blue.");
        }
      }
    }
    //индексатор
    public Person this[int index]
    {
      get
      {
        return Children[index];
      }
      set
      {
        Children[index] = value;
      }
    }
  }
}