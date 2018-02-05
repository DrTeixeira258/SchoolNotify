import { NavController, ViewController, NavParams } from 'ionic-angular';
import { Component } from '@angular/core';
import { LoadingController } from 'ionic-angular/components/loading/loading-controller';
import { AlertController } from 'ionic-angular/components/alert/alert-controller';
import { AngularFireDatabase } from 'angularfire2/database-deprecated';
import { Uteis } from '../../uteis';
import { Sala } from '../../../models/sala';

@Component({
    selector: 'criar-sala-page',
    templateUrl: 'criar-sala.html',
    providers: [AngularFireDatabase]
})

export class CriarSalaPage extends Uteis {

    sala: Sala = new Sala();

    constructor(public loadingCtrl: LoadingController,
        public alertCtrl: AlertController,
        public navCtrl: NavController,
        public viewCtrl: ViewController,
        public navParams: NavParams,
        private angularFire: AngularFireDatabase) {
        super(loadingCtrl, alertCtrl);
        if (this.navParams.get("sala"))
            this.sala = this.navParams.get("sala");
    }

    ionViewWillEnter() {
    }

    dismiss() {
        this.viewCtrl.dismiss();
    }

    salvar() {
        this.criarLoader();
        if (this.sala.$key) {
            this.angularFire.list("sala").update(this.sala.$key, this.sala)
            .then(() => {
                this.exibirMensagem("Sala Editada", "Sala editada com sucesso!");
                this.fecharLoader();
                this.viewCtrl.dismiss();
            }),
                (e: any) => {
                    console.log(e.message);
                    this.fecharLoader();
                };
        } else {
            this.angularFire.list("sala").push(
                {
                    nome: this.sala.nome,
                    serie: this.sala.serie
                }
            ).then((t: any) => {
                console.log('dados gravados: ' + t.key);
                this.exibirMensagem("Sala Criada", "Sala criada com sucesso!");
                this.fecharLoader();
                this.viewCtrl.dismiss();
            }),
                (e: any) => {
                    console.log(e.message);
                    this.fecharLoader();
                };
        }

    }

}