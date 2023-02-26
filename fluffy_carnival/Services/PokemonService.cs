using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using fluffy_carnival.Data.DTO;
using fluffy_carnival.Services.Interfaces;
using RestSharp;

namespace fluffy_carnival.Services;

public class PokemonService : IPokemonService
{
    public readonly IRedisService _redis;
    private readonly IHttpClientFactory _httpClientFactory;
    public PokemonService(
        IRedisService redis,
        IHttpClientFactory httpClientFactory) =>
        (_redis, _httpClientFactory) = (redis, httpClientFactory);

    public async Task<IList<PokemonDTO>?> GetList()
    {
        var cached = await _redis.Read("AllPokemons");
        var pokemonsDTO = new List<PokemonDTO>();

        if (!string.IsNullOrEmpty(cached))
            pokemonsDTO = JsonSerializer.Deserialize<List<PokemonDTO>>(cached.ToString());
        else
        {
            var pokemkonsData = await File.ReadAllTextAsync("Data/PokemonSeed.json");

            if (pokemkonsData == null) return pokemonsDTO;

            await _redis.Save("AllPokemons", pokemkonsData);

            pokemonsDTO = JsonSerializer.Deserialize<List<PokemonDTO>>(pokemkonsData);
        }

        return pokemonsDTO;

    }

    public async Task<PokemonDTO?> GetById(int id)
    {
        var allPokemons = await GetList();
        var chosenPokemon = allPokemons?.FirstOrDefault(p => p.Id == id);

        using HttpClient client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync(chosenPokemon?.Url);

        if (!response.IsSuccessStatusCode) throw new Exception("Not found");

        var pokemon = await response.Content.ReadFromJsonAsync<PokemonDTO>();

        return pokemon;
    }

    public async Task<PokemonDTO?> GetByName(string name)
    {
        var options = new RestClientOptions("https://pokeapi.co/api/v2/pokemon/")
        {
            ThrowOnAnyError = true,
            MaxTimeout = 1000
        };
        var client = new RestClient(options);
        var request = new RestRequest(name);
        var pokemon = await client.GetAsync<PokemonDTO>(request);

        return pokemon;
    }

}