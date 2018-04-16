import { NavController, ModalController } from 'ionic-angular';
import { Component } from '@angular/core';
import { LoadingController } from 'ionic-angular/components/loading/loading-controller';
import { AlertController } from 'ionic-angular/components/alert/alert-controller';
import { SplashScreen } from '@ionic-native/splash-screen';
import { Uteis } from '../../uteis';
import { Usuario } from '../../../models/usuario.model';
import { CriarNotificacaoPage } from '../criar-notificacao/criar-notificacao';
import { Aluno } from '../../../models/aluno.model';
import { AlunoService } from '../../../services/aluno.service';

@Component({
    selector: 'alunos-page',
    templateUrl: 'alunos.html',
    providers: [AlunoService]
})

export class AlunosPage extends Uteis {

    public alunos: Aluno[] = [];
    public usuario: Usuario = null;

    myInput

    constructor(public loadingCtrl: LoadingController,
        public alertCtrl: AlertController,
        public navCtrl: NavController,
        public splashScreen: SplashScreen,
        public modalCtrl: ModalController,
        private alunoService: AlunoService) {
        super(loadingCtrl, alertCtrl);
        this.usuario = JSON.parse(localStorage.getItem("usuario"));
    }

    ionViewWillEnter() {
        this.splashScreen.hide();
    }

    ionViewDidLoad() {
        this.ObterAlunosPorProfessor();
    }

    onInput(e){
        console.log(e);
    }

    ObterAlunosPorProfessor() {
        this.criarLoader();
        this.alunoService.ObterAlunosPorProfessor(this.usuario.idProfessor).subscribe(
            data => {
                this.alunos = data;
                this.fecharLoader();
            },
            error => {
                this.fecharLoader();
                this.exibirMensagem("Ops!","Nao foi possivel obter os alunos.");
            }
        );
    }

    modalCriarNotificacao(idAluno) {
        let modal = this.modalCtrl.create(CriarNotificacaoPage,
            {
                idAluno: idAluno
            });
        modal.present();
    }
}