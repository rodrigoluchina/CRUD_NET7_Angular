import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListComponent } from './pages/list/list.component';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FormCadastroComponent } from './pages/form-cadastro/form-cadastro.component';
import { InputTextModule } from 'primeng/inputtext';
import { DeleteComponent } from './pages/delete/delete.component';
import { UpdateComponent } from './pages/update/update.component';


@NgModule({
  declarations: [
    AppComponent,
    FormCadastroComponent,
    ListComponent,
    DeleteComponent,
    UpdateComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,

    TableModule,
    ButtonModule,
    FormsModule,
    ReactiveFormsModule,
    InputTextModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
