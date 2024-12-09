using AirplanesAPI.Service;
using FlightInfo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FlightInfo.Controllers;

public class FindAircraftController : Controller
{
    // GET
    public IActionResult Index()
    {
        
        return View();
    }

    [HttpPost]
    public IActionResult Find(int SearchMode, string SearchParam)
    {
        AircraftViewModel vm = new AircraftViewModel();

        switch (SearchMode) {
            case 1:
                vm.Aircraft = AirplanesAPIService.FindAircraftByCallsign(SearchParam);
                return View(vm);
            case 2:
                vm.Aircraft = AirplanesAPIService.FindAircraftByICAOCode(SearchParam);
                return View(vm);
        }

        return View();
    } 
}