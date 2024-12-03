using System;
using System.Collections.Generic;
using AdventureGame.Models;
using AdventureGame.Services;
using Spectre.Console;
using Figgle;


namespace AdventureGame
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string title = "Adventure Game";
            string asciiTitle = Figgle.FiggleFonts.Standard.Render(title);
            AnsiConsole.MarkupLine("[bold green]" + asciiTitle + "[/]");

            List<Item> items = GameDataService.LoadItems();

            // Check if any items are loaded, for debugging or info
            if (items.Count > 0)
            {
                AnsiConsole.MarkupLine("[bold cyan]Items loaded:[/]");
                foreach (var item in items)
                {
                    AnsiConsole.MarkupLine($"- {item.Name}: {item.Effect}");
                }
            }
            else
            {
                AnsiConsole.MarkupLine("[bold red]No items found![/]");
            }

            GameMenu menu = new GameMenu();
            menu.StartGame();
        }
    }
}


