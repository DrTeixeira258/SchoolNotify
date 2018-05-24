import { Component, OnInit } from '@angular/core';
import { SalaService } from 'services/sala.service';
import { Sala } from 'models/sala.model';
import { Router } from '@angular/router';
import { BaseComponent } from 'app/base/base.component';

@Component({
    selector: 'listar-sala',
    templateUrl: './listar-sala.component.html',
    styleUrls: ['./listar-sala.component.scss'],
    providers: [SalaService]
})

export class ListarSalaComponent extends BaseComponent implements OnInit {

    activeLoader: boolean = false;
    salas: Sala[] = [];

    constructor(private salaService: SalaService, private router: Router) {
        super();
    }

    ngOnInit() {
        this.buscarSalas();
    }

    buscarSalas() {
        this.activeLoader = true;
        this.salaService.obterSalas().subscribe(
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

    criarSala() {
        this.router.navigate(['apps/criar-sala', "Criar"], { skipLocationChange: true });
    }

    editarSala(idSala) {
        this.router.navigate(['apps/criar-sala', "Alterar", idSala], { skipLocationChange: true });
    }

    deletar(sala) {
        this.activeLoader = true;
        this.salaService.deletarSala(sala).subscribe(
            data => {
                if (data)
                    this.showNotification("top", "right", true);
                else 
                    this.showCustomNotification("warning","A sala não pode ser deletada porque existe(m) aluno(s) vinculado(s) a ela.")
            },
            error => {
                this.activeLoader = false;
                this.showNotification("top", "right", false);
            },
            () => {
                this.activeLoader = false;
                this.buscarSalas();
            }
        );
    }
}