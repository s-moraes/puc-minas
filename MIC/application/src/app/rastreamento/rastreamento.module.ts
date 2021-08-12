import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { RastreamentoRoutingModule } from './rastreamento-routing.module';
import { LayoutComponent } from './layout.component';
import { ListComponent } from './list.component';

@NgModule({
    imports: [
        CommonModule,
        ReactiveFormsModule,
        RastreamentoRoutingModule
    ],
    declarations: [
        LayoutComponent,
        ListComponent
    ]
})
export class RastreamentoModule { }