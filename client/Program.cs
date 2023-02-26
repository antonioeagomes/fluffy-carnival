using System.Collections.Generic;
using client;
using client.Models;

List<Pokemon> Pokemons = new List<Pokemon>();

string? option;
bool isOn = true;

var pokemons = await PokemonService.List();

while (isOn)
{

    Console.WriteLine("What is your name?");
    var username = Console.ReadLine();
    Console.WriteLine("\n******************************* MENU *******************************\n");
    Console.WriteLine($"Hi, {username} choose an option\n");
    Console.WriteLine("1 - Adopt a pokemon");
    Console.WriteLine("2 - My adopted pokemons");
    Console.WriteLine("0 - Exit");

    option = Console.ReadLine();

    switch (option)
    {
        case "1":
            // var pokemons = await PokemonService.List();
            Console.WriteLine("\n******************************* ADOPTION *******************************\n");
            Console.WriteLine("Choose a pokemon:\n");

            if (pokemons != null)
            {
                foreach (var item in pokemons)
                {
                    Console.WriteLine($"{item.Id} - {item.Name}");
                }
                Console.WriteLine("");
            }

            while (option != "0")
            {
                var subMenuOption = Console.ReadLine();

                if (subMenuOption == "0")
                {
                    option = subMenuOption;
                    break;
                }

                var pokemon = await PokemonService.GetById(int.Parse(subMenuOption ?? "0"));

                Console.WriteLine("\nWhat do you want to do?\n");
                Console.WriteLine($"1 - Adopt {pokemon?.Name}");
                Console.WriteLine($"2 - Get to know more about {pokemon?.Name}");
                Console.WriteLine($"0 - Exit");

                var thirdOption = Console.ReadLine();

                if (thirdOption == "0")
                {
                    subMenuOption = thirdOption;
                    break;
                }

                switch (thirdOption)
                {
                    case "1":
                        if (pokemon == null) break;

                        Console.WriteLine("Adopted");
                        if (Pokemons != null) Pokemons.Add(pokemon);
                        break;

                    case "2":
                        Console.WriteLine($"");
                        Console.WriteLine($"Pokemons name: {pokemon?.Name}");
                        Console.WriteLine($"Height: {pokemon?.Height}");
                        Console.WriteLine($"Weight: {pokemon?.Weight}");
                        Console.WriteLine($"Abilities: {pokemon?.Abilities()}");
                        break;

                    default:
                        Console.WriteLine("Wrong! Try again");
                        break;
                }

            }
            break;

        case "2":
            if (Pokemons != null)
            {
                foreach (var item in Pokemons)
                {
                    Console.WriteLine($"{item.Id} - {item.Name}");
                }
                Console.WriteLine("");
            }
            break;
        case "0":
            isOn = false;
            break;

        default:
            Console.WriteLine("Wrong! Try again");
            break;
    }
}

