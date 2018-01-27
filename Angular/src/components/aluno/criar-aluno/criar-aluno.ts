import { NavController, ViewController, NavParams } from 'ionic-angular';
import { Component } from '@angular/core';
import { LoadingController } from 'ionic-angular/components/loading/loading-controller';
import { AlertController } from 'ionic-angular/components/alert/alert-controller';
import { AngularFireDatabase, FirebaseListObservable } from 'angularfire2/database-deprecated';
import { Uteis } from '../../uteis';
import { Aluno } from '../../../models/aluno';
import * as firebase from 'firebase/app';
import { FirebaseApp } from 'angularfire2/firebase.app.module';

@Component({
    selector: 'criar-aluno-page',
    templateUrl: 'criar-aluno.html',
    providers: [AngularFireDatabase]
})

export class CriarAlunoPage extends Uteis {

    aluno: Aluno = new Aluno();
    responsaveis: FirebaseListObservable<any[]>;
    salas: FirebaseListObservable<any[]>;

    constructor(public loadingCtrl: LoadingController,
        public alertCtrl: AlertController,
        public navCtrl: NavController,
        public viewCtrl: ViewController,
        public navParams: NavParams,
        public fb: FirebaseApp,
        private angularFire: AngularFireDatabase) {
        super(loadingCtrl, alertCtrl);
        if (this.navParams.get("aluno")){
            this.aluno = this.navParams.get("aluno");
            console.log("criar-aluno: ", this.aluno)
        }
        this.carregarSelects();
    }

    ionViewWillEnter() {

    }

    dismiss() {
        this.viewCtrl.dismiss();
    }

    carregarSelects() {
        this.criarLoader();
        this.salas = this.angularFire.list('sala');
        this.responsaveis = this.angularFire.list('responsavel');
        this.fecharLoader();
    }

    salvar() {
        this.criarLoader();
        if (this.aluno.$key) {
            this.angularFire.list("aluno").update(this.aluno.$key, this.aluno)
                .then(() => {
                    this.exibirMensagem("Aluno Editado", "Aluno editado com sucesso!");
                    this.fecharLoader();
                    this.viewCtrl.dismiss();
                }),
                (e: any) => {
                    console.log(e.message);
                    this.fecharLoader();
                };
        } else {
            this.fb.database().ref('responsavel').orderByKey().equalTo(this.aluno.keyResponsavel).on("child_added", (snapshot) => {
                this.aluno.responsavel = snapshot.val();
            });

            this.fb.database().ref('sala').orderByKey().equalTo(this.aluno.keySala).on("child_added", (snapshot) => {
                this.aluno.sala = snapshot.val();
            });

            this.angularFire.list("aluno").push(
                {
                    nome: this.aluno.nome,
                    sexo: this.aluno.sexo,
                    idade: this.aluno.idade,
                    keyResponsavel: this.aluno.keyResponsavel,
                    keySala: this.aluno.keySala,
                    responsavel: this.aluno.responsavel,
                    sala: this.aluno.sala
                }
            )
                .then((t: any) => {
                    console.log('dados gravados: ' + t.key);
                    this.exibirMensagem("Aluno Criado", "Aluno criado com sucesso!");
                    this.fecharLoader();
                    this.viewCtrl.dismiss();
                }),
                (e: any) => {
                    console.log(e.message);
                    this.fecharLoader();
                };
        }
    }

}