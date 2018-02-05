import { Component, ViewChild } from '@angular/core';
import { Platform, NavController } from 'ionic-angular';
import { StatusBar } from '@ionic-native/status-bar';
import { LoginPage } from '../components/principal/pages/login/login';
import { SalaPage } from '../components/sala/sala';
import { HomePage } from '../components/home/home';
import { ResponsavelPage } from '../components/responsavel/responsavel';
import { AlunoPage } from '../components/aluno/aluno';

@Component({
  templateUrl: 'app.html'
})

export class MyApp {

  @ViewChild('content') navCtrl: NavController

  rootPage: any = LoginPage;

  constructor(platform: Platform, statusBar: StatusBar
    // , private navCtrl: NavController
  ) {
    platform.ready().then(() => {
      // Okay, so the platform is ready and our plugins are available.
      // Here you can do any higher level native things you might need.
      statusBar.styleDefault();
    });
  }

  home() {
    this.navCtrl.setRoot(HomePage);
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