using AirplanesAPI.Models;
using Newtonsoft.Json;

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
    private static string BuildUrl(API_SEARCH_OPTIONS searchType , string searchParameter)
    {
        string BaseUrl = "https://api.airplanes.live/v2/";


        switch (searchType)
        {
            case API_SEARCH_OPTIONS.CALLSIGN:
                BaseUrl = BaseUrl + "callsign/";
                break;

            case API_SEARCH_OPTIONS.ICAO:
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
        string JSONResponse = HttpGetRequest(BuildUrl(API_SEARCH_OPTIONS.ICAO, ICAO)).Result;
            
        if (JSONResponse == null || JSONResponse == "") return null; 

        // if the json is not null or empty parse it and then convert the Ac list to array
        Ac[] Aircrafts = ParseJSON(JSONResponse).Ac.ToArray();

        if (Aircrafts.Length == 0) return null;

        return Aircrafts[0];
    }
    public static Ac FindAircraftByCallsign(string Callsign)
    {
        string JSONResponse = HttpGetRequest(BuildUrl(API_SEARCH_OPTIONS.CALLSIGN, Callsign)).Result;

        if (JSONResponse == null || JSONResponse == "") return null;

        Ac[] Aircrafts = ParseJSON(JSONResponse).Ac.ToArray();

        if (Aircrafts.Length == 0) return null;
        
        return Aircrafts[0];
    }
}