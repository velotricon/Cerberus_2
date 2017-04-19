import { Component }        from '@angular/core';

@Component({
    selector: 'form-test',
    templateUrl: './templates/form.test.html'
})
export class FormTestComponent {
    private model: any = {};
    private on_submit(Form: any): void {
        alert(this.model.firstname + ' ' + this.model.lastname);
    }
    private on_form_submit(): void {
        alert('form submit');
    }
}