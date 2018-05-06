import { Responsavel } from "./responsavel.model";
import { Sala } from "./sala.model";

export class Aluno {
    id: number = null;
    idResponsavel: number = null;
    idSala: number = null;
    nome: string = null;
    sexo: string = null;
    idade: number = null;
    matricula: number = null;

    responsavel: Responsavel = new Responsavel();
    sala: Sala = new Sala();

    constructor(values: Object = {}) {
        Object.assign(this, values);
    }
}