import { Component } from '@angular/core';
import { LoadingController } from 'ionic-angular/components/loading/loading-controller';
import { AlertController } from 'ionic-angular/components/alert/alert-controller';
import { SplashScreen } from '@ionic-native/splash-screen';
import { Uteis } from '../uteis';
import { SalasPage } from './salas/salas';
import { AlunosPage } from './alunos/alunos';

@Component({
    selector: 'notificacao-page',
    templateUrl: 'notificacao.html'
})

export class NotificacaoPage extends Uteis {

    tab1 = SalasPage;
    tab2 = AlunosPage;

    constructor(public loadingCtrl: LoadingController,
        public alertCtrl: AlertController,
        public splashScreen: SplashScreen) {
        super(loadingCtrl, alertCtrl);
    }

    ionViewWillEnter() {
        this.splashScreen.hide();
    }

    ionViewDidLoad() {
    }
}