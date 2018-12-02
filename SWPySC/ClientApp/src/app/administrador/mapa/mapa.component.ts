import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MouseEvent } from '@agm/core';
import { MapsEventListener } from '@agm/core/services/google-maps-types';
import { Router } from '@angular/router';


@Component({
  selector: 'app-mapa',
  templateUrl: './mapa.component.html',
  styleUrls: ['./mapa.component.css']
})


export class MapaComponent {


  d: datas[];


  constructor(private http: HttpClient, private router: Router) {


    if (sessionStorage.getItem("idUser") == null)
      this.router.navigate(["/Login"]);



    this.http.get<datas[]>("Delitos/GetDatasDelitos").subscribe(result => {

      console.log(result); //<--- verificando los resultados que retorna en forma de lista 
      this.d = result;

    });

  }



}




interface datas {

  latitud: number;
  longitud: number;

}


