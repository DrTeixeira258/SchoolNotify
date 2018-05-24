import { AppComponent } from './app.component';
import { NgModule } from '@angular/core';
import { CommonModule, } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

import { DashboardComponent } from './dashboard/dashboard.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { TableListComponent } from './table-list/table-list.component';
import { TypographyComponent } from './typography/typography.component';
import { IconsComponent } from './icons/icons.component';
import { MapsComponent } from './maps/maps.component';
import { NotificationsComponent } from './notifications/notifications.component';
import { UpgradeComponent } from './upgrade/upgrade.component';
import { CriarSalaComponent } from 'app/manter-sala/criar-sala/criar-sala.component';
import { ListarSalaComponent } from 'app/manter-sala/listar-sala/listar-sala.component';
import { ListarProfessorComponent } from 'app/manter-professor/listar-professor/listar-professor.component';
import { CriarProfessorComponent } from 'app/manter-professor/criar-professor/criar-professor.component';
import { ListarResponsavelComponent } from 'app/mante-responsavel/listar-responsavel/listar-responsavel.component';
import { CriarResponsavelComponent } from 'app/mante-responsavel/criar-responsavel/criar-responsavel.component';
import { ListarAlunoComponent } from 'app/manter-aluno/listar-aluno/listar-aluno.component';
import { CriarAlunoComponent } from 'app/manter-aluno/criar-aluno/criar-aluno.component';
import { LoginGuard } from 'app/guard/login.guard';

const routes: Routes = [

  {
    path: '', children: [
      {
        path: 'user-profile', component: AppComponent, canActivate: [LoginGuard], children: [
          { path: '', component: UserProfileComponent, outlet: 'components' },
        ]
      },
      {
        path: 'dashboard', component: AppComponent, canActivate: [LoginGuard], children: [
          { path: '', component: DashboardComponent, outlet: 'components' },
        ]
      },
      {
        path: 'sala', component: AppComponent, canActivate: [LoginGuard], children: [
          { path: '', component: ListarSalaComponent, outlet: 'components' },
        ]
      },
      {
        path: 'criar-sala/:operacao', component: AppComponent, canActivate: [LoginGuard], children: [
          { path: '', component: CriarSalaComponent, outlet: 'components' },
        ]
      },
      {
        path: 'criar-sala/:operacao/:idSala', component: AppComponent, canActivate: [LoginGuard], children: [
          { path: '', component: CriarSalaComponent, outlet: 'components' },
        ]
      },
      {
        path: 'professor', component: AppComponent, canActivate: [LoginGuard], children: [
          { path: '', component: ListarProfessorComponent, outlet: 'components' },
        ]
      },
      {
        path: 'criar-professor/:operacao', component: AppComponent, canActivate: [LoginGuard], children: [
          { path: '', component: CriarProfessorComponent, outlet: 'components' },
        ]
      },
      {
        path: 'criar-professor/:operacao/:idProfessor', component: AppComponent, canActivate: [LoginGuard], children: [
          { path: '', component: CriarProfessorComponent, outlet: 'components' },
        ]
      },
      {
        path: 'responsavel', component: AppComponent, canActivate: [LoginGuard], children: [
          { path: '', component: ListarResponsavelComponent, outlet: 'components' },
        ]
      },
      {
        path: 'criar-responsavel/:operacao', component: AppComponent, canActivate: [LoginGuard], children: [
          { path: '', component: CriarResponsavelComponent, outlet: 'components' },
        ]
      },
      {
        path: 'criar-responsavel/:operacao/:idResponsavel', component: AppComponent, canActivate: [LoginGuard], children: [
          { path: '', component: CriarResponsavelComponent, outlet: 'components' },
        ]
      },
      {
        path: 'aluno', component: AppComponent, canActivate: [LoginGuard], children: [
          { path: '', component: ListarAlunoComponent, outlet: 'components' },
        ]
      },
      {
        path: 'criar-aluno/:operacao', component: AppComponent, canActivate: [LoginGuard], children: [
          { path: '', component: CriarAlunoComponent, outlet: 'components' },
        ]
      },
      {
        path: 'criar-aluno/:operacao/:idAluno', component: AppComponent, canActivate: [LoginGuard], children: [
          { path: '', component: CriarAlunoComponent, outlet: 'components' },
        ]
      },
    ]
  },


  // { path: '',                                  redirectTo: 'dashboard', pathMatch: 'full' },
  // { path: 'dashboard',                         component: DashboardComponent },
  // { path: 'user-profile',                      component: UserProfileComponent },
  // { path: 'table-list',                        component: TableListComponent },
  // { path: 'typography',                        component: TypographyComponent },
  // { path: 'icons',                             component: IconsComponent },
  // { path: 'maps',                              component: MapsComponent },
  // { path: 'notifications',                     component: NotificationsComponent },
  // { path: 'upgrade',                           component: UpgradeComponent },
  // { path: 'sala',                              component: ListarSalaComponent },
  // { path: 'criar-sala',                        component: CriarSalaComponent },
  // { path: 'criar-sala/:idSala',                component: CriarSalaComponent },
  // { path: 'professor',                         component: ListarProfessorComponent },
  // { path: 'criar-professor',                   component: CriarProfessorComponent },
  // { path: 'criar-professor/:idProfessor',      component: CriarProfessorComponent },
  // { path: 'responsavel',                       component: ListarResponsavelComponent },
  // { path: 'criar-responsavel',                 component: CriarResponsavelComponent },
  // { path: 'criar-responsavel/:idResponsavel',  component: CriarResponsavelComponent },
  // { path: 'aluno',                             component: ListarAlunoComponent },
  // { path: 'criar-aluno',                       component: CriarAlunoComponent },
  // { path: 'criar-aluno/:idAluno',              component: CriarAlunoComponent },
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [
  ],
})
export class AppRoutingModule { }
