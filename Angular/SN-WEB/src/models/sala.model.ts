export class Sala {
    id: number = 0;
    nome: string = "";
    serie: string = "";

    constructor(values: Object = {}) {
        Object.assign(this, values);
    }
}