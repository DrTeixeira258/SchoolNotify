import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseService } from './base.service';
import "rxjs/Rx";
import { Sala } from '../models/sala.model';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class SalaService extends BaseService {

    constructor(http: Http) {
        super(http, 'sala/');
    }

    public obterSalas() : Observable<Sala[]> {
        return this.http.get(this.apiControllerUrl + 'ObterTodas/', this.requestOptions)
            .map(res => res.json())
            .catch(this.handleError);
    }

    public obterSalaPorId(idSala: number) : Observable<Sala> {
        return this.http.get(this.apiControllerUrl + 'ObterSalaPorId/' + idSala, this.requestOptions)
            .map(res => res.json())
            .catch(this.handleError);
    }

    public salvarSala(sala: Sala) : Observable<boolean> {
        return this.http.post(this.apiControllerUrl + 'SalvarSala/', sala, this.requestOptions)
            .map(res => res.json())
            .catch(this.handleError);
    }

    public deletarSala(sala: Sala) : Observable<boolean> {
        return this.http.post(this.apiControllerUrl + 'DeletarSala/', sala, this.requestOptions)
            .map(res => res.json())
            .catch(this.handleError);
    }
    
}