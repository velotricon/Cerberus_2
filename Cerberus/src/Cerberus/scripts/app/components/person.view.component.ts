import { Component, OnInit }        from '@angular/core';
import { ActivatedRoute, Params }   from '@angular/router';
import { Person }                   from '../person';
import { PersonService }            from '../services/person.service';

@Component({
    selector: 'person-view',
    templateUrl: './templates/person.view.html'
})
export class PersonViewComponent implements OnInit {
    constructor(private service: PersonService, private route: ActivatedRoute) { }

    PersonId: number;
    ModelPerson: Person;

    ngOnInit(): void {
        this.route.params.forEach((params: Params) => {
            this.PersonId = +params['id']
            this.service.GetPerson(this.PersonId).then(x => this.ModelPerson = x);
        });
    }
}