using Pokemon_Review_App.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface ICountryRepository
    {
        Country GetCountryById(int id);
        ICollection<Country> GetCountries();
        Country GetCountryByOwner(int ownerId);
        ICollection<Owner> GetOwnersByCountryId(int countryId);
        Country GetCountryByName(string name);
        bool CountryExists(int countryId);
        bool CreateCountry(Country country);
        bool UpdateCountry(Country country);
        bool DeleteCountry(int id);
        bool Save();
    }
}
