import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { Responsavel } from 'models/responsavel.model';
import { Router, ActivatedRoute } from '@angular/router';
import { BaseComponent } from 'app/base/base.component';
import { ResponsavelService } from 'services/responsavel.service';

@Component({
    selector: 'criar-responsavel',
    templateUrl: './criar-responsavel.component.html',
    styleUrls: ['./criar-responsavel.component.scss'],
    providers: [ResponsavelService]
})
export class CriarResponsavelComponent extends BaseComponent implements OnInit {

    responsavel: Responsavel = new Responsavel();
    idResponsavel: number = null;
    activeLoader: boolean = false;

    constructor(private responsavelService: ResponsavelService,
        private router: Router,
        private route: ActivatedRoute) {
        super();
    }

    ngOnInit() {
        this.route.params.subscribe(params => {
            this.idResponsavel = +params['idResponsavel']; // (+) converts string 'id' to a number

            if (this.idResponsavel) {
                this.obterResponsavelPorId();
            }
        });
    }

    obterResponsavelPorId() {
        this.activeLoader = true;
        this.responsavelService.obterResponsavelPorId(this.idResponsavel).subscribe(
            data => {
                this.responsavel = data;
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
        if (this.responsavel.nome && this.responsavel.email && this.responsavel.telefone)
            return true;
        else
            return false;
    }

    voltar() {
        this.router.navigate(["responsavel"]);
    }

    salvar() {
        if (this.validar()) {
            this.activeLoader = true;
            this.responsavelService.salvarResponsavel(this.responsavel).subscribe(
                data => {
                    this.responsavel = new Responsavel();
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