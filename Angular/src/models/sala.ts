export class Sala {
    $key: string = "";
    nome: string = "";
    serie; string = "";

    constructor(values: Object = {}) {
        Object.assign(this, values);
    }
}