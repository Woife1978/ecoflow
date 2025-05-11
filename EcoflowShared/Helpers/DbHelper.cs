using EcoflowShared.http.response;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EcoflowShared.helpers.db
{
    public class DbHelper
    {
        //DbContext
        public static void WriteSolarDataToDatabase(DbContext dbContext, EcoflowDevice device, Dictionary<string, object> values)
        {
            if(Convert.ToInt32(values["mppt.inWatts"]) == 0)
            {
                //Console.WriteLine("Device {0}: No solar input", device.Sn);
                return;
            }
            else
            {
                //Console.WriteLine("Device {0}: Solar Input {1} Output {2}",device.Sn, Convert.ToInt32(values["mppt.inWatts"])/10, Convert.ToInt32(values["mppt.outWatts"])/10);
                
                var tracker = new SolarInputOutputTracker
                {
                    devicename = device.ProductName ?? "Unknown",
                    serialnumber = device.Sn ?? "Unknown",
                    datetime = DateTime.UtcNow,
                    input = Convert.ToInt32(values["mppt.inWatts"].ToString())/10,
                    output = Convert.ToInt32(values["mppt.outWatts"].ToString())/10
                };
                dbContext.Set<SolarInputOutputTracker>().Add(tracker);
                dbContext.SaveChanges();
            }
        }

        public static void WriteBatteryDataToDatabase(DbContext dbContext, EcoflowDevice device, Dictionary<string, object> values)
        {
            if(Convert.ToInt32(values["bmsMaster.soc"]) == 0)
            {
                //Console.WriteLine("Device {0}: No battery data", device.Sn);
                return;
            }
            else
            {
                var tracker = new BatterySocVoltageTracker
                {
                    devicename = device.ProductName ?? "Unknown",
                    serialnumber = device.Sn ?? "Unknown",
                    datetime = DateTime.UtcNow,
                    soc = Convert.ToDecimal(values["bmsMaster.targetSoc"].ToString()),
                    voltage = Convert.ToInt32(values["bmsMaster.vol"].ToString())
                };
                if(values.ContainsKey("kit.productInfoDetails"))
                {
                    //Console.WriteLine("Device has extra batteries attached");
                    var kit = values["kit.productInfoDetails"];
                    //Console.WriteLine("Kit details: {0}", kit.ToString());
                    if(kit != null)
                    {
                        var kitDetails = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(kit.ToString());

                        if(kitDetails != null)
                        {
                            if(kitDetails.Count == 1)
                            {
                                var kitDetail = kitDetails.FirstOrDefault();
                                tracker.extrabattery1soc = Convert.ToDecimal(kitDetail["f32Soc"].ToString());
                            }
                            if(kitDetails.Count == 2)
                            {
                                tracker.extrabattery1soc = Convert.ToDecimal(kitDetails.First()["f32Soc"].ToString());
                                tracker.extrabattery2soc = Convert.ToDecimal(kitDetails.Last()["f32Soc"].ToString());
                            }
                        }
                    }
                }
                dbContext.Set<BatterySocVoltageTracker>().Add(tracker);
                dbContext.SaveChanges();
            }
        }
    }
}