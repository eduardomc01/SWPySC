import { Component } from '@angular/core';


@Component({
  selector: 'app-nav-menu-ci',
  templateUrl: './nav-menu-ci.component.html',
  styleUrls: ['./nav-menu-ci.component.css','./icons-downloads.component.css']
})

  
export class NavMenuCiComponent {
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
