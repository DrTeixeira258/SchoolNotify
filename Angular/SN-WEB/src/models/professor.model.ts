export class Professor {
    id: number = 0;
    nome: string = "";
    matricula: number = null;
    email: string = "";

    constructor(values: Object = {}) {
        Object.assign(this, values);
    }
}