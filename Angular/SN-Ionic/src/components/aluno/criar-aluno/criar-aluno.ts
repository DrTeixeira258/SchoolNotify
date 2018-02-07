import { NavController, ViewController, NavParams } from 'ionic-angular';
import { Component } from '@angular/core';
import { LoadingController } from 'ionic-angular/components/loading/loading-controller';
import { AlertController } from 'ionic-angular/components/alert/alert-controller';
import { Uteis } from '../../uteis';
import { Aluno } from '../../../models/aluno';

@Component({
    selector: 'criar-aluno-page',
    templateUrl: 'criar-aluno.html'
})

export class CriarAlunoPage extends Uteis {

    aluno: Aluno = new Aluno();
    // responsaveis: FirebaseListObservable<any[]>;
    // salas: FirebaseListObservable<any[]>;

    constructor(public loadingCtrl: LoadingController,
        public alertCtrl: AlertController,
        public navCtrl: NavController,
        public viewCtrl: ViewController,
        public navParams: NavParams) {
        super(loadingCtrl, alertCtrl);
        if (this.navParams.get("aluno")) {
            this.aluno = this.navParams.get("aluno");
        }
        this.carregarSelects();
    }

    ionViewWillEnter() {

    }

    dismiss() {
        this.viewCtrl.dismiss();
    }

    carregarSelects() {
        // this.criarLoader();
        // this.salas = this.angularFire.list('sala');
        // this.responsaveis = this.angularFire.list('responsavel');
        // this.fecharLoader();
    }

    salvar() {
        this.criarLoader();
        // this.angularFire.list("aluno").update(this.aluno.$key, this.aluno)
        //     .then(() => {
        //         this.exibirMensagem("Aluno Editado", "Aluno editado com sucesso!");
        //         this.fecharLoader();
        //         this.viewCtrl.dismiss();
        //     }),
        //     (e: any) => {
        //         console.log(e.message);
        //         this.fecharLoader();
        //     };
    }

}