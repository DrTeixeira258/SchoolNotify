import { NavController, ModalController } from 'ionic-angular';
import { Component } from '@angular/core';
import { LoadingController } from 'ionic-angular/components/loading/loading-controller';
import { AlertController } from 'ionic-angular/components/alert/alert-controller';
import { SplashScreen } from '@ionic-native/splash-screen';
import { Uteis } from '../uteis';
import { CriarSalaPage } from './criar-sala/criar-sala';
import { Sala } from '../../models/sala.model';
import { SalaService } from '../../services/sala.service';

@Component({
    selector: 'sala-page',
    templateUrl: 'sala.html',
    providers: [SalaService]
})

export class SalaPage extends Uteis {

    private salas: Sala[] = [];

    constructor(public loadingCtrl: LoadingController,
        public alertCtrl: AlertController,
        public navCtrl: NavController,
        public splashScreen: SplashScreen,
        public modalCtrl: ModalController,
        private salaService: SalaService) {
        super(loadingCtrl, alertCtrl);
    }

    ionViewWillEnter() {
        this.splashScreen.hide();
    }

    ionViewDidLoad() {
        this.obterSalas();
    }

    obterSalas() {
        this.criarLoader();
        this.salaService.obterSalas().subscribe(
            data => {
                this.salas = data;
            },
            error => {
                this.exibirMensagem("Ops!", "Erro ao buscar as salas!");
            },
            () => {
                this.fecharLoader();
            }
        );
    }

    modalCriarSala() {
        let modal = this.modalCtrl.create(CriarSalaPage);
        modal.present();

        modal.onWillDismiss(data => {
            if (data)
                this.obterSalas();
        });
    }

    modalEditarSala(sala) {
        let modal = this.modalCtrl.create(CriarSalaPage,
            {
                sala: new Sala(sala)
            });
        modal.present();

        modal.onWillDismiss(data => {
            if (data)
                this.obterSalas();
        });
    }

    prepararDeletarSala(sala) {
        let confirm = this.alertCtrl.create({
            title: 'Deletar Sala!',
            message: 'Deseja continuar com operação?',
            buttons: [
                {
                    text: 'Não',
                    handler: () => {
                        console.log("'No' clicked");
                    }
                },
                {
                    text: 'Sim',
                    handler: () => {
                        this.deletarSala(sala);
                    }
                }
            ]
        });
        confirm.present();
    }

    deletarSala(sala) {
        this.criarLoader();
        this.salaService.deletarSala(sala).subscribe(
            data => {
                if (data)
                    this.exibirMensagem("Sucesso!", "Operação realizada com sucesso!");
            },
            error => {
                this.exibirMensagem("Ops!", "Ocorreu um erro ao realizar a operação.");
            },
            () => {
                this.fecharLoader();
                this.obterSalas();
            }
        );
    }

}