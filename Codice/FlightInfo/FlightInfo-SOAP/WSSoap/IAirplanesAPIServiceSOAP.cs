using AirplanesAPI.Models;
using System.ServiceModel;

namespace FlightInfo_SOAP.WSSoap
{
    [ServiceContract]
    public interface IAirplanesAPIServiceSOAP 
    {
        [OperationContract]
        public Ac FindAircraftByICAOCode(string ICAO); 

        [OperationContract]
        public Ac FindAircraftByCallsign(string Callsign);
       
    }
}
