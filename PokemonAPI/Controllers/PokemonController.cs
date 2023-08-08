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
            //Create new instance of class
            HttpClient client = new HttpClient();

            //User pokemon name input
            Console.WriteLine("Please enter a pokemon name");
            var pokemonInput = Console.ReadLine();
            Console.WriteLine();

            //While loop to get valid input
            bool conditional = true;

            while (conditional)
            {
                //Try-Catch if input is incorrect
                try
                {
                    //URL endpoint
                    string pokemonURL = $"https://pokeapi.co/api/v2/pokemon/{pokemonInput.ToLower()}";
                    //GET request
                    string pokemonResponse = client.GetStringAsync(pokemonURL).Result;
                    //Parse Object/Array
                    var pokemonObject = JObject.Parse(pokemonResponse);
                    //var pokemonObject = JsonConvert.DeserializeObject<PokemonModel>(pokemonResponse);

                    //Write to console
                    Console.WriteLine("Species:");
                    Console.WriteLine($"{pokemonObject["species"]["name"]}");
                    Console.WriteLine();

                    Console.WriteLine($"ID:");
                    Console.WriteLine($"{pokemonObject["id"]}");
                    Console.WriteLine();

                    //Foreach loop to write multiple answers if pokemon has more than 1 answer
                    Console.WriteLine("Type:");
                    foreach (var type in pokemonObject["types"])
                    {
                        Console.WriteLine($"{type["type"]["name"]}");
                    }
                    Console.WriteLine();

                    Console.WriteLine("Height:");
                    Console.WriteLine($"{pokemonObject["height"]} decimeters");
                    Console.WriteLine();

                    Console.WriteLine("Weight:");
                    Console.WriteLine($"{pokemonObject["weight"]} hectograms");
                    Console.WriteLine();

                    //If statement if pokemon doesn't have answer
                    Console.WriteLine("Possible held items:");
                    JToken dataToken;
                    if (pokemonObject.TryGetValue("held_items", out dataToken) && dataToken is JArray array && array.Count == 0)
                    {
                        Console.WriteLine("None");
                    }
                    else
                    {
                        foreach (var items in pokemonObject["held_items"])
                        {
                            Console.WriteLine($"{items["item"]["name"]}");
                        }

                    }
                    Console.WriteLine();

                    Console.WriteLine("Possible Abilities:");
                    foreach (var ability in pokemonObject["abilities"])
                    {
                        Console.WriteLine($"{ability["ability"]["name"]}");
                    }
                    Console.WriteLine();

                    Console.WriteLine("Base Stats:");
                    foreach (var stats in pokemonObject["stats"])
                    {
                        Console.WriteLine($"{stats["stat"]["name"]}: {stats["base_stat"]} ");
                    }
                    Console.WriteLine();

                    conditional = false;
                    //return View(pokemonObject);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Please enter a pokemon name");
                    string retryInput = Console.ReadLine();
                    pokemonInput = retryInput;
                    Console.WriteLine();
                }
            }

            return View(pokemonObject);
        }
    }
}
