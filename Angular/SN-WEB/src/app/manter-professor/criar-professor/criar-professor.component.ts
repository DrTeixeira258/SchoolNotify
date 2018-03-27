import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { ProfessorService } from './../../../services/professor.service';
import { Professor } from 'models/professor.model';
import { Router, ActivatedRoute } from '@angular/router';
import { BaseComponent } from 'app/base/base.component';

@Component({
    selector: 'criar-professor',
    templateUrl: './criar-professor.component.html',
    styleUrls: ['./criar-professor.component.scss'],
    providers: [ProfessorService]
})

export class CriarProfessorComponent extends BaseComponent implements OnInit {

    professor: Professor = new Professor();
    idProfessor: number = null;
    activeLoader: boolean = false;

    constructor(private professorService: ProfessorService,
        private router: Router,
        private route: ActivatedRoute) {
        super();
    }

    ngOnInit() {
        this.route.params.subscribe(params => {
            this.idProfessor = +params['idProfessor']; // (+) converts string 'id' to a number

            if (this.idProfessor) {
                this.obterProfessorPorId();
            }
        });
    }

    obterProfessorPorId() {
        this.activeLoader = true;
        this.professorService.obterProfessorPorId(this.idProfessor).subscribe(
            data => {
                this.professor = data;
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

    validar() {
        if (this.professor.nome && this.professor.email && this.professor.matricula)
            return true;
        else
            return false;
    }

    voltar() {
        this.router.navigate(["apps/professor"]);
    }

    salvar() {
        this.professor.telefone = this.converterTelefone(this.professor.telefone.toString());
        if (this.validar()) {
            this.activeLoader = true;
            this.professorService.salvarProfessor(this.professor).subscribe(
                data => {
                    this.professor = new Professor();
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