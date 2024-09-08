using AutoMapper;
using Pokemon_Review_App.Data;
using Pokemon_Review_App.Models;
using PokemonReviewApp.Interfaces;

namespace PokemonReviewApp.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _context;
        

        public OwnerRepository(DataContext context)
        {
            _context = context;

        }
        public bool CreateOwner(Owner owner)
        {
            _context.Add(owner);
            return Save();
        }


        public bool DeleteOwner(Owner owner)
        {
            _context.Remove(owner);
            return Save();        }

        public Country GetCountryOfOwner(int ownerId)
        {
            return _context.Owners.Where(o => o.Id == ownerId).Select(o => o.Country).FirstOrDefault();
        }

        public Owner GetOwnerById(int id)
        {
            return _context.Owners.Where(o => o.Id == id).FirstOrDefault();
        }

        public Owner GetOwnerByName(string name)
        {
            return _context.Owners.Where(o => o.FirstName == name).FirstOrDefault();
        }

        public ICollection<Owner> GetOwners()
        {
            return _context.Owners.ToList();
        }

        public ICollection<Owner> GetOwnersOfPokemon(int pokemonId)
        {
            return _context.PokemonOwners.Where(p => p.PokemonId == pokemonId).Select(o => o.Owner).ToList();
        }

        public bool OwnerExists(int ownerId)
        {
            return _context.Owners.Any(o => o.Id == ownerId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateOwner(Owner owner)
        {
            _context.Update(owner);
            return Save();
        }
    }
}
