import { Component } from '@angular/core';
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: 'resultado',
  templateUrl: './resultado.component.html'
}) 

export class ResultadoComponent {
  campeao: string;
  viceCampeao: string;

  constructor(private activatedRoute: ActivatedRoute) {

    this.campeao = this.activatedRoute.snapshot.params["campeao"];
    this.viceCampeao = this.activatedRoute.snapshot.params["vice"];
  }  

}
