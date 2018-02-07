import { NavController, ModalController } from 'ionic-angular';
import { Component } from '@angular/core';
import { LoadingController } from 'ionic-angular/components/loading/loading-controller';
import { AlertController } from 'ionic-angular/components/alert/alert-controller';
import { SplashScreen } from '@ionic-native/splash-screen';
import { Uteis } from '../uteis';
import { CriarAlunoPage } from './criar-aluno/criar-aluno';

@Component({
    selector: 'aluno-page',
    templateUrl: 'aluno.html'
})

export class AlunoPage extends Uteis {

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

    modalCriarAluno() {
        let modal = this.modalCtrl.create(CriarAlunoPage);
        modal.present();
    }

    modalEditarAluno(aluno) {
        console.log("aluno: ",aluno);
        let modal = this.modalCtrl.create(CriarAlunoPage,
            {
                aluno: aluno
            });
        modal.present();
    }

    deletarAluno(aluno) {
        // this.angularFire.list("/aluno").remove(aluno)
        //     .then(() => {
        //         this.exibirMensagem("Aluno Removido", "Aluno removido com sucesso!");
        //         this.fecharLoader();
        //     }),
        //     (e: any) => {
        //         console.log(e.message);
        //         this.fecharLoader();
        //     };
    }

}