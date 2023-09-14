import { Component, OnInit } from '@angular/core';
import { Pokemon } from 'src/app/interfaces/list';
import { PokemonService } from 'src/app/services/pokemon.service';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit {

  
   pokemons: Pokemon[] = [];
   isEditing = false;
  constructor(private pokemonService: PokemonService) { }

  ngOnInit(): void {

    let url = 'http://localhost:5039/Pokemons'
    let options = {};
    debugger
    //chama o método getPokemons do serviço listService, passando a url e options como argumentos.
    this.pokemonService.getPokemons(url, options).subscribe((data: any) => {
      debugger
      this.pokemons = data;
      debugger
    }, error => {
      let testerror = error;
      console.log(testerror)
    }
    );


    debugger
    // this.pokemonList = response
  }


  onEditClicked(pokemon: Pokemon) {
    pokemon.isEditing = true;
  }

  onSaveClicked(pokemon: Pokemon) {
    pokemon.isEditing = false;

    this.pokemonService.updatePokemon(pokemon.id, pokemon.name, pokemon.category).subscribe(
      (response: any) => {
        console.log('Atualização bem-sucedida:', response);
        // Atualização bem-sucedida, você pode tratar a resposta conforme necessário
      },
      (error) => {
        console.error('Erro ao atualizar:', error);
        // Tratamento de erro, se necessário
      }
    );
  }
}

