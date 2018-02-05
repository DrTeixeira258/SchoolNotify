import { NavController, ModalController } from 'ionic-angular';
import { Component } from '@angular/core';
import { LoadingController } from 'ionic-angular/components/loading/loading-controller';
import { AlertController } from 'ionic-angular/components/alert/alert-controller';
import { SplashScreen } from '@ionic-native/splash-screen';
import { Uteis } from '../uteis';
import { AngularFireDatabase, FirebaseListObservable } from 'angularfire2/database-deprecated';
import { CriarResponsavelPage } from './criar-responsavel/criar-responsavel';

@Component({
    selector: 'responsavel-page',
    templateUrl: 'responsavel.html',
    providers: [AngularFireDatabase]
})

export class ResponsavelPage extends Uteis {

    responsaveis: FirebaseListObservable<any[]>;

    constructor(public loadingCtrl: LoadingController,
        public alertCtrl: AlertController,
        public navCtrl: NavController,
        public splashScreen: SplashScreen,
        public modalCtrl: ModalController,
        private angularFire: AngularFireDatabase) {
        super(loadingCtrl, alertCtrl);
        this.responsaveis = angularFire.list('responsavel');
    }

    ionViewWillEnter() {
        this.splashScreen.hide();
    }

    modalCriarResponsavel() {
        let modal = this.modalCtrl.create(CriarResponsavelPage);
        modal.present();
    }

    modalEditarResponsavel(responsavel) {
        let modal = this.modalCtrl.create(CriarResponsavelPage,
            {
                responsavel: responsavel
            });
        modal.present();
    }

    deletarResponsavel(responsavel) {
        this.criarLoader();
        this.angularFire.list("/responsavel").remove(responsavel)
            .then(() => {
                this.exibirMensagem("Responsavel Removido", "Responsavel removido com sucesso!");
                this.fecharLoader();
            }),
            (e: any) => {
                console.log(e.message);
                this.fecharLoader();
            };
    }

}