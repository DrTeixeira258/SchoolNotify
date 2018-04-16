import { NavController, NavParams, ViewController } from 'ionic-angular';
import { Component } from '@angular/core';
import { LoadingController } from 'ionic-angular/components/loading/loading-controller';
import { AlertController } from 'ionic-angular/components/alert/alert-controller';
import { Uteis } from '../../uteis';
import { ResponsavelService } from '../../../services/responsavel.service';

@Component({
    selector: 'criar-notificacao-page',
    templateUrl: 'criar-notificacao.html',
    providers: [ResponsavelService]
})

export class CriarNotificacaoPage extends Uteis {

    idSala: number = null;
    idAluno: number = null;
    telefonesResps: number[] = [];

    constructor(public loadingCtrl: LoadingController,
        public alertCtrl: AlertController,
        public navCtrl: NavController,
        public viewCtrl: ViewController,
        public navParams: NavParams,
        private responsavelService: ResponsavelService) {
        super(loadingCtrl, alertCtrl);
        if (this.navParams.get("idSala"))
            this.idSala = this.navParams.get("idSala");
        else
            this.idAluno = this.navParams.get("idAluno");
    }

    dismiss() {
        this.viewCtrl.dismiss(false);
    }

    ionViewDidLoad() {
        if (this.idSala)
            this.buscarTelefonesResponsaveis();
        else
            this.buscarTelefoneResponsavel();
    }

    buscarTelefonesResponsaveis() {
        this.criarLoader();
        this.telefonesResps = [];
        this.responsavelService.buscarTelefonesResponsaveis(this.idSala).subscribe(
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
        this.responsavelService.buscarTelefoneResponsavel(this.idAluno).subscribe(
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

}