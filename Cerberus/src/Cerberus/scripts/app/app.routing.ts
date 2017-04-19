import { ModuleWithProviders }      from '@angular/core';
import { Routes, RouterModule }     from '@angular/router';
import { TestComponent }            from './components/test.component';
import { HomeComponent }            from './components/home.component';
import { PersonViewComponent }      from './components/person.view.component';
import { PersonListComponent }      from './components/person.list.component';
import { PersonAddComponent }       from './components/person.add.component';
import { RegisterComponent }        from './components/register.component';
import { LoginComponent }           from './components/login.component';
import { ProfileSettingsComponent } from './components/profile.settings.component';
import { FormTestComponent }        from './components/form.test.component';

const AppRoutes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'register', component: RegisterComponent },
    { path: 'login', component: LoginComponent },
    { path: 'test', component: TestComponent },
    { path: 'home', component: HomeComponent },
    { path: 'person/view/:id', component: PersonViewComponent },
    { path: 'persons', component: PersonListComponent },
    { path: 'person/add', component: PersonAddComponent },
    { path: 'profile/settings', component: ProfileSettingsComponent },
    { path: 'formtest', component: FormTestComponent }
];

export const Routing: ModuleWithProviders = RouterModule.forRoot(AppRoutes, { useHash: true });