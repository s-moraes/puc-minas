import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { DepositoRoutingModule } from './deposito-routing.module';
import { LayoutComponent } from './layout.component';
import { ListComponent } from './list.component'

@NgModule({
    imports: [
        CommonModule,
        ReactiveFormsModule,
        DepositoRoutingModule
    ],
    declarations: [
        LayoutComponent,
        ListComponent
    ]
})
export class DepositoModule { }