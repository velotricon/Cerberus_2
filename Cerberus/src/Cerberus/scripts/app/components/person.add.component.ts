import { Component }        from '@angular/core';
import { PersonService }    from '../services/person.service';

@Component({
    selector: 'person-add',
    templateUrl: './templates/person.add.html'
})
export class PersonAddComponent {
    constructor(private service: PersonService) { }

    Model = {};
    ErrorMessage: string;
    public PersonNameTest: string = "test person name222";

    AddNewPerson() {
        this.service.AddPerson(this.Model).subscribe(
            result => this.RedirectToPersonView(result),
            error => this.ErrorMessage = error
        );
    }

    private test_val: string = "dupa";
    TextBoxTest() {
        alert(this.test_val);
        
    }

    RedirectToPersonView(PersonId: number) {

    }
}
