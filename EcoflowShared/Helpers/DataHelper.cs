using EcoflowShared.http.response;
using EcoflowShared.helpers.db;
using EcoflowShared.http;

namespace EcoflowShared.helpers.data
{
    public class DataHelper
    {
        private readonly EcoflowPostgreDbContext _dbContext;

        public DataHelper(EcoflowPostgreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task FetchDeviceData(List<EcoflowDevice> ecoflowDevices, EcoflowClient ecoflowClient)
        {
            foreach (var device in ecoflowDevices)
            {
                //if device is online, get all parameters and write to database
                if(device.Online == 1)
                {
                    var values = ecoflowClient.GetDeviceAllParameters(device.Sn);
                    if(device.ProductName == "DELTA Pro")
                    {
                       DbHelper.WriteSolarDataToDatabase(_dbContext,device, values);
                       DbHelper.WriteBatteryDataToDatabase(_dbContext,device, values);
                    }
                }
            }
            return Task.CompletedTask;
        }

        public async Task FetchDeviceDataAsync(List<EcoflowDevice> ecoflowDevices, EcoflowClient ecoflowClient)
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
                            DbHelper.WriteSolarDataToDatabase(_dbContext, device, values);
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
                            DbHelper.WriteBatteryDataToDatabase(_dbContext, device, values);
                        }
                    }
                }
            });

            await Task.WhenAll(solarTask, batteryTask); // Run both tasks concurrently
        }
    }
}