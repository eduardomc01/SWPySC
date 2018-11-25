import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MouseEvent } from '@agm/core';
import { MapsEventListener } from '@agm/core/services/google-maps-types';


@Component({
  selector: 'app-mapa-ci',
  templateUrl: './mapa-ci.component.html',
  styleUrls: ['./mapa-ci.component.css']
})


export class MapaCiComponent {

  title: string = 'Mapa';
  title_table: string = 'Tabla de resultados';
  d: datas[];


  constructor(private http: HttpClient) {

    this.http.get<datas[]>("Delitos/GetDatasDelitos").subscribe(result => {

      // console.log(result); //<--- verificando los resultados que retorna en forma de lista 
      this.d = result;

    });

  }



}




interface datas {

  latitud: number;
  longitud: number;

}


