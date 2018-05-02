import { Professor } from "./professor.model";
import { Sala } from "./sala.model";
import { Aluno } from "./aluno.model";

export class Notificacao {

  id: number = null;
  idProfessor: number = null;
  idSala: number = null;
  idAluno: number = null;
  titulo: string = null;
  assunto: string = null;
  mensagem: string = null;
  data: Date = null;

  professor: Professor = null;
  sala: Sala = null;
  aluno: Aluno = null;

  constructor(values: Object = {}) {
    Object.assign(this, values);
  }
}