import { Component, OnInit, EventEmitter, Output }      from '@angular/core';
import { Router }                                       from '@angular/router';
import { IdentityService }                              from '../services/identity.service';
import { StatusContainer }                              from '../containers/status.container';
import { GenericResultContainer }                       from '../containers/generic.result.container';

@Component({
    selector: 'profile',
    templateUrl: './templates/profile.html'
})
export class ProfileComponent implements OnInit {
    constructor(private service: IdentityService, private router: Router) {
    }

    @Output() StatusPublisher = new EventEmitter<StatusContainer>();

    private logged_in: boolean = false;
    private username: string;

    private model_success(RequestResutlt: GenericResultContainer) {
        this.username = RequestResutlt.Result.Username;
        this.logged_in = true;
    }

    private model_error(Error: any) {
        //alert('2');
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

    public RefreshProfileInfo(): void {
        this.service.GetUserInfo().subscribe(
            result => this.model_success(result),
            error => this.model_error(error)
        );
    }

    ngOnInit(): void {
        this.RefreshProfileInfo();

        //let status = new StatusContainer();
        //status.StatusText = 'Test raz dwa trzy';
        //this.StatusPublisher.emit(status);  
    }
};