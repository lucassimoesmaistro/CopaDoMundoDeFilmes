import { Component, Inject } from '@angular/core';
import { Router } from "@angular/router";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Filme } from '../interfaces/filme';
import { Resultado } from '../interfaces/resultado';

@Component({
  selector: 'app-copa-de-filmes',
  templateUrl: './copa-de-filmes.component.html'
})

//const httpOptions = {
//  headers: new HttpHeaders({
//    'Content-Type': 'application/json'
//  })
//};

export class CopaDeFilmesComponent {
  public _filmes: Filme[];
  public _quantidadeDeSelecionados = 0;
  

  constructor(private router: Router,
              private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
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

  public gerarCampeonato() {
    var filmesSelecionados = JSON.stringify( this.obterSelecionados());

    var httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };

    this.http
      .post<Resultado>(this.baseUrl + 'api/SampleData/GerarCampeonato', filmesSelecionados, httpOptions)
      .subscribe(response => {

        this.router.navigate(["resultado", response.campeao.titulo, response.viceCampeao.titulo]);
      }, error => console.log(error));
  }

  obterSelecionados() {
    var filmesSelecionados = this._filmes.filter(f => {
      return f.selecionado;
    });
    return filmesSelecionados;
  }
}
