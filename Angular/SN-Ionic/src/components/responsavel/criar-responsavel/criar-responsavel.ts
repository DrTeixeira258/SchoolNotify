import { NavController, ViewController, NavParams } from 'ionic-angular';
import { Component } from '@angular/core';
import { LoadingController } from 'ionic-angular/components/loading/loading-controller';
import { AlertController } from 'ionic-angular/components/alert/alert-controller';
import { AngularFireDatabase } from 'angularfire2/database-deprecated';
import { Uteis } from '../../uteis';
import { Responsavel } from '../../../models/responsavel';

@Component({
    selector: 'criar-responsavel-page',
    templateUrl: 'criar-responsavel.html',
    providers: [AngularFireDatabase]
})

export class CriarResponsavelPage extends Uteis {

    responsavel: Responsavel = new Responsavel();

    constructor(public loadingCtrl: LoadingController,
        public alertCtrl: AlertController,
        public navCtrl: NavController,
        public viewCtrl: ViewController,
        public navParams: NavParams,
        private angularFire: AngularFireDatabase) {
        super(loadingCtrl, alertCtrl);
        if (this.navParams.get("responsavel"))
            this.responsavel = this.navParams.get("responsavel");
    }

    ionViewWillEnter() {
    }

    dismiss() {
        this.viewCtrl.dismiss();
    }

    salvar() {
        this.criarLoader();
        if (this.responsavel.$key) {
            this.angularFire.list("responsavel").update(this.responsavel.$key, this.responsavel)
            .then(() => {
                this.exibirMensagem("Responsável Editado", "Responsável editado com sucesso!");
                this.fecharLoader();
                this.viewCtrl.dismiss();
            }),
                (e: any) => {
                    console.log(e.message);
                    this.fecharLoader();
                };
        } else {
            this.angularFire.list("responsavel").push(
                {
                    nome: this.responsavel.nome,
                    email: this.responsavel.email,
                    telefone: this.responsavel.telefone
                }
            ).then((t: any) => {
                console.log('dados gravados: ' + t.key);
                this.exibirMensagem("Responsável Criado", "Responsável criado com sucesso!");
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