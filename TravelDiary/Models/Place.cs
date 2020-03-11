using System.Collections.Generic;

namespace TravelDiary.Models
{
  public class Place
  {
    public string CityName { get; set; }
    private static List<Place> _instances = new List<Place> {};

    public Place(string cityName)
    {
      CityName = cityName;
      _instances.Add(this);
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }
  }
}