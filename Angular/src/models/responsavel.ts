export class Responsavel {
    $key: string = "";
    nome: string = "";
    telefone: number = 0;
    email: string = "";

    constructor(values: Object = {}) {
        Object.assign(this, values);
    }
}