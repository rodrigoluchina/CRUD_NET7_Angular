import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';

import { PokemonService } from 'src/app/services/pokemon.service';

@Component({
  selector: 'app-form-cadastro',
  templateUrl: './form-cadastro.component.html',
  styleUrls: ['./form-cadastro.component.css']
})
export class FormCadastroComponent {
  pokemonForm = this.fb.group({
    name: [''],
    category: ['']
  })
  constructor(private fb: FormBuilder, private http: HttpClient, private pokemonService: PokemonService){}

  addPokemon() {
    const formData = this.pokemonForm.value; 
    const newPokemon = {
      name: formData.name,
      category: formData.category
    };
  
    
    this.pokemonService.createPokemon(newPokemon).subscribe(
      (response) => {
        console.log('Novo Pokémon:', response);
        this.pokemonForm.reset();
      },
      (error) => {
        console.error('Erro ao cadastrar o Pokémon:', error);
      }
    );
  }
}
