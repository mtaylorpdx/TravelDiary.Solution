using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace TravelDiary.Models
{
  public class Place
  {
    public string City {get;set;}
    public string Country {get;set;}
    public string Duration {get;set;}
    public string Activity {get;set;}
    public int Id {get;set;}
    private static List<Place> _instances = new List<Place> {};

    public Place(string city, string country, string duration, string activity)
    {
      City = city;
      Country = country;
      Duration = duration;
      Activity = activity;
    }
      public Place(string city, string country, string duration, string activity, int id)
    {
      City = city;
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
      cmd.CommandText = @"SELECT * FROM places;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int placeId = rdr.GetInt32(0);
        string placeCity = rdr.GetString(1);
        string placeCountry = rdr.GetString(2);
        string placeDuration = rdr.GetString(3);
        string placeActivity = rdr.GetString(4);
        Place newPlace = new Place(placeCity, placeCountry, placeDuration, placeActivity, placeId);
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
      cmd.CommandText = @"DELETE FROM places;";
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

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;

      // Begin new code

      cmd.CommandText = @"INSERT INTO places (city) VALUES (@City);";
      MySqlParameter city = new MySqlParameter();
      city.ParameterName = "@PlaceCity";
      city.Value = this.City;
      cmd.Parameters.Add(city);    
      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;

      cmd.CommandText = @"INSERT INTO places (country) VALUES (@Country);";
      MySqlParameter country = new MySqlParameter();
      country.ParameterName = "@PlaceCountry";
      country.Value = this.Country;
      cmd.Parameters.Add(country);    
      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;

      cmd.CommandText = @"INSERT INTO places (duration) VALUES (@Duration);";
      MySqlParameter duration = new MySqlParameter();
      duration.ParameterName = "@PlaceDuration";
      duration.Value = this.Duration;
      cmd.Parameters.Add(duration);    
      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;

      cmd.CommandText = @"INSERT INTO places (activity) VALUES (@Activity);";
      MySqlParameter activity = new MySqlParameter();
      activity.ParameterName = "@PlaceActivity";
      activity.Value = this.Activity;
      cmd.Parameters.Add(activity);    
      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;

      // End new code

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}