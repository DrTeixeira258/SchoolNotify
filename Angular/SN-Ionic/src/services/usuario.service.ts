import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from "rxjs/Observable";
import { BaseService } from './base.service';
import { Usuario } from '../models/usuario.model';
import "rxjs/Rx";

@Injectable()
export class UsuarioService extends BaseService {

    constructor(http: Http) {
        super(http, 'usuario/');
    }

    public logar(usuario: Usuario): Observable<Usuario> {
        return this.http.post(this.apiControllerUrl + 'Logar/', usuario, this.requestOptions)
            .map(res => res.json())
            .catch(this.handleError);
    }

    public cadastrar(usuario: Usuario): Observable<Usuario> {
        return this.http.post(this.apiControllerUrl + 'Cadastrar/', usuario, this.requestOptions)
            .map(res => res.json())
            .catch(this.handleError);
    }

}