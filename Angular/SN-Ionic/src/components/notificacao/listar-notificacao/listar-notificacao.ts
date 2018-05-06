import { Notificacao } from './../../../models/notificacao.model';
import { NavController, NavParams, ViewController } from 'ionic-angular';
import { Component } from '@angular/core';
import { LoadingController } from 'ionic-angular/components/loading/loading-controller';
import { AlertController } from 'ionic-angular/components/alert/alert-controller';
import { Uteis } from '../../uteis';
import { ExibirNotificacaoPage } from './exibir-notificacao/exibir-notificacao';
import { NotificacaoService } from '../../../services/notificacao.service';
import { MyApp } from '../../../app/app.component';

@Component({
  selector: 'listar-notificacao-page',
  templateUrl: 'listar-notificacao.html',
  providers: [NotificacaoService]
})

export class ListarNotificacaoPage extends Uteis {

  public notificacoes: Notificacao[] = [];
  public notificacoesMesAtual: Notificacao[] = [];
  public notificacoesOutras: Notificacao[] = [];


  constructor(public loadingCtrl: LoadingController,
    public alertCtrl: AlertController,
    public navCtrl: NavController,
    public viewCtrl: ViewController,
    public navParams: NavParams,
    private notificacaoService: NotificacaoService) {
    super(loadingCtrl, alertCtrl);
  }

  ionViewDidLoad() {
    this.obterNotificacoes();
  }

  obterNotificacoes() {
    this.criarLoader();
    this.notificacaoService.BuscarNotificacoesResponsavel(MyApp.usuario.id).subscribe(
      data => {
        this.notificacoes = data;
      },
      error => {
        this.fecharLoader();
        this.exibirMensagem("Ops!","Nao foi possivel obter as notificacoes.");
      },
      () => {
        this.filtrarNotificacoes();
        this.fecharLoader();
      }
    );
  }

  async ajustarDatasNotificacoes() {
    this.notificacoes.forEach(notificacao => {
      notificacao.data = new Date(notificacao.data);
    });
  }

  async filtrarNotificacoes() {
    let dataHJ = new Date();

    await this.ajustarDatasNotificacoes();

    this.notificacoesMesAtual = [...this.notificacoes.filter(x => x.data.getMonth() == dataHJ.getMonth())];
    this.notificacoesOutras = [...this.notificacoes.filter(x => x.data.getMonth() != dataHJ.getMonth())];
  }
  
  exibirNotificacao(idNotificacao) {
    this.navCtrl.push(ExibirNotificacaoPage,
      {
        idNotificacao: idNotificacao
      });
  }
}