﻿import { Component }        from '@angular/core'
import { IdentityService }  from './identity.service'

@Component({
    selector: 'login',
    templateUrl: './templates/login.html'
})
export class LoginComponent {
    constructor(private service: IdentityService) { }

    UserName: string;
    UserPassword: string;

    LoginAction(): void {
        alert('login action');
    }
}