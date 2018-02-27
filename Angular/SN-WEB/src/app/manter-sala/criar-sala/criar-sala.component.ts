import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { SalaService } from 'services/sala.service';
import { ProfessorService } from './../../../services/professor.service';
import { Sala } from 'models/sala.model';
import { Professor } from 'models/professor.model';
import { Router, ActivatedRoute } from '@angular/router';
import { BaseComponent } from 'app/base/base.component';

@Component({
  selector: 'criar-sala',
  templateUrl: './criar-sala.component.html',
  styleUrls: ['./criar-sala.component.scss'],
  providers: [SalaService, ProfessorService]
})
export class CriarSalaComponent extends BaseComponent implements OnInit {

  sala: Sala = new Sala();
  professores: Professor[] = [];
  idSala: number = null;
  activeLoader: boolean = false;

  constructor(private salaService: SalaService,
    private professorService: ProfessorService,
    private router: Router,
    private route: ActivatedRoute) {
    super();
  }

  ngOnInit() {
    this.obterProfessores();
    this.route.params.subscribe(params => {
      this.idSala = +params['idSala']; // (+) converts string 'id' to a number

      if (this.idSala) {
        this.obterSalaPorId();
      }
    });
  }

  obterProfessores() {
    this.activeLoader = true;
    this.professorService.obterProfessores().subscribe(
      data => {
        this.professores = data;
      },
      error => {
        this.activeLoader = false;
        this.showNotification("top", "right", false);
      },
      () => {
        this.activeLoader = false;
      }
    );
  }

  obterSalaPorId() {
    this.activeLoader = true;
    this.salaService.obterSalaPorId(this.idSala).subscribe(
      data => {
        this.sala = data;
      },
      error => {
        this.activeLoader = false;
        this.showNotification("top", "right", false);
      },
      () => {
        this.activeLoader = false;
      }
    );
  }

  obterNomeProfessor(id: number) {
    let professor = this.professores.find(x => x.id == id);
    if (professor)
      return professor.nome;
    return "";

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
    if (this.validar()) {
      this.activeLoader = true;
      this.salaService.salvarSala(this.sala).subscribe(
        data => {
          this.sala = new Sala();
        },
        error => {
          this.activeLoader = false;
          this.showNotification("top", "right", false);
        },
        () => {
          this.activeLoader = false;
          this.showNotification("top", "right", true);
        }
      );
    } else {
      this.showNotificationValidation();
    }
  }

}