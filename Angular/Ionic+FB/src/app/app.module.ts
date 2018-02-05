import { BrowserModule } from '@angular/platform-browser';
import { ErrorHandler, NgModule } from '@angular/core';
import { IonicApp, IonicErrorHandler, IonicModule } from 'ionic-angular';
import { SplashScreen } from '@ionic-native/splash-screen';
import { HttpModule } from '@angular/http';
import { StatusBar } from '@ionic-native/status-bar';

//FIREBASE
import { FirebaseConfig } from '../environments/firebase.config';
import { AngularFireModule } from 'angularfire2/index';

import { MyApp } from './app.component';
import { LoginPage } from './../components/principal/pages/login/login';
import { SalaPage } from '../components/sala/sala';
import { CriarSalaPage } from '../components/sala/criar-sala/criar-sala';
import { HomePage } from '../components/home/home';
import { ResponsavelPage } from '../components/responsavel/responsavel';
import { CriarResponsavelPage } from '../components/responsavel/criar-responsavel/criar-responsavel';
import { AlunoPage } from '../components/aluno/aluno';
import { CriarAlunoPage } from '../components/aluno/criar-aluno/criar-aluno';


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
    CriarAlunoPage
  ],
  imports: [
    BrowserModule,
    HttpModule,
    IonicModule.forRoot(MyApp),
    AngularFireModule.initializeApp(FirebaseConfig)
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
    CriarAlunoPage
  ],
  providers: [
    StatusBar,
    SplashScreen,
    { provide: ErrorHandler, useClass: IonicErrorHandler }
  ]
})
export class AppModule { }