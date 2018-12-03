import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-estadisticas-ci',
  templateUrl: './estadisticas-ci.component.html',
  styleUrls: ['./estadisticas-ci.component.css']
})

export class EstadisticasCiComponent {

  // doughnut
  public doughnutChartLabels: string[] = ["Delitos de grado 1", "Delitos de grado 2", "Delitos de grado 3"];
  public doughnutChartType: string = 'doughnut';
  public doughnutChartData: number[] = [, , , ,];

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
    { data: [], label: 'Dic' },

  ];

  constructor(private http: HttpClient) {

    this.EstadisticasDona();

  }


  EstadisticasDona() {


    this.http.get("Delitos/GetEstadisticsCrimes?op="+1).subscribe(result => {


      this.doughnutChartData = [result[1], result[2], result[3]];

    });

  }


   
  EstadisticasBarra() {

    let i;
    this.http.get("Delitos/GetEstadisticsMonth").subscribe(result => {

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
