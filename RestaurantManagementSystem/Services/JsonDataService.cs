using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace RestaurantManagementSystem.Services
{
    public class JsonDataService
    {
        private readonly string filePath = "restaurantData.json";

        private readonly JsonSerializerOptions options =
            new JsonSerializerOptions
            {
                WriteIndented = true
            };

        public AppData LoadData()
        {
            if (!File.Exists(filePath))
            {
                SaveData(new AppData());
                return new AppData();
            }

            try
            {
                string json = File.ReadAllText(filePath);

                if (string.IsNullOrWhiteSpace(json))
                {
                    return new AppData();
                }

                AppData? data =
                    JsonSerializer.Deserialize<AppData>(json);

                return data ?? new AppData();
            }
            catch (JsonException)
            {
                Console.WriteLine("Invalid data");
  

                return new AppData();
            }
            catch (IOException)
            {
                Console.WriteLine(
                    "The data file could not be read. Starting with empty data.");

                return new AppData();
            }
        }

        public void SaveData(AppData data)
        {
            try
            {
                string json =
                    JsonSerializer.Serialize(data, options);

                File.WriteAllText(filePath, json);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Could not save data: " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Permission error: " + ex.Message);
            }
        }
    }
}