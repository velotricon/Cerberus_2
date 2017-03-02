import { NgModule }                 from '@angular/core';
import { BrowserModule }            from '@angular/platform-browser';
import { FormsModule }              from '@angular/forms';
import { ModuleWithProviders }      from '@angular/core';
import { Routes, RouterModule }     from '@angular/router';
import { HttpModule, JsonpModule }  from '@angular/http';

import { Routing }                  from './app.routing';

//Components:
import { HomeComponent }            from './components/home.component';
import { AppComponent }             from './components/app.component';
import { MenuComponent }            from './components/menu.component';
import { TestComponent }            from './components/test.component';
import { PersonViewComponent }      from './components/person.view.component';
import { PersonListComponent }      from './components/person.list.component';
import { BackButtonComponent }      from './components/back.button.component';
import { PersonAddComponent }       from './components/person.add.component';
import { RegisterComponent }        from './components/register.component';
import { LoginComponent }           from './components/login.component';
import { ProfileComponent }         from './components/profile.component';
import { NotificationComponent }    from './components/notification.component';
import { ConfirmPopupComponent }    from './components/confirm.popup.component';
import { ButtonCtrlComponent }      from './components/button.ctrl.component';

//Services:
import { MenuService }              from './services/menu.service';
import { PersonService }            from './services/person.service';
import { LoggerService }            from './services/logger.service';
import { IdentityService }          from './services/identity.service';
import { NotificationService }      from './services/notification.service';

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
        BackButtonComponent,
        PersonAddComponent,
        RegisterComponent,
        LoginComponent,
        ProfileComponent,
        NotificationComponent,
        ConfirmPopupComponent,
        ButtonCtrlComponent
    ],
    bootstrap: [AppComponent],
    providers: [
        MenuService,
        PersonService,
        LoggerService,
        IdentityService,
        NotificationService
    ]
})
export class AppModule { }