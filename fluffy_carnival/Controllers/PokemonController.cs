using fluffy_carnival.Data;
using fluffy_carnival.Data.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fluffy_carnival.Controllers;
public class PokemonController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PokemonDTO>>> Get()
    {
        var pokemons = await Seed.GetList();

        return Ok(pokemons);
    }
}
