import { Responsavel } from "./responsavel.model";
import { Sala } from "./sala.model";

export class Aluno {
    id: number = 0;
    idResponsavel: number = null;
    idSala: number = null;
    matricula: number = null;
    nome: string = "";
    sexo: string = "";
    idade: number = null;

    responsavel: Responsavel = new Responsavel();
    sala: Sala = new Sala();

    constructor(values: Object = {}) {
        Object.assign(this, values);
    }
}