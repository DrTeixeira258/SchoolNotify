import { NavController, ModalController } from 'ionic-angular';
import { Component } from '@angular/core';
import { LoadingController } from 'ionic-angular/components/loading/loading-controller';
import { AlertController } from 'ionic-angular/components/alert/alert-controller';
import { SplashScreen } from '@ionic-native/splash-screen';
import { Uteis } from '../uteis';
import { Professor } from '../../models/professor.model';
import { ProfessorService } from '../../services/professor.service';
import { CriarProfessorPage } from './criar-professor/criar-professor';

@Component({
    selector: 'professor-page',
    templateUrl: 'professor.html',
    providers: [ProfessorService]
})

export class ProfessorPage extends Uteis {

    professores: Professor[] = [];

    constructor(public loadingCtrl: LoadingController,
        public alertCtrl: AlertController,
        public navCtrl: NavController,
        public splashScreen: SplashScreen,
        public modalCtrl: ModalController,
        private professorService: ProfessorService) {
        super(loadingCtrl, alertCtrl);
    }

    ionViewWillEnter() {
        this.splashScreen.hide();
    }

    ionViewDidLoad() {
        this.obterProfessores();
    }

    obterProfessores() {
        this.criarLoader();
        this.professorService.obterProfessores().subscribe(
            data => {
                this.professores = data;
            },
            error => {
                this.exibirMensagem("Ops!", "Erro ao buscar os professores!");
            },
            () => {
                this.fecharLoader();
            }
        );
    }

    modalCriarProfessor() {
        let modal = this.modalCtrl.create(CriarProfessorPage);
        modal.present();

        modal.onWillDismiss(data => {
            if (data)
                this.obterProfessores();
        });
    }

    modalEditarProfessor(professor: Professor) {
        let modal = this.modalCtrl.create(CriarProfessorPage,
            {
                professor: new Professor(professor)
            });
        modal.present();

        modal.onWillDismiss(data => {
            if (data)
                this.obterProfessores();
        });
    }

    prepararDeletarProfessor(professor: Professor) {
        let confirm = this.alertCtrl.create({
            title: 'Deletar Professor!',
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
                        this.deletarProfessor(professor);
                    }
                }
            ]
        });
        confirm.present();
    }



    deletarProfessor(professor: Professor) {
        this.criarLoader();
        this.professorService.deletarProfessor(professor).subscribe(
            data => {
                if (data)
                    this.exibirMensagem("Sucesso!", "Operação realizada com sucesso!");
            },
            error => {
                this.exibirMensagem("Ops!", "Ocorreu um erro ao realizar a operação.");
            },
            () => {
                this.fecharLoader();
                this.obterProfessores();
            }
        );
    }

}