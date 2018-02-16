import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseService } from './base.service';
import { Professor } from '../models/professor.model';
import "rxjs/Rx";

@Injectable()
export class ProfessorService extends BaseService {

    constructor(http: Http) {
        super(http, 'professor/');
    }

    public obterProfessores() {
        return this.http.get(this.apiControllerUrl + 'ObterTodos/', this.requestOptions)
            .map(res => res.json())
            .catch(this.handleError);
    }

    public obterProfessorPorId(idProfessor: number) {
        return this.http.get(this.apiControllerUrl + 'ObterProfessorPorId/' + idProfessor, this.requestOptions)
            .map(res => res.json())
            .catch(this.handleError);
    }

    public salvarProfessor(professor: Professor) {
        return this.http.post(this.apiControllerUrl + 'SalvarProfessor/', professor, this.requestOptions)
            .map(res => res.json())
            .catch(this.handleError);
    }

    public deletarProfessor(professor: Professor) {
        return this.http.post(this.apiControllerUrl + 'DeletarProfessor/', professor, this.requestOptions)
            .map(res => res.json())
            .catch(this.handleError);
    }
    
}