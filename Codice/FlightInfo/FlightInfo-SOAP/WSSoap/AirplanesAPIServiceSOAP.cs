using AirplanesAPI.Models;
using AirplanesAPI.Service;

namespace FlightInfo_SOAP.WSSoap
{
    public class AirplanesAPIServiceSOAP : IAirplanesAPIServiceSOAP {
        private readonly AirplanesAPIService api;

        public AirplanesAPIServiceSOAP(AirplanesAPIService airplanesService) {
            api = airplanesService;
        }
        public Ac FindAircraftByCallsign(string Callsign) {
            return api.FindAircraftByCallsign(Callsign);
        }

        public Ac FindAircraftByICAOCode(string ICAO) {
          return api.FindAircraftByICAOCode(ICAO);
        }
    }
}
