import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-mapa-ci',
  templateUrl: './mapa-ci.component.html',
  styleUrls: ['./mapa-ci.component.css']
})


export class MapaCiComponent {

  d: datas[];

  constructor(private http: HttpClient) {

    this.http.get<datas[]>("Delitos/GetDatasCrimes").subscribe(result => {

      this.d = result;

    });

  }



}


interface datas {

  /*
  latitud: number;
  longitud: number;
  */

}


