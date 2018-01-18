import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from "rxjs/Observable";
import { BaseService } from './base.service';
import { Usuario } from '../models/usuario';
import "rxjs/Rx";

@Injectable()
export class LoginService extends BaseService {

    static usuarioPerfil : string;
    static usuario: Usuario = new Usuario();

    constructor(http: Http) {
        super(http, 'loginad/');
    }

    public logar(usuario: Usuario) {
        return this.http.post(this.apiControllerUrl + 'validar/', usuario, this.requestOptions)
            .map(res => res.json())
            .catch(this.handleError);
    }
    
}