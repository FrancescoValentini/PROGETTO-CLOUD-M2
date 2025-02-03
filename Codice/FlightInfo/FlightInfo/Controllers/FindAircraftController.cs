using AirplanesAPI.Service;
using FlightInfo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FlightInfo.Controllers;

public class FindAircraftController : Controller
{
    private AircraftViewModel vm = new AircraftViewModel();
    private readonly AirplanesAPIService api;

    public FindAircraftController(AirplanesAPIService airplanesService) {
        api = airplanesService;
    }

    // GET
    public IActionResult Index()
    {
        vm.IsValid = true;
        vm.Aircraft = api.FindAircraftsByCoordinates("45.62261", "8.72821", "50")[0];
        return View(vm);

    }

    [HttpPost]
    public IActionResult Find(int SearchMode, string SearchParam)
    {
        switch (SearchMode) 
        {
            case 1:
                vm.Aircraft = api.FindAircraftByCallsign(SearchParam);
                break;
            case 2:
                vm.Aircraft = api.FindAircraftByICAOCode(SearchParam);
                break;
        }

        if (vm.Aircraft == null) vm.IsValid = false;
        else vm.IsValid = true;
        return View("Index", vm);
    } 
}