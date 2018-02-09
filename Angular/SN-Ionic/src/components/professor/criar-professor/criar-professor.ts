import { NavController, ViewController, NavParams } from 'ionic-angular';
import { Component } from '@angular/core';
import { LoadingController } from 'ionic-angular/components/loading/loading-controller';
import { AlertController } from 'ionic-angular/components/alert/alert-controller';
import { Uteis } from '../../uteis';
import { ProfessorService } from '../../../services/professor.service';
import { Professor } from '../../../models/professor.model';

@Component({
    selector: 'criar-professor-page',
    templateUrl: 'criar-professor.html',
    providers: [ProfessorService]
})

export class CriarProfessorPage extends Uteis {

    professor: Professor = new Professor();

    constructor(public loadingCtrl: LoadingController,
        public alertCtrl: AlertController,
        public navCtrl: NavController,
        public viewCtrl: ViewController,
        public navParams: NavParams,
        private professorService: ProfessorService) {
        super(loadingCtrl, alertCtrl);
        if (this.navParams.get("professor"))
            this.professor = this.navParams.get("professor");
    }

    ionViewWillEnter() {
    }

    dismiss() {
        this.viewCtrl.dismiss(false);
    }

    salvar() {
        this.criarLoader();
        this.professorService.salvarProfessor(this.professor).subscribe(
            data => {
                if (data)
                    this.exibirMensagem("Sucesso!", "Operação realizada com sucesso!");
            },
            error => {
                this.exibirMensagem("Ops!", "Ocorreu um erro ao realizar a operação.");
            },
            () => {
                this.fecharLoader();
                this.viewCtrl.dismiss(true)
            }
        );
    }

}