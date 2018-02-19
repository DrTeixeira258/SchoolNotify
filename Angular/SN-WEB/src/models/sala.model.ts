export class Sala {
    id: number = 0;
    nome: string = "";
    serie: string = "";
    idsProfessores: number[] = [];

    constructor(values: Object = {}) {
        Object.assign(this, values);
    }
}