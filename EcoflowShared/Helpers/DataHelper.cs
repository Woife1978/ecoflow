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
            // Get the DLL build path dynamically
            var buildPath = AppDomain.CurrentDomain.BaseDirectory;
            var logFilePath = Path.Combine(buildPath, "error_log.txt");
            var solarTask = Task.Run(async () =>
            {
                while (true)
                {
                    try
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
                                DbHelper.WriteBatteryDataToDatabase(_dbContext, device, values);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions (e.g., log them)
                        Console.WriteLine($"Error in solarTask: {ex.Message}"); 
                        // Log the exception to a file
                        await File.AppendAllTextAsync(logFilePath, $"[{DateTime.UtcNow}] SolarTask Error: {ex.Message}{Environment.NewLine}");
            }
                }
            });

            await solarTask;
        }
    }
}