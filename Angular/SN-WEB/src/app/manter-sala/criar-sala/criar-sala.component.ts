import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { SalaService } from 'services/sala.service';
import { ProfessorService } from './../../../services/professor.service';
import { Sala } from 'models/sala.model';
import { Professor } from 'models/professor.model';

@Component({
  selector: 'criar-sala',
  templateUrl: './criar-sala.component.html',
  styleUrls: ['./criar-sala.component.scss'],
  providers: [SalaService, ProfessorService]
})
export class CriarSalaComponent implements OnInit {

  sala: Sala = new Sala();
  professores: Professor[] = [];

  constructor(private salaService: SalaService, private professorService: ProfessorService) { }

  ngOnInit() {
    this.obterProfessores();
  }

  obterProfessores() {
    this.professorService.obterProfessores().subscribe(
      data => {
        this.professores = data;
      }
    );
  }

  obterNomeProfessor(id: number) {
    let nomeProfessor = this.professores.find(x => x.id == id).nome;
    return nomeProfessor;
  }

  validar() {
    if (this.sala.nome && this.sala.serie && this.sala.idsProfessores.length > 0)
      return true;
    else
      return false;
  }

  salvar() {
    console.log(this.sala);
    if (this.validar()) {
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
}