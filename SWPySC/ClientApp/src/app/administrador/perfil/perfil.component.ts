import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-perfil-component',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.css', './icons-downloads.component.css']
})

export class PerfilComponent {

  d: datas[];

  idUser: string = sessionStorage.getItem("idUser");
  name: string;
  email: string;
  pass: string;


  constructor(private http: HttpClient, private router: Router) {

    if (sessionStorage.getItem("idUser") == null)
      this.router.navigate(["/Login"]);


    this.http.get<datas[]>('Administrators/GetAdministrator?id='+this.idUser).subscribe(result => {

      this.d = result;
      this.name = result[0].nombre;
      this.email = result[0].correo;
      this.pass = result[0].password;

    });

  }


  profileAdmin() {

    let json = JSON.stringify({ Nombre: this.name, Correo: this.email, Password: this.pass });

    this.http.post('Administrators/UpdateAdministrator?id='+this.idUser, JSON.parse(json)).subscribe(result => {

      if (result == 1) {

        alert("Registro Actualizado!");
        this.router.navigate(["/perfil"]);

      } else {

        alert("Error al guardar los datos");

      }

    });



  }



}


interface datas {

  
  nombre: string;
  correo: string;
  password: string;
  

}
