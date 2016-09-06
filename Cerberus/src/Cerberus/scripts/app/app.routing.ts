import { ModuleWithProviders }      from '@angular/core';
import { Routes, RouterModule }     from '@angular/router';
import { TestComponent }            from './test.component';
import { HomeComponent }            from './home.component';
import { PersonViewComponent }      from './person.view.component';
import { PersonListComponent }      from './person.list.component';

const AppRoutes: Routes = [
    { path: '', redirectTo: 'home', terminal: true, pathMatch: 'full' },
    { path: 'test', component: TestComponent },
    { path: 'home', component: HomeComponent },
    { path: 'person/:id', component: PersonViewComponent },
    { path: 'persons', component: PersonListComponent }
];

export const Routing: ModuleWithProviders = RouterModule.forRoot(AppRoutes);