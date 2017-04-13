import { Component }                        from '@angular/core';
import { PersonService }                    from '../services/person.service';
import { LoggerService }                    from '../services/logger.service';
import { LightComboBoxModelContainer }      from '../containers/light.combo.box.model.container';
import { LightComboBoxItemContainer }       from '../containers/light.combo.box.item.container';
import { LIGHT_COMBO_MODEL }                from '../mockups/light.combo.box.mock';


@Component({
    selector: 'person-add',
    templateUrl: './templates/person.add.html'
})
export class PersonAddComponent {
    constructor(private service: PersonService, private logger: LoggerService) { }

    Model = {};
    ErrorMessage: string;
    public PersonNameTest: string = "test person name222";

    AddNewPerson() {
        this.service.AddPerson(this.Model).subscribe(
            result => this.RedirectToPersonView(result),
            error => this.ErrorMessage = error
        );
    }

    //Test:
    private combo_model: LightComboBoxModelContainer = LIGHT_COMBO_MODEL;
    TextBoxTest() {
        alert('SelectedValue: ' + this.combo_model.SelectedValue);
    }
    //end-of-Test

    RedirectToPersonView(PersonId: number) {

    }
}
