import { Component, ViewChild } from '@angular/core';
import { Platform, NavController } from 'ionic-angular';
import { StatusBar } from '@ionic-native/status-bar';
import { LoginPage } from '../components/principal/pages/login/login';
import { SalaPage } from '../components/sala/sala';
import { HomePage } from '../components/home/home';
import { ResponsavelPage } from '../components/responsavel/responsavel';
import { AlunoPage } from '../components/aluno/aluno';
import { ProfessorPage } from '../components/professor/professor';
import { NotificacaoPage } from '../components/notificacao/notificacao';
import { Usuario } from '../models/usuario.model';
import { ListarNotificacaoPage } from '../components/notificacao/listar-notificacao/listar-notificacao';

@Component({
  templateUrl: 'app.html'
})

export class MyApp {

  @ViewChild('content') navCtrl: NavController

  static pages = [];

  rootPage: any = LoginPage;
  public static usuario: Usuario = new Usuario();

  constructor(public platform: Platform, statusBar: StatusBar) {
    platform.ready().then(() => {
      statusBar.styleDefault();
    });
  }

  static montarMenu() {
    MyApp.pages = [];
    MyApp.pages.push({ title: 'Home', component: HomePage });
    if (MyApp.usuario.professor)
      MyApp.pages.push({ title: 'Notificar', component: NotificacaoPage })
    if (MyApp.usuario.responsavel)
      MyApp.pages.push({ title: 'Notificacões', component: ListarNotificacaoPage });
    MyApp.pages.push({ title: 'Sair', component: LoginPage });
  }

  get buscarUsuario() {
    return MyApp.usuario;
  }

  get menu() {
    return MyApp.pages
  }

  goTo(page) {
    this.navCtrl.setRoot(page);
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

}