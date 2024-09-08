using Pokemon_Review_App.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();
        Owner GetOwnerById(int id);
        Owner GetOwnerByName(string name);
        ICollection<Pokemon> GetPokemonsByOwnerId(int ownerId);
        ICollection<Owner> GetOwnersOfPokemon(int pokemonId);
        Country GetCountryOfOwner(int ownerId);
        bool OwnerExists(int ownerId);
        bool CreateOwner(Owner owner);
        bool UpdateOwner(Owner owner);
        bool DeleteOwner(Owner owner);
        bool Save();
    }
}
