using System.Collections.Generic;

namespace TravelDiary.Models
{
  public class Place
  {
    public string CityName {get;set;}
    public string Country {get;set;}
    public string Duration {get;set;}
    public string Activity {get;set;}
    private static List<Place> _instances = new List<Place> {};

    public Place(string cityName, string country, string duration, string activity)
    {
      CityName = cityName;
      Country = country;
      Duration = duration;
      Activity = activity;
      _instances.Add(this);
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }
  }
}