namespace AdventureGame.Models
{
    public class Player : IDamageable
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackDamage { get; set; }
        public List<Item> Inventory { get; set; }

        public Player(string name)
        {
            Name = name;
            Health = 100;  // Starta med 100 HP
            AttackDamage = 10;  // Grundläggande attackdamage
            Inventory = new List<Item>();
        }

        // Implementering av TakeDamage från IDamageable
        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0; // Förhindra att hälsan blir negativ
        }

        // Lägg till metod för att återställa hälsan
        public void ResetHealth()
        {
            Health = 100;  // Återställ till full hälsa
            Console.WriteLine($"{Name} har återställt sin hälsa till full!");
        }

        // Vanlig attack
        public int RegularAttack()
        {
            return AttackDamage;
        }

        // Super attack
        public int SuperAttack()
        {
            return AttackDamage * 2;  // Super attack ger dubbelt så mycket skada
        }

        // Lägg till metod för att använda föremål (om du vill)
        public void UseItem(string itemName)
        {
            var item = Inventory.FirstOrDefault(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
            if (item != null)
            {
                Console.WriteLine($"{Name} använder {item.Name}: {item.Effect}");
                if (item.Type == "Consumable" && item.Name == "Health Potion")
                {
                    Health += 20;  // Hälsopotion ger 20 hälsa
                    Console.WriteLine($"{Name} får 20 hälsa tillbaka!");
                    Inventory.Remove(item);  // Ta bort föremålet från inventory
                }
            }
            else
            {
                Console.WriteLine("Föremålet finns inte i din inventory.");
            }
        }
    }
}
