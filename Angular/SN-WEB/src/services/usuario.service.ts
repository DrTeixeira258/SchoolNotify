import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from "rxjs/Observable";
import { BaseService } from './base.service';
import { Usuario } from 'models/usuario.model';
import "rxjs/Rx";

@Injectable()
export class UsuarioService extends BaseService {

    constructor(http: Http) {
        super(http, 'usuario/');
    }

    public logar(usuario: Usuario) {
        return this.http.post(this.apiControllerUrl + 'logar/', usuario, this.requestOptions)
            .map(res => res.json())
            .catch(this.handleError);
    }
    
}