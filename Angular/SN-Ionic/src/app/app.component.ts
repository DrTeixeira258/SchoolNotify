import { Component, ViewChild } from '@angular/core';
import { Platform, NavController } from 'ionic-angular';
import { StatusBar } from '@ionic-native/status-bar';
import { LoginPage } from '../components/principal/pages/login/login';
import { SalaPage } from '../components/sala/sala';
import { HomePage } from '../components/home/home';
import { ResponsavelPage } from '../components/responsavel/responsavel';
import { AlunoPage } from '../components/aluno/aluno';
import { ProfessorPage } from '../components/professor/professor';

@Component({
  templateUrl: 'app.html'
})

export class MyApp {

  @ViewChild('content') navCtrl: NavController

  rootPage: any = LoginPage;

  constructor(public platform: Platform, statusBar: StatusBar) {
    // platform.ready().then(() => {
    //   // Okay, so the platform is ready and our plugins are available.
    //   // Here you can do any higher level native things you might need.
    //   statusBar.styleDefault();
    // });
    this.initializeApp();
  }

  initializeApp() {
    this.platform.ready().then(() => {
      let funcaoRetorno = (data) => {
        console.log('Notificações: ' + JSON.stringify(data));
      };

      window["plugins"].OneSignal.startInit("c2efd703-7e75-475b-a138-52a1d18d571d",
        "873655996905")
        .handleNotificationOpened(funcaoRetorno)
        .endInit();
    });
  }

  home() {
    this.navCtrl.setRoot(HomePage);
  }

  professor() {
    this.navCtrl.setRoot(ProfessorPage);
  }

  responsavel() {
    this.navCtrl.setRoot(ResponsavelPage);
  }

  sala() {
    this.navCtrl.setRoot(SalaPage);
  }

  aluno() {
    this.navCtrl.setRoot(AlunoPage);
  }

  sair() {
    this.navCtrl.setRoot(LoginPage);
  }

}