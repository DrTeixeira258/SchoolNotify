export class Usuario {
    id: number = null;
    idProfessor: number = null;
    idResponsavel: number = null;
    login: string = '';
    senha: string = '';
    telefone: number = null;
    responsavel: boolean = null;
    professor: boolean = null;
    admin: boolean = null;
    nome: string = null;

    constructor(values: Object = {}) {
        Object.assign(this, values);
    }
}