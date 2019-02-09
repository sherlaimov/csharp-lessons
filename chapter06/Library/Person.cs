using System;
using System.Collections.Generic;
using static System.Console;

namespace PeopleApp
{
  // Declare a delegate that takes a single string parameter
  // and has no return type.
  public delegate void LogHandler(string message);

  //TODO О чем именно говорит данное наследование?
  public partial class Person : IComparable<Person>
  {
    public string Name;
    public DateTime DateOfBirth;
    public List<Person> Children = new List<Person>();
    public static Person Procreate(Person p1, Person p2)
    {
      var baby = new Person { Name = $"Baby of {p1.Name} and {p2.Name}" };
      p1.Children.Add(baby);
      p2.Children.Add(baby);
      return baby;
    }
    // methods 
    public void WriteToConsole()
    {
      WriteLine(
        $"{Name} was born on {DateOfBirth:dddd, d MMMM yyyy}");
    }
    public Person ProcreateWith(Person partner)
    {
      return Procreate(this, partner);
    }
    // оператор 
    public static Person operator *(Person p1, Person p2)
    {
      return Person.Procreate(p1, p2);
    }
    // метод с локальной функцией
    public static int Factorial(int number)
    {
      if (number < 0)
      {
        throw new ArgumentException(
        $"{nameof(number)} cannot be less than zero.");
      }
      return localFactorial(number);

      //TODO От чего наследуется данная функция?
      int localFactorial(int localNumber)
      {
        if (localNumber < 1) return 1;
        return localNumber * localFactorial(localNumber - 1);
      }
    }
    public int MethodIWantToCall(string input)
    {
      return input.Length; // неважно, что выполняется здесь
    }


    // The use of the delegate is just like calling a function directly,
    // though we need to add a check to see if the delegate is null
    // (that is, not pointing to a function) before calling the function.
    public static void Process(LogHandler logHandler)
    {
      if (logHandler != null)
      {
        logHandler("Process() begin");
      }

      if (logHandler != null)
      {
        logHandler("Process() end");
      }
    }
    // EVENTS
    public event EventHandler Shout;
    // поле
    public int AngerLevel;
    // метод
    public void Poke()
    {
      AngerLevel++;
      if (AngerLevel >= 3)
      {
        // если кто-то нас слушает...
        if (Shout != null)
        {
          //TODO How does this work?
          // ...поднимается событие
          Shout(this, EventArgs.Empty);
        }
      }
    }
    public int CompareTo(Person other)
    {
      //TODO String.CompareTo?
      return Name.CompareTo(other.Name);
    }
    // overridden methods 
    public override string ToString()
    {
      return $"{Name} is a {base.ToString()}";
    }
    public void TimeTravel(DateTime when)
    {
      if (when <= DateOfBirth)
      {
        throw new PersonException("If you travel back in time to a date earlier than your own birth then the universe will explode!");
      }
      else
      {
        WriteLine($"Welcome to {when:yyyy}!");
      }
    }
  }
}
