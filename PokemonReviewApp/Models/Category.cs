﻿using Pokemon_Review_App.Models;

namespace Pokemon_Review_App.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PokemonCategory> PokemonCategories { get; set; }

    }
}
