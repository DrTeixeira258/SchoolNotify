import { Component, OnInit } from '@angular/core';
import { ResponsavelService } from 'services/responsavel.service';
import { Responsavel } from 'models/responsavel.model';
import { Router } from '@angular/router';
import { BaseComponent } from 'app/base/base.component';

@Component({
    selector: 'listar-responsavel',
    templateUrl: './listar-responsavel.component.html',
    styleUrls: ['./listar-responsavel.component.scss'],
    providers: [ResponsavelService]
})

export class ListarResponsavelComponent extends BaseComponent implements OnInit {

    activeLoader: boolean = false;
    responsaveis: Responsavel[] = [];

    constructor(private responsavelService: ResponsavelService, private router: Router) {
        super();
    }

    ngOnInit() {
        this.buscarResponsaveis();
    }

    buscarResponsaveis() {
        this.activeLoader = true;
        this.responsavelService.obterResponsaveis().subscribe(
            data => {
                this.responsaveis = data;
            },
            error => {
                this.showNotification("top", "right", false);
            },
            () => {
                this.activeLoader = false;
            }
        );
    }

    criarResponsavel() {
        this.router.navigate(['criar-responsavel'], { skipLocationChange: true });
    }

    editarResponsavel(idResponsavel) {
        this.router.navigate(['criar-responsavel', idResponsavel], { skipLocationChange: true });
    }

    deletar(responsavel) {
        this.activeLoader = true;
        this.responsavelService.deletarResponsavel(responsavel).subscribe(
            data => {
                if (data)
                    this.showNotification("top", "right", true);
                else 
                    this.showCustomNotification("warning","O reponável não pode ser deletado porque ele possui aluno(s).")
            },
            error => {
                this.showNotification("top", "right", false);
            },
            () => {
                this.activeLoader = false;
                this.buscarResponsaveis();
            }
        );
    }
}