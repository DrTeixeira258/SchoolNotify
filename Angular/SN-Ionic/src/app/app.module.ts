import { TelefonePipe } from './../pipe/phone';
import { BrowserModule } from '@angular/platform-browser';
import { ErrorHandler, NgModule } from '@angular/core';
import { IonicApp, IonicErrorHandler, IonicModule } from 'ionic-angular';
import { SplashScreen } from '@ionic-native/splash-screen';
import { HttpModule } from '@angular/http';
import { StatusBar } from '@ionic-native/status-bar';

import { BrMaskerModule } from 'brmasker-ionic-3';

import { MyApp } from './app.component';
import { LoginPage } from './../components/principal/pages/login/login';
import { SalaPage } from '../components/sala/sala';
import { CriarSalaPage } from '../components/sala/criar-sala/criar-sala';
import { HomePage } from '../components/home/home';
import { ResponsavelPage } from '../components/responsavel/responsavel';
import { CriarResponsavelPage } from '../components/responsavel/criar-responsavel/criar-responsavel';
import { AlunoPage } from '../components/aluno/aluno';
import { CriarAlunoPage } from '../components/aluno/criar-aluno/criar-aluno';
import { ProfessorPage } from '../components/professor/professor';
import { CriarProfessorPage } from '../components/professor/criar-professor/criar-professor';
import { SalasPage } from '../components/notificacao/salas/salas';
import { NotificacaoPage } from '../components/notificacao/notificacao';
import { CriarNotificacaoPage } from '../components/notificacao/criar-notificacao/criar-notificacao';
import { AlunosPage } from '../components/notificacao/alunos/alunos';
import { CadastroPage } from '../components/principal/pages/cadastro/cadastro';
import { ListarNotificacaoPage } from '../components/notificacao/listar-notificacao/listar-notificacao';
import { ExibirNotificacaoPage } from '../components/notificacao/listar-notificacao/exibir-notificacao/exibir-notificacao';
import { OneSignal } from '@ionic-native/onesignal';


@NgModule({
  declarations: [
    MyApp,
    HomePage,
    LoginPage,
    SalaPage,
    CriarSalaPage,
    ResponsavelPage,
    CriarResponsavelPage,
    AlunoPage,
    CriarAlunoPage,
    ProfessorPage,
    CriarProfessorPage,
    NotificacaoPage,
    CriarNotificacaoPage,
    SalasPage,
    AlunosPage,
    CadastroPage,
    ListarNotificacaoPage,
    ExibirNotificacaoPage,
    TelefonePipe
  ],
  imports: [
    BrowserModule,
    HttpModule,
    BrMaskerModule,
    IonicModule.forRoot(MyApp, {backButtonText: 'Voltar'})
  ],
  bootstrap: [IonicApp],
  entryComponents: [
    MyApp,
    HomePage,
    LoginPage,
    SalaPage,
    CriarSalaPage,
    ResponsavelPage,
    CriarResponsavelPage,
    AlunoPage,
    CriarAlunoPage,
    ProfessorPage,
    CriarProfessorPage,
    NotificacaoPage,
    CriarNotificacaoPage,
    SalasPage,
    AlunosPage,
    CadastroPage,
    ListarNotificacaoPage,
    ExibirNotificacaoPage
  ],
  providers: [
    StatusBar,
    SplashScreen,
    OneSignal,
    { provide: ErrorHandler, useClass: IonicErrorHandler }
  ]
})
export class AppModule { }