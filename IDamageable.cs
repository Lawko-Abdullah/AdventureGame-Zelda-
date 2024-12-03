namespace AdventureGame.Models
{
    public interface IDamageable
    {
        string Name { get; set; }  // Added the Name property
        void TakeDamage(int damage);
        int Health { get; set; }
    }
}
