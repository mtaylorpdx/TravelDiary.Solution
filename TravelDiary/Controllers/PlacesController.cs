using Microsoft.AspNetCore.Mvc;
using TravelDiary.Models;
using System.Collections.Generic;

namespace TravelDiary.Controllers
{
  public class PlacesController : Controller
  {
    [HttpPost("/places")]
    public ActionResult Create(string cityName)
    {
      Place newPlace = new Place(cityName);
      return RedirectToAction("Index");
    }

    [HttpGet("/places")]
    public ActionResult Index()
    {
      return View();
    }
  }
}