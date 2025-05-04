using EcoflowShared.http.response;
using EcoflowShared.helpers.db;
using EcoflowShared.http;

namespace EcoflowShared.helpers.data
{
    public class DataHelper
    {
        public static Task FetchDeviceData(List<EcoflowDevice> ecoflowDevices, EcoflowClient ecoflowClient)
        {
            foreach (var device in ecoflowDevices)
            {
                //if device is online, get all parameters and write to database
                if(device.Online == 1)
                {
                    var values = ecoflowClient.GetDeviceAllParameters(device.Sn);
                    if(device.ProductName == "DELTA Pro")
                    {
                       DbHelper.WriteSolarDataToDatabase(new EcoflowPostgreDbContext(),device, values);
                       DbHelper.WriteBatteryDataToDatabase(new EcoflowPostgreDbContext(),device, values);
                    }
                }
            }
            return Task.CompletedTask;
        }

        public static async Task FetchDeviceDataAsync(List<EcoflowDevice> ecoflowDevices, EcoflowClient ecoflowClient)
        {
            var solarTask = Task.Run(async () =>
            {
                while (true)
                {
                    var now = DateTime.UtcNow;
                    // Calculate the delay to align with the next exact second
                    var delay = 1000 - (now.Millisecond % 1000);
                    await Task.Delay(delay); // Wait until the next exact second

                    foreach (var device in ecoflowDevices)
                    {
                        if (device.Online == 1 && device.ProductName == "DELTA Pro")
                        {
                            var values = ecoflowClient.GetDeviceAllParameters(device.Sn);
                            DbHelper.WriteSolarDataToDatabase(new EcoflowPostgreDbContext(), device, values);
                        }
                    }
                }
            });

            var batteryTask = Task.Run(async () =>
            {
                while (true)
                {
                    var now = DateTime.UtcNow;
                    var delay = (60 - now.Second) * 1000 - now.Millisecond; // Align with the next full minute
                    await Task.Delay(delay);

                    foreach (var device in ecoflowDevices)
                    {
                        if (device.Online == 1 && device.ProductName == "DELTA Pro")
                        {
                            var values = ecoflowClient.GetDeviceAllParameters(device.Sn);
                            DbHelper.WriteBatteryDataToDatabase(new EcoflowPostgreDbContext(), device, values);
                        }
                    }
                }
            });

            await Task.WhenAll(solarTask, batteryTask); // Run both tasks concurrently
        }
    }
}