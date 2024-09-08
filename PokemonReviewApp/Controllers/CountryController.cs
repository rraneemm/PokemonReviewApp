using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pokemon_Review_App.Data;
using Pokemon_Review_App.Models;
using PokemonReviewApp.Dtos;
using PokemonReviewApp.Interfaces;

namespace PokemonReviewApp.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryController(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        public IActionResult GetCountries()
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var countries = _mapper.Map<List<CountryDto>>(_countryRepository.GetCountries());

            return Ok(countries);
        }

        [HttpGet("{countryId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        public IActionResult GetCountryById(int countryId)
        {
            if (!_countryRepository.CountryExists(countryId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var country = _mapper.Map<CountryDto>(_countryRepository.GetCountryById(countryId));

            return Ok(country);
        }

        [HttpGet("{countryName}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        public IActionResult GetCountryByName(string countryName)
        {
            //if (!_countryRepository.CountryExists(countryId))
            //    return NotFound();

            var country = _mapper.Map<CountryDto>(_countryRepository.GetCountryByName(countryName));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(country);

        }

        /*
        [HttpGet("{ownerId}")]
        [ProducesReponseType(200, Type = typeof(Owner))]
        public IActionResult GetCountryOfOwner(int ownerId)
        {
            
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var country = _mapper.Map<OwnerDto>(_ownerRepository.GetCountryOfOwner(ownerId));
            return Ok(country);
        }
         */

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCountry([FromBody] CountryDto createdCountry)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var country = _countryRepository.GetCountries()
                .Where(c => c.Name.Trim().ToUpper() == createdCountry.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (country != null)
            {
                ModelState.AddModelError("", "Country Already Exists");
                return StatusCode(442, ModelState);
            }

            if (createdCountry == null)
                return BadRequest(ModelState);

            var countryMap = _mapper.Map<Country>(createdCountry);

            if (!_countryRepository.CreateCountry(countryMap))
            {
                ModelState.AddModelError("", "Something went wrong adding country.");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully added country");

        }

        [HttpPut("{countryId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult UpdateCountry(int countryId, [FromBody] CountryDto updatedCountry)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (updatedCountry == null)
                return BadRequest(ModelState);

            if (countryId != updatedCountry.Id)
                return BadRequest(ModelState);

            if (!_countryRepository.CountryExists(countryId))
                return NotFound();

            var countryMap = _mapper.Map<Country>(updatedCountry);

            if(!_countryRepository.UpdateCountry(countryMap))
            {
                ModelState.AddModelError("", "Something went wrong updating data");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{countryId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult DeleteCountry(int countryId)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!_countryRepository.CountryExists(countryId))
                return NotFound();

            var country = _countryRepository.GetCountryById(countryId);

            if (!_countryRepository.DeleteCountry(country))
            {
                ModelState.AddModelError("", "Something went wrong deleting country");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }


    }
}
