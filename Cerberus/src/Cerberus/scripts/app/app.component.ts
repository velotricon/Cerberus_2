import { Component, ViewChild }     from '@angular/core';
import { RouterModule }             from '@angular/router';
import { ProfileComponent }         from './profile.component';
import './rxjs.operators';

@Component({
    selector: 'cerberus-app',
    templateUrl: './templates/app.html',
    directives: [ProfileComponent]
})
export class AppComponent {
    @ViewChild('profile') profile: ProfileComponent;

    OnClick_TestBtn(): void {
        this.profile.hello_world();
    }   
}