import { ActivatedRouteSnapshot, RouterStateSnapshot, CanActivate, Router, ActivatedRoute } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import 'rxjs/add/observable/of';
import { UsuarioService } from 'services/usuario.service';
import { Usuario } from 'models/usuario.model';

@Injectable()
export class LoginGuard implements CanActivate {

    constructor(private usuarioService: UsuarioService, private router: Router, private route: ActivatedRoute) {
    }

    canActivate(route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot) {
        let usuario: Usuario = new Usuario();
        usuario.login = atob(localStorage.getItem("nu"));
        usuario.senha = atob(localStorage.getItem("su"));
        return this.usuarioService.logar(usuario).map(
            data => {
                if (data) {
                    return true;
                }
                this.router.navigate(['/']);
                return false;
            },
        );
    }
}