using System;
using System.IO;
using System.Text.Json;
using AdventureGame.Models;

namespace AdventureGame.Services
{
    public static class PlayerDataService
    {
        private const string filePath = "PlayerData.json";

        // Load player data from file
        public static Player LoadPlayer()
        {
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                var playerData = JsonSerializer.Deserialize<Player>(jsonString);

                // Ensure player data is not null, and that the name is assigned
                if (playerData != null && !string.IsNullOrEmpty(playerData.Name))
                {
                    return playerData;
                }
                else
                {
                    // Fallback: If no valid player data, create a default player with a name
                    return new Player("Venox");
                }
            }
            else
            {
                // If no player data exists, create a new player with a default name
                return new Player("Venox");
            }
        }

        // Save player data to file
        public static void SavePlayer(Player player)
        {
            string jsonString = JsonSerializer.Serialize(player, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonString);
        }
    }
}
