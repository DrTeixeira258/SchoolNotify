import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { SalaService } from 'services/sala.service';
import { ResponsavelService } from './../../../services/responsavel.service';
import { AlunoService } from './../../../services/aluno.service';
import { Sala } from 'models/sala.model';
import { Responsavel } from 'models/responsavel.model';
import { Router, ActivatedRoute } from '@angular/router';
import { BaseComponent } from 'app/base/base.component';
import { Aluno } from 'models/aluno.model';

@Component({
    selector: 'criar-aluno',
    templateUrl: './criar-aluno.component.html',
    styleUrls: ['./criar-aluno.component.scss'],
    providers: [SalaService, ResponsavelService, AlunoService]
})
export class CriarAlunoComponent extends BaseComponent implements OnInit {

    salas: Sala[] = [];
    responsaveis: Responsavel[] = [];
    aluno: Aluno = new Aluno();
    idAluno: number = null;
    activeLoader: boolean = false;
    operacao: string = '';
    maskData = [/[0-9]/, /\d/, '/',/\d/, /\d/, '/', /\d/, /\d/, /\d/, /\d/];
    dataNascimento: string = '';
    teste: string = '';
    teste3: string = '';

    constructor(private salaService: SalaService,
        private responsavelService: ResponsavelService,
        private alunoService: AlunoService,
        private router: Router,
        private route: ActivatedRoute) {
        super();
    }

    ngOnInit() {
        this.obterSalas();
        this.obterResponsaveis();
        this.route.params.subscribe(params => {
            this.operacao = params['operacao'];
            this.idAluno = +params['idAluno']; // (+) converts string 'id' to a number

            if (this.idAluno) {
                this.obterAlunoPorId();
            }
        });
    }

    converterData() {
        debugger
        let aux = this.dataNascimento.replace(/\//g,'-');
        this.dataNascimento = aux.substring(3,6);
        this.dataNascimento += aux.substring(0,3);
        this.dataNascimento += aux.substring(6);

        this.aluno.dataNascimento = new Date(this.dataNascimento);
    }

    obterResponsaveis() {
        this.activeLoader = true;
        this.responsavelService.obterResponsaveis().subscribe(
            data => {
                this.responsaveis = data;
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

    obterSalas() {
        this.activeLoader = true;
        this.salaService.obterSalasComProfessores().subscribe(
            data => {
                this.salas = data;
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

    obterAlunoPorId() {
        this.activeLoader = true;
        this.alunoService.obterAlunoPorId(this.idAluno).subscribe(
            data => {
                this.aluno = data;
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
        if (this.aluno.nome && this.aluno.matricula && this.aluno.sexo && this.aluno.idResponsavel && this.aluno.idSala)
            return true;
        else
            return false;
    }

    voltar() {
        this.router.navigate(["apps/aluno"]);
    }

    salvar() {
        this.converterData();
        if (this.validar()) {
            if (this.aluno.dataNascimento < new Date()) {
                this.activeLoader = true;
                this.alunoService.salvarAluno(this.aluno).subscribe(
                    data => {
                        this.aluno = new Aluno();
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
                this.showCustomNotification("warning","A data de nascimento deve ser menor que a data de hoje!");
            }
        } else {
            this.showNotificationValidation();
        }
    }

}