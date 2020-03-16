using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace TravelDiary.Models
{
  public class Place
  {
    public string CityName {get;set;}
    public string Country {get;set;}
    public string Duration {get;set;}
    public string Activity {get;set;}
    public int Id {get;}
    private static List<Place> _instances = new List<Place> {};

    public Place(string cityName, string country, string duration, string activity)
    {
      CityName = cityName;
      Country = country;
      Duration = duration;
      Activity = activity;
    }

    public static List<Place> GetAll()
    {
      return _instances;
    }
    public static void ClearAll()
    {
    }
    public static Place Find(int searchId)
    {
      return null;
    }

    
  }
}