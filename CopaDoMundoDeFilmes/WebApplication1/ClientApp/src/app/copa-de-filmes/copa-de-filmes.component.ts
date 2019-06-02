import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
//import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-copa-de-filmes',
  templateUrl: './copa-de-filmes.component.html'
})
//const httpOptions = {
//  headers: new HttpHeaders({
//    'Content-Type': 'application/json',
//    'Authorization': 'my-auth-token'
//  })
//};
export class CopaDeFilmesComponent {
  public _filmes: Filme[];
  public _quantidadeDeSelecionados = 0;
  

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Filme[]>(baseUrl + 'api/SampleData/ObterFilmes').subscribe(result => {
      this._filmes = result;
    }, error => console.error(error));
  }

  public contador(selecionado: boolean) {
    if (selecionado) {
      this._quantidadeDeSelecionados--;
    }
    else {
      this._quantidadeDeSelecionados++;
    }
  }

  //public gerarCampeonato() {
  //  var filmesSelecionados = this.obterSelecionados();
  //  this.http.post<Filme[]>(this._baseUrl + 'api/SampleData/GerarCampeonato', filmesSelecionados, httpOptions);
  //}

  obterSelecionados() {
    var filmesSelecionados = this._filmes.filter(f => {
      return f.selecionado;
    });
    return filmesSelecionados;
  }
}
