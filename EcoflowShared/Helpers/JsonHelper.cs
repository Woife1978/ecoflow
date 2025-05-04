using Newtonsoft.Json;

namespace EcoflowShared.helpers.json
{
    public class Json
    {
        public static void ExportDictionaryToJson(Dictionary<string, object> data, string filePath)
        {
            try
            {
                // Serialize the dictionary to JSON
                string json = JsonConvert.SerializeObject(data, Formatting.Indented);

                // Write the JSON to the specified file
                File.WriteAllText(filePath, json);

                Console.WriteLine($"Dictionary exported to JSON file at: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while exporting the dictionary to JSON: {ex.Message}");
            }
        }

        public static void ExportToJson<T>(List<T> data, string filePath)
        {
            try
            {
                // Serialize the list of data to JSON
                string json = JsonConvert.SerializeObject(data, Formatting.Indented);

                // Write the JSON to the specified file
                File.WriteAllText(filePath, json);

                Console.WriteLine($"Data exported to JSON file at: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while exporting data to JSON: {ex.Message}");
            }
        }
    }
}