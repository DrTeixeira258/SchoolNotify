import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseService } from './base.service';
import "rxjs/Rx";
import { Sala } from '../models/sala';

@Injectable()
export class SalaService extends BaseService {

    constructor(http: Http) {
        super(http, 'sala/');
    }

    public obterSalas() {
        return this.http.get(this.apiControllerUrl + 'ObterTodas/', this.requestOptions)
            .map(res => res.json())
            .catch(this.handleError);
    }

    public obterSalaPorId(idSala: number) {
        return this.http.get(this.apiControllerUrl + 'ObterSalaPorId/' + idSala, this.requestOptions)
            .map(res => res.json())
            .catch(this.handleError);
    }

    public salvarSala(sala: Sala) {
        return this.http.post(this.apiControllerUrl + 'SalvarSala/', sala, this.requestOptions)
            .map(res => res.json())
            .catch(this.handleError);
    }

    public deletarSala(sala: Sala) {
        return this.http.post(this.apiControllerUrl + 'DeletarSala/', sala, this.requestOptions)
            .map(res => res.json())
            .catch(this.handleError);
    }
    
}