using pokemonApi.AdoNet.Models;
using pokemonApi.AdoNet.Repositores;
using System;
using System.Collections.Generic;

namespace pokemonApi.AdoNet.Services
{
    public class PokemonService
    {
        private readonly PokemonRepository _repository;

        public PokemonService(PokemonRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Pokemon> GetAllPokemons()
        {
            try
            {
                return _repository.Select();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public void InsertPokemon(Pokemon pokemon)
        {
            try
            {
                _repository.Insert(pokemon);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
         public Pokemon GetPokemonById(int id)
        {
            try
            {
                return _repository.SelectById(id);
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }
         public void UpdatePokemon(Pokemon pokemon)
        {
            try
            {
                _repository.Update(pokemon);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
         public void DeletePokemon(int id)
        {
            try
            {
                _repository.Delete(id);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        
    }
}
