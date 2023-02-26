using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace client.Models;

public class Pokemon
    {
        public int Id { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public bool is_default { get; set; }
        public string? location_area_encounters { get; set; }
        public string? Name { get; set; }
        public int Order { get; set; }
        public List<Abilities>? abilities { get; set; }
        public int base_experience { get; set; }
        public Species? species { get; set; }

        public string Abilities() {
            var ablilitiesList = new StringBuilder();

            foreach (var item in abilities ?? Enumerable.Empty<Abilities>())
            {
                ablilitiesList.Append($"{item?.Ability?.Name} ");
            }

            return ablilitiesList.ToString();
        }
    }
    