import { MyApp } from './../../../../app/app.component';
import { Component } from '@angular/core';
import { SplashScreen } from '@ionic-native/splash-screen';
import { Platform, NavController } from 'ionic-angular';
import { OneSignal } from '@ionic-native/onesignal';
import { LoadingController } from 'ionic-angular/components/loading/loading-controller';
import { AlertController } from 'ionic-angular/components/alert/alert-controller';
import { Uteis } from '../../../uteis';
import { Usuario } from '../../../../models/usuario.model';
import { HomePage } from '../../../home/home';
import { UsuarioService } from '../../../../services/usuario.service';
import { CadastroPage } from '../cadastro/cadastro';
import { Token } from '../../../../models/token.model';
import { TokenService } from '../../../../services/token.service';
import { ListarNotificacaoPage } from '../../../notificacao/listar-notificacao/listar-notificacao';

@Component({
    selector: 'page-login',
    templateUrl: 'login.html',
    providers: [UsuarioService, TokenService]
})

export class LoginPage extends Uteis {

    usuario: Usuario = new Usuario();

    constructor(
        public loadingCtrl: LoadingController,
        public alertCtrl: AlertController,
        public navCtrl: NavController,
        public splashScreen: SplashScreen,
        public platform: Platform,
        public oneSignal: OneSignal,
        private usuarioService: UsuarioService,
        private tokenService: TokenService) {
        super(loadingCtrl, alertCtrl);
    }

    ionViewWillEnter() {
        this.splashScreen.hide();
    }

    private logar() {
        this.criarLoader();
        this.usuarioService.logar(this.usuario).subscribe(
            data => {
                this.fecharLoader();
                if (data) {
                    localStorage.setItem("usuario", JSON.stringify(data));
                    MyApp.usuario = data;
                    MyApp.montarMenu();
                    // this.initializeOnesignal();
                    this.navCtrl.setRoot(HomePage);
                } else {
                    this.exibirMensagem("Login", "Usuario e/ou senha incorreto(s).");
                }
            },
            error => {
                this.fecharLoader();
                this.exibirMensagem("Login", "Nao foi possivel efetuar o login.");
            }
        );
    }

    public goCadastro() {
        this.navCtrl.push(CadastroPage);
    }

    initializeOnesignal() {
        window["plugins"].OneSignal.startInit("c2efd703-7e75-475b-a138-52a1d18d571d", "873655996905")
            .handleNotificationOpened(data => {
                this.navCtrl.setRoot(ListarNotificacaoPage,
                    {
                        idNotificacao: data.notification.payload.additionalData.idNotificacao
                    });
            })
            .endInit();

        this.oneSignal.getIds().then(
            data => {
                let token = new Token();
                token.userId = data.userId;
                token.telefoneResp = MyApp.usuario.telefone;
                this.tokenService.SalvarToken(token).subscribe();
            }
        );
    }
}