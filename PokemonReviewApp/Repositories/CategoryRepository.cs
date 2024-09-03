using AutoMapper;
using Pokemon_Review_App.Data;
using Pokemon_Review_App.Models;
using PokemonReviewApp.Interfaces;

namespace PokemonReviewApp.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;

        }
        public bool CategoriesExists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
          
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.OrderBy(c => c.Name).ToList();
        }

        public Category GetCategoryByID(int id)
        {
            return _context.Categories.Where(c => c.Id == id).FirstOrDefault();
        }

        public Category GetCategoryByName(string name)
        {
            return _context.Categories.Where(c => c.Name == name).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonsByCategory(int categoryId)
        {
            return _context.PokemonCategories.Where(c => c.CategoryId == categoryId).Select(e => e.Pokemon).ToList();
        }
    }
}
