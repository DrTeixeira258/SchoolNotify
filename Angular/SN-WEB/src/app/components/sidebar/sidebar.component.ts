import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

declare const $: any;
declare interface RouteInfo {
    path: string;
    title: string;
    icon: string;
    class: string;
    material: boolean;
    classOption: string;
}
export const ROUTES: RouteInfo[] = [
    { path: 'apps/dashboard', title: 'Dashboard',  icon: 'dashboard', class: '', material: true, classOption: '' },
    // { path: '../user-profile', title: 'User Profile',  icon:'person', class: '', material: true, classOption: '' },
    // { path: '../table-list', title: 'Table List',  icon:'content_paste', class: '', material: true, classOption: '' },
    // { path: '../typography', title: 'Typography',  icon:'library_books', class: '', material: true, classOption: '' },
    // { path: '../icons', title: 'Icons',  icon:'bubble_chart', class: '', material: true, classOption: '' },
    // { path: '../maps', title: 'Maps',  icon:'location_on', class: '', material: true, classOption: '' },
    // { path: '../notifications', title: 'Notifications',  icon:'notifications', class: '', material: true, classOption: '' },
    // { path: '../upgrade', title: 'Upgrade to PRO',  icon:'unarchive', class: 'active-pro', material: true, classOption: '' },
    { path: 'apps/professor', title: 'Professores',  icon:'', class: '', material: false, classOption: 'fa fa-group' },
    { path: 'apps/sala', title: 'Salas',  icon:'library_books', class: '', material: true, classOption: '' },
    { path: 'apps/responsavel', title: 'Responsáveis',  icon:'person', class: '', material: true, classOption: '' },
    { path: 'apps/aluno', title: 'Alunos',  icon:'person', class: '', material: true, classOption: '' },
];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  menuItems: any[];
  public nomeUsuario: string = "";
  

  constructor(private router: Router) { }

  ngOnInit() {
    this.nomeUsuario = localStorage.getItem("nomeUsuario");
    this.menuItems = ROUTES.filter(menuItem => menuItem);
  }
  
  isMobileMenu() {
      if ($(window).width() > 991) {
          return false;
      }
      return true;
  };

  goTo(rota) {
      this.router.navigateByUrl(rota);
  }
}
