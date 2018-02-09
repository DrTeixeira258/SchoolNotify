import { Component } from '@angular/core';
import { SplashScreen } from '@ionic-native/splash-screen';
import { NavController } from 'ionic-angular';
import { LoadingController } from 'ionic-angular/components/loading/loading-controller';
import { AlertController } from 'ionic-angular/components/alert/alert-controller';
import { Uteis } from '../../../uteis';
import { Usuario } from '../../../../models/usuario.model';
import { HomePage } from '../../../home/home';

@Component({
    selector: 'page-login',
    templateUrl: 'login.html'
})

export class LoginPage extends Uteis {

    usuario: Usuario = new Usuario();

    constructor(
        public loadingCtrl: LoadingController,
        public alertCtrl: AlertController,
        public navCtrl: NavController,
        public splashScreen: SplashScreen) {
        super(loadingCtrl, alertCtrl);
    }

    ionViewWillEnter() {
        this.splashScreen.hide();
    }

    private logar() {
        this.criarLoader();
        this.navCtrl.setRoot(HomePage);
        this.fecharLoader();
    }

}