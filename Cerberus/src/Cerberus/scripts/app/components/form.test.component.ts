import { Component }            from '@angular/core';
import { ValidationService }    from '../services/validation.service';

@Component({
    selector: 'form-test',
    templateUrl: './templates/form.test.html'
})
export class FormTestComponent {
    constructor(private validation_service: ValidationService) {
        this.validation_service.ClearControls();
    }

    private model: any = {};
    private on_submit(Form: any): void {
        alert(this.model.text);
    }
    private on_form_submit(Form: any): void {
        let result: string = '';
        for (let obj_name in Form.controls) {
            result += Form.controls[obj_name].value + ' ';
        }
        debugger;
    }

    private on_last_name_change(Input: any): void {
        if (Input.value.length < 5) {
            Input.setCustomValidity("Invalid field.");
        }
    }
}