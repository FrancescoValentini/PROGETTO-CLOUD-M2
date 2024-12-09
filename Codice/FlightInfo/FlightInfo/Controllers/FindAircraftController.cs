using AirplanesAPI.Models;
using AirplanesAPI.Service;
using FlightInfo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FlightInfo.Controllers;

public class FindAircraftController : Controller
{
    private AircraftViewModel vm = new AircraftViewModel();
    // GET
    public IActionResult Index()
    {
        if (TempData["Aircraft"] != null) {
            var aircraftJson = TempData["Aircraft"] as string;
            vm.Aircraft = JsonConvert.DeserializeObject<Ac>(aircraftJson);
        }
        return View(vm);
    }

    [HttpPost]
    public IActionResult Find(int SearchMode, string SearchParam)
    {
        Ac foundAircraft = null;
        switch (SearchMode) 
        {
            case 1:
                foundAircraft = AirplanesAPIService.FindAircraftByCallsign(SearchParam);
                break;
            case 2:
                foundAircraft = AirplanesAPIService.FindAircraftByICAOCode(SearchParam);
                break;
        }

        if (foundAircraft != null) {
            TempData["Aircraft"] = JsonConvert.SerializeObject(foundAircraft);
        }

        return RedirectToAction("Index");
    } 
}