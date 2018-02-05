export class Responsavel {
    $key: string = "";
    nome: string = "";
    telefone: number = null;
    email: string = "";

    constructor(values: Object = {}) {
        Object.assign(this, values);
    }
}