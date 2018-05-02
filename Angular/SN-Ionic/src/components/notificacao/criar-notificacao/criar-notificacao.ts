import { NotificacaoService } from './../../../services/notificacao.service';
import { NavController, NavParams, ViewController } from 'ionic-angular';
import { Component } from '@angular/core';
import { LoadingController } from 'ionic-angular/components/loading/loading-controller';
import { AlertController } from 'ionic-angular/components/alert/alert-controller';
import { Uteis } from '../../uteis';
import { ResponsavelService } from '../../../services/responsavel.service';
import { Sala } from '../../../models/sala.model';
import { Aluno } from '../../../models/aluno.model';
import { Notificacao } from '../../../models/notificacao.model';
import { MyApp } from '../../../app/app.component';

@Component({
    selector: 'criar-notificacao-page',
    templateUrl: 'criar-notificacao.html',
    providers: [ResponsavelService, NotificacaoService]
})

export class CriarNotificacaoPage extends Uteis {

    notificacao: Notificacao = new Notificacao();
    sala: Sala = null;
    aluno: Aluno = null;
    telefonesResps: number[] = [];
    titulo: string = "";
    subTitulo: string = "";


    constructor(public loadingCtrl: LoadingController,
        public alertCtrl: AlertController,
        public navCtrl: NavController,
        public viewCtrl: ViewController,
        public navParams: NavParams,
        private responsavelService: ResponsavelService,
        private notificacaoService: NotificacaoService) {
        super(loadingCtrl, alertCtrl);
        if (this.navParams.get("sala")) {
            this.sala = this.navParams.get("sala");
            this.titulo = this.sala.nome;
            this.subTitulo = this.sala.serie;
        }
        else {
            this.aluno = this.navParams.get("aluno");
            this.titulo = this.aluno.nome;
            this.subTitulo = this.aluno.sala.nome;
        }
    }

    dismiss() {
        this.viewCtrl.dismiss(false);
    }

    ionViewDidLoad() {
        if (this.sala)
            this.buscarTelefonesResponsaveis();
        else
            this.buscarTelefoneResponsavel();
    }

    buscarTelefonesResponsaveis() {
        this.criarLoader();
        this.telefonesResps = [];
        this.responsavelService.buscarTelefonesResponsaveis(this.sala.id).subscribe(
            data => {
                this.telefonesResps = data;
                console.log(this.telefonesResps);
                this.fecharLoader();
            },
            error => {
                this.fecharLoader();
                this.exibirMensagem("Ops!", "Ocorreu um erro.");
            }
        );
    }

    buscarTelefoneResponsavel() {
        this.criarLoader();
        this.telefonesResps = [];
        this.responsavelService.buscarTelefoneResponsavel(this.aluno.id).subscribe(
            data => {
                this.telefonesResps.push(data);
                console.log(this.telefonesResps);
                this.fecharLoader();
            },
            error => {
                this.fecharLoader();
                this.exibirMensagem("Ops!", "Ocorreu um erro.");
            }
        );
    }

    salvarNotificacao() {
        this.criarLoader();
        this.notificacao.idProfessor = MyApp.usuario.idProfessor;
        if (this.aluno)
            this.notificacao.idAluno = this.aluno.id;
        else
            this.notificacao.idSala = this.sala.id;
        this.notificacaoService.SalvarNotificacao(this.notificacao).subscribe(
            data => {
                this.fecharLoader();
                this.exibirMensagem("Sucesso", "Mensagem enviada com sucesso!");
            },
            error => {
                this.fecharLoader();
                this.exibirMensagem("Ops!", "Ocorreu um erro.");
            }
        );
    }

}