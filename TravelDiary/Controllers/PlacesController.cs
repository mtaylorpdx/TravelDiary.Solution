using Microsoft.AspNetCore.Mvc;
using TravelDiary.Models;
using System.Collections.Generic;

namespace TravelDiary.Controllers
{
  public class PlacesController : Controller
  {
    [HttpPost("/places")]
    public ActionResult Create(string cityName, string country, string duration, string activity)
    {
      Place newPlace = new Place(cityName, country, duration, activity);
      return RedirectToAction("Index");
    }

    [HttpGet("/places")]
    public ActionResult Index()
    {
      List<Place> placesList = Place.GetAll();
      return View(placesList);
    }
    
    [HttpGet("/places/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpGet("/places/{id}")]
    public ActionResult Show(int id)
    {
      Place foundPlace = Place.Find(id);
      return View(foundPlace);
    }
  }
}