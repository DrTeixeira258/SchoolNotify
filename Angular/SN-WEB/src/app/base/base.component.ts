import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
declare var $: any;

export abstract class BaseComponent {

    public mask = ['(', /[0-9]/, /\d/, ')', ' ', /\d/, /\d/, /\d/, /\d/, /\d/, '-', /\d/, /\d/, /\d/, /\d/];

    constructor() { }

    converterTelefone(telefone: string) {
        let telefoneAux: number = Number.parseInt(telefone.replace("(","").replace(")","").replace(" ","").replace("-",""));
        return telefoneAux;
    }

    showNotification(from?: string, align?: string, sucesso?: boolean) {
        let mensagem = '';
        let tipo = '';

        if (sucesso) {
            mensagem = "Operação realizada com sucesso!";
            tipo = "success";
        } else {
            mensagem = "Ocorreu um erro ao realizar a operação!";
            tipo = "danger";
        }

        $.notify({
            icon: "",
            message: mensagem

        },
            {
                type: tipo,
                timer: 2000,
                placement: {
                    from: from,
                    align: align
                }
            });
    }

    showNotificationValidation() {
        $.notify({
            icon: "",
            message: "Preencha todos os campos obrigatórios"

        },
            {
                type: "warning",
                timer: 2000,
                placement: {
                    from: "top",
                    align: "right"
                }
            });
    }

    showCustomNotification(tipo: string, mensagem: string) {
        $.notify({
            icon: "",
            message: mensagem

        },
            {
                type: tipo,
                timer: 2000,
                placement: {
                    from: "top",
                    align: "right"
                }
            });
    }
}