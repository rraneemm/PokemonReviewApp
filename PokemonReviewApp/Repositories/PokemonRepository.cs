using Microsoft.Identity.Client;
using Pokemon_Review_App.Data;
using Pokemon_Review_App.Models;
using PokemonReviewApp.Interfaces;

namespace PokemonReviewApp.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly  DataContext _context; 
        public PokemonRepository (DataContext context)
            {
                _context = context;
            }

        public bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            var pokemonOwnerEntity = _context.Owners.Where(o => o.Id == ownerId).FirstOrDefault();
            var pokeonCategoryEntity = _context.Categories.Where(c => c.Id == categoryId).FirstOrDefault();

            var pokemonOwner = new PokemonOwner()
            {
                Owner = pokemonOwnerEntity,
                Pokemon = pokemon,
            };

            _context.Add(pokemonOwner);

            var pokemonCategory = new PokemonCategory()
            {
                Category = pokeonCategoryEntity,
                Pokemon = pokemon,
            };

            _context.Add(pokemonCategory);

            _context.Add(pokemon);

            return Save();
        }

        public bool DeletePokemon(Pokemon pokemon)
        {
            _context.Remove(pokemon);
            return Save();
        }

        public ICollection<Owner> GetOwnersOfPokemon(int pokemonId)
        {
            return _context.PokemonOwners.Where(o => o.PokemonId == pokemonId).Select(p => p.Owner).ToList();
        }

        public Pokemon GetPokemonById(int id)
        {
            return _context.Pokemons.Where(p => p.Id == id).FirstOrDefault();

        }

        public Pokemon GetPokemonByName(string name)
        {
            return _context.Pokemons.Where(p => p.Name == name).FirstOrDefault();

        }


        public decimal GetPokemonRating(int pokemanId)
        {
            var review = _context.Reviews.Where(p => p.Id == pokemanId);

            if (review.Count() <= 0)
                return 0;

            return ((decimal)review.Sum(r => r.Rating) / review.Count());
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemons.OrderBy(p => p.Id).ToList();
        }

        public bool PokemonExists(int pokemnId)
        {
            return _context.Pokemons.Any(p => p.Id == pokemnId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdatePokemon(Pokemon pokemon)
        {
            _context.Update(pokemon);
            return Save();
        }
    }
}
