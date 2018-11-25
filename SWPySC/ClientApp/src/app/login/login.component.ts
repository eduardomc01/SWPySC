import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css', './icons-downloads.component.css']
})

export class LoginComponent {

  user: string;
  pass: string;

  constructor(private http: HttpClient, private router: Router) {

    sessionStorage.clear();

  }


  VerifyUser() {

    var json = JSON.stringify({ User: this.user, Pass: this.pass });

    this.http.post('Login/Admin', JSON.parse(json)).subscribe(result => {

      if (result[0] == undefined) {

        alert("Contraseña o usuario inconrrecto, Ingrese de nuevo porfavor");

      }

      else if (result[0].idTipoUsuario == 1) {

        sessionStorage.setItem("idUser", result[0].id);
        this.router.navigate(["/home-sa"]);

      }

      else if (result[0].idTipoUsuario == 2) {

        sessionStorage.setItem("idUser", result[0].id);
        this.router.navigate(["/home"]);

      }

    });

  }


}
