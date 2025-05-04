using Microsoft.Extensions.Configuration;
using EcoflowShared.http;
using EcoflowShared.http.response;
using EcoflowShared.helpers.json;
using EcoflowShared.helpers.data;

namespace EcoflowDataCollector{
  public class Program
    {
        private static string ACCESS_KEY = string.Empty;
        private static string SECRET_KEY = string.Empty;

        public static void LoadConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            ACCESS_KEY = config["AccessKey"] ?? string.Empty;
            SECRET_KEY = config["SecretKey"] ?? string.Empty;
        }

        static async Task Main(string[] args)
        {
            LoadConfiguration();
            HttpRestClient httpRestClient = new HttpRestClient(ACCESS_KEY, SECRET_KEY);
            EcoflowClient ecoflowClient = new EcoflowClient(httpRestClient);
            //get all linked devices
            List<EcoflowDevice> devices = ecoflowClient.GetDevices();
            //Export devices to json file
            Json.ExportToJson(devices, "./temp/json/devices.json");

            foreach (var item in devices)
            {
                //if device is online, get all parameters and export to json file
                if(item.Online == 1)
                {
                    var values = ecoflowClient.GetDeviceAllParameters(item.Sn);
                    Json.ExportDictionaryToJson(values, $"./temp/json/{item.Sn}.json");    
                }   
            }
            Console.WriteLine("Running data collector");
            await DataHelper.FetchDeviceDataAsync(devices, ecoflowClient);
        }  
    }
}