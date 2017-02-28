import { Component, OnInit, EventEmitter, Output }      from '@angular/core';
import { IdentityService }                              from '../services/identity.service';
import { StatusContainer }                              from '../containers/status.container';

@Component({
    selector: 'profile',
    templateUrl: './templates/profile.html'
})
export class ProfileComponent implements OnInit {
    constructor(private service: IdentityService) {
    }

    @Output() StatusPublisher = new EventEmitter<StatusContainer>();

    private model_success(RequestResutlt: Object) {
        //alert('1');
    }

    private model_error(Error: any) {
        //alert('2');
    }

    public hello_world(): void {
        alert('Hello world!');
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