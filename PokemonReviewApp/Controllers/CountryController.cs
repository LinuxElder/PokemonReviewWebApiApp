using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interface;
using PokemonReviewApp.Models;
using PokemonReviewApp.Repository;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

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
            var countries = _mapper.Map<List<CountryDto>>(_countryRepository.GetCountries());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            else
            {
                return Ok(countries);
            }
        }

        [HttpGet("{countryId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]

        public IActionResult GetCountry(int countryId)
        {

            if (!_countryRepository.CountryExists(countryId))
            {
                return NotFound();
            }
            else
            {
                var country = _mapper.Map<CountryDto>(_countryRepository.GetCountry(countryId));

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                else
                {
                    return Ok(country);
                }

            }

        }

        [HttpGet("/owners/{ownerId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult GetCountryByOwner(int ownerId)
        {
            var country = _mapper.Map<CountryDto>(_countryRepository.GetCountryByOwner(ownerId));


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            else
            {
                return Ok(country);
            }
        }



        [HttpGet("{ownerId}/countryId")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        [ProducesResponseType(400)]
        public IActionResult GetOwnersFromACountry(int countryId)
        {
            var owners = _mapper.Map<List<OwnerDto>>(_countryRepository.GetOwnersFromACountry(countryId));


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            else
            {
                return Ok(owners);
            }
        }

        




    }
}
