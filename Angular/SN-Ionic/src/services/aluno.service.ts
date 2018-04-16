import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseService } from './base.service';
import { Aluno } from '../models/aluno.model';
import { Observable } from 'rxjs/Rx';
import "rxjs/Rx";

@Injectable()
export class AlunoService extends BaseService {

    constructor(http: Http) {
        super(http, 'aluno/');
    }

    public ObterAlunosPorProfessor(idProfessor: number) : Observable<Aluno[]> {
        return this.http.get(this.apiControllerUrl + 'ObterAlunosPorProfessor/' + idProfessor, this.requestOptions)
            .map(res => res.json())
            .catch(this.handleError);
    }

}