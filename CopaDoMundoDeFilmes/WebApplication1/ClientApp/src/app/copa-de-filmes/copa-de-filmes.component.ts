import { Component, Inject } from '@angular/core';
//import { HttpClient } from '@angular/common/http';
import { HttpClient, HttpHeaders } from '@angular/common/http';

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
  

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
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
      .post<boolean>(this.baseUrl + 'api/SampleData/GerarCampeonato', filmesSelecionados, httpOptions)
      .subscribe(res => {
        var v = res;
        console.log("ok.");
        //this.router.navigate(["quiz/edit", v.QuizId]);
      }, error => console.log(error));
  }

  obterSelecionados() {
    var filmesSelecionados = this._filmes.filter(f => {
      return f.selecionado;
    });
    return filmesSelecionados;
  }
}
