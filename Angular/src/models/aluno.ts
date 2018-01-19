import { Responsavel } from "./responsavel";
import { Sala } from "./sala";

export class Aluno {
    $key: string = "";
    $keyResponsavel: string = "";
    $keySala: string = "";
    nome: string = "";
    sexo: string = "";
    idade: number = null;

    responsavel: Responsavel = new Responsavel();
    sala: Sala = new Sala();

    constructor(values: Object = {}) {
        Object.assign(this, values);
    }
}