using System;
using Packt.CS7;
using static System.Console;
/*
TODO How this project was created
cd PacktLibrary
dotnet new classlib
cd ..
cd PeopleApp
dotnet new console
 */
namespace PeopleApp
{
  class Program : object
  {
    static void Main(string[] args)
    {
      var p1 = new Person("");
      p1.Name = "Bob Smith";
      p1.DateOfBirth = new System.DateTime(1954, 12, 22);
      p1.FavouriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
      WriteLine($"{p1.Name} was born on {p1.DateOfBirth:dddd, d MMMM yyyy}. And favourite wonder is {p1.FavouriteAncientWonder}");
      WriteLine(p1.ToString());
      p1.BucketList = WondersOfTheAncientWorld.HangingGardensOfBabylon |
WondersOfTheAncientWorld.MausoleumAtHalicarnassus;
      // p1.BucketList = (WondersOfTheAncientWorld)18;
      WriteLine($"{p1.Name}'s bucket list is {p1.BucketList}");

      //TODO это возов конструктора такой через {}?
      p1.Children.Add(new Person("") { Name = "Alfred" });
      p1.Children.Add(new Person("") { Name = "Zoe" });

      WriteLine(
      $"{p1.Name} has {p1.Children.Count} children:");
      for (int child = 0; child < p1.Children.Count; child++)
      {
        WriteLine($" {p1.Children[child].Name}");
      }
      WriteLine($"{p1.Name} was instantiated at {p1.Instantiated:hh:mm:ss} on {p1.Instantiated:dddd, d MMMM yyyy}");

      /* ****BankAccount**** */

      BankAccount.InterestRate = 0.012M;
      var ba1 = new BankAccount();
      ba1.AccountName = "Mrs. Jones";
      ba1.Balance = 2400;
      WriteLine($"{ba1.AccountName} earned {ba1.Balance * BankAccount.InterestRate:C} interest.");
      var ba2 = new BankAccount();

      ba2.AccountName = "Ms. Gerrier";
      ba2.Balance = 98;
      WriteLine($"{ba2.AccountName} earned {ba2.Balance * BankAccount.InterestRate:C} interest.");

      WriteLine($"{p1.Name} is a {Person.Species}");
      WriteLine($"{p1.Name} was born on {p1.HomePlanet}");

      /* TUPLES */

      Tuple<string, int> fruit = p1.GetFruitCS4();
      WriteLine($"There are {fruit.Item2} {fruit.Item1}.");

      (string, int) fruit7 = p1.GetFruitCS7();
      WriteLine($"{fruit7.Item1}, {fruit7.Item2} there are.");

      /* TUPLE DESTRUCTURING */
      var thing1 = ("Neville", 4);
      (string name, int childNum) = thing1;
      WriteLine(
      $"{thing1.Item1} has {thing1.Item2} children.");
      WriteLine($"Deconstructed {name} and his {childNum} children");

      /* Optional Named Parameters */
      WriteLine(p1.OptionalParameters(number: 52.7, command: "Hide!"));

      /* Управление передачей параметров */
      //TODO ref, out
      int a = 10;
      int b = 20;
      int c = 30;
      WriteLine($"Before: a = {a}, b = {b}, c = {c}");
      // p1.PassingParameters(a, ref b, out c);

      // System.Int32.TryParse("23", out int result);

      WriteLine($"After: a = {a}, b = {b}, c = {c}");

      /* OBJECT DUMPER */
      ObjectHelper.Dump(p1);

      /* Свойства только для чтения*/
      //TODO а какже readonly? 

      var sam = new Person("")
      {
        Name = "Sam",
        DateOfBirth = new DateTime(1972, 1, 27)
      };
      //TODO данные свойства внутри выполнряются как функции?
      WriteLine(sam.Origin);
      WriteLine(sam.Greeting);
      WriteLine(sam.Age);

      // Lambda Expressions
      Func<int, int, int> adder = (m, n) => m + n;

      //TODO Print out object properties.
      ObjectHelper.Dump(sam);

      // Computed properties
      sam.FavoriteIceCream = "Chocolate Fudge";
      WriteLine($"Sam's favorite ice-cream flavor is {sam.FavoriteIceCream}.");
      sam.FavoritePrimaryColor = "Red";
      WriteLine($"Sam's favorite primary color is {sam.FavoritePrimaryColor}.");

      //ИНДЕКСАТОР
      sam.Children.Add(new Person("") { Name = "Charlie" });
      sam.Children.Add(new Person("") { Name = "Ella" });
      WriteLine($"Sam's first child is {sam.Children[0].Name}");
      WriteLine($"Sam's second child is {sam.Children[1].Name}");
      WriteLine($"Sam's first child is {sam[0].Name}");
      WriteLine($"Sam's second child is {sam[1].Name}");
    }
  }
}
