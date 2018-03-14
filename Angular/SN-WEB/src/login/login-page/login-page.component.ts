import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Usuario } from 'models/usuario.model';
import { UsuarioService } from 'services/usuario.service';
import { BaseComponent } from 'app/base/base.component';

@Component({
  selector: 'login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss'],
  providers: [UsuarioService]
})
export class LoginPageComponent extends BaseComponent implements OnInit {

  activeLoader: boolean = false;
  usuario: Usuario = new Usuario();

  constructor(private router: Router, private usuarioService: UsuarioService) {
    super();
 }

  ngOnInit() {
  }

  logar() {
    this.activeLoader = true;
    this.usuarioService.logar(this.usuario).subscribe(
      data => {
        if(data)
          this.router.navigate(['/apps/dashboard']);
        else
          this.showCustomNotification("warning","Login e/ou Senha incorreto(s).")
        this.activeLoader = false;
      },
      error => {
        this.showNotification("top","right",false);
        this.activeLoader = false;
      }
    );
  }

  validar() {
    if (this.usuario.login && this.usuario.senha)
      return false;
    return true;
  }
}
