using fluffy_carnival.Data.DTO;

namespace fluffy_carnival.Services.Interfaces;

public interface IPokemonService
{
        public Task<IList<PokemonDTO>?> GetList();
        public Task<PokemonDTO?> GetById(int id);
        public Task<PokemonDTO?> GetByName(string name);
}
