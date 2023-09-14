import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Pokemon } from '../interfaces/list';



@Injectable({
  providedIn: 'root'
})

export class PokemonService {
  constructor(
    private http: HttpClient,
   ) { }

  private baseUrl = 'http://localhost:5039/Pokemons';
  public getPokemons(url: string, options?: any) { 
    return this.http.get(url, options); 
  } 

  public deletePokemon(id: number) {
    const url = `http://localhost:5039/Pokemons/${id}`;    
    return this.http.delete(url);
  }

  public createPokemon(newPokemon: any) {
    return this.http.post('http://localhost:5039/Pokemons', newPokemon);
  }

  public updatePokemon(id: number,name:string,category:string){
    let pokemonBody = {id:id,name:name,category:category};

    const url = `${this.baseUrl}/${pokemonBody.id}`;
    return this.http.put<Pokemon>(url, pokemonBody);
  }
}
