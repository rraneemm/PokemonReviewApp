using Microsoft.Identity.Client;
using Pokemon_Review_App.Data;
using Pokemon_Review_App.Models;
using PokemonReviewApp.Interfaces;

namespace PokemonReviewApp.Repositories
{
    public class PokemonRepository: IPokemonRepository
    {
        private readonly  DataContext _context; 
        public PokemonRepository (DataContext context)
            {
                _context = context;
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
    }
}
