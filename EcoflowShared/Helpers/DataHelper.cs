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

        public Task WriteOrUpdateDeviceToDatabase(EcoflowDevice device)
        {
            // Check if the device already exists in the database
            var existingDevice = _dbContext.ecoflowdevice.FirstOrDefault(d => d.Sn == device.Sn);
            if (existingDevice == null)
            {
                // If not, add it to the database
                _dbContext.ecoflowdevice.Add(device);
                _dbContext.SaveChanges();
            }
            else
            {
                // If it exists, update the existing record
                existingDevice.Online = device.Online;
                _dbContext.SaveChanges();
            }
            // Optionally, you can return a Task.CompletedTask or any other relevant task
            // to indicate that the operation is complete.
            // For example:
            // return Task.CompletedTask;
            // Or if you want to return a completed task:
            // return Task.FromResult(0);
            return Task.CompletedTask;
        }

        // Fetch device data and write to database

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