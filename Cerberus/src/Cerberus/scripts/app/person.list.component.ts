import { Component, OnInit }        from '@angular/core';
import { Router }                   from '@angular/router';
import { Person }                   from './person';
import { PersonService }            from './person.service';

@Component({
    selector: 'person-list',
    templateUrl: './templates/person.list.html'
})
export class PersonListComponent implements OnInit {
    constructor(private service: PersonService, private router: Router) { }

    ModelPersonList: Person[];
    ErrorMessage: string;

    PersonSelected(SelectedPerson: Person): void {
        let link = ['/person/', SelectedPerson.Id];
        this.router.navigate(link);
    }

    ngOnInit(): void {
        this.service.GetPersonArray().subscribe(
            result => this.ModelPersonList = result,
            error => this.ErrorMessage = <any>error
        );
    }
}