using AirplanesAPI.Service;
using FlightInfo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FlightInfo.Controllers;

public class FindAircraftController : Controller
{
    private AircraftViewModel vm = new AircraftViewModel();
    // GET
    public IActionResult Index()
    {
        return View(vm);
    }

    [HttpPost]
    public IActionResult Find(int SearchMode, string SearchParam)
    {
        switch (SearchMode) 
        {
            case 1:
                vm.Aircraft = AirplanesAPIService.FindAircraftByCallsign(SearchParam);
                break;
            case 2:
                vm.Aircraft = AirplanesAPIService.FindAircraftByICAOCode(SearchParam);
                break;
        }
        return View("Index", vm);
    } 
}