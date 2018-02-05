import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import { environment } from "../environments/environment";

@Injectable()
export abstract class BaseService {

    protected headers: Headers;
    protected requestOptions: RequestOptions;

    protected apiControllerUrl: string;

    constructor(protected http: Http, rota: string) {
        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json');
        this.requestOptions = new RequestOptions({ headers: this.headers, withCredentials: true });

        this.apiControllerUrl = environment.urlSisCEAPI + rota;
    }

    public handleError(error: any) {
        return Promise.reject(error);
    }

}