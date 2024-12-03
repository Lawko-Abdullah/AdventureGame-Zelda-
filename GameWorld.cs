using AdventureGame.Models;
using System;
using System.Collections.Generic;

namespace AdventureGame
{
    public class GameWorld
    {
        private List<Enemy> enemies;
        private List<Item> items;

        public GameWorld()
        {
            enemies = new List<Enemy>();
            items = new List<Item>();

            // Skapa fiender
            CreateEnemies();

            // Skapa föremål
            CreateItems();
        }

        // Skapa fiender
        private void CreateEnemies()
        {
            enemies.Add(new Enemy("Stella Viper", 100, 10));   // Första fienden
            enemies.Add(new Enemy("Nemo Warrior", 100, 12));   // Andra fienden
            enemies.Add(new Enemy("Talon Beast", 100, 14));    // Tredje fienden
        }

        // Skapa föremål
        private void CreateItems()
        {
            items.Add(new Item("Health Potion", "Consumable", "Restores 20 health", 20));
            items.Add(new Item("Sword", "Weapon", "Increases attack damage by 10", 10));
            items.Add(new Item("Shield", "Armor", "Reduces incoming damage by 5", 5));
        }

        public List<Enemy> GetEnemies()
        {
            return enemies;
        }

        public List<Item> GetItems()
        {
            return items;
        }

        // Metod för att slåss med en fiende
        public void BattleWithEnemy(Player player, Enemy enemy)
        {
            // Visa alternativ för attacker
            Console.WriteLine($"Du har stött på {enemy.Name}! Välj din attack:");
            Console.WriteLine("1: Vanlig attack");
            Console.WriteLine("2: Super attack");
            string choice = Console.ReadLine();

            int damageDealt = 0;
            if (choice == "1")
            {
                damageDealt = player.RegularAttack();
            }
            else if (choice == "2")
            {
                damageDealt = player.SuperAttack();
            }
            else
            {
                Console.WriteLine("Ogiltigt val, du gör en vanlig attack.");
                damageDealt = player.RegularAttack();
            }

            // Spelaren attackerar
            enemy.TakeDamage(damageDealt);
            Console.WriteLine($"{player.Name} attackerar {enemy.Name} och gör {damageDealt} skada!");
            Console.WriteLine($"{enemy.Name} har {enemy.Health} HP kvar.");

            // Om fienden fortfarande lever, attackerar den tillbaka
            if (enemy.Health > 0)
            {
                int enemyDamage = enemy.AttackDamage;
                player.TakeDamage(enemyDamage);
                Console.WriteLine($"{enemy.Name} attackerar {player.Name} och gör {enemyDamage} skada!");
                Console.WriteLine($"{player.Name} har {player.Health} HP kvar.");
            }
            else
            {
                Console.WriteLine($"{enemy.Name} har besegrats!");
            }
        }

        // Utforska världen och träffa på en fiende
        public void Explore(Player player)
        {
            Console.WriteLine("Du utforskar världen...");
            Console.WriteLine("Du har stött på en fiende!");

            // Välj en fiende slumpmässigt
            Random rand = new Random();
            Enemy enemy = enemies[rand.Next(enemies.Count)];

            // Starta strid med fienden
            BattleWithEnemy(player, enemy);
        }
    }
}
