import { NavController, NavParams, ViewController } from 'ionic-angular';
import { Component } from '@angular/core';
import { LoadingController } from 'ionic-angular/components/loading/loading-controller';
import { AlertController } from 'ionic-angular/components/alert/alert-controller';
import { Uteis } from '../../../uteis';

@Component({
  selector: 'exibir-notificacao-page',
  templateUrl: 'exibir-notificacao.html',
  providers: []
})

export class ExibirNotificacaoPage extends Uteis {

  constructor(public loadingCtrl: LoadingController,
    public alertCtrl: AlertController,
    public navCtrl: NavController,
    public viewCtrl: ViewController,
    public navParams: NavParams) {
    super(loadingCtrl, alertCtrl);
  }

  ionViewDidLoad() {
    
  }

}