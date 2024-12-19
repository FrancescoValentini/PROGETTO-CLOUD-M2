namespace AirplanesAPI.Models;

public class Ac
{
    public string Hex { get; set; }
    public string Type { get; set; }
    public string Flight { get; set; }
    public string R { get; set; }
    public string T { get; set; }
    public double DbFlags { get; set; }
    public string Desc { get; set; }
    public string OwnOp { get; set; }
    public string Alt_baro { get; set; }
    public double Gs { get; set; }
    public double Ias { get; set; }
    public double Tas { get; set; }
    public double Mach { get; set; }
    public double Oat { get; set; }
    public double Tat { get; set; }
    public double Track { get; set; }
    public double Track_rate { get; set; }
    public double Roll { get; set; }
    public double Mag_heading { get; set; }
    public double True_heading { get; set; }
    public double Baro_rate { get; set; }
    public string Squawk { get; set; }
    public string Category { get; set; }
    public double Nav_qnh { get; set; }
    public double Nav_altitude_mcp { get; set; }
    public double Nav_altitude_fms { get; set; }
    public double Rr_lat { get; set; }
    public double Rr_lon { get; set; }
    public LastPosition LastPosition { get; set; }
    public string Sil_type { get; set; }
    public double Alert { get; set; }
    public double Spi { get; set; }
    public List<object> Mlat { get; set; }
    public List<object> Tisb { get; set; }
    public double Messages { get; set; }
    public double Seen { get; set; }
    public double Rssi { get; set; }
    public double Lat { get; set; }
    public double Lon { get; set; }
}