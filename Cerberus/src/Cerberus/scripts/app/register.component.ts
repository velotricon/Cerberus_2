import { Component }        from '@angular/core'
import { IdentityService }  from './identity.service'

@Component({
    selector: 'register',
    templateUrl: './templates/register.html'
})
export class RegisterComponent {
    constructor(private service: IdentityService) { }

    Username: string;
    Email: string;
    Password: string;

    RegisterAction() {
        this.service.Register(this.Username, this.Email, this.Password);
        
    }
}