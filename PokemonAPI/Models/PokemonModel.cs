namespace PokemonAPI.Models
{
    public class PokemonModel
    {
        public PokemonModel()
        {
            
        }
        public PokemonModel(string species, int id, List<string> types, int height, int weight, List<string> heldItems, List<string> abilities, List<string> stats)
        {
            Species = species;
            ID = id;
            Types = types;
            Height = height;
            Weight = weight;
            HeldItems = heldItems;
            Abilities = abilities;
            Stats = stats;
        }
        public string Species { get; set; }
        public int ID { get; set; }
        public List<string> Types { get; set; } =new List<string>();
        //public string Types { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public List<string> HeldItems { get; set; } = new List<string>();
        //public string HeldItems { get; set; }
        public List<string> Abilities { get; set; } = new List<string>();
        //public string Abilities { get; set; }
        public List<string> Stats { get; set; } = new List<string>();
        //public string Stats { get; set; }
        public string Sprite { get; set; }
    }
}
