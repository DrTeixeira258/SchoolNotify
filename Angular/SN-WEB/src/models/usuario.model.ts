export class Usuario {
    id: number = null;
    login: string = '';
    senha: string = '';
    telefone: number = null;
    responsavel: boolean = false;
    professor: boolean = false;
    admin: boolean = false;

    constructor(values: Object = {}) {
        Object.assign(this, values);
    }
}