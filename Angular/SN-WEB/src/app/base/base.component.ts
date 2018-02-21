import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
declare var $: any;

export abstract class BaseComponent {

    constructor() { }

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
}