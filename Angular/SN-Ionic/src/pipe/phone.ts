import { PipeTransform, Pipe } from "@angular/core";

@Pipe({ name: 'phone' })
export class TelefonePipe implements PipeTransform {
    transform(value: any, ...args: any[]) {
        if (value) {
            let retorno = value.replace(/(\d{2})(\d{4,5})(\d{4})/, "($1) $2-$3");

            return retorno;
        }
    }
}