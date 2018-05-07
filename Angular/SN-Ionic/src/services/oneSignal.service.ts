import { Injectable } from '@angular/core';
import { Http, RequestOptions, Headers, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import "rxjs/Rx";

@Injectable()
export class OneSignalService {

    protected headers: Headers;
    protected requestOptions: RequestOptions;
    
    constructor(public http: Http) {
        this.headers = new Headers();
        this.headers.append('Accept', 'application/json');
        this.headers.append('Content-Type', 'application/json');
        this.requestOptions = new RequestOptions({ headers: this.headers, withCredentials: false});
    }

    public enviarNotificacao(notificacao: any): Observable<boolean>{
        return this.http.post('https://onesignal.com/api/v1/notifications/', notificacao, this.requestOptions)
        .map(res=> res.json());
    }

}