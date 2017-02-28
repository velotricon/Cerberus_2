import { Component, OnInit }        from '@angular/core';
import { Router }                   from '@angular/router';
import { Person }                   from './person';
import { PersonService }            from './person.service';
import { LoggerService }            from './logger.service';
import { NotificationService }      from './notification.service';
import { AbstractComponent }        from './abstractions/abstract.component';

@Component({
    selector: 'person-list',
    templateUrl: './templates/person.list.html'
})
export class PersonListComponent extends AbstractComponent implements OnInit {
    constructor(
        private service: PersonService,
        private router: Router,
        logger: LoggerService,
        notification_service: NotificationService
    ) {
        super('PersonListComponent',
            logger,
            notification_service);
    }

    ModelPersonList: Person[];
    ErrorMessage: string;

    PersonSelected(SelectedPerson: Person): void {
        let link = ['/person/', SelectedPerson.Id];
        this.router.navigate(link);
    }

    private model_success(RequestResutlt: Person[]) {
        this.ModelPersonList = RequestResutlt;
    }

    private model_error(Error: any) {
        this.ErrorMessage = Error;
    }

    ngOnInit(): void {
        this.service.GetPersonArray().subscribe(
            result => this.model_success(result),
            error => this.model_error(error)
        );
    }
}