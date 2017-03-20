import { Component }                    from '@angular/core'
import { Router }                       from '@angular/router';
import { IdentityService }              from '../services/identity.service'
import { RootCommunicationService }     from '../services/root.communication.service';
import { GenericResultContainer }       from '../containers/generic.result.container';
import { NotificationService }          from '../services/notification.service';

@Component({
    selector: 'login',
    templateUrl: './templates/login.html'
})
export class LoginComponent {
    constructor(private service: IdentityService,
        private root_communication_service: RootCommunicationService,
        private notification_service: NotificationService,
        private router: Router
    ) { }

    UserName: string;
    UserPassword: string;

    private on_login_success(Result: GenericResultContainer): void {
        if (Result.Succeded) {
            this.notification_service.ShowNotification("Logowanie", "Logowanie zakończyło się sukcesem");
            this.root_communication_service.AnnounceStringMessage('refresh profile');
            this.router.navigateByUrl('/home');
        } else {
            this.notification_service.ShowNotification("Logowanie", "Logowanie nie powiodło się");
        }
    }

    private on_login_error(Error: any): void {
        this.notification_service.ShowNotification("Logowanie - błąd", Error);
    }

    LoginAction(): void {
        let result = this.service.Login(this.UserName, this.UserPassword).subscribe(
            result => this.on_login_success(result),
            error => this.on_login_success(error)
        );
    }
}