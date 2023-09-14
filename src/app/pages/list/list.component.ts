import { Component, OnInit } from '@angular/core';
import { Pokemon } from 'src/app/interfaces/list';
import { PokemonService } from 'src/app/services/pokemon.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  pokemons: Pokemon[] = [];
  editMode = false;
  editedPokemon: Pokemon = { id: 0, name: '', category: '' }; // Objeto vazio por padrão

  constructor(private pokemonService: PokemonService) { }

  ngOnInit(): void {
    let url = 'http://localhost:5039/Pokemons'
    let options = {};
    debugger
    this.pokemonService.getPokemons(url, options).subscribe((data: any) => {
      debugger
      this.pokemons = data;
      console.log(this.pokemons);
      debugger
    }, error => {
      let testerror = error;
      console.log(testerror)
    }
    );
    debugger
  }


  deletePokemon(pokemon: Pokemon) {
    const idToDelete = pokemon.id;

    this.pokemonService.deletePokemon(idToDelete).subscribe(
      () => {
        const index = this.pokemons.indexOf(pokemon);
        if (index !== -1) {
          this.pokemons.splice(index, 1);
        }
      },
      (error) => {
        console.error('Erro ao excluir o Pokémon:', error);
      }
    );
  }

}




