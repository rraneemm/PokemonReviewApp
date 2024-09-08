using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pokemon_Review_App.Models;
using PokemonReviewApp.Dtos;
using PokemonReviewApp.Interfaces;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : Controller
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;

        public OwnerController(IOwnerRepository ownerRepository, ICountryRepository countryRepository, IMapper mapper, IPokemonRepository pokemonRepository)
        {
            _ownerRepository = ownerRepository;
            _pokemonRepository = pokemonRepository;
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpGet("{countryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        public IActionResult GetOwnersByCountryId(int countryId)
        {
            var owners = _mapper.Map<List<OwnerDto>>(_countryRepository.GetOwnersByCountryId(countryId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(owners);

        }

        [HttpGet("{pokemonId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        public IActionResult GetOwnersOfPokemon(int pokemonId)
        {
            var owners = _mapper.Map<List<OwnerDto>>(_pokemonRepository.GetOwnersOfPokemon(pokemonId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(owners);

        }
}
