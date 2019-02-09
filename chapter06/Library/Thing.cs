using System;

namespace PeopleApp
{
  public class Thing
  {
    public object Data;

    public string Process(string input)
    {
      if (Data == input)
      {
        return Data.ToString() + Data.ToString();
      }
      else
      {
        return Data.ToString();
      }
    }
  }
}