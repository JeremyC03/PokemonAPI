using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PokemonAPI.Models;
using System;

namespace PokemonAPI.Controllers
{
    public class PokemonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RetrievePokemon(string pokemon)
        {
            //Declare pokemonObject to be used outside Try-Catch
            JObject pokemonObject;

            //Handle null answers
            if (string.IsNullOrEmpty(pokemon))
            {
                return RedirectToAction("Index");
            }

            //Create new instance of class
            HttpClient client = new HttpClient();
            //Try-Catch if input is incorrect
            try
            {
                //URL endpoint
                string pokemonURL = $"https://pokeapi.co/api/v2/pokemon/{pokemon.ToLower()}";
                //GET request
                string pokemonResponse = client.GetStringAsync(pokemonURL).Result;
                //Parse Object/Array
                pokemonObject = JObject.Parse(pokemonResponse);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
            //Made list for muliple answers to be given
            List<string> types = new List<string>();
            foreach(var type in pokemonObject["types"])
            {
                types.Add(type["type"]["name"].ToString());
            }
            List<string> heldItems = new List<string>();
            foreach (var items in pokemonObject["held_items"])
            {
                heldItems.Add(items["item"]["name"].ToString());
            }
            List<string> abilities = new List<string>();
            foreach (var ability in pokemonObject["abilities"])
            {
               abilities.Add(ability["ability"]["name"].ToString());
            }
            List<string> stats = new List<string>();
            foreach (var stat in pokemonObject["stats"])
            {
                stats.Add(stat["stat"]["name"].ToString());
                stats.Add(stat["base_stat"].ToString());
            }
            //What info will be shown to user
            var newPokemon = new PokemonModel(
            pokemonObject["species"]["name"].ToString(),
            pokemonObject["id"].Value<int>(),
            types,
            pokemonObject["height"].Value<int>(),
            pokemonObject["weight"].Value<int>(),
            heldItems,
            abilities,
            stats
            );
            newPokemon.Sprite = pokemonObject["sprites"]["front_default"].ToString();
            return RedirectToAction("Info", newPokemon);
        }
        public IActionResult Info(PokemonModel newPokemon)
        {
            return View(newPokemon);
        }
    }
}
