import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-copa-de-filmes',
  templateUrl: './copa-de-filmes.component.html'
})
export class CopaDeFilmesComponent {
  public filmes: Filme[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Filme[]>(baseUrl + 'api/SampleData/ObterFilmes').subscribe(result => {
      this.filmes = result;
    }, error => console.error(error));
  }
}
