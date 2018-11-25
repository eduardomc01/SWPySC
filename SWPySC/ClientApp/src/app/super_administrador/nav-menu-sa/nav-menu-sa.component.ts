import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-menu-sa',
  templateUrl: './nav-menu-sa.component.html',
  styleUrls: ['./nav-menu-sa.component.css','./icons-downloads.component.css']
})
export class NavMenuSaComponent {

  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
