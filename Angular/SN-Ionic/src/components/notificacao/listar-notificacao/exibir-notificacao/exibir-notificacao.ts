import { NavController, NavParams, ViewController } from 'ionic-angular';
import { Component } from '@angular/core';
import { LoadingController } from 'ionic-angular/components/loading/loading-controller';
import { AlertController } from 'ionic-angular/components/alert/alert-controller';
import { Uteis } from '../../../uteis';
import { NotificacaoService } from '../../../../services/notificacao.service';
import { Notificacao } from '../../../../models/notificacao.model';

@Component({
  selector: 'exibir-notificacao-page',
  templateUrl: 'exibir-notificacao.html',
  providers: [NotificacaoService]
})

export class ExibirNotificacaoPage extends Uteis {

  idNotificacao: number = null;
  notificacao: Notificacao = null;

  constructor(public loadingCtrl: LoadingController,
    public alertCtrl: AlertController,
    public navCtrl: NavController,
    public viewCtrl: ViewController,
    public navParams: NavParams,
    private notificacaoService: NotificacaoService) {
    super(loadingCtrl, alertCtrl);
    this.idNotificacao = this.navParams.get("idNotificacao");
  }

  ionViewDidLoad() {
    this.buscarNotificacao();
  }

  buscarNotificacao() {
    this.criarLoader();
    this.notificacaoService.BuscarNotificacaoPorId(this.idNotificacao).subscribe(
      data =>  {
        this.notificacao = data;
        this.fecharLoader();
        console.log(this.notificacao)
      },
      error => {
        this.fecharLoader();
        this.exibirMensagem("Ops!","Nao foi possivel obter a notificacao.");
      }
    )
  }

}