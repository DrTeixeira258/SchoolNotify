import { Component, OnInit } from '@angular/core';
import { AlunoService } from 'services/aluno.service';
import { Aluno } from 'models/aluno.model';
import { Router } from '@angular/router';
import { BaseComponent } from 'app/base/base.component';

@Component({
    selector: 'listar-aluno',
    templateUrl: './listar-aluno.component.html',
    styleUrls: ['./listar-aluno.component.scss'],
    providers: [AlunoService]
})

export class ListarAlunoComponent extends BaseComponent implements OnInit {

    activeLoader: boolean = false;
    alunos: Aluno[] = [];

    constructor(private alunoService: AlunoService, private router: Router) {
        super();
    }

    ngOnInit() {
        this.buscarAlunos();
    }

    buscarAlunos() {
        this.activeLoader = true;
        this.alunoService.obterAlunos().subscribe(
            data => {
                this.alunos = data;
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

    criarAluno() {
        this.router.navigate(['apps/criar-aluno'], { skipLocationChange: true });
    }

    editarAluno(idAluno) {
        this.router.navigate(['apps/criar-aluno', idAluno], { skipLocationChange: true });
    }

    deletar(aluno) {
        this.activeLoader = true;
        this.alunoService.deletarAluno(aluno).subscribe(
            data => {
                this.showNotification("top", "right", true);
            },
            error => {
                this.activeLoader = false;
                this.showNotification("top", "right", false);
            },
            () => {
                this.activeLoader = false;
                this.buscarAlunos();
            }
        );
    }
}