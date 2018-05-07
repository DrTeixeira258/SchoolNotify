import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BaseService } from './base.service';
import { Observable } from 'rxjs/Rx';
import "rxjs/Rx";
import { Notificacao } from '../models/notificacao.model';

@Injectable()
export class NotificacaoService extends BaseService {

    constructor(http: Http) {
        super(http, 'notificacao/');
    }

    public SalvarNotificacao(notificacao: Notificacao): Observable<number> {
        return this.http.post(this.apiControllerUrl + 'SalvarNotificacao', notificacao, this.requestOptions)
            .map(res => res.json())
            .catch(this.handleError);
    }

    public BuscarNotificacoesResponsavel(idResponsavel): Observable<Notificacao[]> {
        return this.http.get(this.apiControllerUrl + 'BuscarNotificacoesResponsavel/' + idResponsavel, this.requestOptions)
            .map(res => res.json())
            .catch(this.handleError);
    }

    public BuscarNotificacaoPorId(idNotificacao): Observable<Notificacao> {
        return this.http.get(this.apiControllerUrl + 'ObterNotificacaoPorId/' + idNotificacao, this.requestOptions)
            .map(res => res.json())
            .catch(this.handleError);
    }

}