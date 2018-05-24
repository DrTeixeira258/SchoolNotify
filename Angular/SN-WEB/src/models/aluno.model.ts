import { Responsavel } from "./responsavel.model";
import { Sala } from "./sala.model";

export class Aluno {
    id: number = 0;
    idResponsavel: number = null;
    idSala: number = null;
    matricula: number = null;
    nome: string = "";
    sexo: string = "";
    dataNascimento: Date = null;

    responsavel: Responsavel = null;
    sala: Sala = null;

    constructor(values: Object = {}) {
        Object.assign(this, values);
    }
}