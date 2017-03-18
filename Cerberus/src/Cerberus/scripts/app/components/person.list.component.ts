import { Component, OnInit }        from '@angular/core';
import { Router }                   from '@angular/router';
import { PersonContainer }          from '../containers/person.container';
import { PersonService }            from '../services/person.service';
import { LoggerService }            from '../services/logger.service';
import { NotificationService }      from '../services/notification.service';
import { AbstractComponent }        from '../abstractions/abstract.component';

@Component({
    selector: 'person-list',
    templateUrl: './templates/person.list.html'
})
export class PersonListComponent implements OnInit {
    constructor(
        private service: PersonService,
        private router: Router,
        private logger: LoggerService,
        private notification_service: NotificationService
    ) {
        this.logger.Debug("test", "Constructor", "PersonListComponent");
    }

    ModelPersonList: PersonContainer[];
    ErrorMessage: string;

    PersonSelected(SelectedPerson: PersonContainer): void {
        let link = ['/person/', SelectedPerson.Id];
        this.router.navigate(link);
    }

    private model_success(RequestResutlt: PersonContainer[]) {
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

        this.logger.Debug("ngOnInit", "Test");
    }
}