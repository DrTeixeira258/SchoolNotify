import { NavController, ModalController } from 'ionic-angular';
import { Component } from '@angular/core';
import { LoadingController } from 'ionic-angular/components/loading/loading-controller';
import { AlertController } from 'ionic-angular/components/alert/alert-controller';
import { SplashScreen } from '@ionic-native/splash-screen';
import { Uteis } from '../uteis';
import { AngularFireDatabase, FirebaseListObservable } from 'angularfire2/database-deprecated';
import { CriarSalaPage } from './criar-sala/criar-sala';

@Component({
    selector: 'sala-page',
    templateUrl: 'sala.html',
    providers: [AngularFireDatabase]
})

export class SalaPage extends Uteis {

    salas: FirebaseListObservable<any[]>;

    constructor(public loadingCtrl: LoadingController,
        public alertCtrl: AlertController,
        public navCtrl: NavController,
        public splashScreen: SplashScreen,
        public modalCtrl: ModalController,
        private angularFire: AngularFireDatabase) {
        super(loadingCtrl, alertCtrl);
        this.salas = angularFire.list('sala');
    }

    ionViewWillEnter() {
        this.splashScreen.hide();
    }

    modalCriarSala() {
        let modal = this.modalCtrl.create(CriarSalaPage);
        modal.present();
    }

    modalEditarSala(sala) {
        let modal = this.modalCtrl.create(CriarSalaPage,
            {
                sala: sala
            });
        modal.present();
    }

    deletarSala(sala) {
        this.angularFire.list("/sala").remove(sala)
            .then(() => {
                this.exibirMensagem("Sala Removida", "Sala removida com sucesso!");
                this.fecharLoader();
            }),
            (e: any) => {
                console.log(e.message);
                this.fecharLoader();
            };
    }

}