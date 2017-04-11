import { Component, OnInit, EventEmitter, Output }      from '@angular/core';
import { Router }                                       from '@angular/router';
import { IdentityService }                              from '../services/identity.service';
import { NotificationService }                          from '../services/notification.service';
import { LoggerService }                                from '../services/logger.service';
import { StatusContainer }                              from '../containers/status.container';
import { GenericResultContainer }                       from '../containers/generic.result.container';


@Component({
    selector: 'profile',
    templateUrl: './templates/profile.html'
})
export class ProfileComponent implements OnInit {
    constructor(private service: IdentityService, private router: Router,
        private logger: LoggerService) {
        this.logger.Debug('log', 'constructor', 'ProfileComponent');
    }

    @Output() StatusPublisher = new EventEmitter<StatusContainer>();

    private logged_in: boolean = false;
    private username: string;
    private avatar_path: string;

    private model_success(RequestResutlt: GenericResultContainer) {
        this.logger.Log('RequestResutlt.Succeeded = ' + RequestResutlt.Succeeded, 'model_success', 'ProfileComponent');
        if (RequestResutlt.Succeeded) {
            this.username = RequestResutlt.Result.Username;
            this.avatar_path = RequestResutlt.Result.AvatarPath;
            this.logger.Log('this.avatar_path = ' + this.avatar_path, 'model_success', 'ProfileComponent');
            this.logged_in = true;
        } else {
            this.logged_in = false;
        }
    }

    private model_error(Error: any) {
        this.logger.Log('log', 'model_error', 'ProfileComponent');
        this.logged_in = false;
    }

    private logout_success(RequestResult: any) {
        this.logged_in = false;
    }

    private logout_error(Error: any) {
        let error = Error;
    }

    public hello_world(): void {
        alert('Hello world!');
    }

    private login_click(): void {
        this.router.navigateByUrl('/login');
    }

    private register_click(): void {
        alert('register not implemented yet');
    }

    private logout_click(): void {
        this.service.Logout().subscribe(
            result => this.logout_success(result),
            error => this.logout_error(error)
        );
    }

    private profile_info_click(): void {
        this.router.navigateByUrl('/profile/settings');
    }

    public RefreshProfileInfo(): void {
        this.logger.Log('log', 'RefreshProfileInfo', 'ProfileComponent');
        this.service.GetUserInfo().subscribe(
            result => this.model_success(result),
            error => this.model_error(error)
        );
    }

    ngOnInit(): void {
        this.logger.Debug('before RefreshProfileInfo', 'ngOnInit', 'ProfileComponent');
        this.RefreshProfileInfo();

        //let status = new StatusContainer();
        //status.StatusText = 'Test raz dwa trzy';
        //this.StatusPublisher.emit(status);  
    }
};