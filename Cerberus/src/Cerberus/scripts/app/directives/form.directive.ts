import { Directive, ElementRef, Input, HostListener }             from '@angular/core';
import { ValidationService }                                from '../services/validation.service';

@Directive({
    selector: '[crb-form]'
})
export class FormDirective {
    constructor(private element: ElementRef, private validation_service: ValidationService) {
        //this.validation_service.ClearControls();
    }

    @HostListener('submit') OnSubmit(): void {
        debugger;
    }
}