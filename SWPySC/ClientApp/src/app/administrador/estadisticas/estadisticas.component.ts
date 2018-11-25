import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-estadisticas',
  templateUrl: './estadisticas.component.html',
  styleUrls: ['./estadisticas.component.css']
})

export class EstadisticasComponent {

  // doughnut
  public doughnutChartLabels: string[] = ["Robo", "Robo unidad habitacional", "Peleas", "Asesinato", "Robos a mano armada", "Secuestro"];
  public doughnutChartType: string = 'doughnut';
  public doughnutChartData: number[] = [, , , , , ,];

  // Barra
  public barChartOptions: any = {
    scaleShowVerticalLines: false,
    responsive: true
  };
  public barChartLabels: string[] = ['Cantidad de delitos por mes'];
  public barChartType: string = 'bar';
  public barChartLegend: boolean = true;

  public barChartData: any[] = [
    { data: [], label: 'Ene'},
    { data: [], label: 'Feb'},
    { data: [], label: 'Mar'},
    { data: [], label: 'Abr'},
    { data: [], label: 'May'},
    { data: [], label: 'Jun'},
    { data: [], label: 'Jul'},
    { data: [], label: 'Ago'},
    { data: [], label: 'Sep'},
    { data: [], label: 'Oct'},
    { data: [], label: 'Nov'},
    { data: [], label: 'Dic'},
  ];

  constructor(private http: HttpClient, private router: Router) {



    if (sessionStorage.getItem("idUser") == null)
      this.router.navigate(["/Login"]);



    this.EstadisticasDona();
   //  this.EstadisticasBarra();

  }


  EstadisticasDona() {


    this.http.get("Delitos/GetEstadisticsCrimes").subscribe(result => {

      console.log(result);

      this.doughnutChartData = [result[1], result[2], result[3], result[4], result[5], result[6]];

    });

  }


   
  EstadisticasBarra() {

    let i;
    this.http.get("Delitos/GetEstadisticsMonth").subscribe(result => {

      console.log(result[0].enero);

      //let month: string[] = ["enero","febrero","marzo","abril","mayo","junio","julio","agosto","septiembre","octubre","noviembre","diciembre"]; 

      this.barChartData = [
        { data: [result[0].enero] },
        { data: [result[0].febrero] },
        { data: [result[0].marzo] },
        { data: [result[0].abril] },
        { data: [result[0].mayo] },
        { data: [result[0].junio] },
        { data: [result[0].julio] },
        { data: [result[0].agosto] },
        { data: [result[0].septiembre] },
        { data: [result[0].octubre] },
        { data: [result[0].noviembre] },
        { data: [result[0].diciembre] },
      ];
      

    });


  }

}
