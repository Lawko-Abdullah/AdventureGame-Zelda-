using AdventureGame.Models;
using System.Text.Json;

namespace AdventureGame.Services
{
    public static class GameDataService
    {
        private const string filePath = "GameData.json";

        public static List<Item> LoadItems()
        {
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                var items = JsonSerializer.Deserialize<List<Item>>(jsonString);
                return items ?? new List<Item>();
            }
            return new List<Item>();
        }

        public static void SaveItems(List<Item> items)
        {
            string jsonString = JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonString);
        }
    }
}
 