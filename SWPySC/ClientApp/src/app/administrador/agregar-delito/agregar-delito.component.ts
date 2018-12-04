import { Component } from '@angular/core';
import { MouseEvent } from '@agm/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';


@Component({
  selector: 'app-agregar-delito',
  templateUrl: './agregar-delito.component.html',
  styleUrls: ['./agregar-delito.component.css','./icons-downloads.component.css']
})


export class AgregarDelitoComponent{

  idUser: string = sessionStorage.getItem("idUser");

  lat: number;
  long: number;
  direccion: string;
  cp: string;
  grado_delito: number;
  tipo_delito: number;
  date: Date;

  d: datas[] = []; //inicializar el arreglo, sino no se podia agregar marker nuevo.
  x: datasCodes[];
  y: datasCodes[];

  constructor(private http: HttpClient, private router: Router) {


    if (sessionStorage.getItem("idUser") == null)
      this.router.navigate(["/Login"]);


    this.CrimeGrade();

  }


  RegisterCrime() {

    if (!this.lat || !this.long || !this.direccion || !this.cp || !this.grado_delito || !this.tipo_delito || !this.date) {
      alert("OJO: Campos sin rellenar, porfavor complete todos los campos porfavor");
      return ;
    }

    var json = JSON.stringify({ Latitud: this.lat, Longitud: this.long, Direccion: this.direccion, Cp: this.cp, IdGd: this.grado_delito, IdCodigo: this.tipo_delito, fecha: this.date });

    this.http.post("Delitos/InsertDatasCrimes", JSON.parse(json)).subscribe(result => {

      if (result == 1) {
        alert("Datos guardados con exito !");

        this.registerActivityInsert();

      }

    });


  }


  CrimeGrade() {

    this.http.get<datasCodes[]>("Delitos/GetGradeCrimes").subscribe(result => {

      this.y = result;

    });


  }
   

  CrimeCodes() {

    this.http.get<datasCodes[]>("Delitos/GetCodesCrimes").subscribe(result => {

      this.x = result;

    });


  }


  MapClicked($event: MouseEvent) { //colocando las cordenadas en los campos de texto

    this.lat = $event.coords.lat;
    this.long = $event.coords.lng;

    this.d.push({

      latitud: $event.coords.lat,
      longitud: $event.coords.lng

    });

  }


  MarkerDelete() {

    this.d.pop();

  }




  registerActivityInsert() {

    var json = JSON.stringify({ IdUsuario: this.idUser, IdAccion: 1 });

    this.http.post('SuperAdministrators/InsertModifications', JSON.parse(json)).subscribe(() => { });


  }



}


interface datas {

  latitud: number;
  longitud: number;

}


interface datasCodes {
  id: number;
  tipo: string;
  comentario: string;
}
