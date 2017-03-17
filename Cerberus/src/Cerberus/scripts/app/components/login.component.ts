import { Component }                    from '@angular/core'
import { AbstractComponent }            from '../abstractions/abstract.component';
import { IdentityService }              from '../services/identity.service'
import { RootCommunicationService }     from '../services/root.communication.service';

@Component({
    selector: 'login',
    templateUrl: './templates/login.html'
})
export class LoginComponent extends AbstractComponent {
    constructor(private service: IdentityService,
        protected root_communication_service: RootCommunicationService) {
        super("LoginComponent");
        
    }

    UserName: string;
    UserPassword: string;

    LoginAction(): void {
        let result = this.service.Login(this.UserName, this.UserPassword).subscribe();
    }
}