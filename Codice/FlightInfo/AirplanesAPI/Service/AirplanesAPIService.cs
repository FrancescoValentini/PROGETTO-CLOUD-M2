using AirplanesAPI.Models;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using static System.Net.WebRequestMethods;

namespace AirplanesAPI.Service;

public class AirplanesAPIService
{
    private static async Task<string> DoGETRequest(int Scelta , string ParametroDiRicerca)
    {
        string BaseUrl = "https://api.airplanes.live/v2/";


        switch(Scelta)
        {
            case 1:
                BaseUrl = BaseUrl + "callsign/";

                break;
               
            case 2:
                BaseUrl = BaseUrl + "hex/";

                break;

        }

        BaseUrl = BaseUrl+ParametroDiRicerca;

        HttpClient Client = new HttpClient();
        // Esegue una richiesta GET all'API e ottiene la risposta JSON
        HttpResponseMessage Response = await Client.GetAsync(BaseUrl);
        Response.EnsureSuccessStatusCode();
        string json = await Response.Content.ReadAsStringAsync();

       return json;
    }
    private static APIResponse ParseJSON(string json)
    {
        APIResponse Response = JsonConvert.DeserializeObject<APIResponse>(json);
        
        return Response;
    }

    public static Ac FindAircraftByICAOCode(string ICAO)
    {
        string JSONResponse = DoGETRequest(2, ICAO).Result;
        return ParseJSON(JSONResponse).Ac.ToArray()[0];
    }
    public static Ac FindAircraftByCallsign(string Callsign)
    {
        string JSONResponse = DoGETRequest(1, Callsign).Result;
        return ParseJSON(Callsign).Ac.ToArray()[0];
    }

}