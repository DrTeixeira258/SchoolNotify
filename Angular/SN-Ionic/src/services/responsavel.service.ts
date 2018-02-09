import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseService } from './base.service';
import { Responsavel } from '../models/responsavel.model';
import "rxjs/Rx";

@Injectable()
export class ResponsavelService extends BaseService {

    constructor(http: Http) {
        super(http, 'responsavel/');
    }

    public obterResponsaveis() {
        return this.http.get(this.apiControllerUrl + 'ObterTodos/', this.requestOptions)
            .map(res => res.json())
            .catch(this.handleError);
    }

    public obterResponsavelPorId(idResponsavel: number) {
        return this.http.get(this.apiControllerUrl + 'ObterResponsavelPorId/' + idResponsavel, this.requestOptions)
            .map(res => res.json())
            .catch(this.handleError);
    }

    public salvarResponsavel(responsavel: Responsavel) {
        return this.http.post(this.apiControllerUrl + 'SalvarResponsavel/', responsavel, this.requestOptions)
            .map(res => res.json())
            .catch(this.handleError);
    }

    public deletarResponsavel(responsavel: Responsavel) {
        return this.http.post(this.apiControllerUrl + 'DeletarResponsavel/', responsavel, this.requestOptions)
            .map(res => res.json())
            .catch(this.handleError);
    }
    
}