namespace AdventureGame.Models
{
    public class Enemy : IDamageable
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackDamage { get; set; }

        public Enemy(string name, int health, int attackDamage)
        {
            Name = name;
            Health = health;
            AttackDamage = attackDamage;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0; // Prevent negative health
        }
    }
}
