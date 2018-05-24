import { CommonModule, LocationStrategy, APP_BASE_HREF } from '@angular/common';
import { BrowserAnimationsModule, NoopAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { MatSelectModule } from '@angular/material/select';
import { TextMaskModule } from 'angular2-text-mask';

import { AppRoutingModule } from './app.routing';
import { ComponentsModule } from './components/components.module';
import { AppComponent } from './app.component';
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
import { UsuarioService } from 'services/usuario.service';
import { CustomLocationStrategy } from 'app/shared/customLocationStrategy';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    UserProfileComponent,
    TableListComponent,
    TypographyComponent,
    IconsComponent,
    MapsComponent,
    NotificationsComponent,
    UpgradeComponent,
    CriarSalaComponent,
    ListarSalaComponent,
    ListarProfessorComponent,
    CriarProfessorComponent,
    ListarResponsavelComponent,
    CriarResponsavelComponent,
    ListarAlunoComponent,
    CriarAlunoComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpModule,
    ComponentsModule,
    RouterModule,
    AppRoutingModule,
    TextMaskModule,
    // BrowserAnimationsModule,
    // NoopAnimationsModule,
    MatSelectModule
  ],
  providers: [
    LoginGuard,
    UsuarioService,
    { provide: APP_BASE_HREF, useValue: '/SchoolNotify' },
    { provide: LocationStrategy, useClass: CustomLocationStrategy }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
