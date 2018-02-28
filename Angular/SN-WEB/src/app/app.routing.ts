import { NgModule } from '@angular/core';
import { CommonModule, } from '@angular/common';
import { BrowserModule  } from '@angular/platform-browser';
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
import { LoginComponent } from 'app/login/login.component';

const routes: Routes =[
    { path: '',                                  redirectTo: 'login', pathMatch: 'full' },
    { path: 'login',                             component: LoginComponent },
    { path: 'dashboard',                         component: DashboardComponent },
    { path: 'user-profile',                      component: UserProfileComponent },
    { path: 'table-list',                        component: TableListComponent },
    { path: 'typography',                        component: TypographyComponent },
    { path: 'icons',                             component: IconsComponent },
    { path: 'maps',                              component: MapsComponent },
    { path: 'notifications',                     component: NotificationsComponent },
    { path: 'upgrade',                           component: UpgradeComponent },
    { path: 'sala',                              component: ListarSalaComponent},
    { path: 'criar-sala',                        component: CriarSalaComponent},
    { path: 'criar-sala/:idSala',                component: CriarSalaComponent},
    { path: 'professor',                         component: ListarProfessorComponent},
    { path: 'criar-professor',                   component: CriarProfessorComponent},
    { path: 'criar-professor/:idProfessor',      component: CriarProfessorComponent},
    { path: 'responsavel',                       component: ListarResponsavelComponent},
    { path: 'criar-responsavel',                 component: CriarResponsavelComponent},
    { path: 'criar-responsavel/:idResponsavel',  component: CriarResponsavelComponent},
    { path: 'aluno',                             component: ListarAlunoComponent},
    { path: 'criar-aluno',                       component: CriarAlunoComponent},
    { path: 'criar-aluno/:idAluno',              component: CriarAlunoComponent},
];

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    RouterModule.forRoot(routes)
  ],
  exports: [
  ],
})
export class AppRoutingModule { }
