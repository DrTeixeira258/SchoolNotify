import { NgModule } from '@angular/core';
import { CommonModule, } from '@angular/common';
import { BrowserModule  } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from 'login/login.component';


const routes: Routes =[
    { path: '', component: LoginComponent },
    { path: 'dashboard', loadChildren: 'app/app.module#AppModule'},
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