export class Usuario {
    login: string = '';
    senha: string = '';
    id: number = null;
    siglaPerfil:string = null;
    idProjeto:number = null;
    idColaboradorSelecionado:number = null;

    constructor(values: Object = {}) {
        Object.assign(this, values);
    }
}