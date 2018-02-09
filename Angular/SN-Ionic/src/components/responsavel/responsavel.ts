import { NavController, ModalController } from 'ionic-angular';
import { Component } from '@angular/core';
import { LoadingController } from 'ionic-angular/components/loading/loading-controller';
import { AlertController } from 'ionic-angular/components/alert/alert-controller';
import { SplashScreen } from '@ionic-native/splash-screen';
import { Uteis } from '../uteis';
import { CriarResponsavelPage } from './criar-responsavel/criar-responsavel';
import { Responsavel } from '../../models/responsavel.model';
import { ResponsavelService } from '../../services/responsavel.service';

@Component({
    selector: 'responsavel-page',
    templateUrl: 'responsavel.html',
    providers: [ResponsavelService]
})

export class ResponsavelPage extends Uteis {

    responsaveis: Responsavel[] = [];

    constructor(public loadingCtrl: LoadingController,
        public alertCtrl: AlertController,
        public navCtrl: NavController,
        public splashScreen: SplashScreen,
        public modalCtrl: ModalController,
        private resposavelService: ResponsavelService) {
        super(loadingCtrl, alertCtrl);
    }

    ionViewWillEnter() {
        this.splashScreen.hide();
    }

    ionViewDidLoad() {
        this.obterResponsaveis();
    }

    obterResponsaveis() {
        this.criarLoader();
        this.resposavelService.obterResponsaveis().subscribe(
            data => {
                this.responsaveis = data;
            },
            error => {
                this.exibirMensagem("Ops!", "Erro ao buscar os responsaveis!");
            },
            () => {
                this.fecharLoader();
            }
        );
    }

    modalCriarResponsavel() {
        let modal = this.modalCtrl.create(CriarResponsavelPage);
        modal.present();

        modal.onWillDismiss(data => {
            if (data)
                this.obterResponsaveis();
        });
    }

    modalEditarResponsavel(responsavel: Responsavel) {
        let modal = this.modalCtrl.create(CriarResponsavelPage,
            {
                responsavel: responsavel
            });
        modal.present();

        modal.onWillDismiss(data => {
            if (data)
                this.obterResponsaveis();
        });
    }

    prepararDeletarResponsavel(responsavel: Responsavel) {
        let confirm = this.alertCtrl.create({
            title: 'Deletar Responsavel!',
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
                        this.deletarResponsavel(responsavel);
                    }
                }
            ]
        });
        confirm.present();
    }

    

    deletarResponsavel(responsavel: Responsavel) {
        this.criarLoader();
        this.resposavelService.deletarResponsavel(responsavel).subscribe(
            data => {
                if (data)
                    this.exibirMensagem("Sucesso!", "Operação realizada com sucesso!");
            },
            error => {
                this.exibirMensagem("Ops!", "Ocorreu um erro ao realizar a operação.");
            },
            () => {
                this.fecharLoader();
                this.obterResponsaveis();
            }
        );
    }

}