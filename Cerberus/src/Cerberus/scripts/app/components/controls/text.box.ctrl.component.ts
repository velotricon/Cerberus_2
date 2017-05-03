import { Component, Input, Output, EventEmitter }   from '@angular/core';
import { AbstractCtrlComponent}                     from '../../abstractions/abstract.ctrl.component';
import { LoggerService }                            from '../../services/logger.service';
import { ValidationService }                        from '../../services/validation.service';

@Component({
    templateUrl: './templates/controls/text.box.ctrl.html',
    selector: 'text-box-ctrl'
})
export class TextBoxCtrlComponent extends AbstractCtrlComponent {
    constructor(private logger: LoggerService,
        validation_service: ValidationService) {
        super(validation_service);
    }

    private _value: string;
    @Output() valueChange: EventEmitter<string> = new EventEmitter<string>();
    @Input()
    get value(): string {
        return this._value;
    }
    set value(Value: string) {
        this._value = Value;
    }

    private on_value_change(Element: any): void {
        if (this._value.length < 5) {
            Element.setCustomValidity("Invalid field.");
        }
        this.valueChange.emit(this._value);
    }
}