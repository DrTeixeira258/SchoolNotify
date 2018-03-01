import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule, NoopAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { LoginComponent } from 'login/login.component';

import { LoginRoutingModule } from 'login/login.routing';


@NgModule({
  declarations: [
    LoginComponent,
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
  providers: [],
  bootstrap: [LoginComponent]
})
export class LoginModule { }
