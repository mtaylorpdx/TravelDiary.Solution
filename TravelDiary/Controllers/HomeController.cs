using Microsoft.AspNetCore.Mvc;

namespace TravelDiary.Controllers
{
  public class HomeController : Controller
  {

    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
    
  }
}