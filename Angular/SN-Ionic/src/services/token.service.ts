import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from "rxjs/Observable";
import { BaseService } from './base.service';
import "rxjs/Rx";
import { Token } from '../models/token.model';

@Injectable()
export class TokenService extends BaseService {

    constructor(http: Http) {
        super(http, 'token/');
    }

    public BuscarTokensPorTelefones(telefones: number[]): Observable<string[]> {
        return this.http.post(this.apiControllerUrl + 'BuscarTokensPorTelefones/', telefones, this.requestOptions)
            .map(res => res.json())
            .catch(this.handleError);
    }

    public SalvarToken(token: Token): Observable<boolean> {
        return this.http.post(this.apiControllerUrl + 'SalvarToken/', token, this.requestOptions)
            .map(res => res.json())
            .catch(this.handleError);
    }

}