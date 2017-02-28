﻿import { ModuleWithProviders }      from '@angular/core';
import { Routes, RouterModule }     from '@angular/router';
import { TestComponent }            from './components/test.component';
import { HomeComponent }            from './components/home.component';
import { PersonViewComponent }      from './components/person.view.component';
import { PersonListComponent }      from './components/person.list.component';
import { PersonAddComponent }       from './components/person.add.component';
import { RegisterComponent }        from './components/register.component';
import { LoginComponent }           from './components/login.component';

const AppRoutes: Routes = [
    { path: '', redirectTo: 'home', terminal: true, pathMatch: 'full' },
    { path: 'register', component: RegisterComponent },
    { path: 'login', component: LoginComponent },
    { path: 'test', component: TestComponent },
    { path: 'home', component: HomeComponent },
    { path: 'person/view/:id', component: PersonViewComponent },
    { path: 'persons', component: PersonListComponent },
    { path: 'person/add', component: PersonAddComponent }
];

export const Routing: ModuleWithProviders = RouterModule.forRoot(AppRoutes);