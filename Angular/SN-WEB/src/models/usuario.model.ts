export class Usuario {
    id: number = null;
    login: string = '';
    senha: string = '';

    constructor(values: Object = {}) {
        Object.assign(this, values);
    }
}