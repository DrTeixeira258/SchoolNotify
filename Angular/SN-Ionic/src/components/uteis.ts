import { LoadingController, AlertController, Loading, Alert } from "ionic-angular";

export class Uteis {

    loader: Loading;
    alert: Alert;
    nomeSelecionado: string = null;
    cargoSelecionado: string = null;

    constructor(
        public loadingCtrl: LoadingController,
        public alertCtrl: AlertController) {

    }

    public criarLoader() {
        if (!this.loader) {
            this.loader = this.loadingCtrl.create({
                content: 'Aguarde...',
                dismissOnPageChange: false
            });
            this.loader.present();
        }
    }

    public fecharLoader() {
        if (this.loader) {
            this.loader.dismiss();
            this.loader = null;
        }
    }

    public exibirMensagem(titulo: string, subTitulo: string) {
        this.alert = this.alertCtrl.create({
            title: titulo,
            subTitle: subTitulo,
            buttons: ['Ok']
        });
        this.alert.present();
    }

    converterTelefone(telefone: string) {
        let telefoneAux: number = Number.parseInt(telefone.replace("(", "").replace(")", "").replace(" ", "").replace("-", ""));
        return telefoneAux;
    }
}