namespace AdventureGame.Models
{
    public class Item
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Effect { get; set; }
        public int Value { get; set; }  // Value represents the effect amount (e.g., health restored)

        public Item(string name, string type, string effect, int value)
        {
            Name = name;
            Type = type;
            Effect = effect;
            Value = value;  // Value is for the amount of health restored for Health Potions
        }
    }
}
