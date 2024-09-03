using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Pokemon_Review_App.Models;
using PokemonReviewApp.Dtos;
using PokemonReviewApp.Interfaces;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            
        }

        // get categories by id
        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetCategoryById(int categoryId)
        {
            if (!_categoryRepository.CategoriesExists(categoryId))
                return NotFound();

            var pokemon = _mapper.Map<CategoryDto>(_categoryRepository.GetCategoryByID(categoryId));

            return Ok(pokemon)
;        }
        // get categories by name
         //TODO: need to fetch the id of that name -->> inside the repo not here!!!
//        [HttpGet("{name}")]  
//        [ProducesResponseType(200, Type = typeof(Category))]
//        [ProducesResponseType(400)]
//        public IActionResult GetCategoryByName(string name)
//        {
//            var category = _categoryRepository.GetCategoryByName(name)
//            //if (!_categoryRepository.CategoriesExists(categoryId))
//            //    return NotFound();

//            var pokemon = _mapper.Map<CategoryDto>(_categoryRepository.GetCategoryByID(categoryId));

//            return Ok(pokemon)
//;
//        }
        // get all categories
        [HttpGet]
        [ProducesResponseType(200, Type= typeof(IEnumerable<Category>))]
        public IActionResult GetCategories()
        {
            var categories = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(categories);
        }

    }
}
