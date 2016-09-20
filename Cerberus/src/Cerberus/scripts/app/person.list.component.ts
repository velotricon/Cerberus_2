import { Component, OnInit }        from '@angular/core';
import { Router }                   from '@angular/router';
import { Person }                   from './person';
import { PersonService }            from './person.service';
import { LoggerService }            from './logger.service';

@Component({
    selector: 'person-list',
    templateUrl: './templates/person.list.html'
})
export class PersonListComponent implements OnInit {
    constructor(private service: PersonService, private router: Router, private logger: LoggerService) { }

    ModelPersonList: Person[];
    ErrorMessage: string;

    PersonSelected(SelectedPerson: Person): void {
        let link = ['/person/', SelectedPerson.Id];
        this.router.navigate(link);
    }

    private model_success(RequestResutlt: Person[]) {
        this.logger.Debug('PersonListComponent.model_success', 'begin');
        this.logger.Debug('PersonListComponent.model_success', 'count: ' + RequestResutlt.length);
        this.ModelPersonList = RequestResutlt;
        this.logger.Debug('PersonListComponent.model_success', 'end');
    }

    private model_error(Error: any) {
        this.logger.Debug('PersonListComponent.model_error', 'begin');
        this.ErrorMessage = Error;
        this.logger.Debug('PersonListComponent.model_error', 'end');
    }

    ngOnInit(): void {
        this.logger.Debug('PersonListComponent.ngOnInit', 'begin');
        this.service.GetPersonArray().subscribe(
            result => this.model_success(result),
            error => this.model_error(error)
        );
        this.logger.Debug('PersonListComponent.ngOnInit', 'end');
    }
}