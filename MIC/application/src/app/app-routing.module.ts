import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home';
import { AuthGuard } from './_helpers';

const accountModule = () => import('./account/account.module').then(x => x.AccountModule);
const usersModule = () => import('./users/users.module').then(x => x.UsersModule);
const depositoModule = () => import('./deposito/deposito.module').then(x => x.DepositoModule);
const historicoModule = () => import('./historico/historico.module').then(x => x.HistoricoModule);
const rastreamentoModule = () => import('./rastreamento/rastreamento.module').then(x => x.RastreamentoModule);
const cotacaoModule = () => import('./cotacao/cotacao.module').then(x => x.CotacaoModule);

const routes: Routes = [
    { path: '', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'users', loadChildren: usersModule, canActivate: [AuthGuard] },
    { path: 'deposito', loadChildren: depositoModule, canActivate: [AuthGuard] },
    { path: 'cotacao', loadChildren: cotacaoModule, canActivate: [AuthGuard] },
    { path: 'historico', loadChildren: historicoModule, canActivate: [AuthGuard] },
    { path: 'rastreamento', loadChildren: rastreamentoModule, canActivate: [AuthGuard] },
    { path: 'account', loadChildren: accountModule },

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }