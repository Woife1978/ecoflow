using EcoflowShared.http;
using EcoflowShared.http.response;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EcoflowShared.helpers.data
{
    public class DeviceDataFetcher
    {
        private readonly List<EcoflowDevice> _devices;
        private readonly EcoflowClient _ecoflowClient;
        private readonly DataHelper _dataHelper;

        public DeviceDataFetcher(List<EcoflowDevice> devices, EcoflowClient ecoflowClient, DataHelper dataHelper)
        {
            _devices = devices;
            _ecoflowClient = ecoflowClient;
            _dataHelper = dataHelper;
        }
        public async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _dataHelper.FetchDeviceDataAsync(_devices, _ecoflowClient);
                await Task.Delay(1000, stoppingToken); // Adjust delay as needed
            }
        }
    }
}