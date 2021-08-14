import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { AccountService } from '@app/_services';

@Component({ templateUrl: 'list.component.html' })
export class ListComponent implements OnInit {
    form: FormGroup;
    id: string;
    loading = false;
    submitted = false;

    constructor(
        private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private accountService: AccountService
    ) {}

    ngOnInit() {
        this.id = this.route.snapshot.params['id'];
        
        this.form = this.formBuilder.group({
            remetente: ['', Validators.required],
            email: ['', Validators.required],
            enderecoOrigem: ['', Validators.required],
            cepOrigem: ['', Validators.required],
            cidadeOrigem: ['', Validators.required],
            estadoOrigem: ['', Validators.required],
            peso: ['', Validators.required],
            tamanho: ['', Validators.required],
            destinatario: ['', Validators.required],
            enderecoDestino: ['', Validators.required],
            cepDestino: ['', Validators.required],
            cidadeDestino: ['', Validators.required],
            estadoDestino: ['', Validators.required]
        });
    }

    // convenience getter for easy access to form fields
    get f() { return this.form.controls; }

    onSubmit() {
        this.submitted = true;

        // stop here if form is invalid
        if (this.form.invalid) {
            return;
        }

        this.loading = true;

        this.pesquisaCodigo();  
    }

    private pesquisaCodigo() {
        /*this.accountService.register(this.form.value)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('User added successfully', { keepAfterRouteChange: true });
                    this.router.navigate(['.', { relativeTo: this.route }]);
                },
                error => {
                    this.alertService.error(error);
                    this.loading = false;
                });*/
    }
}