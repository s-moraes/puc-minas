import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { CotacaoRoutingModule } from './cotacao-routing.module';
import { LayoutComponent } from './layout.component';
import { ListComponent } from './list.component'

@NgModule({
    imports: [
        CommonModule,
        ReactiveFormsModule,
        CotacaoRoutingModule
    ],
    declarations: [
        LayoutComponent,
        ListComponent
    ]
})
export class CotacaoModule { }