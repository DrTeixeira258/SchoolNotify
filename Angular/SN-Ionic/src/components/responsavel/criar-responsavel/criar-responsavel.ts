import { NavController, ViewController, NavParams } from 'ionic-angular';
import { Component } from '@angular/core';
import { LoadingController } from 'ionic-angular/components/loading/loading-controller';
import { AlertController } from 'ionic-angular/components/alert/alert-controller';
import { Uteis } from '../../uteis';
import { Responsavel } from '../../../models/responsavel.model';
import { ResponsavelService } from '../../../services/responsavel.service';

@Component({
    selector: 'criar-responsavel-page',
    templateUrl: 'criar-responsavel.html',
    providers: [ResponsavelService]
})

export class CriarResponsavelPage extends Uteis {

    responsavel: Responsavel = new Responsavel();

    constructor(public loadingCtrl: LoadingController,
        public alertCtrl: AlertController,
        public navCtrl: NavController,
        public viewCtrl: ViewController,
        public navParams: NavParams,
        private responsavelService: ResponsavelService) {
        super(loadingCtrl, alertCtrl);
        if (this.navParams.get("responsavel"))
            this.responsavel = this.navParams.get("responsavel");
    }

    ionViewWillEnter() {
    }

    dismiss() {
        this.viewCtrl.dismiss(false);
    }

    salvar() {
        this.criarLoader();
        this.responsavelService.salvarResponsavel(this.responsavel).subscribe(
            data => {
                if (data)
                    this.exibirMensagem("Sucesso!", "Operação realizada com sucesso!");
            },
            error => {
                this.exibirMensagem("Ops!", "Ocorreu um erro ao realizar a operação.");
            },
            () => {
                this.fecharLoader();
                this.viewCtrl.dismiss(true)
            }
        );
    }

}