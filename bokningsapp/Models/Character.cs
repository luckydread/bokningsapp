namespace bokningsapp.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

      
        public Backpack Backpack { get; set; } = null!;
        public List<Weapon> Weapons { get; set; } = null!;
    }
}
