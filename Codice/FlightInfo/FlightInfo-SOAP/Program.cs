using FlightInfo_SOAP.WSSoap;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSoapCore();
builder.Services.AddScoped<IAirplanesAPIServiceSOAP, AirplanesAPIServiceSOAP>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.UseEndpoints(endpoints =>
{
    endpoints.UseSoapEndpoint<IAirplanesAPIServiceSOAP>("/service.wsdl", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);
});


app.Run();
