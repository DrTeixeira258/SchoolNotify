import { NavController, ModalController } from 'ionic-angular';
import { Component } from '@angular/core';
import { LoadingController } from 'ionic-angular/components/loading/loading-controller';
import { AlertController } from 'ionic-angular/components/alert/alert-controller';
import { SplashScreen } from '@ionic-native/splash-screen';
import { Uteis } from '../uteis';

@Component({
    selector: 'home-page',
    templateUrl: 'home.html'
})

export class HomePage extends Uteis {

    constructor(public loadingCtrl: LoadingController,
        public alertCtrl: AlertController,
        public navCtrl: NavController,
        public splashScreen: SplashScreen,
        public modalCtrl: ModalController) {
        super(loadingCtrl, alertCtrl);
    }

    ionViewWillEnter() {
        this.splashScreen.hide();
    }

}