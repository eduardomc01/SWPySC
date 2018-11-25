import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home-sa',
  templateUrl: './home-sa.component.html',
  styleUrls: ['./home-sa.component.css']
})
export class HomeSaComponent {

  constructor(private router: Router) {


    if (sessionStorage.getItem("idUser") == null)
      this.router.navigate(["/Login"]);


  }


}
