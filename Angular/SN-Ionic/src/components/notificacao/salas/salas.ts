import { NavController, ModalController } from 'ionic-angular';
import { Component } from '@angular/core';
import { LoadingController } from 'ionic-angular/components/loading/loading-controller';
import { AlertController } from 'ionic-angular/components/alert/alert-controller';
import { SplashScreen } from '@ionic-native/splash-screen';
import { SalaService } from '../../../services/sala.service';
import { Uteis } from '../../uteis';
import { Sala } from '../../../models/sala.model';
import { Usuario } from '../../../models/usuario.model';
import { CriarNotificacaoPage } from '../criar-notificacao/criar-notificacao';

@Component({
    selector: 'salas-page',
    templateUrl: 'salas.html',
    providers: [SalaService]
})

export class SalasPage extends Uteis {

    public salas: Sala[] = [];
    public usuario: Usuario = null;

    constructor(public loadingCtrl: LoadingController,
        public alertCtrl: AlertController,
        public navCtrl: NavController,
        public splashScreen: SplashScreen,
        public modalCtrl: ModalController,
        private salaService: SalaService) {
        super(loadingCtrl, alertCtrl);
        this.usuario = JSON.parse(localStorage.getItem("usuario"));
    }

    ionViewWillEnter() {
        this.splashScreen.hide();
    }

    ionViewDidLoad() {
        this.buscarSalasPorIdProfessor();
    }

    buscarSalasPorIdProfessor() {
        this.criarLoader();
        this.salaService.obterSalasPorIdProfessor(this.usuario.idProfessor).subscribe(
            data => {
                this.salas = data;
                this.fecharLoader();
            },
            error => {
                this.fecharLoader();
                this.exibirMensagem("Ops!","Não foi possivel obter as salas.");
            }
        );
    }

    modalCriarNotificacao(sala: Sala) {
        let modal = this.modalCtrl.create(CriarNotificacaoPage,
            {
                sala: sala
            });
        modal.present();
    }
}