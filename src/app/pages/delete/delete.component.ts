import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms'; 
import { PokemonService } from 'src/app/services/pokemon.service';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.css']
})
export class DeleteComponent {
  pokemonForm: FormGroup; 
  pokemonId: number; 

  constructor(private fb: FormBuilder, private pokemonService: PokemonService) {
    this.pokemonId = -1;
    this.pokemonForm = this.fb.group({
      id: ['', [Validators.required, Validators.min(1)]]
    });
  }

  
  deletePokemon() {
    if (this.pokemonForm.valid) {
      this.pokemonId = this.pokemonForm.value.id; 
      this.pokemonService.deletePokemon(this.pokemonId).subscribe(
        () => {
          
          console.log(`Pokémon com ID ${this.pokemonId} excluído com sucesso.`);
       
          this.pokemonForm.reset();
        },
        (error) => {
          console.error('Erro ao excluir o Pokémon:', error);
        }
      );
    } else {
      console.error('Por favor, forneça um ID de Pokémon válido.');
    }
  }
}
