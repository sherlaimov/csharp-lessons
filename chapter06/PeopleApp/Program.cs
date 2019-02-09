using System;
// using PeopleApp;
using static System.Console;

namespace PeopleApp
{
  class Program
  {
    static void Main(string[] args)
    {
      var harry = new Person { Name = "Harry" };
      var mary = new Person { Name = "Mary" };
      var jill = new Person { Name = "Jill" };
      // метод вызова экземпляра
      var baby1 = mary.ProcreateWith(harry);
      // метод статического вызова
      var baby2 = Person.Procreate(harry, jill);
      // вызов оператора
      var baby3 = harry * mary;
      WriteLine($"{mary.Name} has {mary.Children.Count} children.");
      WriteLine($"{harry.Name} has {harry.Children.Count} children.");
      WriteLine($"{jill.Name} has {jill.Children.Count} children.");
      WriteLine($"{mary.Name}'s first child is named \"{mary.Children[0].Name}\".");

      WriteLine($"5! is {Person.Factorial(5)}");

      //TODO FAILED DELEGATE
      var p1 = new Person { Name = "Crybaby" };
      var d = new DelegateWithMatchingSignature(p1.MethodIWantToCall);
      int answer2 = d("Frog");

      // Crate an instance of the delegate, pointing to the logging function.
      // This delegate will then be passed to the Process() function.
      LogHandler myLogger = new LogHandler(Logger);
      Person.Process(myLogger);

      //TODO EVENT HANDLER
      harry.Shout += Harry_Shout;
      harry.Poke();
      harry.Poke();
      harry.Poke();
      harry.Poke();

      // INTERFACES
      Person[] people =
  {
      new Person { Name = "Simon" },
      new Person { Name = "Jenny" },
      new Person { Name = "Adam" },
      new Person { Name = "Richard" }
    };

      WriteLine("Initial list of people:");
      foreach (var person in people)
      {
        WriteLine($"{person.Name}");
      }

      WriteLine("Use Person's IComparable implementation to sort:");
      Array.Sort(people);
      foreach (var person in people)
      {
        WriteLine($"{person.Name}");
      }

      //TODO Arrat.Sort принимать компаратор вторым параметром
      // который реализует интерфейс IComparer?
      WriteLine("Use PersonComparer's IComparer implementation to sort:");
      Array.Sort(people, new PersonComparer());
      foreach (var person in people)
      {
        WriteLine($"{person.Name}");
      }

      //TODO Создание универсальных типов
      var t = new Thing();
      t.Data = 42;
      WriteLine($"Thing: {t.Process("42")}");

      var gt = new GenericThing<int>();
      gt.Data = 42;
      WriteLine($"GenericThing: {gt.Process("42")}");

      //TODO Создание универсального метода
      string number1 = "4";
      WriteLine($"{number1} squared is {Squarer.Square<string>(number1)}");
      byte number2 = 3;
      WriteLine($"{number2} squared is {Squarer.Square<byte>(number2)}");

      //TODO Определение структур
      var dv1 = new DisplacementVector(3, 5);
      var dv2 = new DisplacementVector(-2, 7);
      var dv3 = dv1 + dv2;
      WriteLine($"({dv1.X}, {dv1.Y}) + ({dv2.X}, {dv2.Y}) = ({dv3.X},{dv3.Y})");

      // Наследование классов
      Employee e1 = new Employee
      {
        Name = "John Jones",
        DateOfBirth = new DateTime(1990, 7, 28)
      };
      e1.WriteToConsole();

      e1.EmployeeCode = "JJ001";
      e1.HireDate = new DateTime(2014, 11, 23);
      WriteLine($"{e1.Name} was hired on {e1.HireDate:dd/MM/yy}");

      WriteLine(e1.ToString());

      //TODO Что происходит на при определении Person aliceInPerson?
      //TODO а если object aliceInEmployee = new Employee { Name = "Alice"};
      Employee aliceInEmployee = new Employee { Name = "Alice", EmployeeCode = "AA123" };
      Person aliceInPerson = aliceInEmployee;
      aliceInEmployee.WriteToConsole();
      aliceInPerson.WriteToConsole();
      WriteLine(aliceInEmployee.ToString());
      WriteLine(aliceInPerson.ToString());

      //Явное приведение
      if (aliceInPerson is Employee)
      {
        WriteLine($"{nameof(aliceInPerson)} IS an Employee");
        Employee e2 = (Employee)aliceInPerson;
        // действия с e2
      }

      Employee e3 = aliceInPerson as Employee;
      if (e3 != null)
      {
        WriteLine($"{nameof(aliceInPerson)} AS an Employee");
        // действия с e3
      }

      //Наследование исключений
      try
      {
        e1.TimeTravel(new DateTime(1999, 12, 31));
        e1.TimeTravel(new DateTime(1950, 12, 25));
      }
      catch (PersonException ex)
      {
        WriteLine(ex.Message);
      }

      //Расширение типов при невозможности наследования
      string email1 = "pamela@test.com";
      string email2 = "ian&test.com";

      WriteLine($"{email1} is a valid e-mail address: {StringExtensions.IsValidEmail(email1)}.");
      WriteLine($"{email2} is a valid e-mail address: {StringExtensions.IsValidEmail(email2)}.");

      //Extension methods
      WriteLine($"{email1} is a valid e-mail address: {email1.IsValidEmail()}.");
      WriteLine($"{email2} is a valid e-mail address: {email2.IsValidEmail()}.");
    }
    public static void Harry_Shout(object sender, EventArgs e)
    {
      //TODO what is this syntax?
      Person p = (Person)sender;
      WriteLine(
        $"{p.Name} is this angry: {p.AngerLevel}.");
    }

    static void Logger(string s)
    {
      Console.WriteLine(s);
    }
  }
  delegate int DelegateWithMatchingSignature(string s);
}
