import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { Sala } from 'models/sala.model';
import { SalaService } from 'services/sala.service';

@Component({
  selector: 'criar-sala',
  templateUrl: './criar-sala.component.html',
  styleUrls: ['./criar-sala.component.scss'],
  providers: [SalaService]
})
export class CriarSalaComponent implements OnInit {

  sala: Sala = new Sala();

  constructor(private salaService: SalaService) { }

  ngOnInit() {
  }

  salvar() {
    alert(this.sala.nome + "/" + this.sala.serie);
    // this.salaService.salvarSala(this.sala).subscribe(
    //   data => {
    //     alert("Sala Salva!");
    //   },
    //   error => {
    //     alert("Erro!")
    //   }
    // );
  }
}