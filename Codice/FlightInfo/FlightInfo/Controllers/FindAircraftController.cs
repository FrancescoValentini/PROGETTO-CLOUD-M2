using Microsoft.AspNetCore.Mvc;

namespace FlightInfo.Controllers;

public class FindAircraftController : Controller
{
    // GET
    public IActionResult Index()
    {
        
        return View();
    }
}