using AirplanesAPI.Models;
using AirplanesAPI.Service;

namespace FlightInfo_SOAP.WSSoap
{
    public class AirplanesAPIServiceSOAP : IAirplanesAPIServiceSOAP {
        public Ac FindAircraftByCallsign(string Callsign) {
            return AirplanesAPIService.FindAircraftByCallsign(Callsign);
        }

        public Ac FindAircraftByICAOCode(string ICAO) {
          return AirplanesAPIService.FindAircraftByICAOCode(ICAO);
        }
    }
}
