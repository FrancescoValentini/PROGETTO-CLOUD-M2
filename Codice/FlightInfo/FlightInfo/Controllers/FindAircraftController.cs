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
        vm.IsValid = true;
        vm.Aircraft = AirplanesAPIService.FindAircraftsByCoordinates("45.62261", "8.72821", "50")[0];
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

        if (vm.Aircraft == null) vm.IsValid = false;
        else vm.IsValid = true;
        return View("Index", vm);
    } 
}