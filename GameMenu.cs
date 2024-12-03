using Spectre.Console;
using System;
using AdventureGame.Models;
using AdventureGame.Services;

namespace AdventureGame
{
    public class GameMenu
    {
        private Player player;
        private GameWorld gameWorld;

        public GameMenu()
        {
            // Ladda spelarens data vid start
            player = PlayerDataService.LoadPlayer();
            gameWorld = new GameWorld();
        }

        public void StartGame()
        {
            AnsiConsole.WriteLine("Välkommen till Äventyret!");
            AnsiConsole.WriteLine($"Hej, {player.Name}!");

            bool gameOver = false;
            while (!gameOver)
            {
                AnsiConsole.MarkupLine("[bold yellow]1. Utforska[/]");
                AnsiConsole.MarkupLine("[bold yellow]2. Se inventory[/]");
                AnsiConsole.MarkupLine("[bold yellow]3. Spara och avsluta[/]");
                AnsiConsole.MarkupLine("[bold yellow]4. Använd föremål[/]");
                AnsiConsole.MarkupLine("[bold yellow]5. Återställ hälsa[/]"); // Nytt alternativ
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        gameWorld.Explore(player); // Utforska världen
                        break;
                    case "2":
                        ShowInventory();
                        break;
                    case "3":
                        PlayerDataService.SavePlayer(player);
                        GameDataService.SaveItems(gameWorld.GetItems());
                        AnsiConsole.MarkupLine("[bold green]Spelet har sparats.[/]");
                        gameOver = true;
                        break;
                    case "4":
                        UseItem();
                        break;
                    case "5":
                        player.ResetHealth(); // Återställ hälsa
                        break;
                    default:
                        AnsiConsole.MarkupLine("[red]Ogiltigt val, försök igen.[/]");
                        break;
                }
            }
        }

        private void ShowInventory()
        {
            AnsiConsole.MarkupLine("[bold blue]Din inventory:[/]");
            foreach (var item in player.Inventory)
            {
                AnsiConsole.MarkupLine($"- {item.Name} ({item.Type}): {item.Effect}");
            }
        }

        private void UseItem()
        {
            AnsiConsole.MarkupLine("[bold blue]Vilket föremål vill du använda?[/]");
            string itemName = Console.ReadLine();
            player.UseItem(itemName);
        }
    }
}
