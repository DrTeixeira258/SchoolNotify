import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { LoadingController } from 'ionic-angular/components/loading/loading-controller';
import { AlertController } from 'ionic-angular/components/alert/alert-controller';
import { Uteis } from '../../../uteis';
import { Usuario } from '../../../../models/usuario.model';
import { UsuarioService } from '../../../../services/usuario.service';
import { LoginPage } from '../login/login';

@Component({
    selector: 'page-cadastro',
    templateUrl: 'cadastro.html',
    providers: [UsuarioService]
})

export class CadastroPage extends Uteis {

    usuario: Usuario = new Usuario();
    confirmarSenha: string = "";
    telefone: string = "";

    constructor(
        public loadingCtrl: LoadingController,
        public alertCtrl: AlertController,
        public navCtrl: NavController,
        private usuarioService: UsuarioService) {
        super(loadingCtrl, alertCtrl);
    }

    ionViewWillEnter() {
    }

    private cadastrar(valido) {
        if (valido) {
            if (this.usuario.senha == this.confirmarSenha) {
                this.criarLoader();
                this.usuario.telefone = this.converterTelefone(this.telefone);
                this.usuarioService.cadastrar(this.usuario).subscribe(
                    data => {
                        this.fecharLoader();
                        if (data) {
                            this.exibirConfirmarcao("Cadastro", "Cadastro efetuado com sucesso!");
                        } else {
                            this.exibirMensagem("Cadastro", "Cadastro não autorizado.");
                        }
                    },
                    error => {
                        this.fecharLoader();
                        this.exibirMensagem("Cadastro", "Não foi possivel efetuar o cadastro.");
                    }
                );
            }
            else {
                this.exibirMensagem("Atencao", "A confirmacão da senha não confere.");
            }
        }
        else {
            this.exibirMensagem("Atencao!", "Preencha todos os campos.");
        }
    }

    exibirConfirmarcao(titulo: string, subTitulo: string) {
        this.alert = this.alertCtrl.create({
            title: titulo,
            subTitle: subTitulo,
            buttons: [
                {
                    text: 'OK',
                    handler: () => {
                        this.navCtrl.setRoot(LoginPage);
                    }
                }
            ]
        });
        this.alert.present();
    }

}