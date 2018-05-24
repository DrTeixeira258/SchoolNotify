import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule, NoopAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { LoginComponent } from 'login/login.component';

import { LoginRoutingModule } from 'login/login.routing';
import { LoginPageComponent } from 'login/login-page/login-page.component';
import { LocationStrategy, APP_BASE_HREF } from '@angular/common';
import { CustomLocationStrategy } from 'app/shared/customLocationStrategy';


@NgModule({
  declarations: [
    LoginComponent,
    LoginPageComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule,
    LoginRoutingModule,
    BrowserAnimationsModule,
    NoopAnimationsModule,
  ],
  providers: [
    { provide: APP_BASE_HREF, useValue: '/SchoolNotify' },
    { provide: LocationStrategy, useClass: CustomLocationStrategy }
  ],
  bootstrap: [LoginComponent]
})
export class LoginModule { }
