using fluffy_carnival.Data.DTO;
using System.Text.Json;

namespace fluffy_carnival.Data;

public static class Seed
{
    public static async Task<IList<PokemonDTO>>? GetList()
    {
        var pokemkonsData = await File.ReadAllTextAsync("Data/PokemonSeed.json");
        var pokemonsDTO = new List<PokemonDTO>();

        if (pokemkonsData == null)
        {
            return pokemonsDTO;
        }

        pokemonsDTO = JsonSerializer.Deserialize<List<PokemonDTO>>(pokemkonsData);        

        return pokemonsDTO;

    }
}
