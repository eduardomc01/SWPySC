import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { observable } from 'rxjs';


@Component({
  selector: 'app-mapa',
  templateUrl: './mapa.component.html',
  styleUrls: ['./mapa.component.css']
})


export class MapaComponent {

  idUser: string = sessionStorage.getItem("idUser");

  cantidad: number;
  d: datas[];


  constructor(private http: HttpClient, private router: Router) {

    if (sessionStorage.getItem("idUser") == null)
      this.router.navigate(["/Login"]);

  }


  SearchCrimes() {

    this.http.get<datas[]>("Delitos/GetSomeDatasCrimes?cantidad=" + this.cantidad).subscribe(result => {

      console.log(result);

      this.d = result;

    });

  }


  DeleteCrime(idCrime: number) {

    console.log(idCrime);

    this.http.post("Delitos/DeleteCrimes", idCrime).subscribe(result => {

      if (result == 1) {
        alert("Delito ELIMINADO ");

        this.registerActivityDelete();

      }

    });

  }




  registerActivityDelete() {

    var json = JSON.stringify({ IdUsuario: this.idUser, IdAccion: 3 });

    this.http.post('SuperAdministrators/InsertModifications', JSON.parse(json)).subscribe(() => { });


  }



}




interface datas {

  /*latitud: number;
  longitud: number;
  */

}


