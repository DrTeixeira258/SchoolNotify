export class Responsavel {
    id: number = 0;
    nome: string = "";
    telefone: number = null;
    email: string = "";

    constructor(values: Object = {}) {
        Object.assign(this, values);
    }
}