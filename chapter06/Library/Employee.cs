using System;
using static System.Console;

namespace PeopleApp
{
  public class Employee : Person
  {
    public string EmployeeCode { get; set; }
    public DateTime HireDate { get; set; }

    //TODO что это такое public new void?
    public new void WriteToConsole()
    {
      WriteLine($"{Name}'s birth date is {DateOfBirth:dd/MM/yy} and hire date was {HireDate:dd/MM/yy}");
    }

    //TODO если убрать override будет вызываться System.Object.ToString();?
    public override string ToString()
    {
      return $"{Name}'s code is {EmployeeCode}";
    }
  }
}