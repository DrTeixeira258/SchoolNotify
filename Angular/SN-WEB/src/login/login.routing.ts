import { NgModule } from '@angular/core';
import { CommonModule, } from '@angular/common';
import { BrowserModule  } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from 'login/login.component';
import { LoginPageComponent } from 'login/login-page/login-page.component';


const routes: Routes =[
    { path: '', component: LoginPageComponent },
    // { path: '**', component: LoginPageComponent },
    { path: 'apps', loadChildren: 'app/app.module#AppModule'},
    
];

@NgModule({
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes)
  ],
  exports: [
  ],
})
export class LoginRoutingModule { }