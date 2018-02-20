import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { SalaService } from 'services/sala.service';
import { ProfessorService } from './../../../services/professor.service';
import { Sala } from 'models/sala.model';
import { Professor } from 'models/professor.model';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'criar-sala',
  templateUrl: './criar-sala.component.html',
  styleUrls: ['./criar-sala.component.scss'],
  providers: [SalaService, ProfessorService]
})
export class CriarSalaComponent implements OnInit {

  @ViewChild('teste') teste : ElementRef;
  sala: Sala = new Sala();
  professores: Professor[] = [];
  idSala: number = null;

  constructor(private salaService: SalaService,
    private professorService: ProfessorService,
    private router: Router,
    private route: ActivatedRoute) {

  }

  ngOnInit() {
    this.obterProfessores();
    this.route.params.subscribe(params => {
      this.idSala = +params['idSala']; // (+) converts string 'id' to a number

      if (this.idSala) {
        this.obterProfessor();
      }
    });
  }

  obterProfessores() {
    this.professorService.obterProfessores().subscribe(
      data => {
        this.professores = data;
      }
    );
  }

  obterProfessor() {
    this.salaService.obterSalaPorId(this.idSala).subscribe(
      data => {
        this.sala = data;
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

  voltar() {
    this.router.navigate(["sala"]);
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