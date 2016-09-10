import { NgModule }                 from '@angular/core';
import { BrowserModule }            from '@angular/platform-browser';
import { FormsModule }              from '@angular/forms';
import { ModuleWithProviders }      from '@angular/core';
import { Routes, RouterModule }     from '@angular/router';
import { HttpModule, JsonpModule }  from '@angular/http';

import { Routing }                  from './app.routing';

//Components:
import { HomeComponent }            from './home.component';
import { AppComponent }             from './app.component';
import { MenuComponent }            from './menu.component';
import { TestComponent }            from './test.component';
import { PersonViewComponent }      from './person.view.component';
import { PersonListComponent }      from './person.list.component';
import { BackButtonComponent }      from './back.button.component';

//Services:
import { MenuService }              from './menu.service';
import { PersonService }            from './person.service';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        Routing
    ],
    declarations: [
        AppComponent,
        HomeComponent,
        MenuComponent,
        TestComponent,
        PersonViewComponent,
        PersonListComponent,
        BackButtonComponent
    ],
    bootstrap: [AppComponent],
    providers: [MenuService, PersonService]
})
export class AppModule { }