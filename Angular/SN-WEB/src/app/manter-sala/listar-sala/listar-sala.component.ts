import { Component, OnInit } from '@angular/core';
import { SalaService } from 'services/sala.service';
import { Sala } from 'models/sala.model';
import { Router } from '@angular/router';

@Component({
    selector: 'listar-sala',
    templateUrl: './listar-sala.component.html',
    styleUrls: ['./listar-sala.component.scss'],
    providers: [SalaService]
})

export class ListarSalaComponent implements OnInit {

    salas: Sala[] = [];

    constructor(private salaService: SalaService, private router: Router) { }

    ngOnInit() {
        this.buscarSalas();
    }

    buscarSalas() {
        this.salaService.obterSalas().subscribe(
            data => {
                this.salas = data;
            }
        );
    }

    criarSala() {
        this.router.navigate(['criar-sala'], { skipLocationChange: true });
    }

    editarSala(idSala) {
        this.router.navigate(['criar-sala', idSala], { skipLocationChange: true });
    }

    deletar(sala) {
        this.salaService.deletarSala(sala).subscribe(
            data => {
                alert("FON");
            }
        );
    }
}