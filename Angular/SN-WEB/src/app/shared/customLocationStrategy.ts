import { Injectable } from '@angular/core';
import { HashLocationStrategy } from "@angular/common";
import { environment } from "environments/environment";

@Injectable()    
export class CustomLocationStrategy extends HashLocationStrategy {
    prepareExternalUrl(internal: string): string {
        const url = this.getBaseHref() + '/#' + internal;
        return environment.production ? url : '/#' + internal;
    }
}