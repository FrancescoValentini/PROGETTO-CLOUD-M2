using AirplanesAPI.Models;
using Newtonsoft.Json;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using static System.Net.WebRequestMethods;

namespace AirplanesAPI.Service;

public class AirplanesAPIService
{

    /*
     * Does a http GET request 
     * Input: url
     * Output: response body
     */
    private static async Task<string> HttpGetRequest(string url)
    {
        HttpClient Client = new HttpClient();
        HttpResponseMessage Response = await Client.GetAsync(url);
        Response.EnsureSuccessStatusCode();
        string json = await Response.Content.ReadAsStringAsync();
        return json;
    }

    /*
     * Create the url for the request
     * Input : 
     *  - searchType
     *  - search parameter
     *  
     * Output: Complete url for the request
     * 
     */
    private static string BuildUrl(int searchType , string searchParameter)
    {
        string BaseUrl = "https://api.airplanes.live/v2/";


        switch (searchType)
        {
            case 1:
                BaseUrl = BaseUrl + "callsign/";

                break;

            case 2:
                BaseUrl = BaseUrl + "hex/";

                break;

        }

        return BaseUrl + searchParameter;
    }

    
    private static APIResponse ParseJSON(string json)
    {
        return  JsonConvert.DeserializeObject<APIResponse>(json);   
    }

    public static Ac FindAircraftByICAOCode(string ICAO)
    {
        /* Performs the http GET request
         * 
         * DoGETRequest when used with option 2 performs a search using the ICAO CODE
         * 
         */
        string JSONResponse = HttpGetRequest(BuildUrl(2, ICAO)).Result;
            
        if (JSONResponse == null || JSONResponse == "") return null; 

        // if the json is not null or empty parse it and then convert the Ac list to array
        Ac[] Aircrafts = ParseJSON(JSONResponse).Ac.ToArray();

        if (Aircrafts.Length == 0) return null;

        return Aircrafts[0];
    }
    public static Ac FindAircraftByCallsign(string Callsign)
    {
        string JSONResponse = HttpGetRequest(BuildUrl(1, Callsign)).Result;

        if (JSONResponse == null || JSONResponse == "") return null;

        Ac[] Aircrafts = ParseJSON(JSONResponse).Ac.ToArray();

        if (Aircrafts.Length == 0) return null;
        
        return Aircrafts[0];
    }

}