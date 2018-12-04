import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-historial-sa',
  templateUrl: './historial-sa.component.html',
  styleUrls: ['./historial-sa.component.css']
})
export class HistorialSaComponent {

  d: datas[]; 

  constructor(private http: HttpClient) {

    this.http.get<[]>("Administrators/GetAllChangeAdministrators").subscribe( result => {

      console.log(result);

      this.d = result;

    });

  }


}

interface datas {

}
