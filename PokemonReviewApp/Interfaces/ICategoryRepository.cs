using Pokemon_Review_App.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface ICategoryRepository
    {
        // get all categories
        ICollection<Category> GetCategories();
        // get category by id
        Category GetCategoryByID(int id);
        // get pokeman by category id --> returns list of pokemons
        ICollection<Pokemon> GetPokemonsByCategory(int categoryId);
        // get category by name
        Category GetCategoryByName(string name);
        // check if category exists
        bool CategoriesExists(int id);
    }
}
