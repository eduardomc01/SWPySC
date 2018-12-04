
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AgmCoreModule } from '@agm/core'; // <-- mapa de google
import { ChartsModule } from 'ng2-charts'; // <-- graficas

import { AppComponent } from './app.component';
import { NavMenuComponent } from './administrador/nav-menu/nav-menu.component';
import { HomeComponent } from './administrador/home/home.component';
import { PerfilComponent } from './administrador/perfil/perfil.component';
import { MapaComponent } from './administrador/mapa/mapa.component';
import { LoginComponent } from './login/login.component';

import { HomeSaComponent } from './super_administrador/home-sa/home-sa.component';
import { NavMenuSaComponent } from './super_administrador/nav-menu-sa/nav-menu-sa.component';
import { PerfilSaComponent } from './super_administrador/perfil-sa/perfil-sa.component';

import { RegisterComponent } from './super_administrador/register/register.component';
import { AgregarDelitoComponent } from './administrador/agregar-delito/agregar-delito.component';
import { EstadisticasComponent } from './administrador/estadisticas/estadisticas.component';
import { UsersSaComponent } from './super_administrador/users-sa/users-sa.component';

import { HomeCiComponent } from './ciudadano/home-ci/home-ci.component';
import { NavMenuCiComponent } from './ciudadano/nav-menu-ci/nav-menu-ci.component';
import { MapaCiComponent } from './ciudadano/mapa-ci/mapa-ci.component';
import { EstadisticasCiComponent } from './ciudadano/estadisticas-ci/estadisticas-ci.component';

import { HistorialSaComponent } from './super_administrador/historial-sa/historial-sa.component';




@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    PerfilComponent,
    MapaComponent,
    LoginComponent,
    HomeSaComponent,
    NavMenuSaComponent,
    RegisterComponent,
    AgregarDelitoComponent,
    EstadisticasComponent,

    HomeCiComponent,
    NavMenuCiComponent,
    MapaCiComponent,
    EstadisticasCiComponent,

    PerfilSaComponent,

    UsersSaComponent,

    HistorialSaComponent,



  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ChartsModule,
    FormsModule,
    RouterModule.forRoot([
      { path: 'Login', component: LoginComponent }, //<--- aqui agregue esto / para ver si arreglaba lo de inicio
      { path: 'home', component: HomeComponent },
      { path: 'perfil', component: PerfilComponent },
      { path: 'mapa', component: MapaComponent },
      { path: 'agregar-delito', component: AgregarDelitoComponent },
      { path: 'home-sa', component: HomeSaComponent },
      { path: 'perfil-sa', component: PerfilSaComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'estadisticas', component: EstadisticasComponent },
      { path: 'mapa-ci', component: MapaCiComponent },
      { path: 'estadisticas-ci', component: EstadisticasCiComponent },
      { path: 'users-sa', component: UsersSaComponent },
      { path: 'historial-sa', component: HistorialSaComponent },
      { path: '', component: HomeCiComponent },
  

    ]),
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyAgg-Q430e4mgB0bTGe4yxUKq6VAzxmujg' + '&libraries=visualization'
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule {


}
