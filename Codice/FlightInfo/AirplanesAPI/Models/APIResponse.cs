namespace AirplanesAPI.Models;

public class APIResponse
{
    public List<Ac> Ac { get; set; }
    public string Msg { get; set; }
    public long Now { get; set; }
    public int Total { get; set; }
    public long Ctime { get; set; }
    public int Ptime { get; set; }
}
