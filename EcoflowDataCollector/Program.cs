using Microsoft.Extensions.Configuration;
using EcoflowShared.http;
using EcoflowShared.http.response;
using EcoflowShared.helpers.json;
using EcoflowShared.helpers.data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace EcoflowDataCollector{
  public class Program
    {
        private static string ACCESS_KEY = string.Empty;
        private static string SECRET_KEY = string.Empty;
        
        public static void LoadConfiguration(IConfiguration configuration)
        {
            ACCESS_KEY = configuration["AccessKey"] ?? string.Empty;
            SECRET_KEY = configuration["SecretKey"] ?? string.Empty;
        }

        static async Task Main(string[] args)
        {
            // Set up DI container
            var serviceCollection = new ServiceCollection();
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            
            LoadConfiguration(configuration);
            serviceCollection.AddSingleton(configuration);

            serviceCollection.AddDbContext<EcoflowPostgreDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("EcoflowDatabase")));
            serviceCollection.AddSingleton<EcoflowClient>(sp =>
            {
                var httpRestClient = new HttpRestClient(ACCESS_KEY, SECRET_KEY);
                return new EcoflowClient(httpRestClient);
            });
            serviceCollection.AddSingleton<DataHelper>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var ecoflowClient = serviceProvider.GetRequiredService<EcoflowClient>();
            var dataHelper = serviceProvider.GetRequiredService<DataHelper>();

            //get all linked devices
            List<EcoflowDevice> devices = ecoflowClient.GetDevices();
            //Export devices to json file
            Json.ExportToJson(devices, "./temp/json/devices.json");

            foreach (var item in devices)
            {
                var values = ecoflowClient.GetDeviceAllParameters(item.Sn);
                //if device is online, get all parameters and export to json file
                if(item.Online == 1)
                {
                    switch (item.ProductName)
                    {
                        case "DELTA Pro":
                            DeltaPro deltaPro = await ecoflowClient.GetDeviceAllParameters<DeltaPro>(item.Sn);
                            Json.ExportToJson(deltaPro, $"./temp/json/{item.Sn}.json");    
                            break;
                        case "Smart Home Panel":
                            SmartHomePanel smartHomePanel = await ecoflowClient.GetDeviceAllParameters<SmartHomePanel>(item.Sn);
                            Json.ExportToJson(smartHomePanel, $"./temp/json/{item.Sn}.json");
                            break;
                        case "RIVER 2":
                            Console.WriteLine($"Device {item.Sn} is online");
                            Json.ExportDictionaryToJson(values, $"./temp/json/{item.Sn}.json");
                            break;
                        default:
                            Console.WriteLine($"Device {item.Sn} is offline");
                            break;
                    }
                }   
            }
            Console.WriteLine("Running data collector");
            await dataHelper.FetchDeviceDataAsync(devices, ecoflowClient);
        }  
    }
}