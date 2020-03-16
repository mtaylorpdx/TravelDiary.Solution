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

    public static Place Find(int id)
    {
      // We open a connection.
      MySqlConnection conn = DB.Connection();
      conn.Open();

      // We create MySqlCommand object and add a query to its CommandText property. We always need to do this to make a SQL query.
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM `places` WHERE id = @thisId;";

      // We have to use parameter placeholders (@thisId) and a `MySqlParameter` object to prevent SQL injection attacks. This is only necessary when we are passing parameters into a query. We also did this with our Save() method.
      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = id;
      cmd.Parameters.Add(thisId);

      // We use the ExecuteReader() method because our query will be returning results and we need this method to read these results. This is in contrast to the ExecuteNonQuery() method, which we use for SQL commands that don't return results like our Save() method.
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int placeId = 0;
      string placeCity = "";
      string placeCountry = "";
      string placeDuration = "";
      string placeActivity = "";
      while (rdr.Read())
      {
        placeId = rdr.GetInt32(0);
        placeCity = rdr.GetString(1);
        placeCountry = rdr.GetString(2);
        placeDuration = rdr.GetString(3);
        placeActivity = rdr.GetString(4);
      }
      Place foundPlace= new Place(placeCity, placeCountry, placeDuration, placeActivity, placeId);

      // We close the connection.
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundPlace;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;

      // Begin new code

      cmd.CommandText = @"INSERT INTO places (city) VALUES (@City);";
      MySqlParameter city = new MySqlParameter();
      city.ParameterName = "@City";
      city.Value = this.City;
      cmd.Parameters.Add(city);    
      cmd.ExecuteNonQuery();

      cmd.CommandText = @"INSERT INTO places (country) VALUES (@Country);";
      MySqlParameter country = new MySqlParameter();
      country.ParameterName = "@Country";
      country.Value = this.Country;
      cmd.Parameters.Add(country);    
      cmd.ExecuteNonQuery();

      cmd.CommandText = @"INSERT INTO places (duration) VALUES (@Duration);";
      MySqlParameter duration = new MySqlParameter();
      duration.ParameterName = "@Duration";
      duration.Value = this.Duration;
      cmd.Parameters.Add(duration);    
      cmd.ExecuteNonQuery();

      cmd.CommandText = @"INSERT INTO places (activity) VALUES (@Activity);";
      MySqlParameter activity = new MySqlParameter();
      activity.ParameterName = "@Activity";
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