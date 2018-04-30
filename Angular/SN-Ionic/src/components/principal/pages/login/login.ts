import { MyApp } from './../../../../app/app.component';
import { Component } from '@angular/core';
import { SplashScreen } from '@ionic-native/splash-screen';
import { NavController } from 'ionic-angular';
import { LoadingController } from 'ionic-angular/components/loading/loading-controller';
import { AlertController } from 'ionic-angular/components/alert/alert-controller';
import { Uteis } from '../../../uteis';
import { Usuario } from '../../../../models/usuario.model';
import { HomePage } from '../../../home/home';
import { UsuarioService } from '../../../../services/usuario.service';
import { CadastroPage } from '../cadastro/cadastro';

@Component({
    selector: 'page-login',
    templateUrl: 'login.html',
    providers: [UsuarioService]
})

export class LoginPage extends Uteis {

    usuario: Usuario = new Usuario();

    constructor(
        public loadingCtrl: LoadingController,
        public alertCtrl: AlertController,
        public navCtrl: NavController,
        public splashScreen: SplashScreen,
        private usuarioService: UsuarioService) {
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

}