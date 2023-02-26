namespace fluffy_carnival.Data.DTO
{
    public class PokemonDTO
    {
        public int Id { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public bool is_default { get; set; }
        public string? location_area_encounters { get; set; }
        public string? Name { get; set; }
        public int Order { get; set; }
        public string Url { get; set; }
        public List<AbilitiesDTO>? Abilities { get; set; }
        public int base_experience { get; set; }
        public SpeciesDTO? species { get; set; }        
        
    }
}
