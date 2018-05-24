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
import { TokenService } from '../../../services/token.service';
import { OneSignalService } from '../../../services/oneSignal.service';
import { Token } from '../../../models/token.model';

@Component({
    selector: 'criar-notificacao-page',
    templateUrl: 'criar-notificacao.html',
    providers: [ResponsavelService, NotificacaoService, TokenService, OneSignalService]
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
        private notificacaoService: NotificacaoService,
        private tokenService: TokenService,
        private oneSignalService: OneSignalService) {
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

    buscarTokens() {
        this.criarLoader();
        this.tokenService.BuscarTokensPorTelefones(this.telefonesResps).subscribe(
            data => {
                this.enviarNotificacao(data);
            },
            error => {
                this.fecharLoader();
                this.exibirMensagem("Ops!", "Ocorreu um erro ao salvar a notificacão.");
            }
        )
    }

    enviarNotificacao(tokens: string[]) {
        let osNotification = {
            app_id: "c2efd703-7e75-475b-a138-52a1d18d571d",
            include_player_ids: tokens,
            contents: {
                en: this.notificacao.assunto,
            },
            headings: {
                en: "School Notify",
            },
            data: {
                idNotificacao: this.notificacao.id.toString()
            }
        };
        this.oneSignalService.enviarNotificacao(osNotification).subscribe(
            data => {
                this.fecharLoader();
                this.dismiss();
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
                this.notificacao.id = data;
                this.fecharLoader();
                this.exibirMensagem("Sucesso", "Mensagem enviada com sucesso!");
            },
            error => {
                this.fecharLoader();
                this.exibirMensagem("Ops!", "Ocorreu um erro ao salvar a notificacão.");
            },
            () => {
                this.buscarTokens();
            }
        );
    }
}