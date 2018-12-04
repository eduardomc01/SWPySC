import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css', './icons-downloads.component.css']
})
export class RegisterComponent {

  constructor(private http: HttpClient, private router: Router) {


    if (sessionStorage.getItem("idUser") == null)
      this.router.navigate(["/Login"]);


     
  }

  name: string;
  email: string;
  pass: string;

  idUser: string = sessionStorage.getItem("idUser");

  registerAdmin() {

    var json = JSON.stringify({ Nombre: this.name, Correo: this.email, Password: this.pass });

    this.http.post('Administrators/InsertAdmin', JSON.parse(json)).subscribe(result => {

      if (result == 1) {
        alert("Administrador agregado");

        this.registerActivity();

      }

      else {
        alert("Ops ocurrio algun error");
      }

    });

  } 

  registerActivity() {

    var json = JSON.stringify({ IdUsuario: this.idUser, IdAccion: 1 });

    this.http.post('SuperAdministrators/InsertModifications', JSON.parse(json)).subscribe(() => { });


  }



}
