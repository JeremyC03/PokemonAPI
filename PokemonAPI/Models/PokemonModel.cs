namespace PokemonAPI.Models
{
    public class PokemonModel
    {
        public PokemonModel()
        {
            
        }
        //Custom constructor for controller
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
        //Info retrieving from API
        public string Species { get; set; }
        public int ID { get; set; }
        public List<string> Types { get; set; } =new List<string>();
        public int Height { get; set; }
        public int Weight { get; set; }
        public List<string> HeldItems { get; set; } = new List<string>();
        public List<string> Abilities { get; set; } = new List<string>();
        public List<string> Stats { get; set; } = new List<string>();
        public string Sprite { get; set; }
    }
}
