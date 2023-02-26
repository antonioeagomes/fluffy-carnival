using fluffy_carnival.Data;
using fluffy_carnival.Data.DTO;
using fluffy_carnival.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fluffy_carnival.Controllers;
public class PokemonController : BaseApiController
{
    private readonly IPokemonService _pokemonService;
    public PokemonController(IPokemonService pokemonService)
    {
        _pokemonService = pokemonService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PokemonDTO>>> Get()
    {
        var pokemons = await _pokemonService.GetList();

        return Ok(pokemons);
    }

    [HttpGet("{id}", Name = "GetById")]
    public async Task<ActionResult<PokemonDTO>> GetById(int id)
    {
        var pokemon = await _pokemonService.GetById(id);

        return Ok(pokemon);
    }

    [HttpGet("get/{name}", Name = "GetByName")]
    public async Task<ActionResult<PokemonDTO>> GetByName(string name)
    {
        var pokemon = await _pokemonService.GetByName(name);

        return Ok(pokemon);
    }

}
