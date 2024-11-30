using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using TrimlightTest;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Configuration.Sources.Clear();
builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

Config? config = builder.Configuration.Get<Config>();

if (config == null)
{
    Console.WriteLine("Configuration could not be loaded.");
    return;
}

var repository = new TrimlightData.Repositories.DeviceRepository(config.ClientId, config.ClientSecret);
var devices = await repository.GetDevicesAsync();
if (devices != null && devices.Length > 0)
{
    var deviceId = devices[0].DeviceId;
    var device = await repository.GetDeviceAsync(deviceId);
    if (device != null)
    {
        Console.WriteLine($"Device {device.Name} found" + device.ToString());
    }
    else
    {
        Console.WriteLine($"Device {deviceId} not found");
    }
}
else
{
    Console.WriteLine("No devices found");
}
