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
    public int Id {get;set;}
    private static List<Place> _instances = new List<Place> {};

    public Place(string cityName, string country, string duration, string activity)
    {
      CityName = cityName;
      Country = country;
      Duration = duration;
      Activity = activity;
    }
      public Place(string cityName, string country, string duration, string activity, int id)
    {
      CityName = cityName;
      Country = country;
      Duration = duration;
      Activity = activity;
      Id = id;
    }

    public static List<Place> GetAll()
    {
      List<Place> allPlaces = new List<Place> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM items;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int placeId = rdr.GetInt32(0);
        string placeCityName = rdr.GetString(1);
        string placeCountry = rdr.GetString(2);
        string placeDuration = rdr.GetString(3);
        string placeActivity = rdr.GetString(4);
        Place newPlace = new Place(placeCityName, placeCountry, placeDuration, placeActivity, placeId);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allPlaces;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM items;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static Place Find(int searchId)
    {
      return null;
    }
  }
}