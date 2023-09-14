import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FormCadastroComponent } from './pages/form-cadastro/form-cadastro.component';
import { ListComponent } from './pages/list/list.component';
import { DeleteComponent } from './pages/delete/delete.component';
import { UpdateComponent } from './pages/update/update.component';

const routes: Routes = [
  {path: '', component: ListComponent},
  {path: 'postPokemon', component: FormCadastroComponent},
  {path: 'deletePokemon', component: DeleteComponent},
  {path: 'updatePokemon', component: UpdateComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
