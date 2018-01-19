import { NavController, ModalController } from 'ionic-angular';
import { Component } from '@angular/core';
import { LoadingController } from 'ionic-angular/components/loading/loading-controller';
import { AlertController } from 'ionic-angular/components/alert/alert-controller';
import { SplashScreen } from '@ionic-native/splash-screen';
import { Uteis } from '../uteis';
import { AngularFireDatabase, FirebaseListObservable } from 'angularfire2/database-deprecated';
import { CriarAlunoPage } from './criar-aluno/criar-aluno';

// rootRef: const rootRef = this.angularFire.database().Ref();

@Component({
    selector: 'aluno-page',
    templateUrl: 'aluno.html',
    providers: [AngularFireDatabase]
})

export class AlunoPage extends Uteis {

    alunos: FirebaseListObservable<any[]>;

    constructor(public loadingCtrl: LoadingController,
        public alertCtrl: AlertController,
        public navCtrl: NavController,
        public splashScreen: SplashScreen,
        public modalCtrl: ModalController,
        private angularFire: AngularFireDatabase) {
        super(loadingCtrl, alertCtrl);
    }
    
    ionViewWillEnter() {
        this.alunos = this.angularFire.list('aluno');
        this.splashScreen.hide();
    }

    modalCriarAluno() {
        let modal = this.modalCtrl.create(CriarAlunoPage);
        modal.present();
    }

    modalEditarAluno(aluno) {
        let modal = this.modalCtrl.create(CriarAlunoPage,
            {
                aluno: aluno
            });
        modal.present();
    }

    deletarSala(aluno) {
        this.angularFire.list("/aluno").remove(aluno)
            .then(() => {
                this.exibirMensagem("Aluno Removido", "Aluno removido com sucesso!");
                this.fecharLoader();
            }),
            (e: any) => {
                console.log(e.message);
                this.fecharLoader();
            };
    }

}