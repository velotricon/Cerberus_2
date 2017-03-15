import { Component, OnInit, EventEmitter, Output }      from '@angular/core';
import { Router }                                       from '@angular/router';
import { IdentityService }                              from '../services/identity.service';
import { StatusContainer }                              from '../containers/status.container';

@Component({
    selector: 'profile',
    templateUrl: './templates/profile.html'
})
export class ProfileComponent implements OnInit {
    constructor(private service: IdentityService, private router: Router) {
    }

    @Output() StatusPublisher = new EventEmitter<StatusContainer>();

    private logged_in: boolean = false;

    private model_success(RequestResutlt: Object) {
        //alert('1');
        this.logged_in = true;
    }

    private model_error(Error: any) {
        //alert('2');
        this.logged_in = false;
    }

    private logout_success(RequestResult: Object) {
        this.logged_in = false;
    }

    private logout_error(Error: any) {
        let error = Error;
    }

    public hello_world(): void {
        alert('Hello world!');
    }

    public login_click(): void {
        this.router.navigateByUrl('/login');
    }

    public register_click(): void {
        alert('register not implemented yet');
    }

    public logout_click(): void {
        this.service.Logout().subscribe(
            result => this.logout_success(result),
            error => this.logout_error(error)
        );
    }

    ngOnInit(): void {
        this.service.GetUserInfo().subscribe(
            result => this.model_success(result),
            error => this.model_error(error)
        );

        let status = new StatusContainer();
        status.StatusText = 'Test raz dwa trzy';
        this.StatusPublisher.emit(status);
            
    }
};