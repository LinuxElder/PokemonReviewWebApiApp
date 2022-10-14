﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interface;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class Pokemon_Controller : Controller
    {
        private IPokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;

        public Pokemon_Controller(IPokemonRepository pokemonRepository, IMapper mapper)
        {
            this._pokemonRepository = pokemonRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type=typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons()
        {   
            var pokemons = _mapper.Map<List<PokemonDto>>(_pokemonRepository.GetPokemons());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            else
            {
                return Ok(pokemons);
            }
        }

        [HttpGet("{pokeId}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(400)]

        public IActionResult GetPokemon(int pokeId)
        {
            if (!_pokemonRepository.PokemonExists(pokeId))
            {
                return NotFound();
            }
            else 
            {
                Console.WriteLine("Null");
                var pokemon = _mapper.Map<PokemonDto>(_pokemonRepository.GetPokemon(pokeId));

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                else
                {
                    return Ok(pokemon);
                }
               
            }


        }

        [HttpGet("{pokeId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        
        public IActionResult GetPokemonRating(int pokeId)
        {
            if (!_pokemonRepository.PokemonExists(pokeId))
            {
                return NotFound();
            }
            else
            {
                var rating = _pokemonRepository.GetPokemonRating(pokeId);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                else
                {
                    return Ok(rating);
                }
            }
        }
    }
}