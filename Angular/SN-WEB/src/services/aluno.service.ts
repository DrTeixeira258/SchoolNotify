import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseService } from './base.service';
import { Aluno } from '../models/aluno.model';
import { Observable } from 'rxjs/Observable';
import "rxjs/Rx";

@Injectable()
export class AlunoService extends BaseService {

    constructor(http: Http) {
        super(http, 'aluno/');
    }

    public obterAlunos() : Observable<Aluno[]> {
        return this.http.get(this.apiControllerUrl + 'ObterTodos/', this.requestOptions)
            .map(res => res.json())
            .catch(this.handleError);
    }

    public obterAlunoPorId(idAluno: number) : Observable<Aluno> {
        return this.http.get(this.apiControllerUrl + 'ObterAlunoPorId/' + idAluno, this.requestOptions)
            .map(res => res.json())
            .catch(this.handleError);
    }

    public salvarAluno(aluno: Aluno) : Observable<boolean> {
        return this.http.post(this.apiControllerUrl + 'SalvarAluno/', aluno, this.requestOptions)
            .map(res => res.json())
            .catch(this.handleError);
    }

    public deletarAluno(aluno: Aluno) : Observable<boolean> {
        return this.http.post(this.apiControllerUrl + 'DeletarAluno/', aluno, this.requestOptions)
            .map(res => res.json())
            .catch(this.handleError);
    }
    
}