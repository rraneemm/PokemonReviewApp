using AutoMapper;
using Pokemon_Review_App.Data;
using Pokemon_Review_App.Models;
using PokemonReviewApp.Interfaces;

namespace PokemonReviewApp.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public OwnerRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        public ICollection<Pokemon> GetPokemonsByOwnerId(int ownerId)
        {
            return _context.PokemonOwners.Where(o => o.OwnerId == ownerId).Select(p => p.Pokemon).ToList();
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
