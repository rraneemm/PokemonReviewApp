﻿using Pokemon_Review_App.Models;

namespace Pokemon_Review_App.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly BirthDate { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<PokemonCategory> PokemonCategories { get; set; }
        public ICollection<PokemonOwner> PokemonOwners { get; set; }


    }

}
