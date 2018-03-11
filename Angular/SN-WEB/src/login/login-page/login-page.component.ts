import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Usuario } from 'models/usuario.model';

@Component({
  selector: 'login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {

  activeLoader: boolean = false;
  usuario: Usuario = new Usuario();

  constructor(private router: Router) { }

  ngOnInit() {
  }

  teste() {
    this.activeLoader = true;
    this.router.navigate(['/apps/dashboard']);
    // this.activeLoader = false;
  }

  validar() {
    if (this.usuario.login && this.usuario.senha)
      return false;
    return true;
  }
}
