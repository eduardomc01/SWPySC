import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-home-sa',
  templateUrl: './home-sa.component.html',
  styleUrls: ['./home-sa.component.css']
})
export class HomeSaComponent {

  name: string;
  user: string;
  date: string;
  type_user: string;

  idUser: string = sessionStorage.getItem("idUser");


  constructor(private http: HttpClient, private router: Router) {

    if (sessionStorage.getItem("idUser") == null)
      this.router.navigate(["/Login"]);

    this.http.get("SuperAdministrators/GetSuperAdministratorDatasHome?id=" + this.idUser).subscribe(result => {

      this.name = result[0].nombre;
      this.user = result[0].correo;
      this.date = result[0].date;
      this.type_user = result[0].tipoUsuario;


    });


  }



}
