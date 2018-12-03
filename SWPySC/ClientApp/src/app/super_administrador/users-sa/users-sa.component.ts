import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router} from '@angular/router';

@Component({
  selector: 'app-users-sa',
  templateUrl: './users-sa.component.html',
  styleUrls: ['./users-sa.component.css']
})

export class UsersSaComponent {

  d:datas[];

  idUser: string = sessionStorage.getItem("idUser");

  constructor(private http: HttpClient, private router: Router) {

    if (sessionStorage.getItem("idUser") == null)
      this.router.navigate(["/Login"]);

    this.http.get<datas[]>("SuperAdministrators/GetAllSuperAdministrator").subscribe(result => {

      this.d = result; 

    });

  }


  UpAdmin(idAdmin: number) {

    let op = confirm("Estas seguro dar de ALTA de este Administrador ");

    if (op == true) {


      this.http.post("SuperAdministrators/EstatusSuperAdministrator?op=" + 1, idAdmin).subscribe(result => {

        if (result == 1)
          alert("Administrador en ALTA");
          
      });

    }

  }


  DownAdmin(idAdmin: number) {

    let op = confirm("Estas seguro dar de BAJA de este Administrador ");

    if (op == true) {


      this.http.post("SuperAdministrators/EstatusSuperAdministrator?op="+2, idAdmin).subscribe(result => {

        if (result == 1)
          alert("Administrador en BAJA");

      });

    }


  }


  DeletAdmin(idAdmin: number) {

    let op = confirm("Estas seguro de ELIMINAR de este Administrador ");

    if (op == true) {

      
      this.http.post("SuperAdministrators/EstatusSuperAdministrator?op="+3, idAdmin).subscribe( result => {

        if (result == 1)
          alert("Administrador BORRADO");

      });

    }


  }


}

interface datas {

}

