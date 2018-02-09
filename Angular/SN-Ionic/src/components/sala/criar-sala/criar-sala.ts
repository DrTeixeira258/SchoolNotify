import { NavController, ViewController, NavParams } from 'ionic-angular';
import { Component } from '@angular/core';
import { LoadingController } from 'ionic-angular/components/loading/loading-controller';
import { AlertController } from 'ionic-angular/components/alert/alert-controller';
import { Uteis } from '../../uteis';
import { Sala } from '../../../models/sala.model';
import { SalaService } from '../../../services/sala.service';

@Component({
    selector: 'criar-sala-page',
    templateUrl: 'criar-sala.html',
    providers: [SalaService]
})

export class CriarSalaPage extends Uteis {

    sala: Sala = new Sala();

    constructor(public loadingCtrl: LoadingController,
        public alertCtrl: AlertController,
        public navCtrl: NavController,
        public viewCtrl: ViewController,
        public navParams: NavParams,
        private salaService: SalaService) {
        super(loadingCtrl, alertCtrl);
        if (this.navParams.get("sala"))
            this.sala = this.navParams.get("sala");
    }

    ionViewWillEnter() {
    }

    dismiss() {
        this.viewCtrl.dismiss(false);
    }

    salvar() {
        this.criarLoader();
        this.salaService.salvarSala(this.sala).subscribe(
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