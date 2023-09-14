using Microsoft.AspNetCore.Mvc;
using pokemonApi.AdoNet.Models;
using pokemonApi.AdoNet.Services;

namespace pokemonApi.AdoNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonsController : ControllerBase
    {
        private readonly ILogger<PokemonsController> _logger;

        private readonly PokemonService _pokemonService;

        public PokemonsController(ILogger<PokemonsController> logger, PokemonService pokemonService)
        {
            _logger = logger;
            _pokemonService = pokemonService;
        }

        [HttpGet]
        public IEnumerable<Pokemon> Get()
        {
            try
            {
                return _pokemonService.GetAllPokemons();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public Pokemon GetById(int id)
        {
            try
            {
                return _pokemonService.GetPokemonById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost]
        public Pokemon Post([FromBody]Pokemon pokemon)
        {
            try
            {
                _pokemonService.InsertPokemon(pokemon);
                return pokemon;
            }
            catch (Exception)
            {

                throw;
            }
        }

       [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Pokemon updatedPokemon)
        {
            try
            {
                updatedPokemon.Id = id; 
                _pokemonService.UpdatePokemon(updatedPokemon);
                return Ok(updatedPokemon);
            }
            catch (Exception)
            {
                return BadRequest(); 
            }
        }

         [HttpDelete("{id}")]
         public IActionResult Delete(int id)
         {
            try
            {
                _pokemonService.DeletePokemon(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


    }
}