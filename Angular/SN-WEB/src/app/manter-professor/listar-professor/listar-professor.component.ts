import { Component, OnInit } from '@angular/core';
import { ProfessorService } from 'services/professor.service';
import { Professor } from 'models/professor.model';
import { Router } from '@angular/router';
import { BaseComponent } from 'app/base/base.component';
declare var $: any;

@Component({
    selector: 'listar-professor',
    templateUrl: './listar-professor.component.html',
    styleUrls: ['./listar-professor.component.scss'],
    providers: [ProfessorService]
})

export class ListarProfessorComponent extends BaseComponent implements OnInit {

    activeLoader: boolean = false;
    professores: Professor[] = [];

    constructor(private professorService: ProfessorService, private router: Router) {
        super();
    }

    ngOnInit() {
        this.buscarProfessores();
    }

    buscarProfessores() {
        this.activeLoader = true;
        this.professorService.obterProfessores().subscribe(
            data => {
                this.professores = data;
            },
            error => {
                this.showNotification("top", "right", false);
            },
            () => {
                this.activeLoader = false;
            }
        );
    }

    criarProfessor() {
        this.router.navigate(['criar-professor'], { skipLocationChange: true });
    }

    editarProfessor(idProfessor) {
        this.router.navigate(['criar-professor', idProfessor], { skipLocationChange: true });
    }

    deletar(professor) {
        this.activeLoader = true;
        this.professorService.deletarProfessor(professor).subscribe(
            data => {
                this.showNotification("top", "right", true);
            },
            error => {
                this.showNotification("top", "right", false);
            },
            () => {
                this.activeLoader = false;
                this.buscarProfessores();
            }
        );
    }
}