﻿import { NgModule }                 from '@angular/core';
import { BrowserModule }            from '@angular/platform-browser';
import { FormsModule }              from '@angular/forms';
import { AppComponent }             from './app.component';
import { MenuComponent }            from './menu.component';

@NgModule({
    imports: [BrowserModule, FormsModule],
    declarations: [AppComponent, MenuComponent],
    bootstrap: [AppComponent]
})
export class AppModule { }