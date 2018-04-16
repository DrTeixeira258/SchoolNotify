import { Component } from '@angular/core';
import { LoadingController } from 'ionic-angular/components/loading/loading-controller';
import { AlertController } from 'ionic-angular/components/alert/alert-controller';
import { SplashScreen } from '@ionic-native/splash-screen';
import { Uteis } from '../uteis';
import { SalaService } from '../../services/sala.service';
import { SalasPage } from './salas/salas';
import { HomePage } from '../home/home';
import { AlunosPage } from './alunos/alunos';

@Component({
    selector: 'notificacao-page',
    templateUrl: 'notificacao.html',
    providers: [SalaService]
})

export class NotificacaoPage extends Uteis {

    tab1 = SalasPage;
    tab2 = AlunosPage;

    constructor(public loadingCtrl: LoadingController,
        public alertCtrl: AlertController,
        public splashScreen: SplashScreen,
        private salaService: SalaService) {
        super(loadingCtrl, alertCtrl);
    }

    ionViewWillEnter() {
        this.splashScreen.hide();
    }

    ionViewDidLoad() {
    }
}