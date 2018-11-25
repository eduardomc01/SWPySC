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

  title: string = "Mapa";
  subtitle: string = "Agregar información del delito";

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



  registerCrime() {

    var json = JSON.stringify({ Latitud: this.lat, Longitud: this.long, Direccion: this.direccion, Cp: this.cp, IdGd: this.grado_delito, IdCodigo: this.tipo_delito, fecha: this.date });

    this.http.post("Delitos/InsertDatasDelitos", JSON.parse(json)).subscribe(result => {

      if (result == 1)
        alert("Datos guardados con exito !"); //<-- aun falta validar esto


    });


  }


  CrimeGrade() {

    this.http.get<datasCodes[]>("Delitos/GetGradeDelitos").subscribe(result => {

      this.y = result;

    });


  }
   

  CrimeCodes() {

    this.http.get<datasCodes[]>("Delitos/GetCodigosDelitos").subscribe(result => {

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


  MarkerDelet() {

    this.d.pop();

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
