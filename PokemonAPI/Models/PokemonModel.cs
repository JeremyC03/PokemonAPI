namespace PokemonAPI.Models
{
    public class PokemonModel
    {
       // public Species Species { get; set; }
        public string Species { get; set; }
        public int ID { get; set; }
        //public List<Type> Types { get; set; }
        public string Types { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        //public List<object> HeldItems { get; set; }
        public string HeldItems { get; set; }
        //public List<Ability> Abilities { get; set; }
        public string Abilities { get; set; }
        //public List<Stat> Stats { get; set; }
        public string Stats { get; set; }
    }
}
